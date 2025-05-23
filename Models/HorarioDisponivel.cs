using System.ComponentModel.DataAnnotations;

namespace SistemaReservaHorarios.Models
{
    public class HorarioDisponivel
    {
        public int Id { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        public bool Reservado { get; set; } = false;

        public Reserva Reserva { get; set; } // Navegação opcional para a reserva
    }
}
