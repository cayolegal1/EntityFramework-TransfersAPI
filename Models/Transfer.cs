using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrame.Models
{

    [Table("transferencias")]
    public class Transfer
    {

        [Key]
        public string id_transaccion { get; set; }

        [Required]
        [ForeignKey("num_cta")]
        public string num_cta { get; set; }

        [Required]
        [ForeignKey("num_cta_destino")]
        public string num_cta_destino { get; set; }

        [Required]
        [ForeignKey("cedula")]
        public string cedula_cliente { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public float monto { get; set; }

        [Required]
        public string estado { get; set; }

        [Required]
        [ForeignKey("codigo_banco")]
        public string cod_banco_origen { get; set; }

        [Required]
        [ForeignKey("codigo_banco")]
        public string cod_banco_destino { get; set; }
    }
}
