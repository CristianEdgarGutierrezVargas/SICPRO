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
    public class Cvcb_listacuoamort
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cvcb_listacuoamort(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public List<vcb_listacuoamort> Listacuoamort(long idPol, long idMov)
        
        {
            try
            {
                //SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vcb_veripoliza1 WHERE estado = 'true'
                var sql = _context.vcb_listacuoamort.Where(x=>x.id_poliza== idPol && x.id_movimiento==idMov).ToList();
                
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
       
    }
}
