using DNC.ProjectAudit.AuditClient;
using DNC.ProjectAudit.AuditClient.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5299/api/v1/") });
builder.Services.AddScoped<AuditService>();
builder.Services.AddScoped<AuditQuestionnaireService>();

await builder.Build().RunAsync();
