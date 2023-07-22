using Data.DAL.Context;
using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace VisitorGenerated.Context;

public class GeneratedContext : DbContext
{
    public DbSet<Visitor> VisitorsGenerated { get; set; }

    public GeneratedContext(DbContextOptions<GeneratedContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
