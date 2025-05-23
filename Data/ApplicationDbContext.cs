using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaReservaHorarios.Models;

namespace SistemaReservaHorarios.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HorarioDisponivel> HorariosDisponiveis { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}
