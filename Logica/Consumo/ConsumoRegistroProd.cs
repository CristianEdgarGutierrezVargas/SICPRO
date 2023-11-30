using Common;
using EntidadesClases.CustomModelEntities;
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
        private readonly Cgr_persona _manejador_gr_persona;
        private readonly Cgr_direccion _manejador_gr_direccion;
        private readonly Cpr_grupo _manejador_pr_grupo;
        private readonly Cpr_polmov _manejador_pr_polmov;

        public static sicproEntities dbContext;
        public ConsumoRegistroProd()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_gr_parametro = new Cgr_parametro(dbContext);
            _manejador_gr_persona = new Cgr_persona(dbContext);
            _manejador_gr_direccion = new Cgr_direccion(dbContext);
            _manejador_pr_grupo = new Cpr_grupo(dbContext);
            _manejador_pr_polmov = new Cpr_polmov(dbContext);            
        }

        #endregion

        #region gr_parametro
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
                //dbContext.Dispose();
            }
        }

        #endregion

        #region gr_persona
        public gr_persona InsertarPersona(gr_persona objPersona)
        {
            try
            {
                return _manejador_gr_persona.InsertarPersona(objPersona);
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

        public bool ModificarPersona(gr_persona objPersona)
        {
            try
            {
                return _manejador_gr_persona.ModificarPersona(objPersona);
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

        public gr_persona ObtenerPersona(string varbusqueda)
        {
            try
            {
                return _manejador_gr_persona.ObtenerPersona(varbusqueda);
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

        public List<gr_persona> ObtenerListaPersona()
        {
            try
            {
                return _manejador_gr_persona.ObtenerListaPersona();
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

        public List<gr_persona> ObtenerEjecutivoClientes()
        {
            try
            {
                return _manejador_gr_persona.ObtenerEjecutivoClientes();
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

        #region gr_direccion

        public List<OC_DIRECCION_PARAMETRO> ObtenerListaDireccion(string varBusqueda)
        {
            try
            {
                return _manejador_gr_direccion.ObtenerListaDireccion(varBusqueda);
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

        public gr_direccion ObtenerDireccion(long varBusqueda)
        {
            try
            {
                return _manejador_gr_direccion.ObtenerDireccion(varBusqueda);
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

        public gr_direccion InsertarDireccion(gr_direccion objDireccion)
        {
            try
            {
                return _manejador_gr_direccion.InsertarDireccion(objDireccion);
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

        public bool ModificarDireccion(gr_direccion objDireccion)
        {
            try
            {
                return _manejador_gr_direccion.ModificarDireccion(objDireccion);
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

        #region pr_grupo

        public List<pr_grupo> ObtenerGrupo()
        {
            try
            {
                return _manejador_pr_grupo.ObtenerGrupo();
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

        #region pr_polmov

        public List<gr_parametro> listas1()
        {
            try
            {
                return _manejador_pr_polmov.listas1();
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
