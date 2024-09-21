using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
namespace LearningSystem.DAL.Context
{
    public class LearningPlatformContext:DbContext
    {
        public LearningPlatformContext() : base() { }
        
        public LearningPlatformContext(DbContextOptions<LearningPlatformContext> options) : base(options) { }

        public DbSet<Course> Courses { set; get; }
        public DbSet<Trainee> Trainees { set; get; }
        public DbSet<CourseResult> CourseResult { set; get; }
        public DbSet<Department> Departments { set; get; }
        public DbSet<Instructor> Instructors { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                }
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // one-to-many relation between course and instructor

            modelBuilder.Entity<Course>().
                HasOne(C => C.Instructor).
                WithMany(I => I.Courses).
                HasForeignKey(C => C.InstructorId);

            // one-to-many relation between course and CourseResults
            modelBuilder.Entity<Course>().
                 HasMany(C => C.CourseResults)
                .WithOne(Cr => Cr.Course)
                .HasForeignKey(Cr => Cr.CourseId);

            // many-to-one relation between course and Department
            modelBuilder.Entity<Course>().
                 HasOne(C => C.Department)
                .WithMany(D => D.Courses)
                .HasForeignKey(C => C.DepartmentId);

            // one-to-many relation between instructor and  department 
            modelBuilder.Entity<Instructor>()
                .HasOne(I => I.Department)
                .WithMany(D => D.Instructors)
                .HasForeignKey(I => I.DepartmentId);

            // Manager Relation between department and Instructor (one to one relation )
            modelBuilder.Entity<Department>()
                .HasOne<Instructor>()
                .WithOne(M => M.Department);

            modelBuilder.Entity<Trainee>()
                .HasOne(T => T.Department)
                .WithMany(D => D.Trainees)
                .HasForeignKey(T => T.DepartmentId);

            modelBuilder.Entity<Trainee>()
                .HasMany(T => T.CourseResults)
                .WithOne(Cr => Cr.Trainee)
                .HasForeignKey(Cr => Cr.TraineeId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
