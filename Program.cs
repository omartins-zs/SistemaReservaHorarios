using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaReservaHorarios.Data;
using SistemaReservaHorarios.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext com a string de conex�o
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar o Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>() // Se for usar controle de acesso por pap�is (Admin, Cliente, etc)
.AddEntityFrameworkStores<ApplicationDbContext>();

// Adicionar controllers com views (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar o pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Habilita o uso de autentica��o (login)
app.UseAuthorization();  // Habilita o uso de autoriza��o (roles, [Authorize])

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Se voc� usou scaffolding para Identity, mapeia as p�ginas de �rea
app.MapRazorPages(); // Importante para funcionar com login/register do Identity

app.Run();
