using EntidadesClases.ModelSicPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesClases.CustomModelEntities
{
    public class OcGrdDev
    {
        public long id_devolucion { get; set; }
        public decimal saldo_devolucion { get; set; }
        public int anio_recibo { get; set; }
        public string id_perclie { get; set; }

     
    }
}
