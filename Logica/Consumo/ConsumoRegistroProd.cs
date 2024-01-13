using Common;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntidadesClases.CustomModelEntities.OC_DATA_FORM;

namespace Logica.Consumo
{
    public class ConsumoRegistroProd
    {
        #region Contructor Principal

        private readonly Cgr_parametro _manejador_gr_parametro;
        private readonly Cgr_persona _manejador_gr_persona;
        private readonly Cgr_direccion _manejador_gr_direccion;
        private readonly Cgr_contactos _manejador_gr_contactos;
        private readonly Cpr_grupo _manejador_pr_grupo;
        private readonly Cpr_polmov _manejador_pr_polmov;
        private readonly Cgr_compania _manejador_gr_compania;
        private readonly Cpr_producto _manejador_pr_producto;
        private readonly Cpr_poliza _manejador_pr_poliza;
        private readonly Cpr_cuotapoliza _manejador_pr_cuota_poliza;
        private readonly Cpr_cobranzas _manejador_pr_cobranzas;
        private readonly Cpr_movimientos _manejador_pr_movimientos;

        public static sicproEntities dbContext;
        public ConsumoRegistroProd()
        {
            //if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_gr_parametro = new Cgr_parametro(dbContext);
            _manejador_gr_persona = new Cgr_persona(dbContext);
            _manejador_gr_direccion = new Cgr_direccion(dbContext);
            _manejador_gr_contactos = new Cgr_contactos(dbContext);
            _manejador_pr_grupo = new Cpr_grupo(dbContext);
            _manejador_pr_polmov = new Cpr_polmov(dbContext);
            _manejador_gr_compania = new Cgr_compania(dbContext);
            _manejador_pr_producto = new Cpr_producto(dbContext);
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

        #region gr_contactos
                
            public List<OC_DIRECCION_CONTACTO> ObtenerListaContactosByIdPer(string idPer)
        {
            try
            {
                return _manejador_gr_contactos.ObtenerListaContactosByIdPer(idPer);
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

        public List<pr_grupo> TablaGrupo()
        {
            try
            {
                return _manejador_pr_grupo.TablaGrupo();
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

        public pr_grupo InsertarGrupo(pr_grupo objGrupo)
        {
            try
            {
                return _manejador_pr_grupo.InsertarGrupo(objGrupo);
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

        public pr_grupo ModificarGrupo(pr_grupo objGrupo)
        {
            try
            {
                return _manejador_pr_grupo.ModificarGrupo(objGrupo);
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

        public bool EliminarGrupo(decimal decIdGrupo)
        {
            try
            {
                return _manejador_pr_grupo.EliminarGrupo(decIdGrupo);
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
                return _manejador_pr_producto.ObtenerTablaProducto(varBusqueda);
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
                return _manejador_pr_producto.ObtenerProducto(varbusqueda);
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

        public List<vpr_polaplivar> ObtenerTablaPolizaAp(OC_ObtenerTablaPolizaIn objObtTablaPolIn)
        {
            try
            {
                return _manejador_pr_poliza.ObtenerTablaPolizaAp(objObtTablaPolIn);
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

        public List<vpr_polincluvar> ObtenerTablaPolizaI(OC_ObtenerTablaPolizaIn objObtTablaPolIn)
        {
            try
            {
                return _manejador_pr_poliza.ObtenerTablaPolizaI(objObtTablaPolIn);
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

        public List<vpr_polexcluvar> ObtenerTablaPolizaEx(OC_ObtenerTablaPolizaIn objObtTablaPolIn)
        {
            try
            {
                return _manejador_pr_poliza.ObtenerTablaPolizaEx(objObtTablaPolIn);
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

        public List<vpr_polanuvar> ObtenerTablaPolizaAn(OC_ObtenerTablaPolizaIn objObtTablaPolIn)
        {
            try
            {
                return _manejador_pr_poliza.ObtenerTablaPolizaAn(objObtTablaPolIn);
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

        public GetDataVeriPoliza_Result GetDataVeriPoliza(long id_poliza, long id_movimiento)
        {
            try
            {
                return _manejador_pr_poliza.GetDataVeriPoliza(id_poliza, id_movimiento);
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

        public List<pr_cuotapoliza> GridCuotasC(long id_poliza, long id_movimiento)
        {
            try
            {
                return _manejador_pr_cuota_poliza.GridCuotasC(id_poliza, id_movimiento);
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

        public decimal Prima_Neta(string id_spvs, long id_poliza, long id_movimiento, decimal num_cuota, decimal prima_neta)
        {
            var num = num_cuota;
            num = num + Convert.ToDecimal(-1.0);

            var num2 = prima_neta; // double.Parse(prima_neta.Text);
            decimal num3 = 0;
            if (num == 0)
            {
                num3 = num2;
            }
            else
            {
                var data = _manejador_pr_cobranzas.Bisa(id_spvs, id_poliza, id_movimiento);
                var num4 = data== null? 0: data.cuota_total_t.Value; //double.Parse(dataTable.Rows[0][0].ToString());
                num3 = num2 - num4;
            }

            return num3;
        }

        //public string Prima_Neta1(int id_poliza, int id_movimiento)
        //{
        //    double num = double.Parse(num_cuota.Text);
        //    num += -1.0;
        //    double num2 = double.Parse(prima_neta.Text);
        //    double num3 = 0.0;
        //    if (num == 0.0)
        //    {
        //        num3 = num2;
        //    }
        //    else
        //    {
        //        DataTable dataTable = Bisa1(id_poliza, id_movimiento);
        //        double num4 = double.Parse(dataTable.Rows[0][0].ToString());
        //        num3 = num2 - num4;
        //    }

        //    return num3.ToString();
        //}

        public string ComisionTotal(string id_spvs, long id_producto, int id_poliza, int id_movimiento, decimal num_cuota, decimal prima_neta, decimal por_comision)
        {
            try
            {
                var data = _manejador_pr_cobranzas.ComisionTotal(id_spvs, id_producto);

                var primaNeta = Prima_Neta(id_spvs, id_poliza, id_movimiento, num_cuota, prima_neta);

                return (primaNeta + data.plus_neta * por_comision / 100).ToString();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            //string sentenciaSQL = "SELECT pr_formriesgo.plus_neta FROM pr_formriesgo " +
            //    "WHERE pr_formriesgo.id_spvs = '" + id_spvs.SelectedValue + "' " +
            //    "AND pr_formriesgo.id_producto = " + id_producto;
            
        }

        //public string ComisionTotal1(int id_poliza, int id_movimiento, int id_producto)
        //{
        //    string sentenciaSQL = "SELECT pr_formriesgo.plus_neta FROM pr_formriesgo WHERE pr_formriesgo.id_spvs = '" + id_spvs1.Value + "' AND pr_formriesgo.id_producto = " + id_producto;
        //    Acceso acceso = new Acceso();
        //    acceso.Conectar();
        //    acceso.CrearComando(sentenciaSQL);
        //    DataTable dataTable = acceso.Consulta();
        //    Bisa1(id_poliza, id_movimiento);
        //    string s = Prima_Neta1(id_poliza, id_movimiento);
        //    return ((double.Parse(s) + double.Parse(dataTable.Rows[0][0].ToString())) * double.Parse(por_comision.Text) / 100.0).ToString();
        //}

        public decimal Comision_Neta(string id_spvs, long id_poliza, long id_movimiento, decimal por_comision)
        {
            var data = _manejador_pr_cobranzas.Bisa(id_spvs, id_poliza, id_movimiento); ; //Bisa(id_poliza, id_movimiento);
            var num = data.cuota_total_t;// double.Parse(dataTable.Rows[0][1].ToString());
            return (num * por_comision / 100).Value;
        }

        //public string Comision_Neta1(int id_poliza, int id_movimiento)
        //{
        //    DataTable dataTable = Bisa1(id_poliza, id_movimiento);
        //    double num = double.Parse(dataTable.Rows[0][1].ToString());
        //    return (num * double.Parse(por_comision.Text) / 100.0).ToString();
        //}

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

        public vpr_polrenovar ObtenerRenPoliza(int id_poliza, int id_movimiento)
        {
            try
            {
                return _manejador_pr_movimientos.ObtenerRenPoliza(id_poliza, id_movimiento);
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

        public oc_data_vrenovar ObtenerDataCompletaRenPoliza(int id_poliza, int id_movimiento)
        {
            try
            {
                var objDataVrenovar = new oc_data_vrenovar();
                var v_renovar = _manejador_pr_movimientos.ObtenerRenPoliza(id_poliza, id_movimiento);
                if (v_renovar != null)
                {                
                    var objPersona = _manejador_gr_persona.ObtenerPersona(v_renovar.id_perclie);
                    var objGrupo = _manejador_pr_grupo.ObtenerGrupo(v_renovar.id_gru);
                    var objProducto = _manejador_pr_producto.ObtenerProducto(v_renovar.id_producto);
                    var objCompania = _manejador_gr_compania.GetCompaniaById(v_renovar.id_spvs);
                    var objDireccion = _manejador_gr_direccion.ObtenerDireccion(v_renovar.id_dir);
                    var objPersonaAgente = _manejador_gr_persona.ObtenerPersona(v_renovar.id_percart);
                    var objParametro = _manejador_gr_parametro.ObtenerParametro(v_renovar.id_div);

                    objDataVrenovar.objPersona = objPersona;
                    objDataVrenovar.objGrupo = objGrupo;
                    objDataVrenovar.objProducto = objProducto;
                    objDataVrenovar.objCompania = objCompania;
                    objDataVrenovar.objDireccion = objDireccion;
                    objDataVrenovar.objPersonaAgente = objPersonaAgente;
                    objDataVrenovar.objParametroDivisa = objParametro;
                }
                else
                {
                    return null;
                }
                objDataVrenovar.objRenovar = v_renovar;
                return objDataVrenovar;
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

        public bool InsertarPolizaMovR(pr_polmov objPolizaMovimiento, List<pr_cuotapoliza> lstCuotaPoliza)
        {
            try
            {
                var objResponse = _manejador_pr_polmov.InsertarPolizaMovimiento(objPolizaMovimiento);
                lstCuotaPoliza.ForEach(s =>
                {
                    s.id_movimiento = objResponse.id_movimiento;
                    s.id_poliza = objResponse.id_poliza;
                });
                var response = _manejador_pr_cuota_poliza.InsertarLstCuotaPoliza(lstCuotaPoliza);

                return response;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }
        #endregion
    }
}
