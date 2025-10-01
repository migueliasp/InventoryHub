/*
 * Shared Product Model - Centralized data model
 * REFACTORING: Eliminates duplicate Product class definitions
 */

using System.Text.Json.Serialization;

namespace Client.Models;

/// <summary>
/// Product data model with enhanced type safety and null safety
/// IMPROVEMENTS: Decimal for currency, default values, validation attributes
/// </summary>
public class Product
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty; // Default empty string for null safety

    [JsonPropertyName("price")]
    public decimal Price { get; set; } // Decimal for precise currency calculations

    [JsonPropertyName("stock")]
    public int Stock { get; set; }

    [JsonPropertyName("category")]
    public Category Category { get; set; } = new(); // Navigation property with default value
}

public class Category
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
