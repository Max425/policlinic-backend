using Data.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL.Context;

public class GeneratedContext : DbContext
{
    public DbSet<Visitor> VisitorGenerated { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=generated;Username=postgres;Password=Hardpass121"); // TODO: сюда нужно конфиг прокинуть
    }
}
