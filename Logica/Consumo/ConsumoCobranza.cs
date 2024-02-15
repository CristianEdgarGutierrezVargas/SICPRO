using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using Common;
namespace Logica.Consumo
{
    public class ConsumoCobranza
    {
        #region Contructor Principal

        private readonly Cpr_poliza _manejador_pr_poliza;
        private readonly Cgr_persona _manejador_gr_persona;
        private readonly Cpr_cobranzas _manejador_pr_cobranzas;
        private readonly Cvcb_veripoliza1 _manejador_vcb_veripoliza1;
        private readonly Cpr_producto _manejador_pr_producto;
        private readonly Cpr_formriesgo _manejador_pr_formriesgo;
        private readonly Cgr_compania _manejador_gr_compania;
        private readonly Cpr_grupo _manejador_pr_grupo;
        private readonly Cgr_parametro _manejador_gr_parametro;
        private readonly Cpr_polmov _manejador_pr_polmov;
        private readonly Cpr_pago _manejador_pr_pago;
        private readonly Cvcb_totalpago _manejador_pr_totalpago;
        private readonly Cpr_devolucion _mnejdor_pr_devolucion;
        public static sicproEntities dbContext;
        private readonly Cvcb_respolpago1 _manejador_respolpago1;
        private readonly Cvcb_resumcuotas _manejador_resumcuotas;
        private readonly Cvcb_listacuoamort _manejador_listacuoamort;
        private readonly Cpr_cuotapoliza _manejador_cuotapoliza;
        private readonly Cpr_recibo _manejador_recibo;

        public ConsumoCobranza()
        {
            //if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_pr_poliza = new Cpr_poliza(dbContext);
            _manejador_pr_cobranzas = new Cpr_cobranzas(dbContext);
            _manejador_vcb_veripoliza1 = new Cvcb_veripoliza1(dbContext);
            _manejador_pr_producto = new Cpr_producto(dbContext);
            _manejador_pr_formriesgo = new Cpr_formriesgo(dbContext);
            _manejador_gr_persona = new Cgr_persona(dbContext);
            _manejador_gr_compania = new Cgr_compania(dbContext);
            _manejador_pr_grupo = new Cpr_grupo(dbContext);
            _manejador_gr_parametro = new Cgr_parametro(dbContext);
            _manejador_pr_polmov = new Cpr_polmov(dbContext);
            _manejador_pr_pago = new Cpr_pago(dbContext);
            _manejador_pr_totalpago = new Cvcb_totalpago(dbContext);
            _mnejdor_pr_devolucion = new Cpr_devolucion(dbContext);
            _manejador_respolpago1 = new Cvcb_respolpago1(dbContext);
            _manejador_resumcuotas = new Cvcb_resumcuotas(dbContext);
            _manejador_listacuoamort = new Cvcb_listacuoamort(dbContext);
            _manejador_cuotapoliza = new Cpr_cuotapoliza(dbContext);
            _manejador_recibo = new Cpr_recibo(dbContext);
        }
        #endregion

