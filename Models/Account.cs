using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrame.Models
{

    [Table("cuentas")]
    public class Account
    {

        [Key]
        public string id_cta { get; set; }

        [Required]
        public string num_cta { get; set; }

        [Required]
        [StringLength(3)]
        public string moneda { get; set; }

        [Required]
        public float saldo { get; set; }

        [Required]
        [ForeignKey("cedula")]
        public string cedula_cliente { get; set; }

        [Required]
        [ForeignKey("codigo_banco")]
        public string cod_banco { get; set; }
    }
}
