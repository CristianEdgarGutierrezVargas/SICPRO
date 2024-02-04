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
    public class Cvcb_cuotaexcludev
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cvcb_cuotaexcludev(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public List<vcb_cuotaexcludev> GetListCuotaexcludev(long idPoliza, long idMom, long idMovi, long idliquida)
        {
            try
            {
                //SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vcb_veripoliza1 WHERE estado = 'true'
                var sql = _context.vcb_cuotaexcludev.Where(x => x.id_poliza == idPoliza && x.id_mom==idMom && x.id_excluye==idMovi && x.id_movimiento==idliquida).ToList();
                
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
      
    }
}
