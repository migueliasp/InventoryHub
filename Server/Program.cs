/*
 * InventoryHub Server - ASP.NET Core Web API
 *
 * REFACTORING IMPROVEMENTS:
 * 1. SERVICE LAYER:
 *    - Extracted ProductService for centralized data management
 *    - Eliminated hardcoded inline data
 *    - Added dependency injection for better testability
 *
 * 2. CODE REUSABILITY:
 *    - Centralized Product and ApiResponse models
 *    - Reusable service layer for data access
 *    - Eliminated repetitive anonymous object creation
 *
 * 3. MAINTAINABILITY:
 *    - Single source of truth for product data
 *    - Easy to extend with database integration
 *    - Type-safe models instead of anonymous objects
 *
 * PREVIOUS IMPROVEMENTS MAINTAINED:
 * - CORS configuration for cross-origin requests
 * - Standardized JSON response format
 * - Enhanced data model with categories
 * - RESTful API design patterns
 */

using Server.Models;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);

// CORS Configuration - Cross-Origin Resource Sharing
// This enables the Blazor WebAssembly client to make API calls to this server
// SECURITY NOTE: "AllowAnything" policy is for development only!
// For production, replace with specific origins, headers, and methods
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAnything",
        policy =>
        {
            // Allow requests from any origin (⚠️ Development only!)
            // Allow any HTTP headers in requests
            // Allow any HTTP methods (GET, POST, PUT, DELETE, etc.)
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    );
});

// REFACTORING: Register services for dependency injection
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Apply CORS middleware - Must be called before mapping endpoints
// This enables the cross-origin policy defined above
app.UseCors("AllowAnything");

// Product List API Endpoint
// REFACTORING: Simplified using service layer and strongly-typed models
app.MapGet(
    "/api/productlist",
    async (IProductService productService) =>
    {
        // Get products from service layer
        var products = await productService.GetProductsAsync();

        // Create standardized API response
        var response = new ApiResponse<Product[]>
        {
            Success = true,
            Message = "Products retrieved successfully",
            Data = products.ToArray(), // Convert IEnumerable to Array for client compatibility
            Timestamp = DateTime.UtcNow,
        };

        return response;
    }
);

app.Run();
