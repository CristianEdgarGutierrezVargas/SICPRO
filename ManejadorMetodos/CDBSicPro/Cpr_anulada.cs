using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_anulada
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_anulada(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public pr_anulada InsertarPrAnulada(pr_anulada objPrAnulada)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_anulada.Add(objPrAnulada);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return objPrAnulada;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }
    }
}
