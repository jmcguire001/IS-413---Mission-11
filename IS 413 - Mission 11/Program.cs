// IS 413 - Mission 11
// by Jacob McGuire
// Section 02, Group 03

using Mission11_McGuire.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookstoreContext>(options =>
{
    // Use the connection string to get the database
    options.UseSqlite(builder.Configuration["ConnectionStrings:BookstoreConnection"]);
}
);

// When we refer to IBookRepository, we actually want to use the EFBookRepository (but it uses IBookstoreRepository as the template)
builder.Services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

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

// Pretty up the URL routing
app.MapControllerRoute("pagination", "Books/{pageNum}", new { Controller = "Home", action = "Index" });

app.MapDefaultControllerRoute();

app.Run();
