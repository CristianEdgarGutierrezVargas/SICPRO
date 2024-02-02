using EntidadesClases.ModelSicPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesClases.CustomModelEntities
{
    [Serializable]
    public class OC_DATA_FORM
    {
        [Serializable]
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

        public class oc_data_vpr_polaplivar
        {
            public vpr_polaplivar objRenovar { get; set; }

            public gr_persona objPersona { get; set; }

            public pr_grupo objGrupo { get; set; }

            public pr_producto objProducto { get; set; }

            public gr_compania objCompania { get; set; }

            public gr_direccion objDireccion { get; set; }

            public gr_persona objPersonaAgente { get; set; }

            public gr_parametro objParametroDivisa { get; set; }
        }

        public class oc_data_vpr_polincluvar
        {
            public vpr_polincluvar objRenovar { get; set; }

            public gr_persona objPersona { get; set; }

            public pr_grupo objGrupo { get; set; }

            public pr_producto objProducto { get; set; }

            public gr_compania objCompania { get; set; }

            public gr_direccion objDireccion { get; set; }

            public gr_persona objPersonaAgente { get; set; }

            public gr_parametro objParametroDivisa { get; set; }
        }

        public class oc_data_vpr_polexcluvar1
        {
            public vpr_polexcluvar1 objPoliza { get; set; }

            public gr_persona objPersona { get; set; }

            public pr_grupo objGrupo { get; set; }

            public pr_producto objProducto { get; set; }

            public gr_compania objCompania { get; set; }

            public gr_direccion objDireccion { get; set; }

            public gr_persona objPersonaAgente { get; set; }

            public gr_parametro objParametroDivisa { get; set; }
        }

        public class oc_data_vcb_veripoliza2
        {
            public vcb_veripoliza2 objDataPoliza { get; set; }

            public gr_persona objPersona { get; set; }

            public pr_grupo objGrupo { get; set; }

            public pr_producto objProducto { get; set; }

            public gr_compania objCompania { get; set; }

            public gr_direccion objDireccion { get; set; }

            public gr_persona objPersonaAgente { get; set; }

            public gr_parametro objParametroDivisa { get; set; }
        }

        public class oc_data_vcb_veripoliza3
        {
            public vcb_veripoliza3 objDataPoliza { get; set; }

            public gr_persona objPersona { get; set; }

            public pr_grupo objGrupo { get; set; }

            public pr_producto objProducto { get; set; }

            public gr_compania objCompania { get; set; }

            public gr_direccion objDireccion { get; set; }

            public gr_persona objPersonaAgente { get; set; }

            public gr_parametro objParametroDivisa { get; set; }
        }

        public class oc_data_vpr_polanuvar
        {
            public vpr_polanuvar objPoliza { get; set; }

            public gr_persona objPersona { get; set; }

            public pr_grupo objGrupo { get; set; }

            public pr_producto objProducto { get; set; }

            public gr_compania objCompania { get; set; }

            public gr_direccion objDireccion { get; set; }

            public gr_persona objPersonaAgente { get; set; }

            public gr_parametro objParametroDivisa { get; set; }
        }

        public class PorcentajeComisionAnulacion 
        {
            public decimal por_neta { get; set; }

            public decimal por_comision { get; set; }
        }
    }
}
