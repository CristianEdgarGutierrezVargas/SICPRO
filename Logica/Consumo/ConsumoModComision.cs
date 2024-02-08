using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using System.Data;
using Common;
using System.Security.Cryptography;

namespace Logica.Consumo
{
    public class ConsumoModComision
    {
        #region Contructor Principal

        private readonly Cpr_pagocompania cpr_Pagocompania;
        private readonly Cpr_recibo cpr_Recibo;
        private readonly Cgr_persona cgr_Persona;
        private readonly Cco_anticom cco_anticom;
        private readonly Cco_presprod cco_presprod;
        private readonly Cvco_veripoliza1 _manejador_vco_veripoliza1;
        private readonly Cvco_veripoliza2 _manejador_vco_veripoliza2;
        private readonly Cvco_veripoliza3 _manejador_vco_veripoliza3;
        private readonly Cvcb_cuotaexcludev _manejador_vcb_cuotaex;
        private readonly Cgr_parametro _manejador_gr_parametro;
        public static sicproEntities dbContext;
        private readonly Cpr_polmov cpr_polmov;
        private readonly Cpr_cuotapoliza cpr_cuotapoliza;
        private readonly Cpr_anulada cpr_anulada;

        public ConsumoModComision()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            cpr_Pagocompania = new Cpr_pagocompania(dbContext);
            cpr_Recibo = new Cpr_recibo(dbContext);
            cgr_Persona = new Cgr_persona(dbContext);
            cco_anticom=new Cco_anticom(dbContext);
            cco_presprod=new Cco_presprod(dbContext);
            _manejador_vco_veripoliza1 = new Cvco_veripoliza1(dbContext);
            _manejador_gr_parametro=new Cgr_parametro(dbContext);
            _manejador_vco_veripoliza2 = new Cvco_veripoliza2(dbContext);
            _manejador_vco_veripoliza3 = new Cvco_veripoliza3(dbContext);
            cpr_polmov=new Cpr_polmov(dbContext);
            cpr_cuotapoliza=new Cpr_cuotapoliza(dbContext);
            cpr_anulada= new Cpr_anulada(dbContext);
            _manejador_vcb_cuotaex = new Cvcb_cuotaexcludev(dbContext);
        }

