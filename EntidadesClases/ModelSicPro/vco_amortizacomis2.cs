//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntidadesClases.ModelSicPro
{
    using System;
    using System.Collections.Generic;
    
    public partial class vco_amortizacomis2
    {
        public long id_poliza { get; set; }
        public string num_poliza { get; set; }
        public long id_movimiento { get; set; }
        public string no_liquida { get; set; }
        public long id_pago { get; set; }
        public Nullable<decimal> cuota { get; set; }
        public Nullable<decimal> comision_pago { get; set; }
        public Nullable<decimal> monto_comis { get; set; }
        public string cheque_comis { get; set; }
        public Nullable<decimal> comis_mes { get; set; }
        public Nullable<decimal> comis_anio { get; set; }
        public string id_spvs { get; set; }
    }
}