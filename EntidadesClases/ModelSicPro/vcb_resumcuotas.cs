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
    
    public partial class vcb_resumcuotas
    {
        public long id_poliza { get; set; }
        public long id_movimiento { get; set; }
        public decimal cuota { get; set; }
        public Nullable<decimal> cuota_total { get; set; }
        public Nullable<decimal> cuota_neta { get; set; }
        public Nullable<decimal> cuota_comis { get; set; }
        public Nullable<decimal> cuota_pago { get; set; }
        public decimal monto_exclusion { get; set; }
        public decimal neta_exclusion { get; set; }
        public decimal comision_exclusion { get; set; }
        public decimal monto_devolucion { get; set; }
        public Nullable<decimal> cuotatotal { get; set; }
        public Nullable<decimal> cuotapago { get; set; }
        public Nullable<long> id_mom { get; set; }
    }
}