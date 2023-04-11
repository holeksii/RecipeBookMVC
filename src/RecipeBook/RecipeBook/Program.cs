using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.EntityFrameworkCore;
using RecipeBook.DAL.Data;
using RecipeBook.BLL.Repositories;
using RecipeBook.BLL.Services;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;

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

    builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseNpgsql(connectionString));
    var dbContext = builder.Services.BuildServiceProvider().GetService<DatabaseContext>();
    builder.Services.AddSingleton<IRecipeService>(_ =>
        new RecipeService(new RecipeRepository(dbContext)));
    builder.Services.AddSingleton<IUserService>(_ =>
        new UserService(new UserRepository(dbContext)));
    builder.Services.AddSingleton<ICommentService>(_ =>
        new CommentService(new CommentRepository(dbContext)));
    builder.Services.AddSingleton<ILikeService>(_ =>
        new LikeService(new LikeRepository(dbContext)));

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
