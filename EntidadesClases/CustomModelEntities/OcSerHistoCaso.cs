using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesClases.CustomModelEntities
{
    [Serializable]
    public class OcSerHistoCaso
    {
        public decimal id_caso { get; set; }
        public decimal anio_caso { get; set; }
        public int id_sucur { get; set; }
        public string id_perclie { get; set; }
        public string nomraz { get; set; }
        public long id_poliza { get; set; }
        public string num_poliza { get; set; }
        public long id_producto { get; set; }
        public string desc_prod { get; set; }
        public string id_spvs { get; set; }
        public string nomraz2 { get; set; }
        public string denunciante { get; set; }
        public string mat_aseg { get; set; }
        public string uniobj { get; set; }
        public DateTime? fc_denuncia { get; set; }
        public string circunstancia { get; set; }
        public DateTime fc_iniestado { get; set; }
        public double id_estca { get; set; }
        public string obs_histcaso { get; set; }
        public string desc_param { get; set; }
        public decimal aprox_caso { get; set; }
        public string divisa { get; set; }
    }
}
