using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SistemaReservaHorarios.Models;
using System;
using System.Threading.Tasks;

namespace SistemaReservaHorarios.Data
{
    public static class DataSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = new[] { "Admin", "Cliente" };

            // Cria as roles, se não existirem
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Cria usuário Admin padrão, se não existir
            var adminEmail = "admin@sistema.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail, Nome = "Administrador" };
                var result = await userManager.CreateAsync(adminUser, "SenhaForte@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Cria usuário Cliente padrão, se não existir
            var clienteEmail = "cliente@sistema.com";
            var clienteUser = await userManager.FindByEmailAsync(clienteEmail);

            if (clienteUser == null)
            {
                clienteUser = new ApplicationUser { UserName = clienteEmail, Email = clienteEmail, Nome = "Cliente Padrão" };
                var result = await userManager.CreateAsync(clienteUser, "SenhaForte@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(clienteUser, "Cliente");
                }
            }
        }
    }
}
