using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrame.Models
{

    [Table("bancos ")]
    public class Bank
    {

        [Key]
        [StringLength(8)]
        public string codigo_banco { get; set; }

        [Required]
        public string nombre_banco { get; set; }

        [Required]
        public string direccion { get; set; }

    }
}
