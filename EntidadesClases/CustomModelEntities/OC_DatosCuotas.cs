using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesClases.CustomModelEntities
{
    [Serializable]
    public class OC_DatosCuotas
    {
        public string NomCliente { get; set; }
        public string NomGrupo { get; set; }
        public string NomProducto { get; set; }
        public string NomCompania { get; set; }
        public string NombreEjecutivo { get; set; }
    }
}
