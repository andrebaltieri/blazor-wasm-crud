using System.Net.Http.Json;
using BlazorWasmCrud.Frontend.Models;

namespace BlazorWasmCrud.Frontend.Services;

public class CategoryService(IHttpClientFactory httpClientFactory)
{
    public async Task CreateAsync(Category category)
    {
        var client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        await client.PostAsJsonAsync($"v1/categories/", category);
    }

    public async Task<List<Category>> GetAsync()
    {
        var client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        return await client.GetFromJsonAsync<List<Category>>("v1/categories") ?? [];
    }
}