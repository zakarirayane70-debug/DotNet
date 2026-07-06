using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using appTest.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<appTestDB>(options =>
    options.UseInMemoryDatabase("AppTestDB"));

var app = builder.Build();

// Au démarrage : créer la base de données en mémoire et la table Produits automatiquement
using (var scope = app.Services.CreateScope()) // ouvre un accès temporaire aux services (dont appTestDB)
{
    var db = scope.ServiceProvider.GetRequiredService<appTestDB>(); // récupère le contexte de base de données
    db.Database.EnsureCreated(); // crée la base et les tables si elles n'existent pas encore
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.Run();
