using DiffApi.Repositories;
using DiffApi.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AppDb")));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDiffDataService, DiffDataService>();
builder.Services.AddScoped<ICompareService, CompareService>();

builder.Services.AddScoped<IDiffDataRepository, DiffDataRepository>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var salesContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    salesContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
