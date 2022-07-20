using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityFrame.Models
{

    public class Bank
    {

        public string codigo_banco { get; set; }

        public string nombre_banco { get; set; }
        public string direccion { get; set; }

        [JsonIgnore]
        public virtual ICollection<Account> codigo_banco_ac { get; set; }

        [JsonIgnore]
        public virtual ICollection<Transfer> codigo_banco_origen { get; set; }

        [JsonIgnore]
        public virtual ICollection<Transfer> codigo_banco_destino { get; set; }
     
    }
}
