using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using utsfrontend72220586.Models;

public class CategoryService
{
    private readonly HttpClient httpClient;

    public CategoryService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    // Read (Get All Categories)
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Category>>("api/categories");
    }

    // Create (Add a new Category)
    public async Task AddCategoryAsync(Category category)
    {
        await httpClient.PostAsJsonAsync("api/categories", category);
    }

    // Update
    public async Task UpdateCategoryAsync(Category category)
    {
        await httpClient.PutAsJsonAsync($"api/categories/{category.Id}", category);
    }

    // Delete
    public async Task DeleteCategoryAsync(int id)
    {
        await httpClient.DeleteAsync($"api/categories/{id}");
    }

    public async Task<List<Category>> GetCategories()
    {
        // Simulasi pengambilan data dari sumber data
        await Task.Delay(100); // Simulasi delay
        return new List<Category>
        {
            new Category { Id = 1, Name = "Category 1" },
            new Category { Id = 2, Name = "Category 2" },
            new Category { Id = 3, Name = "Category 3" }
        };
    }
}
