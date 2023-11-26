using DiffApi.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<DiffData> DiffData { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}