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
    public class Cpr_formriesgo
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_formriesgo(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public List<pr_formriesgo> GetListFormriesgo()
        {

            List<pr_formriesgo> sql = new List<pr_formriesgo>();
            try
            {
                sql = _context.pr_formriesgo.ToList();

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
            return sql;
        }
    }
}
