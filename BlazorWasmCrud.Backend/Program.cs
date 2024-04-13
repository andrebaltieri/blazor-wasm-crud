using BlazorWasmCrud.Backend;
using BlazorWasmCrud.Backend.Data;
using BlazorWasmCrud.Backend.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(x => { x.UseSqlite("DataSource=app.db;Cache=Shared"); });
builder.Services.AddCors(
    options => options.AddPolicy(
        Configuration.CorsPolicyName,
        policy => policy
            .WithOrigins([Configuration.BackendUrl, Configuration.FrontendUrl])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()));

var app = builder.Build();

app.UseCors(Configuration.CorsPolicyName);

app.MapGet("/", () => "Hello World!");

app.MapGet("/v1/categories", async (AppDbContext context) =>
{
    var categories = await context.Categories.AsNoTracking().ToListAsync();
    return Results.Ok(categories);
}).Produces<List<Category>>();

app.MapPost("/v1/categories", async (AppDbContext context, Category category) =>
{
    await context.Categories.AddAsync(category);
    await context.SaveChangesAsync();

    return Results.Created($"/v1/categories/{category.Id}", category);
});

app.Run();