        public List<OcRecuFac> RecuFacMod(double factura, string sId_spvs)
        {


            try
            {
                var sql = _manejador_pr_pago.GetObjPagoByFactura(factura);
                var pol = _manejador_pr_poliza.GetListPoliza();
                var data = sql.Join(pol, x => x.id_poliza, s => s.id_poliza, (x, s) => new { x.id_poliza, x.id_movimiento, x.cuota, s.id_spvs, x.factura, x.fecha_factura, x.id_pago, s.num_poliza }).Where(x => x.id_spvs == sId_spvs).OrderBy(x => x.id_pago).ToList();
                var result = new List<OcRecuFac>();
                foreach (var odata in data)
                {
                    var obj = new OcRecuFac();
                    obj.factura = odata.factura;
                    obj.fecha_factura = odata.fecha_factura;
                    obj.id_pago = odata.id_pago;
                    obj.id_poliza = odata.id_poliza;
                    obj.id_spvs = odata.id_spvs;
                    obj.cuota = odata.cuota;
                    obj.id_movimiento = odata.id_movimiento;
                    obj.num_poliza = odata.num_poliza;
                    result.Add(obj);
                }
                return result;
                //string[] str = new string[] { "SELECT pr_pago.id_poliza, pr_pago.id_movimiento, pr_pago.cuota, pr_poliza.id_spvs, pr_pago.factura, pr_pago.fecha_factura, pr_pago.id_pago, pr_poliza.num_poliza FROM pr_pago INNER JOIN pr_poliza ON (pr_pago.id_poliza = pr_poliza.id_poliza) WHERE pr_poliza.id_spvs = '", this.id_spvs.SelectedValue.ToString(), "' and pr_pago.factura = ", this.nro_factura.Text, " order by pr_pago.id_pago asc" };


            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }

        }
        public bool ModFac1(double? factura, DateTime fechaFactura, long id_pago)
        {

            try
            {
                return _manejador_pr_pago.ActualizarPago(factura, fechaFactura, id_pago);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }

        }
        public bool ModFacM(double? nro_factura, double? nnro_factura, DateTime fechaFactura, string id_spvs)
        {

            try
            {
                return _manejador_pr_pago.ActualizarPagoM(nro_factura, nnro_factura, id_spvs, fechaFactura);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }


        }
        public List<GetFacturaNombreByIdSpvs_Result> ObtenerListaF(string id_spvs)
        {

            try
            {
                return _manejador_pr_poliza.GetFacturaNombreByIdSpvs(id_spvs);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }


        }
        public List<pr_poliza> ObtenerPoliza1(string id_per)
        {

            try
            {
                var cpoliza = _manejador_pr_poliza.ObtenerPoliza1(id_per);
                var pol = cpoliza.Join(_manejador_pr_totalpago.GetListTotalPagoByIdPoliza(), x => x.id_poliza, s => s.id_poliza, ((x, s) => new pr_poliza()
                {

                    id_poliza = x.id_poliza,
                    num_poliza = x.num_poliza,
                    id_producto = x.id_producto,
                    id_perclie = x.id_perclie,
                    id_spvs = x.id_spvs,
                    id_gru = x.id_gru,
                    clase_poliza = x.clase_poliza,
                    estado = x.estado,
                    fc_reg = x.fc_reg,
                    id_percart = x.id_percart,
                    id_suc = x.id_suc

                })).ToList();
                return pol;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }


        }
        public List<pr_polmov> ObtenerMovimiento1(long idPol)
        {

            try
            {
                var cpoliza = _manejador_pr_poliza.ObtenerPolizaByIdEstado(idPol, true);
                var pol = cpoliza.Join(_manejador_pr_polmov.GetPolizaMovimientoByEstado("COMISIONES"), x => x.id_poliza, s => s.id_poliza, ((x, s) => new pr_polmov()
                {
                    id_poliza = s.id_poliza,
                    id_movimiento = s.id_movimiento,
                    id_perejec = s.id_perejec,
                    fc_emision = s.fc_emision,
                    fc_inivig = s.fc_inivig,
                    fc_finvig = s.fc_finvig,
                    prima_bruta = s.prima_bruta,
                    prima_neta = s.prima_neta,
                    por_comision = s.por_comision,
                    comision = s.comision,
                    id_div = s.id_div,
                    tipo_cuota = s.tipo_cuota,
                    num_cuota = s.num_cuota,
                    id_clamov = s.id_clamov,
                    estado = s.estado,
                    id_dir = s.id_dir,
                    fc_recepcion = s.fc_recepcion,
                    mat_aseg = s.mat_aseg,
                    fc_reg = s.fc_reg,
                    no_liquida = s.no_liquida,
                    id_mom = s.id_mom
                })).ToList();
                return pol;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }


        }
        public List<pr_devolucion> GetCuotasDev(long idPol, long idMov)
        {

            try
            {
                return _mnejdor_pr_devolucion.GetCuotasDev(idPol, idMov);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }


        }
        public List<pr_devolucion> DatosDev(long idPol, long idMov, long idDev)
        {

            try
            {
                return _mnejdor_pr_devolucion.DatosDev(idPol, idMov, idDev);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }


        }
        public bool ActualizarDev(pr_devolucion objDev, decimal mcheque)
        {

            try
            {
                return _mnejdor_pr_devolucion.ActualizarDev(objDev, mcheque);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }

        }
        public List<vcb_respolpago1> ObtenerPoliza(string idPercli)
        {

            try
            {
                var cpoliza = _manejador_respolpago1.ObtenerPoliza(idPercli);
                return cpoliza;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }


        }
        public List<vcb_respolpago1> ObtenerMovimiento(long idPoliza)
        {

            try
            {
                var cpoliza = _manejador_respolpago1.ObtenerMovimiento(idPoliza);
                return cpoliza;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }


        }
        public List<OcGrupoM> ObtenerGrupoM(long idPol)
        {

            try
            {
                var cpoliza = _manejador_pr_poliza.GetListPoliza().Where(c => c.id_poliza == idPol);
                var grupo = _manejador_pr_grupo.ObtenerGrupo();
                var pol = cpoliza.Join(grupo, w => w.id_gru, s => (long)s.id_gru, (w, s) => new OcGrupoM { id_gru = (long)s.id_gru, id_poliza = w.id_poliza, desc_grupo = s.desc_grupo, num_poliza = w.num_poliza }).ToList();
                return pol;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }


        }
        public vcb_resumcuotas Cuotas(long idPol, long idMov)
        {

            try
            {
                var cpoliza = _manejador_resumcuotas.Cuotas(idPol, idMov);
                return cpoliza;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }


        }
        public List<vcb_listacuoamort> GridCuotas(long idPol, long idMov)
        {

            try
            {
                var cpoliza = _manejador_listacuoamort.Listacuoamort(idPol, idMov);
                return cpoliza;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }


        }
        public List<vcb_resumcuotas> DatosCuota(long idPol, long idMov, long cuota)
        {

            try
            {
                var cpoliza = _manejador_resumcuotas.DatosCuota(idPol, idMov, cuota);
                return cpoliza;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }


        }
        public pr_pago InsertarPago(pr_pago objPago)
        {
            try
            {
                return _manejador_pr_pago.InsertPago(objPago);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }

        }
        public bool ActualizarCuotaPago(pr_cuotapoliza objCuotaPoliza)

