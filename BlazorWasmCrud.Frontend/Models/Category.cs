namespace BlazorWasmCrud.Frontend.Models;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}