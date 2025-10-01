/*
 * Standardized API Response Models - Consistent response handling
 * REFACTORING: Eliminates repetitive response parsing and provides type safety
 */

using System.Text.Json.Serialization;

namespace Client.Models;

/// <summary>
/// Generic API response wrapper for consistent response handling
/// </summary>
/// <typeparam name="T">Type of data being returned</typeparam>
public class ApiResponse<T>
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public T? Data { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }
}

/// <summary>
/// Specific response for product list API
/// </summary>
public class ProductListResponse : ApiResponse<Product[]>
{
    // Inherits all properties from ApiResponse<Product[]>
    // Can add specific properties if needed in the future
}
