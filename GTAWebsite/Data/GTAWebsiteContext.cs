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

        public DbSet<GTAWebsite.Models.Course> Course { get; set; } = default!;
        public DbSet<GTAWebsite.Models.FileModel> FileModel { get; set; } = default!;
        public DbSet<GTAWebsite.Models.FormApplication> FormApplication { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<FileModel>().ToTable("Files");
            modelBuilder.Entity<FormApplication>().ToTable("Application");
        }




    }
}
