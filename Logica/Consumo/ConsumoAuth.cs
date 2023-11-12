using Common;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Consumo
{
    public class ConsumoAuth
    {
        #region Contructor Principal

        private readonly Cgr_persona _manejador_gr_persona;       

        public static sicproEntities dbContext;
        public ConsumoAuth()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_gr_persona = new Cgr_persona(dbContext);            
        }

        #endregion

        #region gr_persona

        public bool EliminarPersona(string varbusqueda)
        {
            try
            {
                return _manejador_gr_persona.EliminarPersona(varbusqueda);
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

        public bool ExistePersona(string varbusqueda)
        {
            try
            {
                return _manejador_gr_persona.ExistePersona(varbusqueda);
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

        #endregion


        #region gr_pass



        #endregion
    }
}
