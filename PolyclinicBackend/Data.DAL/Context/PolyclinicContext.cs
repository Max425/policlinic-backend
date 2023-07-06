using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Context
{
    public class PolyclinicContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public PolyclinicContext(DbContextOptions<PolyclinicContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
