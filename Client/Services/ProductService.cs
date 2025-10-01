/*
 * Product Service - Centralized API communication
 * REFACTORING: Eliminates repetitive HTTP client code and provides reusable methods
 */

using System.Text.Json;
using Client.Models;
using Client.Services;

namespace Client.Services;

public interface IProductService
{
    Task<(bool Success, Product[]? Products, string? ErrorMessage)> GetProductsAsync(CancellationToken cancellationToken = default);
}

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;
    
    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
    
    /// <summary>
    /// Fetches products from the API with comprehensive error handling
    /// REFACTORING: Centralized, reusable API call logic
    /// </summary>
    public async Task<(bool Success, Product[]? Products, string? ErrorMessage)> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.GetAsync(ApiConfiguration.ProductListUrl, cancellationToken);
            
            if (!response.IsSuccessStatusCode)
            {
                return (false, null, $"Server returned error: {(int)response.StatusCode} {response.ReasonPhrase}");
            }
            
            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            
            if (string.IsNullOrWhiteSpace(json))
            {
                return (false, null, ApiConfiguration.EmptyResponseError);
            }
            
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<Product[]>>(json, _jsonOptions);
            
            if (apiResponse?.Data == null)
            {
                return (false, null, ApiConfiguration.ParseError);
            }
            
            return (true, apiResponse.Data, null);
        }
        catch (OperationCanceledException)
        {
            return (false, null, string.Format(ApiConfiguration.TimeoutErrorTemplate, ApiConfiguration.RequestTimeoutSeconds));
        }
        catch (HttpRequestException ex)
        {
            return (false, null, $"{ApiConfiguration.NetworkErrorPrefix}{ex.Message}. Please check your connection and server availability.");
        }
        catch (JsonException ex)
        {
            return (false, null, $"Failed to parse server response: {ex.Message}");
        }
        catch (Exception ex)
        {
            return (false, null, $"{ApiConfiguration.UnexpectedErrorPrefix}{ex.Message}");
        }
    }
}