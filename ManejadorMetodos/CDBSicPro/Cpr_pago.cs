using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_pago
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_pago(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public List<pr_pago> GetObjPagoByFactura(double factura)
        {
            try
            {
                var sql = _context.pr_pago.Where(w => w.factura == factura).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }


        }
    }
}
