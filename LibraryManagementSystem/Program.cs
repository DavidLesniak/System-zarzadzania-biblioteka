using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() 
    .AddEntityFrameworkStores<LibraryDbContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // 1. Tworzenie ról, jeœli nie istniej¹
    string[] roleNames = { "Admin", "User", "Employee" };
    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    // 2. Tworzenie u¿ytkowników i przypisywanie ról

    // Admin
    var adminEmail = "admin@gmail.com";
    var adminPassword = "Admin123!";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true,
            FirstName = "Admin",
            LastName = "User"
        };
        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (!result.Succeeded)
        {
            throw new Exception($"B³¹d przy tworzeniu u¿ytkownika Admin: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
    if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
    {
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }

    // Pracownik
    var employeeEmail = "pracownik@gmail.com";
    var employeePassword = "Pracownik123!";
    var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
    if (employeeUser == null)
    {
        employeeUser = new ApplicationUser
        {
            UserName = employeeEmail,
            Email = employeeEmail,
            EmailConfirmed = true,
            FirstName = "Jan",
            LastName = "Kowalski"
        };
        var result = await userManager.CreateAsync(employeeUser, employeePassword);
        if (!result.Succeeded)
        {
            throw new Exception($"B³¹d przy tworzeniu u¿ytkownika Employee: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
    if (!await userManager.IsInRoleAsync(employeeUser, "Employee"))
    {
        await userManager.AddToRoleAsync(employeeUser, "Employee");
    }

    // User
    var usereEmail = "czytelnik@gmail.com";
    var userPassword = "Czytelnik123!";
    var user = await userManager.FindByEmailAsync(usereEmail);
    if (user == null)
    {
        user = new ApplicationUser
        {
            UserName = usereEmail,
            Email = usereEmail,
            EmailConfirmed = true,
            FirstName = "Roman",
            LastName = "Kranc"
        };
        var result = await userManager.CreateAsync(user, userPassword);
        if (!result.Succeeded)
        {
            throw new Exception($"B³¹d przy tworzeniu u¿ytkownika User: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
    if (!await userManager.IsInRoleAsync(user, "User"))
    {
        await userManager.AddToRoleAsync(user, "User");
    }
}



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();  

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();

app.Run();