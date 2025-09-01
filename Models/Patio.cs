using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoPatioApi.Models
{
    [Table("PATIO")]
    public class Patio
    {
        [Key]
        [Column("ID_AREA_PATIO")]
        public decimal Id { get; set; }

        [Required]
        [Column("COR")]
        public string Cor { get; set; }

        [Column("DESCRICAO")]
        public string? Descricao { get; set; }

        [Required]
        [Column("CAPACIDADE")]
        public decimal Capacidade { get; set; }
    }
}
