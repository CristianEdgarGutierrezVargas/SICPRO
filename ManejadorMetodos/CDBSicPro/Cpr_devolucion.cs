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
    public class Cpr_devolucion
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_devolucion(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public List<pr_devolucion> GetCuotasDev(long idPol, long idMov)
        {

           
            try
            {
                var sql = _context.pr_devolucion.Where(x=>x.id_poliza==idPol && x.id_movimiento==idMov && x.monto_devolucion > x.saldo_devolucion).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
           
        }
    }
}
