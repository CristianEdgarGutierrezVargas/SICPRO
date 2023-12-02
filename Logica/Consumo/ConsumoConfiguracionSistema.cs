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
    public class ConsumoConfiguracionSistema
    {

        //private readonly Cgr_persona _manejador_gr_persona;
        private readonly Cgr_pass _manejador_gr_pass;
        private readonly Cgr_parametro _manejador_gr_parametro;
        public static sicproEntities dbContext;

        public ConsumoConfiguracionSistema()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_gr_pass = new Cgr_pass(dbContext);
            _manejador_gr_parametro = new Cgr_parametro(dbContext);
        }

        public List<gr_persona> ListaPersonaConPass()
        {
            try
            {
                return _manejador_gr_pass.ListaPersonaConPass();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
            //finally
            //{
            //    dbContext.Dispose();
            //}
        }
        public void ResetPassword(string idPersona)
        {
            try
            {
                _manejador_gr_pass.ResetPassword(idPersona);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
            //finally
            //{
            //    dbContext.Dispose();
            //}
        }
        public List<gr_parametro> ListaRoles()
        {
            try
            {
                return _manejador_gr_parametro.ListRoles();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
            //finally
            //{
            //    dbContext.Dispose();
            //}
        }
    }
}
