using ApplicationCore.Data;
using Management.Data.Abstract;
using Management.Data.Services;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApplicationCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddMvcOptions(options =>
            {
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                    _ => "Поле не может быть пустым.");

            });


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddTransient<IDepartmentServices, DepartmentServices>();
			builder.Services.AddTransient<IEmployeesServices, EmployeesServices>();

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
                pattern: "{controller=Departments}/{action=Index}/{id?}");

            app.Run();
        }
    }
}