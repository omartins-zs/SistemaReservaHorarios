using System.ComponentModel.DataAnnotations;

namespace SistemaReservaHorarios.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; } // Guardar o hash da senha, não a senha em texto puro

        [Required]
        public string Role { get; set; } // "Admin" ou "Cliente"

        public ICollection<Reserva> Reservas { get; set; }
    }
}
