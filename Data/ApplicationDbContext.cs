using Microsoft.EntityFrameworkCore;
using SistemaReservaHorarios.Models;

using SistemaReservaHorarios.Models;
using System.Collections.Generic;

namespace SistemaReservaHorarios.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<HorarioDisponivel> HorariosDisponiveis { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}