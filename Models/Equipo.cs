using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Parcial_2025_I.Models
{
    [Table("t_equipo")]
    public class Equipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public ICollection<Jugador> Jugadores { get; set; }
    }
}