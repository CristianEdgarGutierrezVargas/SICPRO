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
    public class ConsumoRegistroProd
    {
        #region Contructor Principal

        private readonly Cgr_parametro _manejador_gr_parametro;

        public static sicproEntities dbContext;
        public ConsumoRegistroProd()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_gr_parametro = new Cgr_parametro(dbContext);
        }

        #endregion

        public List<gr_parametro> ObtenerLista(string columna)
        {
            try
            {
                return _manejador_gr_parametro.ObtenerLista(columna);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
            finally
            {
                dbContext.Dispose();
            }
        }



    }
}
