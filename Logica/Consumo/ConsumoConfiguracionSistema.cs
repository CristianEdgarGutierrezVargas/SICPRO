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
        private readonly Cgr_persona _manejador_gr_persona;
        private readonly Cgr_parametro _manejador_gr_parametro;
        private readonly Cco_porcomi _manejador_co_porcomi;
        public static sicproEntities dbContext;

        public ConsumoConfiguracionSistema()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_gr_pass = new Cgr_pass(dbContext);
            _manejador_gr_parametro = new Cgr_parametro(dbContext);
            _manejador_gr_persona=new Cgr_persona(dbContext);
            _manejador_co_porcomi=new Cco_porcomi(dbContext);
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
        }
        public List<gr_persona> TablaPersona(string varbusqueda)
        {
            try
            {
                return _manejador_gr_persona.TablaPersona(varbusqueda);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void AgregarUsuario(string login,decimal id_rol,string id_pert)
        {
            try
            {
                _manejador_gr_pass.AgregaUsuario(login, id_rol, id_pert);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void ModificarUsuario1(string login, decimal id_rol, string id_pert)
        {
            try
            {
                _manejador_gr_pass.ModificarUsuario1(login, id_rol, id_pert);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void ObtenerDatos( string id_per, out gr_persona personaOut, out gr_pass passOut)
        {
            try
            {
               _manejador_gr_pass.ObtenerDatos(id_per, out personaOut, out passOut);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<gr_persona> Persona(int parametro)
        {
            try
            {
                return _manejador_gr_persona.Persona(parametro);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public List<co_porcomi> ObtPorcart(string id_per)
        {
            try
            {
                return _manejador_co_porcomi.ObtPorcart(id_per);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
    }
}
