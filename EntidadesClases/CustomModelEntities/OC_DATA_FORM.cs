using EntidadesClases.ModelSicPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesClases.CustomModelEntities
{
    public class OC_DATA_FORM
    {
        public class oc_data_vrenovar
        {
            public vpr_polrenovar objRenovar { get; set; }

            public gr_persona objPersona { get; set; }

            public pr_grupo objGrupo { get; set; }

            public pr_producto objProducto { get; set; }

            public gr_compania objCompania { get; set; }

            public gr_direccion objDireccion { get; set; }

            public gr_persona objPersonaAgente { get; set; }

            public gr_parametro objParametroDivisa { get; set; }
        } 
    }
}
