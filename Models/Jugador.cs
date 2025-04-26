using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial_2025_I.Models
{
    [Table("t_jugador")]
    public class Jugador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Range(15, 50)]
        public int Edad { get; set; }

        [Required]
        public string Posicion { get; set; }

        [ForeignKey("Equipo")]
        public int? EquipoId { get; set; }

        public Equipo? Equipo { get; set; }
    }
}