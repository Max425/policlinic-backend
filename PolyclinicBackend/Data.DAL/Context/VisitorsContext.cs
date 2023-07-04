using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Context
{
    public class VisitorsContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public VisitorsContext(DbContextOptions<VisitorsContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
