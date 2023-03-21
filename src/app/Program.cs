using Microsoft.EntityFrameworkCore;
using RecipeBookMVC.Data;
using RecipeBookMVC.Models;
using Serilog;

Log.Logger = new LoggerConfiguration().
    WriteTo.Console().
    WriteTo.Seq("http://localhost:5341").CreateLogger();

try
{
    Log.Information("Starting");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<RecipeBookMVC.Data.DatabaseContext>(options =>
            options.UseNpgsql(connectionString));

    // get db context
    var dbContext = builder.Services.BuildServiceProvider().GetService<RecipeBookMVC.Data.DatabaseContext>();

    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    app.UseSerilogRequestLogging();

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
catch(Exception ex)
{
    Log.Fatal(ex, "App terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
