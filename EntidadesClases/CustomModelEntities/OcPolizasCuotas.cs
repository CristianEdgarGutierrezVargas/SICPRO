using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesClases.CustomModelEntities
{
    [Serializable]
    public class OcPolizasCuotas
    {
        public string num_poliza { get; set; }
        public decimal? cuota { get; set; }
        public DateTime? fecha_pago { get; set; }
        public decimal? cuota_total { get; set; }
    }
}
