using Microsoft.AspNetCore.Identity;

namespace SistemaReservaHorarios.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }

        // Você pode colocar mais campos se quiser, como:
        // public string CPF { get; set; }
        // public string Endereco { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}
