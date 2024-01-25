using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cvco_veripoliza1
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cvco_veripoliza1(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public List<vco_veripoliza1> GetListVeripolizaByEstado(bool estado)
        {
            try
            {
                //SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vcb_veripoliza1 WHERE estado = 'true'
                var sql = _context.vco_veripoliza1.Where(x => x.estado == estado).ToList();
                
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
    }
}
