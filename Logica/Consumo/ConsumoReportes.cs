using Common;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Consumo
{
    public class ConsumoReportes
    {
        private readonly CReportes _manejador_reportes;
        private readonly Cpr_recibo cpr_Recibo;
        private readonly Cpr_liqrec _manejador_liqrec;

        public static sicproEntities dbContext;
        public ConsumoReportes()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();

            _manejador_reportes = new CReportes(dbContext);
            cpr_Recibo = new Cpr_recibo(dbContext);
            _manejador_liqrec = new Cpr_liqrec(dbContext);
        }

        #region wpr reportes - produccion
        public List<GetReportMemo_Result> GetReportMemo(long idPoliza, long idMovimiento)
        {
            try
            {
                return _manejador_reportes.GetReportMemo(idPoliza, idMovimiento);
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

        public List<GetReportMemo1_Result> GetReportMemo1(string num_poliza, string numLiquidacion, string strTipoFecha, string strFechaDe, string strFechaA, string strIdCartera)
        {
            try
            {
                var sql1 = _manejador_reportes.GetReportMemo1().ToList();

                if (num_poliza != null & (num_poliza.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.num_poliza.Contains(num_poliza.ToUpper())).ToList();
                }

                if (numLiquidacion != null & (numLiquidacion.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.no_liquida.Contains(numLiquidacion.ToUpper())).ToList();
                }
                var dtFechaDe = (DateTime)SqlDateTime.MinValue;
                var dtFechaA = (DateTime)SqlDateTime.MaxValue;
                dtFechaDe = Convert.ToDateTime(dtFechaDe);
                dtFechaA = Convert.ToDateTime(dtFechaA);

                switch (strTipoFecha)
                {
                    case "fc_recepcion":
                        sql1 = sql1.Where(x => x.fc_recepcion >= dtFechaDe && x.fc_recepcion <= dtFechaA).ToList();
                        break;
                    case "fc_reg":
                        sql1 = sql1.Where(x => x.fc_reg >= dtFechaDe && x.fc_reg <= dtFechaA).ToList();
                        break;
                    case "fc_emision":
                        sql1 = sql1.Where(x => x.fc_emision >= dtFechaDe && x.fc_emision <= dtFechaA).ToList();
                        break;
                    case "fc_inivig":
                        sql1 = sql1.Where(x => x.fc_inivig >= dtFechaDe && x.fc_inivig <= dtFechaA).ToList();
                        break;
                    case "fc_finvig":
                        sql1 = sql1.Where(x => x.fc_finvig >= dtFechaDe && x.fc_finvig <= dtFechaA).ToList();
                        break;
                    default:
                        // code block
                        break;
                }

                if (strIdCartera != null & (strIdCartera != ""))
                {
                    sql1 = sql1.Where(x => x.id_percart.Contains(strIdCartera.ToUpper())).ToList();
                    //sql = string.Concat(sql, "AND id_perclie LIKE '%", id_per.ToUpper(), "%'");
                }                

                return sql1;

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

        public List<GetReportClientes_Result> GetReportClientes(string strNombre, int intMesAniv, int intSuc)
        {
            try
            {
                return _manejador_reportes.GetReportClientes(strNombre, intMesAniv, intSuc);
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


        public List<GetReportDirecciones_Result> GetReportDirecciones()
        {
            try
            {
                return _manejador_reportes.GetReportDirecciones();
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

        public List<GetReportGrupos_Result> GetReportGrupos(long idGrupo, long idSucursal)
        {
            try
            {
                return _manejador_reportes.GetReportGrupos(idGrupo, idSucursal);
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

        public List<GetReportProyCartera_Result> GetReportProyCartera()
        {
            try
            {
                return _manejador_reportes.GetReportProyCartera();
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

        #region wre reportes - reclamos
        public List<GetReportHistreclamosh_Result> GetReportHistreclamosh(decimal id_caso, decimal anio_caso)
        {
            try
            {
                //return _manejador_reportes.GetReportHistreclamosh();

                var sql1 = _manejador_reportes.GetReportHistreclamosh().ToList();

                if (id_caso != 0 )
                {
                    sql1 = sql1.Where(x => x.id_caso == id_caso).ToList();
                }

                if (anio_caso != 0)
                {
                    sql1 = sql1.Where(x => x.anio_caso == anio_caso).ToList();
                }

                return sql1.ToList();
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

        public List<GetReportHistreclamoshf_Result> GetReportHistreclamoshf()
        {
            try
            {
                return _manejador_reportes.GetReportHistreclamoshf();
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

        public List<GetReportResumsiniestro_Result> GetReportResumsiniestro(string strIdOfiSucursal, string strIdPer, string strNumPoliza, string strIdCompSpvs, string strIdProducto, string strIdCartera, string strFechaDel, string strFechaAl, string strEstadoCaso)
        {
            try
            {
                var sql1 = _manejador_reportes.GetReportResumsiniestro().ToList();

                if (!string.IsNullOrEmpty(strIdOfiSucursal))
                {
                    var idOfiSucursal = Convert.ToInt32(strIdOfiSucursal);
                    sql1 = sql1.Where(x => x.id_suc == idOfiSucursal).ToList();
                }
                if (!string.IsNullOrEmpty(strIdPer))
                {
                    var idPer = Convert.ToString(strIdPer);
                    sql1 = sql1.Where(x => x.id_perclie == idPer).ToList();
                }
                if (!string.IsNullOrEmpty(strNumPoliza))
                {
                    var numPoliza = Convert.ToString(strNumPoliza);
                    sql1 = sql1.Where(x => x.num_poliza == numPoliza).ToList();
                }
                if (string.IsNullOrEmpty(strIdCompSpvs))
                {
                    var idCompSpvs = Convert.ToString(strIdCompSpvs);
                    sql1 = sql1.Where(x => x.id_spvs == idCompSpvs).ToList();
                }
                if (!string.IsNullOrEmpty(strIdProducto))
                {
                    var idProducto = Convert.ToInt64(strIdProducto);
                    sql1 = sql1.Where(x => x.id_producto == idProducto).ToList();
                }
                if (!string.IsNullOrEmpty(strIdCartera))
                {
                    var idCartera = Convert.ToString(strIdCartera);
                    sql1 = sql1.Where(x => x.id_percart == idCartera).ToList();
                }

                if (!string.IsNullOrEmpty(strFechaDel) && !string.IsNullOrEmpty(strFechaDel))
                {
                    var fechaDel = Convert.ToDateTime(strFechaDel);
                    var fechaAl = Convert.ToDateTime(strFechaAl);
                    sql1 = sql1.Where(x => x.fc_incidente >= fechaDel && x.fc_incidente <= fechaAl).ToList();
                }

                if (!string.IsNullOrEmpty(strEstadoCaso))
                {
                    var idEstadoCaso = Convert.ToDouble(strEstadoCaso);
                    sql1 = sql1.Where(x => x.id_estca == idEstadoCaso).ToList();
                }


                return sql1;
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

        public List<GetReportResumsiniestro1_Result> GetReportResumsiniestro1()
        {
            try
            {
                return _manejador_reportes.GetReportResumsiniestro1();
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

        #region wco reportes - cobranzas
        public List<GetReportCobsxrango_Result> GetReportCobsxrango(DateTime dtFechaIni, DateTime dtFechaFin)
        {
            try
            {
                return _manejador_reportes.GetReportCobsxrango(dtFechaIni, dtFechaFin);
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

        public List<GetReportCuotaadias_Result> GetReportCuotaadias()
        {
            try
            {
                return _manejador_reportes.GetReportCuotaadias();
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

        public List<GetReportEstctaaseg1_Result> GetReportEstctaaseg1(string strIdPer, string strIdCompSpvs, string strIdCartera, string strNumPoliza, string strNoLiq)
        {
            try
            {
                return _manejador_reportes.GetReportEstctaaseg1(strIdPer, strIdCompSpvs, strIdCartera, strNumPoliza, strNoLiq);
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

        public List<GetReportEstctaaseg2_Result> GetReportEstctaaseg2(string strIdPer, string strIdCompSpvs, string strIdCartera, string strNumPoliza, string strNoLiq)
        {
            try
            {
                return _manejador_reportes.GetReportEstctaaseg2(strIdPer, strIdCompSpvs, strIdCartera, strNumPoliza, strNoLiq);
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

        public List<GetReportLiquidacion_Result> GetReportLiquidacion()
        {
            try
            {
                return _manejador_reportes.GetReportLiquidacion();
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

        public List<GetReportPagoacia1_Result> GetReportPagoacia1()
        {
            try
            {
                return _manejador_reportes.GetReportPagoacia1();
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

        public List<GetReportPagopendcias_Result> GetReportPagopendcias()
        {
            try
            {
                return _manejador_reportes.GetReportPagopendcias();
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

        public List<GetReportRecibosnoaplicados_Result> GetReportRecibosnoaplicados(string strIdSuc)
        {
            try
            {
                return _manejador_reportes.GetReportRecibosnoaplicados(strIdSuc);
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

        #region wcm reportes - comisiones

        public List<GetReportAscii_Result> GetReportAscii()
        {
            try
            {
                return _manejador_reportes.GetReportAscii();
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

        public List<GetReportLiqcomiejec3_Result> GetReportLiqcomiejec3()
        {
            try
            {
                return _manejador_reportes.GetReportLiqcomiejec3();
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

        public List<vcm_prodtot> vcm_prodtot()
        {
            try
            {
                return _manejador_reportes.vcm_prodtot();
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

        public List<vcm_prodcap> vcm_prodcap()
        {
            try
            {
                return _manejador_reportes.vcm_prodcap();
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

        public List<vcm_comiefect> vcm_comiefect()
        {
            try
            {
                return _manejador_reportes.vcm_comiefect();
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

        public List<vcm_comicobrada> vcm_comicobrada()
        {
            try
            {
                return _manejador_reportes.vcm_comicobrada();
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

        public List<vcm_comicap> vcm_comicap()
        {
            try
            {
                return _manejador_reportes.vcm_comicap();
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

        #region recibos
        public List<gr_persona> ObtenerCobrador(long id_suc)
        {

            try
            {
                var dt = cpr_Recibo.ObtenerCobrador(id_suc);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }
        }

        #endregion

        #region liqrec

        public List<pr_liqrec> ListTop(string id_perucb)
        {

            try
            {
                var dt = _manejador_liqrec.ListTop(id_perucb);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }
        }

        #endregion
    }
}
