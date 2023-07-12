using Data.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL.Context;

public class PolyclinicContext : DbContext
{
    public DbSet<Record> Records { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Visitor> Visitors { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Credential> Credentials { get; set; }
    public DbSet<Operator> Operators { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=polyclinic;Username=postgres;Password=1474"); // TODO: сюда нужно конфиг прокинуть
    }
}
