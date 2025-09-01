using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoPatioApi.Models
{
    [Table("TRIAGEM")]
    public class Triagem
    {
        [Key]
        [Column("ID_TRIAGEM")]
        public decimal Id { get; set; }

        [Required]
        [Column("ID_MOTO")]
        public decimal IdMoto { get; set; }

        [ForeignKey("IdMoto")]
        public Moto Moto { get; set; }

        [Required]
        [Column("DATA_TRIAGEM")]
        public DateTime DataTriagem { get; set; }

        [Required]
        [Column("CLASSIFICACAO")]
        [StringLength(50)]
        public string Classificacao { get; set; }

        [Column("PROBLEMA_REPORTADO")]
        [StringLength(200)]
        public string ProblemaReportado { get; set; }

        [Column("TEMPO_LIMITE")]
        [StringLength(50)]
        public string TempoLimite { get; set; }

        [Required]
        [Column("STATUS_TRIAGEM")]
        [StringLength(30)]
        public string StatusTriagem { get; set; }
    }
}
