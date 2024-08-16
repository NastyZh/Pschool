using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PschoolFrontEnd;
using System.Net.Http;
using PschoolFrontEnd.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5219/") 
});


builder.Services.AddHttpClient<ParentService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5219/api/"); // Адрес вашего API
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
});

await builder.Build().RunAsync();