        {
            try
            {
                return _manejador_cuotapoliza.ActualizarCuotaPago(objCuotaPoliza);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }

        }
        public bool ActualizarSaldoDev(pr_devolucion objDev, decimal montoPago)

        {
            try
            {
                return _mnejdor_pr_devolucion.ActualizarSaldoDev(objDev, montoPago);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }

        }

        public bool ActualizarReciboCob(pr_recibo objRec, decimal montoPago)

        {
            try
            {
                return _manejador_recibo.ActualizarReciboCob(objRec, montoPago);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }

        }
        public List<pr_recibo> ObtenerRD69(string idPer, string idGru, long idApli)
        {

            try
            {
                var cpoliza = _manejador_recibo.ObtenerRecibo(idPer, idGru, idApli);
                return cpoliza;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }
        }
        public List<OcGrdDev> ObtenerRD70(string idPer, string idGru, long idApli)
        {

            try
            {
                var poliza = _manejador_pr_poliza.GetListPoliza();
                var devolucion = _mnejdor_pr_devolucion.ObtenerDev();
                //SELECT pr_devolucion.id_devolucion, abs(pr_devolucion.saldo_devolucion), to_char(CURRENT_DATE, 'yyyy') AS anio_recibo, pr_poliza.id_perclie
                var lstDevolucion= devolucion.Join(poliza, x => x.id_poliza, s => s.id_poliza,(x,s)=>new OcGrdDev
                {
                     id_devolucion=x.id_devolucion,
                     id_perclie=s.id_perclie,
                     anio_recibo=DateTime.Now.Year,
                     saldo_devolucion=(decimal)x.saldo_devolucion

                
                } ).Where(x=>x.id_perclie== idPer &&  x.saldo_devolucion>0).ToList();
                return lstDevolucion;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }
        }
    }
}
