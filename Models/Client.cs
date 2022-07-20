using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrame.Models
{

    public class Client
    {
        public string cedula { get; set; }

        public string tipo_doc { get; set; }

        public string nombre_apellido { get; set; }

        public virtual ICollection<Account> cedula_ac { get; set; }
    }
}