        #endregion
        public List<vco_veripoliza1> VcoObtenerTablaPolizaNRI(string id_clamov, string num_poliza, string id_per, string id_spvs, string id_producto, bool vigencia, DateTime fc_inivig, DateTime fc_finvig, DateTime fc_polizavencida, bool porvencer)
        {

            try
            {
                var sql1 = _manejador_vco_veripoliza1.GetListVeripolizaByEstado(true).Where(x => x.id_clamov == Convert.ToInt64(id_clamov)).Select(x => x);
                //  string sql1 = string.Concat("SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vcb_veripoliza1 WHERE estado='true'", sql);

                //string sql = "";
                if (num_poliza != null & (num_poliza.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.num_poliza.Contains(num_poliza.ToUpper())).Select(x => x);
                    // sql = string.Concat(sql, "AND num_poliza LIKE '%", num_poliza.ToUpper(), "%'");
                }
                if (id_per != null & (id_per != ""))
                {
                    sql1 = sql1.Where(x => x.id_perclie.Contains(id_per.ToUpper())).Select(x => x);
                    //sql = string.Concat(sql, "AND id_perclie LIKE '%", id_per.ToUpper(), "%'");
                }
                if (id_spvs != null & (id_spvs != ""))
                {
                    sql1 = sql1.Where(x => x.id_spvs.Contains(id_spvs)).Select(x => x);
                    //sql = string.Concat(sql, "AND id_spvs LIKE '%", id_spvs, "%'");
                }
                if (id_producto != "0")
                {
                    sql1 = sql1.Where(x => x.id_producto == Convert.ToInt64(id_producto)).Select(x => x);
                    //sql = string.Concat(sql, "AND id_producto=", id_producto);
                }
                if (vigencia && fc_inivig != null && fc_finvig != null)
                {
                    sql1 = sql1.Where(x => x.fc_inivig >= fc_inivig && x.fc_inivig <= fc_finvig).Select(x => x);
                    //string[] strArrays = new string[] { sql, "AND fc_inivig BETWEEN '", Funciones.fc(fc_inivig), "' AND '", Funciones.fc(fc_polizavencida), "'" };
                    //sql = string.Concat(strArrays);
                }
                if (porvencer & fc_polizavencida != null)
                {
                    sql1.Where(x => x.fc_finvig <= fc_polizavencida).Select(x => x);
                    //sql = string.Concat(sql, "AND fc_finvig <= '", Funciones.fc(fc_polizavencida), "'");
                }

                return sql1.ToList();

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public vco_veripoliza1 VcoObtenerPolizaNRI(long id_poliza, long id_movimiento)
        {
            try
            {
                var objPolizaMov = _manejador_vco_veripoliza1.VcoObtenerPolizaI(id_poliza, id_movimiento);

                return objPolizaMov;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public pr_pagocompania InsertarPagoComp(pr_pagocompania objPagoComision)
        {

            try
            {
                var dt = cpr_Pagocompania.InsertarPagoComp(objPagoComision);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }


        }

        public List<pr_recibo> ObtenerAnio()
        {

            try
            {
                var dt = cpr_Recibo.ObtenerAnio();
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }


        }
        public List<gr_persona> ObtenerCobrador(string dato)
        {

            try
            {
                var dt = cgr_Persona.ObtenerCobrador(dato);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }


        }
        public List<pr_recibo> ObtenerRecibo(string dato)
        {

            try
            {
                var dt = cpr_Recibo.ObtenerRecibo(dato);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }
        }
        public bool EntregarRecibo(pr_recibo dato, int anio_recibo, int i, int j)
        {

            try
            {
                var dt = cpr_Recibo.EntregarRecibo(dato, anio_recibo, i, j);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }
        }
        public List<pr_recibo> GenerarRecibo(int anio)
        {

            try
            {
                var dt = cpr_Recibo.GenerarRecibo(anio);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

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

        public bool InsertarRecibo( int del, int al, string anio)
        {
            try
            {
              
                for (int j = (int)del; j <= (int)al; j += 1)
                {
                    cpr_Recibo.InsertRecibo(j, anio);
                }
                return true;
               
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Transacción", secureException);
            }
        }

        public List<gr_persona> Persona(int parametro)
        {
            try
            {
                var persona= cgr_Persona.Persona(parametro);
                var found = persona.Find(x => x.id_per == "0");
                persona.Remove(found);
                
                return persona;
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
        public bool InsAnticomi(co_anticom objCo_anticom)
        {

            try
            {
                var dt = cco_anticom.InsAnticomi(objCo_anticom);
                return true;
            }
            catch (SecureExceptions secureException)
            {
                return false;
                //throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }


        }
        public bool modifPres(co_presprod objPresProd)
        {
            try
            {
                 return cco_presprod.modifPres(objPresProd);

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Transacción", secureException);
            }
        }

        public bool InsertarPres(co_presprod objPresProd)
        {
            try
            {
                return cco_presprod.InsertarPres(objPresProd);

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Transacción", secureException);
            }
        }
        public List<co_presprod> GridCuotas(string strIdPerCat, string strAnioProy)
        {
            try
            {
                var persona = cco_presprod.GetListPresProd(strIdPerCat, strAnioProy);
               

                return persona;
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

        public List<vco_veripoliza2> VcoObtenerTablaPolizaNRI2(string id_clamov, string num_poliza, string id_per, string id_spvs, string id_producto, bool vigencia, DateTime fc_inivig, DateTime fc_finvig, DateTime fc_polizavencida, bool porvencer)
        {

            try
            {
                var sql1 = _manejador_vco_veripoliza2.GetListVeripolizaByEstado(true).Where(x => x.id_clamov == Convert.ToInt64(id_clamov)).Select(x => x);
                //  string sql1 = string.Concat("SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vcb_veripoliza1 WHERE estado='true'", sql);

                //string sql = "";
                if (num_poliza != null & (num_poliza.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.num_poliza.Contains(num_poliza.ToUpper())).Select(x => x);
                    // sql = string.Concat(sql, "AND num_poliza LIKE '%", num_poliza.ToUpper(), "%'");
                }
                if (id_per != null & (id_per != ""))
                {
                    sql1 = sql1.Where(x => x.id_perclie.Contains(id_per.ToUpper())).Select(x => x);
                    //sql = string.Concat(sql, "AND id_perclie LIKE '%", id_per.ToUpper(), "%'");
                }
                if (id_spvs != null & (id_spvs != ""))
                {
                    sql1 = sql1.Where(x => x.id_spvs.Contains(id_spvs)).Select(x => x);
                    //sql = string.Concat(sql, "AND id_spvs LIKE '%", id_spvs, "%'");
                }
                if (id_producto != "0")
                {
                    sql1 = sql1.Where(x => x.id_producto == Convert.ToInt64(id_producto)).Select(x => x);
                    //sql = string.Concat(sql, "AND id_producto=", id_producto);
                }
                if (vigencia && fc_inivig != null && fc_finvig != null)
                {
                    sql1 = sql1.Where(x => x.fc_inivig >= fc_inivig && x.fc_inivig <= fc_finvig).Select(x => x);
                    //string[] strArrays = new string[] { sql, "AND fc_inivig BETWEEN '", Funciones.fc(fc_inivig), "' AND '", Funciones.fc(fc_polizavencida), "'" };
                    //sql = string.Concat(strArrays);
                }
                if (porvencer & fc_polizavencida != null)
                {
                    sql1.Where(x => x.fc_finvig <= fc_polizavencida).Select(x => x);
                    //sql = string.Concat(sql, "AND fc_finvig <= '", Funciones.fc(fc_polizavencida), "'");
                }

                return sql1.ToList();

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public vco_veripoliza2 VcoObtenerPolizaNRI2(long id_poliza, long id_movimiento)
        {
            try
            {
                var objPolizaMov = _manejador_vco_veripoliza2.VcoObtenerPolizaI(id_poliza, id_movimiento);

                return objPolizaMov;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public List<vco_veripoliza3> VcoObtenerTablaPolizaNRI3(string id_clamov, string num_poliza, string id_per, string id_spvs, string id_producto, bool vigencia, DateTime fc_inivig, DateTime fc_finvig, DateTime fc_polizavencida, bool porvencer, bool estado)
        {

            try
            {
                var sql1 = _manejador_vco_veripoliza3.GetListVeripolizaByEstado(estado).Where(x => x.id_clamov == Convert.ToInt64(id_clamov)).Select(x => x);
                //  string sql1 = string.Concat("SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vcb_veripoliza1 WHERE estado='true'", sql);

                //string sql = "";
                if (num_poliza != null & (num_poliza.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.num_poliza.Contains(num_poliza.ToUpper())).Select(x => x);
                    // sql = string.Concat(sql, "AND num_poliza LIKE '%", num_poliza.ToUpper(), "%'");
                }
                if (id_per != null & (id_per != ""))
                {
                    sql1 = sql1.Where(x => x.id_perclie.Contains(id_per.ToUpper())).Select(x => x);
                    //sql = string.Concat(sql, "AND id_perclie LIKE '%", id_per.ToUpper(), "%'");
                }
                if (id_spvs != null & (id_spvs != ""))
                {
                    sql1 = sql1.Where(x => x.id_spvs.Contains(id_spvs)).Select(x => x);
                    //sql = string.Concat(sql, "AND id_spvs LIKE '%", id_spvs, "%'");
                }
                if (id_producto != "0")
                {
                    sql1 = sql1.Where(x => x.id_producto == Convert.ToInt64(id_producto)).Select(x => x);
                    //sql = string.Concat(sql, "AND id_producto=", id_producto);
                }
                if (vigencia && fc_inivig != null && fc_finvig != null)
                {
                    sql1 = sql1.Where(x => x.fc_inivig >= fc_inivig && x.fc_inivig <= fc_finvig).Select(x => x);
                    //string[] strArrays = new string[] { sql, "AND fc_inivig BETWEEN '", Funciones.fc(fc_inivig), "' AND '", Funciones.fc(fc_polizavencida), "'" };
                    //sql = string.Concat(strArrays);
                }
                if (porvencer & fc_polizavencida != null)
                {
                    sql1.Where(x => x.fc_finvig <= fc_polizavencida).Select(x => x);
                    //sql = string.Concat(sql, "AND fc_finvig <= '", Funciones.fc(fc_polizavencida), "'");
                }

                return sql1.ToList();

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public vco_veripoliza3 VcoObtenerPolizaNRI3(long id_poliza, long id_movimiento)
        {
            try
            {
                var objPolizaMov = _manejador_vco_veripoliza3.VcoObtenerPolizaI(id_poliza, id_movimiento);

                return objPolizaMov;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public bool ActualizaPolizaMov(pr_polmov objPolmMov)
        {
            try
            {
                return cpr_polmov.ActualizaPolizaMov(objPolmMov);

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Transacción", secureException);
            }
        }
        public bool ModificarCuotaPolizaC(pr_cuotapoliza objCuotaPoliza)
        {
            try
            {
                return cpr_cuotapoliza.ModificarCuotaPolizaC(objCuotaPoliza);

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Transacción", secureException);
            }
        }
        public List<pr_anulada> ObtenerGridA(long idPoliza, long idMov)
        {

            try
            {
                var dt = cpr_anulada.ObtenerGridA( idPoliza,  idMov);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }


        }
        public bool ModificarCuotaPolizaCA(pr_anulada objPrAnulada)
        {
            try
            {
                return cpr_anulada.ModificarCuotaPolizaCA(objPrAnulada);

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Transacción", secureException);
            }
        }
        public List<pr_polmov> DatosPolizaEA(long idPoliza, long id_mom)
        {

            try
            {
                var dt = cpr_polmov.DatosPolizaEA(idPoliza, id_mom);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }


        }
      
        public List<vcb_cuotaexcludev> GrillaCuotasC(long idPoliza, long idMom, long idMovi, long idliquida)
        {

            try
            {
                var sql1 = _manejador_vcb_cuotaex.GetListCuotaexcludev(idPoliza, idMom, idMovi, idliquida);
              

                return sql1.ToList();

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }
        public List<pr_recibo> ObtenerReciboA(string dato, string idPerucb)
        {

            try
            {
                var dt = cpr_Recibo.ObtenerReciboA(dato, idPerucb);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }
        }
        public List<pr_recibo> ObtenerReciboM(string dato, string idPerucb)
        {

            try
            {
                var dt = cpr_Recibo.ObtenerReciboM(dato, idPerucb);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }
        }
        public List<pr_recibo> ObtenerReciboMF(pr_recibo objRecibo)
        {

            try
            {
                var dt = cpr_Recibo.ObtenerReciboMF(objRecibo);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }
        }
        public bool ActualizarRecibo(pr_recibo objRecibo)
        {
            try
            {
                return cpr_Recibo.ActualizarRecibo(objRecibo);

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Transacción", secureException);
            }
        }
        public bool ActualizarReciboM(pr_recibo objRecibo)
        {
            try
            {
                return cpr_Recibo.ActualizarReciboM(objRecibo);

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Transacción", secureException);
            }
        }
    }
}
