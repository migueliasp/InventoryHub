/*
 * Server-side Product Models - Centralized data structures
 * REFACTORING: Eliminates inline anonymous objects and provides type safety
 */

using System.Text.Json.Serialization;

namespace Server.Models;

public class Product
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    
    [JsonPropertyName("stock")]
    public int Stock { get; set; }
    
    [JsonPropertyName("category")]
    public Category Category { get; set; } = new();
}

public class Category
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

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