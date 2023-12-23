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
    public class CReportes
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public CReportes(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public List<GetReportMemo_Result> GetReportMemo(long idPoliza, long idMovimiento)
        {
            try
            {
                var sql = _context.GetReportMemo(idPoliza, idMovimiento).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }
    }
}
