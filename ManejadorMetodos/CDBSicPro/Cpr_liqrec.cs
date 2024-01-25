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
    public class Cpr_liqrec
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_liqrec(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public List<pr_liqrec> ListTop(string id_perucb)
        {
            try
            {
                var sql = _context.pr_liqrec.Where(w => w.id_perucb == id_perucb).OrderByDescending(o=>o.id_liq).Take(5).ToList();
                return sql;
                //string sentenciaSQL = "SELECT pr_liqrec.id_liq, pr_liqrec.fc_liq, pr_liqrec.id_perucb, pr_liqrec.monto_liqs, pr_liqrec.monto_liqb, pr_liqrec.id_suc " +
                //    "FROM pr_liqrec WHERE pr_liqrec.id_perucb = '" + id_perucb + "' ORDER BY id_liq DESC LIMIT 5";                
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al ", original);
            }
        }
    }
}
