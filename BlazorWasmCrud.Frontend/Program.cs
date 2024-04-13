using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWasmCrud.Frontend;
using BlazorWasmCrud.Frontend.Services;

const string httpClientName = "backend";
const string backendUrl = "http://localhost:5258";

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Microsoft.Extensions.Http
builder.Services.AddHttpClient(
    httpClientName,
    opt => opt.BaseAddress = new Uri(backendUrl));

builder.Services.AddTransient<CategoryService>();

await builder.Build().RunAsync();