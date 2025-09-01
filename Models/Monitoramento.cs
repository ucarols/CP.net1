using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoPatioApi.Models
{
    [Table("MONITORAMENTO")]
    public class Monitoramento
    {
        [Key]
        [Column("ID_MONITORAMENTO")]
        public decimal Id { get; set; }

        [Required]
        [Column("ID_MOTO")]
        public decimal IdMoto { get; set; }

        [ForeignKey("IdMoto")]
        public Moto Moto { get; set; }

        [Required]
        [Column("ID_AREA_PATIO")]
        public decimal IdAreaPatio { get; set; }

        [ForeignKey("IdAreaPatio")]
        public Patio Patio { get; set; }

        [Required]
        [Column("DATA_HORA_VERIFICACAO")]
        public DateTime DataHoraVerificacao { get; set; }

        [Required]
        [Column("LOCAL_CORRETO")]
        [StringLength(1)]
        public string LocalCorreto { get; set; }

        [Column("TEMPO_PERMANENCIA")]
        [StringLength(50)]
        public string TempoPermanencia { get; set; }

        [Required]
        [Column("ALERTA")]
        [StringLength(255)]
        public string Alerta { get; set; }

        [Required]
        [Column("RESOLVIDO")]
        [StringLength(1)]
        public string Resolvido { get; set; }
    }
}
