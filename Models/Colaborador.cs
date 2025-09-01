using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoPatioApi.Models
{
    [Table("COLABORADOR")]
    public class Colaborador
    {
        [Key]
        [Column("ID_COLABORADOR")]
        public decimal Id { get; set; }

        [Required]
        [Column("NOME")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column("CARGO")]
        [StringLength(50)]
        public string Cargo { get; set; }
    }
}
