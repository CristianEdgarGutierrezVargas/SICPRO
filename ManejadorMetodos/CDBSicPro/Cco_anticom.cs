using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System.Data;
using System.Data.Entity;
namespace ManejadorMetodos.CDBSicPro
{
    public class Cco_anticom
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cco_anticom(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public bool InsAnticomi(co_anticom objCo_anticom)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.co_anticom.Add(objCo_anticom);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }

        }
    }
}
