using Common;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Consumo
{
    public class ConsumoReportes
    {
        private readonly CReportes _manejador_reportes;

        public static sicproEntities dbContext;
        public ConsumoReportes()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();

            _manejador_reportes = new CReportes(dbContext);           
        }

        public List<GetReportMemo_Result> GetReportMemo(long idPoliza, long idMovimiento)
        {
            try
            {
                return _manejador_reportes.GetReportMemo(idPoliza, idMovimiento);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
            finally
            {
                //dbContext.Dispose();
            }
        }
    }
}
