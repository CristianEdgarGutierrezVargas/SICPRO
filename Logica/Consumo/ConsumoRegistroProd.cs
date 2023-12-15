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
        private readonly Cgr_compania _manejador_gr_compania;
        private readonly Cpr_producto _manejador_pr_compania;
        private readonly Cpr_poliza _manejador_pr_poliza;
        private readonly Cpr_cuotapoliza _manejador_pr_cuota_poliza;
        private readonly Cpr_cobranzas _manejador_pr_cobranzas;
        private readonly Cpr_movimientos _manejador_pr_movimientos;

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
            _manejador_gr_compania = new Cgr_compania(dbContext);
            _manejador_pr_compania = new Cpr_producto(dbContext);
            _manejador_pr_poliza = new Cpr_poliza(dbContext);
            _manejador_pr_cuota_poliza = new Cpr_cuotapoliza(dbContext);
            _manejador_pr_cobranzas = new Cpr_cobranzas(dbContext);
            _manejador_pr_movimientos = new Cpr_movimientos(dbContext);
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

        public List<gr_parametro> ParametroA(string columna)
        {
            try
            {
                return _manejador_gr_parametro.ParametroA(columna);
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

        public gr_parametro ObtenerParametro(long id_parametro)
        {
            try
            {
                return _manejador_gr_parametro.ObtenerParametro(id_parametro);
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

        public List<gr_direccion> ObtenerDireccionesPersona(string id_per)
        {
            try
            {
                return _manejador_gr_direccion.ObtenerDireccionesPersona(id_per);
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

        public pr_grupo ObtenerGrupo(long? id_gru)
        {
            try
            {
                return _manejador_pr_grupo.ObtenerGrupo(id_gru);
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

        public pr_polmov InsertarPolizaMovimiento(pr_polmov objPolMov)
        {
            try
            {
                return _manejador_pr_polmov.InsertarPolizaMovimiento(objPolMov);
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

        #region gr_compania

        public List<v_pr_cias_resum> ObtenerListaCompania()
        {
            try
            {
                return _manejador_gr_compania.ObtenerListaCompania();
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

        #region pr_producto

        public List<pr_producto> ObtenerTablaProducto(string varBusqueda)
        {
            try
            {
                return _manejador_pr_compania.ObtenerTablaProducto(varBusqueda);
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

        public pr_producto ObtenerProducto(long varbusqueda)
        {
            try
            {
                return _manejador_pr_compania.ObtenerProducto(varbusqueda);
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

        #region pr_poliza

        public bool ExistePol(string numpoliza, string no_liquida)
        {
            try
            {
                return _manejador_pr_poliza.ExistePol(numpoliza, no_liquida);
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

        public pr_poliza InsertarPoliza(pr_poliza objPoliza)
        {
            try
            {
                return _manejador_pr_poliza.InsertarPoliza(objPoliza);
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

        public List<vpr_polrenovar> ObtenerTablaPolizaR(OC_ObtenerTablaPolizaIn objObtTablaPolIn)
        {
            try
            {
                return _manejador_pr_poliza.ObtenerTablaPolizaR(objObtTablaPolIn);
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

        #region pr_cuotas_poliza

        public pr_cuotapoliza InsertarCuotasPoliza(pr_cuotapoliza objCuotaPoliza)
        {
            try
            {
                return _manejador_pr_cuota_poliza.InsertarCuotaPoliza(objCuotaPoliza);
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

        public bool InsertarLstCuotasPoliza(List<pr_cuotapoliza> lstCuotaPoliza)
        {
            try
            {
                return _manejador_pr_cuota_poliza.InsertarLstCuotaPoliza(lstCuotaPoliza);
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

        public bool ActualizarCuotaPoliza(pr_cuotapoliza objPrCuotaPoliza)
        {
            try
            {
                return _manejador_pr_cuota_poliza.ActualizarCuotaPoliza(objPrCuotaPoliza);
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

        #region pr_cobranza

        public string Porco1(long idProducto, string idSpvs)
        {
            try
            {
                return _manejador_pr_cobranzas.Porco1(idProducto, idSpvs);
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

        public decimal Com3(decimal primaBruta, long id_producto, string id_spvs1, bool tipoCuota)
        {
            try
            {
                return _manejador_pr_cobranzas.Com3(primaBruta, id_producto, id_spvs1, tipoCuota);
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

        public decimal Calculo2(decimal primaBruta, long id_producto, string id_spvs1, bool tipoCuota)
        {
            try
            {
                return _manejador_pr_cobranzas.Calculo2(primaBruta, id_producto, id_spvs1, tipoCuota);
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

        public vcb_veripoliza1 ObtenerPolizaI(long id_poliza, long id_movimiento)
        {
            try
            {
                return _manejador_pr_cobranzas.ObtenerPolizaI(id_poliza, id_movimiento);
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

        #region movimiento

        public vpr_polrenovar ObtenerDatosRenPoliza(int id_poliza, int id_movimiento)
        {
            try
            {
                return _manejador_pr_movimientos.ObtenerDatosRenPoliza(id_poliza, id_movimiento);
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
