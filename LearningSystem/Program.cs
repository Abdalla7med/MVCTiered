using LearningSystem.DAL;
using LearningSystem.DAL.Context;
using LearningSystem.DAL.Repositories_Implementation;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<LearningPlatformContext>(
                options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            /// DI Registration
            
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<ICourseResultRepository, CourseResultRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
