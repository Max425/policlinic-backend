using Data.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL.Context;

public class GeneratedContext : DbContext
{
    public DbSet<Visitor> VisitorsGenerated { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VisitorGenerated;Username=postgres;Password=1474"); // TODO: сюда нужно конфиг прокинуть
    }
}
