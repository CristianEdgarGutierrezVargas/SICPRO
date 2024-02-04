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
    public class ConsumoCommon
    {
        #region Contructor Principal

        private readonly Cgr_componente _manejador_gr_componente;

        public static sicproEntities dbContext;
        public ConsumoCommon()
        {
            //if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_gr_componente = new Cgr_componente(dbContext);
        }

        #endregion

        #region gr_componente

        public List<vgr_comprol> ObtenerTablaComp(decimal idComponente, long idRol)
        {
            try
            {
                return _manejador_gr_componente.ObtenerTablaComp(idComponente, idRol);
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

        #endregion
    }
}
