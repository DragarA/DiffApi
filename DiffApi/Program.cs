using System.Reflection;
using DiffApi.Repositories;
using DiffApi.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AppDb")));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddScoped<IDiffDataService, DiffDataService>();
builder.Services.AddScoped<ICompareService, CompareService>();

builder.Services.AddScoped<IDiffDataRepository, DiffDataRepository>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var salesContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    salesContext.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
