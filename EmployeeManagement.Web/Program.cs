using EmployeeManagement.Web.Services;
using EmployeeManagement.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5202/");
        });
        builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5202/");
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }


        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}

