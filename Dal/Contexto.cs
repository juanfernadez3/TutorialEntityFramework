using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TotorialEntityFramework.Models;

namespace TotorialEntityFramework.Dal
{
    public class Contexto : DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data/Tutoria.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurin One-Many relationship with fluent Api.
            modelBuilder.Entity<Students>()
                .HasOne<Courses>(s => s.Courses)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.CourseId);


            //Configuring One-One relationship with fluent Api.
            modelBuilder.Entity<Students>()
                .HasOne(s => s.Address)
                .WithOne(ad => ad.Students)
                .HasForeignKey<StudentAddress>(x => x.StudentAddressId);

            //Configuring Many-Many relationship with fluent Api.
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

        }
    }
}
