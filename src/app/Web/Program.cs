using Microsoft.EntityFrameworkCore;
using RecipeBook.Business.Services;
using RecipeBook.Data.Context;
using RecipeBook.Data.Repositories;
using RecipeBook.Data.Models;
using Serilog;
using Microsoft.AspNetCore.Identity;

Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.Seq("http://localhost:5341")
    .CreateLogger();

try
{
    Log.Information("Starting");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseNpgsql(connectionString));

    builder.Services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<DatabaseContext>();

    var dbContext = builder.Services.BuildServiceProvider().GetService<DatabaseContext>();

    var recipeRepository = new RecipeRepository(dbContext!);
    var userRepository = new UserRepository(dbContext!);
    var commentRepository = new CommentRepository(dbContext!);
    var likeRepository = new LikeRepository(dbContext!);

    builder.Services.AddSingleton<IRecipeService>(_ =>
        new RecipeService(recipeRepository));
    builder.Services.AddSingleton<IUserService>(_ =>
        new UserService(userRepository));
    builder.Services.AddSingleton<ICommentService>(_ =>
        new CommentService(commentRepository));
    builder.Services.AddSingleton<ILikeService>(_ =>
        new LikeService(likeRepository, recipeRepository, userRepository));

    builder.Services.AddScoped<IAccountRepository, AccountRepository>();

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

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "App terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
