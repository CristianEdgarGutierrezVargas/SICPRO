using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesClases.CustomModelEntities
{
    [Serializable]
    public class OcRecuFac
    {
        public double id_poliza { get; set; }
        public long id_movimiento { get; set; }
        public decimal? cuota { get; set; }
        public string id_spvs { get; set; }
        public double? factura { get; set; }
        public DateTime? fecha_factura { get; set; }
        public long id_pago { get; set; }
        public string num_poliza { get; set; }
    }
}
