using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTAWebsite.Models;
using GTAWebsite.Migrations;

namespace GTAWebsite.Data
{
    public class GTAWebsiteContext : DbContext
    {

        public GTAWebsiteContext (DbContextOptions<GTAWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<GTAWebsite.Models.Course> Course { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
        }

    }
}
