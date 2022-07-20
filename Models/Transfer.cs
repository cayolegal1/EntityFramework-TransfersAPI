using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrame.Models
{
    public class Transfer
    {
        public string id_transaccion { get; set; }

        public string cedula_cliente { get; set; }

        public DateTime fecha { get; set; }

        public float monto { get; set; }

        public string estado { get; set; }


        public string num_cta { get; set; }


        public string num_cta_destino { get; set; }


        public string cod_banco_origen { get; set; }


        public string cod_banco_destino { get; set; }

        public virtual Account num_cta_origen { get; set; }

        public virtual Account numero_cta_destino_ac { get; set; }

        public virtual Bank codigo_banco_origen_bk { get; set; }

        public virtual Bank codigo_banco_destino_bk { get; set; }
    }
}
