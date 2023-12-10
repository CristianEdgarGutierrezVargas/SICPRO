using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesClases.CustomModelEntities
{
    public class OC_ObtenerTablaPolizaIn
    {
        public string num_poliza { get; set; }

        public string id_perclie { get; set; }

        public string id_spvs { get; set; }

        public long id_producto { get; set; }

        public bool vigencia { get; set; }

        public DateTime fc_inivig { get; set; }

        public DateTime fc_finvig { get; set; }

        public DateTime fc_polizavencida { get; set; }

        public bool porvencer { get; set; }

    }
}
