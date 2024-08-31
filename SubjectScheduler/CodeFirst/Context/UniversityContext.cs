using Microsoft.EntityFrameworkCore;
using SubjectScheduler.CodeFirst.Entity.Model;
using SubjectScheduler.CodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SubjectScheduler.CodeFirst.Context
{
    public class UniversityContext : DbContext
    {
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Availability> Availabilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region Database Link
            optionsBuilder.UseSqlServer("");
            #endregion
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // İlişkilerin tanımlanması
            modelBuilder.Entity<Groups>()
                .HasMany(g => g.Shifts)
                .WithOne(s => s.Group)
                .HasForeignKey( s => s.GroupId);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithMany(s => s.Teachers);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Availabilities)
                .WithOne(a => a.Teacher)
                .HasForeignKey(a => a.TeacherId);
        }
    }

}
