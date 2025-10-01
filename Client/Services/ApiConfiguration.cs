/*
 * Shared API Configuration - Centralized constants and configuration
 * REFACTORING: Eliminates magic numbers and hardcoded values throughout the application
 */

namespace Client.Services;

public static class ApiConfiguration
{
    // API Endpoints
    public const string BaseUrl = "http://localhost:5107";
    public const string ProductListEndpoint = "/api/productlist";
    
    // Timeouts and Performance
    public const int RequestTimeoutSeconds = 30;
    public const int CacheValidityMinutes = 5;
    
    // UI Constants
    public const string LoadingMessage = "Loading products...";
    public const string NoDataMessage = "No products found.";
    public const string RetryButtonText = "Retry";
    
    // Error Messages
    public const string EmptyResponseError = "Received empty response from server.";
    public const string ParseError = "Failed to parse product data from server response.";
    public const string NetworkErrorPrefix = "Network error: ";
    public const string TimeoutErrorTemplate = "Request timed out after {0} seconds. Please check your connection and try again.";
    public const string UnexpectedErrorPrefix = "An unexpected error occurred: ";
    
    // Complete API URL
    public static string ProductListUrl => $"{BaseUrl}{ProductListEndpoint}";
}