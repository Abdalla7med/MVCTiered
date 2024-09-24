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


            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Computer Science", ManagerId = 1 },
                new Department { Id = 2, Name = "Mathematics", ManagerId = 2 },
                new Department { Id = 3, Name = "Physics", ManagerId = 3 },
                new Department { Id = 4, Name = "Chemistry", ManagerId = 4 },
                new Department { Id = 5, Name = "Biology", ManagerId = 5 },
                new Department { Id = 6, Name = "Business", ManagerId = 6 },
                new Department { Id = 7, Name = "Economics", ManagerId = 7 },
                new Department { Id = 8, Name = "Electrical Engineering", ManagerId = 8 },
                new Department { Id = 9, Name = "Mechanical Engineering", ManagerId = 9 },
                new Department { Id = 10, Name = "Civil Engineering", ManagerId = 10 }
            );

            // Seed Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, Name = "Alice Johnson", Salary = 75000, address = "123 Main St", DepartmentId = 1, ImageURL = "alice.jpg" },
                new Instructor { Id = 2, Name = "Bob Smith", Salary = 80000, address = "456 High St", DepartmentId = 2, ImageURL = "bob.jpg" },
                new Instructor { Id = 3, Name = "Catherine Williams", Salary = 82000, address = "789 Elm St", DepartmentId = 3, ImageURL = "catherine.jpg" },
                new Instructor { Id = 4, Name = "David Johnson", Salary = 78000, address = "321 Maple Ave", DepartmentId = 4, ImageURL = "david.jpg" },
                new Instructor { Id = 5, Name = "Emily Davis", Salary = 76000, address = "654 Pine St", DepartmentId = 5, ImageURL = "emily.jpg" },
                new Instructor { Id = 6, Name = "Frank Miller", Salary = 90000, address = "987 Oak St", DepartmentId = 6, ImageURL = "frank.jpg" },
                new Instructor { Id = 7, Name = "Grace Lee", Salary = 85000, address = "111 Cedar St", DepartmentId = 7, ImageURL = "grace.jpg" },
                new Instructor { Id = 8, Name = "Henry Brown", Salary = 88000, address = "222 Birch St", DepartmentId = 8, ImageURL = "henry.jpg" },
                new Instructor { Id = 9, Name = "Isabelle Wilson", Salary = 86000, address = "333 Spruce St", DepartmentId = 9, ImageURL = "isabelle.jpg" },
                new Instructor { Id = 10, Name = "Jack Thomas", Salary = 92000, address = "444 Ash St", DepartmentId = 10, ImageURL = "jack.jpg" }
            );

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Intro to Programming", Degree = 100, MinDegree = 50, TotalHours = 40, InstructorId = 1, DepartmentId = 1 },
                new Course { Id = 2, Name = "Data Structures", Degree = 100, MinDegree = 60, TotalHours = 45, InstructorId = 1, DepartmentId = 1 },
                new Course { Id = 3, Name = "Algorithms", Degree = 100, MinDegree = 65, TotalHours = 50, InstructorId = 1, DepartmentId = 1 },
                new Course { Id = 4, Name = "Linear Algebra", Degree = 100, MinDegree = 55, TotalHours = 40, InstructorId = 2, DepartmentId = 2 },
                new Course { Id = 5, Name = "Calculus I", Degree = 100, MinDegree = 50, TotalHours = 42, InstructorId = 2, DepartmentId = 2 },
                new Course { Id = 6, Name = "Quantum Mechanics", Degree = 100, MinDegree = 60, TotalHours = 45, InstructorId = 3, DepartmentId = 3 },
                new Course { Id = 7, Name = "Thermodynamics", Degree = 100, MinDegree = 65, TotalHours = 50, InstructorId = 4, DepartmentId = 4 },
                new Course { Id = 8, Name = "Organic Chemistry", Degree = 100, MinDegree = 55, TotalHours = 40, InstructorId = 4, DepartmentId = 4 },
                new Course { Id = 9, Name = "Business Strategy", Degree = 100, MinDegree = 50, TotalHours = 42, InstructorId = 6, DepartmentId = 6 },
                new Course { Id = 10, Name = "Financial Accounting", Degree = 100, MinDegree = 60, TotalHours = 45, InstructorId = 6, DepartmentId = 6 }
            );

            // Seed Trainees
            modelBuilder.Entity<Trainee>().HasData(
                new Trainee { Id = 1, Name = "John Doe", address = "101 Apple St", DepartmentId = 1, ImageUrl = "john.jpg" },
                new Trainee { Id = 2, Name = "Jane Smith", address = "102 Orange St", DepartmentId = 2, ImageUrl = "jane.jpg" },
                new Trainee { Id = 3, Name = "Samuel Green", address = "103 Banana St", DepartmentId = 3, ImageUrl = "samuel.jpg" },
                new Trainee { Id = 4, Name = "Natalie Brown", address = "104 Peach St", DepartmentId = 4, ImageUrl = "natalie.jpg" },
                new Trainee { Id = 5, Name = "Michael Johnson", address = "105 Grape St", DepartmentId = 5, ImageUrl = "michael.jpg" },
                new Trainee { Id = 6, Name = "Sophia Lee", address = "106 Plum St", DepartmentId = 6, ImageUrl = "sophia.jpg" },
                new Trainee { Id = 7, Name = "William Martinez", address = "107 Pear St", DepartmentId = 7, ImageUrl = "william.jpg" },
                new Trainee { Id = 8, Name = "Olivia Anderson", address = "108 Cherry St", DepartmentId = 8, ImageUrl = "olivia.jpg" },
                new Trainee { Id = 9, Name = "Ethan Scott", address = "109 Kiwi St", DepartmentId = 9, ImageUrl = "ethan.jpg" },
                new Trainee { Id = 10, Name = "Emma Davis", address = "110 Mango St", DepartmentId = 10, ImageUrl = "emma.jpg" }
            );

            // Seed CourseResults
            modelBuilder.Entity<CourseResult>().HasData(
                new CourseResult { Id = 1, Grade = 90.5m, GradeLetter = "A", GradeDate = DateTime.Now, CourseId = 1, TraineeId = 1 },
                new CourseResult { Id = 2, Grade = 85.0m, GradeLetter = "B", GradeDate = DateTime.Now, CourseId = 2, TraineeId = 2 },
                new CourseResult { Id = 3, Grade = 78.5m, GradeLetter = "C", GradeDate = DateTime.Now, CourseId = 3, TraineeId = 3 },
                new CourseResult { Id = 4, Grade = 88.0m, GradeLetter = "B", GradeDate = DateTime.Now, CourseId = 4, TraineeId = 4 },
                new CourseResult { Id = 5, Grade = 92.5m, GradeLetter = "A", GradeDate = DateTime.Now, CourseId = 5, TraineeId = 5 },
                new CourseResult { Id = 6, Grade = 80.0m, GradeLetter = "B", GradeDate = DateTime.Now, CourseId = 6, TraineeId = 6 },
                new CourseResult { Id = 7, Grade = 74.5m, GradeLetter = "C", GradeDate = DateTime.Now, CourseId = 7, TraineeId = 7 },
                new CourseResult { Id = 8, Grade = 89.0m, GradeLetter = "B", GradeDate = DateTime.Now, CourseId = 8, TraineeId = 8 },
                new CourseResult { Id = 9, Grade = 95.0m, GradeLetter = "A", GradeDate = DateTime.Now, CourseId = 9, TraineeId = 9 },
                new CourseResult { Id = 10, Grade = 91.5m, GradeLetter = "A", GradeDate = DateTime.Now, CourseId = 10, TraineeId = 10 }
            );

            base.OnModelCreating(modelBuilder);
        }


    }
}
