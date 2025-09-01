using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoPatioApi.Models
{
    [Table("MOTO")]
    public class Moto
    {
        [Key]
        [Column("ID_MOTO")]
        public decimal Id { get; set; }

        [Required]
        [Column("PLACA")]
        [StringLength(10)]
        public string Placa { get; set; }

        [Column("MODELO")]
        [StringLength(100)]
        public string Modelo { get; set; }

        [Column("MARCA")]
        [StringLength(50)]
        public string Marca { get; set; }

        [Column("ANO")]
        [StringLength(4)]
        public string Ano { get; set; }

        [Required]
        [Column("STATUS_ATUAL")]
        [StringLength(50)]
        public string StatusAtual { get; set; }

        [Required]
        [Column("DATA_ENTRADA")]
        public DateTime DataEntrada { get; set; }

        [ForeignKey("Patio")]
        [Column("ID_AREA_PATIO")]
        public decimal? IdAreaPatio { get; set; }

        public Patio Patio { get; set; }
    }
}
