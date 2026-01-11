using CarsAnalytics.ExperienceApi.Providers;
using CarsAnalytics.ExperienceApi.Services;
using CarsAnalytics.ExperienceApi.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Validation
builder.Services.AddValidatorsFromAssemblyContaining<TerritoryDtoValidator>();

var systemApiUrl = builder.Configuration["SystemApi:BaseUrl"]!;

builder.Services.AddHttpClient<ITerritoriesProvider, TerritoriesProvider>(client =>
{
    client.BaseAddress = new Uri(systemApiUrl);
});

builder.Services.AddScoped<ITerritoryService, TerritoryService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy => policy.WithOrigins("https://localhost:7005")
    .AllowAnyHeader()
    .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarsAnalytics API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowBlazor");

app.MapControllers();

app.Run();
