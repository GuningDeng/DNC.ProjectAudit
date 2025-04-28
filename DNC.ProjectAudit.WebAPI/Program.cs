using DNC.ProjectAudit.Application.Extensions;
using DNC.ProjectAudit.Domain.Entities.AuditManagement;
using DNC.ProjectAudit.Infrastructure.Extensions;
using DNC.ProjectAudit.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterApplication();
builder.Services.RegisterInfrastructure();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5284")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                          policy.WithOrigins("http://localhost:5134")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                          //policy.WithOrigins("http://localhost:5118")
                          //.AllowAnyHeader()
                          //.AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandlingMiddleware();
app.UseHttpsRedirection();
app.UseCors("_myAllowSpecificOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
