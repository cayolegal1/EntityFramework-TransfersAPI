using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrame.Models
{

    [Table("clientes")]
    public class Client
    {

        [Key]
        public string cedula { get; set; }


        [Required]
        public string tipo_doc { get; set; }

        [Required]
        public string nombre_apellido { get; set; }
    }
}
