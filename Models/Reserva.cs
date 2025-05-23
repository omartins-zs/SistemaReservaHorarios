using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaReservaHorarios.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required]
        public int HorarioDisponivelId { get; set; }

        [ForeignKey("HorarioDisponivelId")]
        public HorarioDisponivel HorarioDisponivel { get; set; }

        public DateTime DataReserva { get; set; } = DateTime.Now;
    }
}
