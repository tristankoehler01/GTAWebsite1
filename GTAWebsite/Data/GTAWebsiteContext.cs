using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTAWebsite.Models;
using GTAWebsite.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GTAWebsite.Data
{
    public class GTAWebsiteContext : IdentityDbContext
    {

        public GTAWebsiteContext (DbContextOptions<GTAWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<GTAWebsite.Models.Course> Courses { get; set; } = default!;

        public DbSet<GTAWebsite.Models.FileModel> Files { get; set; } = default!;

        public DbSet<GTAWebsite.Models.FormApplication> Forms { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<GTAWebsite.Models.FormApplication>().ToTable("Forms");
            modelBuilder.Entity<FileModel>().ToTable("Files");
        }




    }
}
