using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrame.Models
{

    public class Bank
    {

        public string codigo_banco { get; set; }

        public string nombre_banco { get; set; }
        public string direccion { get; set; }

        public virtual ICollection<Account> codigo_banco_ac { get; set; }

        public virtual ICollection<Transfer> codigo_banco_origen { get; set; }

        public virtual ICollection<Transfer> codigo_banco_destino { get; set; }
     
    }
}
