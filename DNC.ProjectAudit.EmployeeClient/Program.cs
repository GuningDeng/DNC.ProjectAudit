using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DNC.ProjectAudit.EmployeeClient;
using DNC.ProjectAudit.EmployeeClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5299/api/v1/") });
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<AuditQuestionnaireService>();
builder.Services.AddScoped<EmployeeService>();

await builder.Build().RunAsync();
