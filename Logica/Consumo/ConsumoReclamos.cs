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
using static ManejadorMetodos.CDBSicPro.Cpr_poliza;

namespace Logica.Consumo
{
    public class ConsumoReclamos
    {
        //private readonly Cgr_persona _manejador_gr_persona;
        private readonly Cgr_pass _manejador_gr_pass;
        private readonly Cgr_persona _manejador_gr_persona;
        private readonly Cgr_parametro _manejador_gr_parametro;
        private readonly Cco_porcomi _manejador_co_porcomi;
        private readonly Cpr_riesgo _manejador_pr_riesgo;
        private readonly Cgr_cierreregistro _manejador_gr_cierreregistro;
        private readonly Cgr_tc _manejador_gr_tc;
        private readonly Cpr_producto _manejador_pr_producto;
        private readonly Cgr_compania _manejador_gr_compania;
        private readonly Cre_caso _manejador_re_caso;
        private readonly Cpr_poliza _manejador_pr_poliza;
        private readonly Cre_histcaso _manejador_re_histcaso;
        private readonly Cpr_amortizaciones _manejador_pr_amortizaciones;
        private readonly Cpr_recibo _manejador_pr_recibo;
        public static sicproEntities dbContext;

        public ConsumoReclamos()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_gr_pass = new Cgr_pass(dbContext);
            _manejador_gr_parametro = new Cgr_parametro(dbContext);
            _manejador_gr_persona = new Cgr_persona(dbContext);
            _manejador_co_porcomi = new Cco_porcomi(dbContext);
            _manejador_pr_riesgo = new Cpr_riesgo(dbContext);
            _manejador_gr_cierreregistro = new Cgr_cierreregistro(dbContext);
            _manejador_gr_tc = new Cgr_tc(dbContext);
            _manejador_pr_producto = new Cpr_producto(dbContext);
            _manejador_gr_compania = new Cgr_compania(dbContext);
            _manejador_re_caso = new Cre_caso(dbContext);
            _manejador_pr_poliza = new Cpr_poliza(dbContext);
            _manejador_re_histcaso = new Cre_histcaso(dbContext);
            _manejador_pr_amortizaciones = new Cpr_amortizaciones(dbContext);
            _manejador_pr_recibo = new Cpr_recibo(dbContext);   
        }
        public List<gr_persona> Persona(int idSuc)
        {
            try
            {
                return _manejador_gr_persona.Persona(idSuc);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<gr_parametro> Parametro(string parametro)
        {
            try
            {
                return _manejador_gr_parametro.Parametro(parametro);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<gr_parametro> ParametroA(string parametro)
        {
            try
            {
                return _manejador_gr_parametro.ParametroA(parametro);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<gr_parametro> ParametroV(string columna, int valor_param)
        {
            try
            {
                return _manejador_gr_parametro.ParametroV(columna, valor_param);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<gr_parametro> anio_list()
        {
            try
            {
                return _manejador_gr_parametro.anio_list();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public decimal nextval(decimal anio)
        {
            try
            {
                return _manejador_re_caso.nextval(anio);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public void add_recaso(re_caso item)
        {
            try
            {
                _manejador_re_caso.add_recaso(item);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public void add_siniestro(re_siniestro item)
        {
            try
            {
                _manejador_re_caso.add_siniestro(item);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public void add_histcaso1(re_histcaso item)
        {
            try
            {
                _manejador_re_caso.add_histcaso1(item);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public List<pr_poliza> ObtenerPolizaP(string id_per)
        {
            try
            {
                return _manejador_pr_poliza.ObtenerPolizaP(id_per);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public List<OC_PolizaPP> ObtenerPolizaPP(long id_poliza)
        {
            try
            {
                return _manejador_pr_poliza.ObtenerPolizaPP(id_poliza);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public OcSerHistoCaso ser_histcaso(decimal id_caso, decimal anio_caso)
        {
            try
            {
                return _manejador_re_histcaso.ser_histcaso(id_caso, anio_caso);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public List<pr_recibo> ObtenerRD_Recibo(string id_per, string id_gru, int id_apli)
        {
            try
            {
                return _manejador_pr_amortizaciones.ObtenerRD_Recibo(id_per, id_gru, id_apli);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public void ins_histcaso(decimal id_caso, decimal anio_caso, int id_sucur, double id_estcaso, string obs_histcaso)
        {
            try
            {
                _manejador_re_histcaso.ins_histcaso(id_caso, anio_caso, id_sucur, id_estcaso, obs_histcaso);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public void upd_histcaso1(decimal id_caso, decimal anio_caso)
        {
            try
            {
                _manejador_re_histcaso.upd_histcaso1(id_caso, anio_caso);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public void upd_recaso(decimal id_caso, decimal anio_caso, string id_recibo, decimal pago_caso, decimal franq_caso, decimal indem_caso, decimal anio_recibo)
        {
            try
            {
                _manejador_re_caso.upd_recaso(id_caso, anio_caso, id_recibo, pago_caso, franq_caso, indem_caso, anio_recibo);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public void ActuaReciboR(long id_recibo, decimal anio_recibo)
        {
            try
            {
                _manejador_pr_recibo.ActuaReciboR(id_recibo, anio_recibo);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
    }
}

