using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesClases.CustomModelEntities
{
    public class OC_PolizaPP
    {
        public long id_poliza { get; set; }
        public string num_poliza { get; set; }
        public long id_producto { get; set; }
        public string desc_prod { get; set; }
        public string id_spvs { get; set; }
        public string nomraz { get; set; }
    }
}
