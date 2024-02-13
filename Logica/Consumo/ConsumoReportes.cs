using Common;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
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
                DateTime dtFechaIni = DateTime.Parse(strFechaDe);
                DateTime dtFechaFin = DateTime.Parse(strFechaA);
                var sql1 = _manejador_reportes.GetReportMemo1(num_poliza, numLiquidacion, strTipoFecha, dtFechaIni, dtFechaFin).ToList();

                //if (num_poliza != null & (num_poliza.Replace("%", "") != ""))
                //{
                //    sql1 = sql1.Where(x => x.num_poliza.Contains(num_poliza.ToUpper())).ToList();
                //}

                //if (numLiquidacion != null & (numLiquidacion.Replace("%", "") != ""))
                //{
                //    sql1 = sql1.Where(x => x.no_liquida.Contains(numLiquidacion.ToUpper())).ToList();
                //}
                //var dtFechaDe = (DateTime)SqlDateTime.MinValue;
                //var dtFechaA = (DateTime)SqlDateTime.MaxValue;
                //dtFechaDe = Convert.ToDateTime(dtFechaDe);
                //dtFechaA = Convert.ToDateTime(dtFechaA);

                //switch (strTipoFecha)
                //{
                //    case "fc_recepcion":
                //        sql1 = sql1.Where(x => x.fc_recepcion >= dtFechaDe && x.fc_recepcion <= dtFechaA).ToList();
                //        break;
                //    case "fc_reg":
                //        sql1 = sql1.Where(x => x.fc_reg >= dtFechaDe && x.fc_reg <= dtFechaA).ToList();
                //        break;
                //    case "fc_emision":
                //        sql1 = sql1.Where(x => x.fc_emision >= dtFechaDe && x.fc_emision <= dtFechaA).ToList();
                //        break;
                //    case "fc_inivig":
                //        sql1 = sql1.Where(x => x.fc_inivig >= dtFechaDe && x.fc_inivig <= dtFechaA).ToList();
                //        break;
                //    case "fc_finvig":
                //        sql1 = sql1.Where(x => x.fc_finvig >= dtFechaDe && x.fc_finvig <= dtFechaA).ToList();
                //        break;
                //    default:
                //        // code block
                //        break;
                //}

                if (string.IsNullOrEmpty(strIdCartera) || (strIdCartera != "0"))
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
                var response = _manejador_reportes.GetReportClientes();

                if (!string.IsNullOrEmpty(strNombre))
                {
                    response = response.Where(x => x.nomraz.Contains(strNombre.ToUpper())).ToList();
                }
                if (intMesAniv != 0)
                {
                    response = response.Where(x => x.fechaaniv.Value.Month == intMesAniv).ToList();
                }
                if (intSuc != 0)
                {
                    response = response.Where(x => x.id_suc == intSuc).ToList();
                }

                return response;
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
                var response =  _manejador_reportes.GetReportGrupos();

                if (idGrupo != 0)
                {
                    response = response.Where(x => x.id_gru == idGrupo).ToList();
                }

                if (idSucursal != 0)
                {
                    response = response.Where(x => x.id_suc == idSucursal).ToList();
                }
                return response;
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

        //public List<GetReportProyCartera_Result> GetReportProyCartera()
        //{
        //    try
        //    {
        //        return _manejador_reportes.GetReportProyCartera();
        //    }
        //    catch (SecureExceptions secureException)
        //    {
        //        throw new SecureExceptions("Error al Generar la Transacción", secureException);
        //    }
        //    finally
        //    {
        //        //dbContext.Dispose();
        //    }
        //}

        public List<GetReportProyCarteraDirec_Result> GetReportProyCarteraDirec()
        {
            try
            {
                return _manejador_reportes.GetReportProyCarteraDirec();
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

        public List<GetReportResumProd2_Result> GetReportResumProd2(
                string idSucursal, string idDivisa, string idPersona, string numPoliza, string numLiquidacion,
                string del, string al, string idCartera, string idEjecutivo, string idSpvs,
                string idProducto, string ramoSpvs, string idGrupo, string idMovimiento, string cmbRangoFecha,
                string fechaInicioVig, string fechaFinVig, string cmbPrimaTotal, string primaTotal, string cmbPrimaNeta,
                string primaNeta)
        {
            try
            {
                var intIdSucursal = Convert.ToInt32(idSucursal);
                var intIdDivisa = Convert.ToInt64(idDivisa);

                var sql1 = _manejador_reportes.GetReportResumProd2(intIdSucursal, intIdDivisa);

                //if (!string.IsNullOrEmpty(idSucursal) && idSucursal != "0")
                //{
                //    sql1 = sql1.Where(x => x.id_suc == Convert.ToInt64(idSucursal)).ToList();
                //}

                //if (!string.IsNullOrEmpty(idDivisa) && idDivisa != "0")
                //{
                //    sql1 = sql1.Where(x => x.id_div == Convert.ToInt64(idDivisa)).ToList();
                //}

                if (!string.IsNullOrEmpty(idPersona) && idPersona != "0")
                {
                    sql1 = sql1.Where(x => x.id_perclie == idPersona).ToList();
                }

                if (!string.IsNullOrEmpty(numPoliza) && numPoliza != "0")
                {
                    sql1 = sql1.Where(x => x.num_poliza == numPoliza).ToList();
                }

                if (!string.IsNullOrEmpty(numLiquidacion) && numLiquidacion != "0")
                {
                    sql1 = sql1.Where(x => x.no_liquida == numLiquidacion).ToList();
                }

                if (!string.IsNullOrEmpty(del) && del != "0")
                {
                    if (!string.IsNullOrEmpty(al) && al != "0")
                    {
                        sql1 = sql1.Where(x => x.del >= Convert.ToDecimal(del) && x.al <= Convert.ToDecimal(al)).ToList();
                    }
                }

                if (!string.IsNullOrEmpty(idCartera) && idCartera != "0")
                {
                    sql1 = sql1.Where(x => x.id_percart == idCartera).ToList();
                }

                if (!string.IsNullOrEmpty(idEjecutivo) && idEjecutivo != "0")
                {
                    sql1 = sql1.Where(x => x.id_perejec == idEjecutivo).ToList();
                }

                if (!string.IsNullOrEmpty(idSpvs) && idSpvs != "0")
                {
                    sql1 = sql1.Where(x => x.id_spvs == idSpvs).ToList();
                }

                if (!string.IsNullOrEmpty(idProducto) && idProducto != "0")
                {
                    sql1 = sql1.Where(x => x.id_producto == Convert.ToInt64(idProducto)).ToList();
                }

                if (!string.IsNullOrEmpty(ramoSpvs) && ramoSpvs != "0")
                {
                    sql1 = sql1.Where(x => x.id_riesgo == ramoSpvs).ToList();
                }

                if (!string.IsNullOrEmpty(idGrupo) && idGrupo != "0")
                {
                    sql1 = sql1.Where(x => x.id_gru == Convert.ToInt64(idGrupo)).ToList();
                }

                if (!string.IsNullOrEmpty(idMovimiento) && idMovimiento != "0")
                {
                    sql1 = sql1.Where(x => x.id_clamov == Convert.ToInt64(idMovimiento)).ToList();
                }

                var dtFechaDe = (DateTime)SqlDateTime.MinValue;
                var dtFechaA = (DateTime)SqlDateTime.MaxValue;

                if (!string.IsNullOrEmpty(fechaInicioVig) && fechaInicioVig != "0")
                {
                    dtFechaDe = DateTime.Parse(fechaInicioVig);
                }

                if (!string.IsNullOrEmpty(fechaFinVig) && fechaFinVig != "0")
                {
                    dtFechaA = DateTime.Parse(fechaFinVig);
                }

                switch (cmbRangoFecha)
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

                if (!string.IsNullOrEmpty(cmbPrimaTotal) && cmbPrimaTotal != "0")
                {
                    int num = int.Parse(cmbPrimaTotal);                    
                    switch (num)
                    {
                        case 1:
                            {
                                if (!string.IsNullOrEmpty(primaTotal) && primaTotal != "0")
                                {
                                    sql1 = sql1.Where(x => x.prima_bruta == Convert.ToDecimal(primaTotal)).ToList();
                                }
                                //str10 = " = ";
                                break;
                            }
                        case 2:
                            {
                                if (!string.IsNullOrEmpty(primaTotal) && primaTotal != "0")
                                {
                                    sql1 = sql1.Where(x => x.prima_bruta > Convert.ToDecimal(primaTotal)).ToList();
                                }
                                //str10 = " > ";
                                break;
                            }
                        case 3:
                            {
                                if (!string.IsNullOrEmpty(primaTotal) && primaTotal != "0")
                                {
                                    sql1 = sql1.Where(x => x.prima_bruta < Convert.ToDecimal(primaTotal)).ToList();
                                }
                                //str10 = " < ";
                                break;
                            }
                        case 4:
                            {
                                if (!string.IsNullOrEmpty(primaTotal) && primaTotal != "0")
                                {
                                    sql1 = sql1.Where(x => x.prima_bruta >= Convert.ToDecimal(primaTotal)).ToList();
                                }
                                //str10 = " >= ";
                                break;
                            }
                        case 5:
                            {
                                if (!string.IsNullOrEmpty(primaTotal) && primaTotal != "0")
                                {
                                    sql1 = sql1.Where(x => x.prima_bruta <= Convert.ToDecimal(primaTotal)).ToList();
                                }
                                //str10 = " <= ";
                                break;
                            }
                    }
                }

                if (!string.IsNullOrEmpty(cmbPrimaNeta) && cmbPrimaNeta != "0")
                {
                    int num = int.Parse(cmbPrimaNeta);
                    switch (num)
                    {
                        case 1:
                            {
                                if (!string.IsNullOrEmpty(primaNeta) && primaNeta != "0")
                                {
                                    sql1 = sql1.Where(x => x.prima_neta == Convert.ToDecimal(primaNeta)).ToList();
                                }
                                //str10 = " = ";
                                break;
                            }
                        case 2:
                            {
                                if (!string.IsNullOrEmpty(primaNeta) && primaNeta != "0")
                                {
                                    sql1 = sql1.Where(x => x.prima_neta > Convert.ToDecimal(primaNeta)).ToList();
                                }
                                //str10 = " > ";
                                break;
                            }
                        case 3:
                            {
                                if (!string.IsNullOrEmpty(primaNeta) && primaNeta != "0")
                                {
                                    sql1 = sql1.Where(x => x.prima_neta < Convert.ToDecimal(primaNeta)).ToList();
                                }
                                //str10 = " < ";
                                break;
                            }
                        case 4:
                            {
                                if (!string.IsNullOrEmpty(primaNeta) && primaNeta != "0")
                                {
                                    sql1 = sql1.Where(x => x.prima_neta >= Convert.ToDecimal(primaNeta)).ToList();
                                }
                                //str10 = " >= ";
                                break;
                            }
                        case 5:
                            {
                                if (!string.IsNullOrEmpty(primaNeta) && primaNeta != "0")
                                {
                                    sql1 = sql1.Where(x => x.prima_neta <= Convert.ToDecimal(primaNeta)).ToList();
                                }
                                //str10 = " <= ";
                                break;
                            }
                    }
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

        #endregion

        #region wre reportes - reclamos
        public List<GetReportHistreclamosh_Result> GetReportHistreclamosh(decimal id_caso, decimal anio_caso)
        {
            try
            {
                //return _manejador_reportes.GetReportHistreclamosh();

                var sql1 = _manejador_reportes.GetReportHistreclamosh(id_caso, anio_caso).ToList();

                //if (id_caso != 0 )
                //{
                //    sql1 = sql1.Where(x => x.id_caso == id_caso).ToList();
                //}

                //if (anio_caso != 0)
                //{
                //    sql1 = sql1.Where(x => x.anio_caso == anio_caso).ToList();
                //}

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

        //public List<GetReportHistreclamoshf_Result> GetReportHistreclamoshf()
        //{
        //    try
        //    {
        //        return _manejador_reportes.GetReportHistreclamoshf();
        //    }
        //    catch (SecureExceptions secureException)
        //    {
        //        throw new SecureExceptions("Error al Generar la Transacción", secureException);
        //    }
        //    finally
        //    {
        //        //dbContext.Dispose();
        //    }
        //}

        public List<GetReportResumsiniestro_Result> GetReportResumsiniestro(string strIdOfiSucursal, string strIdPer, string strNumPoliza, string strIdCompSpvs, string strIdProducto, string strIdCartera, string strFechaDel, string strFechaAl, string strEstadoCaso)
        {
            try
            {
                var idSuc = string.IsNullOrEmpty(strIdOfiSucursal) ? 0 : Convert.ToInt32(strIdOfiSucursal);
                var sql1 = _manejador_reportes.GetReportResumsiniestro(idSuc).ToList();

                //if (!string.IsNullOrEmpty(strIdOfiSucursal))
                //{
                //    var idOfiSucursal = Convert.ToInt32(strIdOfiSucursal);
                //    sql1 = sql1.Where(x => x.id_suc == idOfiSucursal).ToList();
                //}
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

        //public List<GetReportResumsiniestro1_Result> GetReportResumsiniestro1()
        //{
        //    try
        //    {
        //        return _manejador_reportes.GetReportResumsiniestro1();
        //    }
        //    catch (SecureExceptions secureException)
        //    {
        //        throw new SecureExceptions("Error al Generar la Transacción", secureException);
        //    }
        //    finally
        //    {
        //        //dbContext.Dispose();
        //    }
        //}

        #endregion

        #region wco reportes - cobranzas
        public List<GetReportCobsxrango_Result> GetReportCobsxrango(string idSucursal, string strFechaIni, string strFechaFin)
        {
            try
            {
                var dtFechaInicio = (DateTime)SqlDateTime.MinValue;
                var dtFechaFin = (DateTime)SqlDateTime.MaxValue;
                if (!string.IsNullOrEmpty(strFechaIni))
                {
                    dtFechaInicio = Convert.ToDateTime(strFechaIni);
                }
                if (!string.IsNullOrEmpty(strFechaFin))
                {
                    dtFechaFin = Convert.ToDateTime(strFechaFin);
                }

                var lstReporte = _manejador_reportes.GetReportCobsxrango(dtFechaInicio, dtFechaFin);

                if (!string.IsNullOrEmpty(idSucursal) && idSucursal != "0")
                {
                    lstReporte.Where(w => w.id_suc == idSucursal);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                return lstReporte;
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

        public List<GetReportCuotaadias_Result> GetReportCuotaadias(string strIdCartera, string strIdSucursal, string strIdCompaniaSpvs, string strIdGrupo, string strVenc1, string strVenc2, string strDiasVcmto, string strFechaListado)
        {
            try
            {
                var lstReporte = _manejador_reportes.GetReportCuotaadias();

                if (strDiasVcmto != "1")
                {
                    lstReporte.Where(w => w.dias >= (Convert.ToInt32(strVenc2)*(-1)) && w.dias <= (Convert.ToInt32(strVenc1) * (-1)));
                    //string[] item = new string[] { "{vcb_cuotasdias.dias} >= -", base.Request.QueryString["e2"], " and {vcb_cuotasdias.dias} <=-", base.Request.QueryString["e1"], " " };                    
                }
                else
                {
                    lstReporte.Where(w => w.dias >= Convert.ToInt32(strVenc1) && w.dias <= Convert.ToInt32(strVenc2));
                    //string[] strArrays = new string[] { "{vcb_cuotasdias.dias} >= ", base.Request.QueryString["e1"], " and {vcb_cuotasdias.dias} <=", base.Request.QueryString["e2"], " " };                    
                }

                if (!string.IsNullOrEmpty(strFechaListado) && strFechaListado != "0")
                {
                    var dtFechaListado = Convert.ToDateTime(strFechaListado);
                    lstReporte.Where(w => w.fecha_pago <= dtFechaListado);                  
                }
                if (!string.IsNullOrEmpty(strIdCompaniaSpvs) && strIdCompaniaSpvs != "0")
                {
                    lstReporte.Where(w => w.id_spvs == strIdCompaniaSpvs);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_spvs}= '", base.Request.QueryString["ci"], "'");
                }
                if (!string.IsNullOrEmpty(strIdCartera) && strIdCartera != "0")
                {
                    lstReporte.Where(w => w.id_percart == strIdCartera);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_percart}= '", base.Request.QueryString["ca"], "'");
                }
                if (!string.IsNullOrEmpty(strIdSucursal) && strIdSucursal != "0")
                {
                    lstReporte.Where(w => w.id_suc == Convert.ToInt64(strIdSucursal));
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_suc} = ", base.Request.QueryString["is"]);
                }
                if (!string.IsNullOrEmpty(strIdGrupo) && strIdGrupo != "0")
                {
                    lstReporte.Where(w => w.id_gru == Convert.ToInt64(strIdGrupo));
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }
                
                return lstReporte;
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

        public List<GetReportLiquidacion_Result> GetReportLiquidacion(string idSucursal, long idLiquidacion)
        {
            try
            {
                var lstReporte = _manejador_reportes.GetReportLiquidacion();
                if (!string.IsNullOrEmpty(idSucursal) && idSucursal != "0")
                {
                    lstReporte.Where(w => w.id_suc == idSucursal);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                if (idLiquidacion != 0)
                {
                    lstReporte.Where(w => w.id_liq == idLiquidacion);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }
                return lstReporte;
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

        public List<GetReportPagoacia1_Result> GetReportPagoacia1(long idSucursal,string idCompania)
        {
            try
            {
                var lstReporte = _manejador_reportes.GetReportPagoacia1();

                if (idSucursal != 0)
                {
                    lstReporte.Where(w => w.id_suc == idSucursal);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                if (!string.IsNullOrEmpty(idCompania) && idCompania != "0")
                {
                    lstReporte.Where(w => w.id_spvs == idCompania);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }
                return lstReporte;
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

        public List<GetReportPagopendcias_Result> GetReportPagopendcias(long longIdSuc)
        {
            try
            {
                var lstReporte = _manejador_reportes.GetReportPagopendcias();

                if (longIdSuc != 0)
                {
                    lstReporte.Where(w => w.id_suc == longIdSuc);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                return lstReporte;
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

        public List<GetReportAscii_Result> GetReportAscii(int mes, int anio)
        {
            try
            {
                var lstReporte =  _manejador_reportes.GetReportAscii();
                if (mes != 0)
                {
                    lstReporte.Where(w => w.mes == mes);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                if (anio != 0)
                {
                    lstReporte.Where(w => w.anio == anio);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                return lstReporte;
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

        public List<GetReportLiqcomiejec3_Result> GetReportLiqcomiejec3(string strFechaIni, string strFechaFin, string idCartera, string idSucursal, string idEjecutivo)
        {
            try
            {
                var dtFechaInicio = (DateTime)SqlDateTime.MinValue;
                var dtFechaFin = (DateTime)SqlDateTime.MaxValue;
                if (!string.IsNullOrEmpty(strFechaIni))
                {
                    dtFechaInicio = Convert.ToDateTime(strFechaIni);
                }
                if (!string.IsNullOrEmpty(strFechaFin))
                {
                    dtFechaFin = Convert.ToDateTime(strFechaFin);
                }
                var lstReporte =  _manejador_reportes.GetReportLiqcomiejec3(dtFechaInicio, dtFechaFin, idCartera);

                
                //lstReporte.Where(w => w.fecha_factura >= dtFechaInicio && w.fecha_factura <= dtFechaFin);

                if (!string.IsNullOrEmpty(idSucursal) && idSucursal != "0")
                {
                    lstReporte.Where(w => w.id_suc == Convert.ToInt64(idSucursal));
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                //if (!string.IsNullOrEmpty(idCartera) && idCartera != "0")
                //{
                //    lstReporte.Where(w => w.id_percart == idCartera);
                //    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                //}

                if (!string.IsNullOrEmpty(idCartera) && idCartera != "0")
                {
                    lstReporte.Where(w => w.id_perejec == idEjecutivo);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                return lstReporte;
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

        
        public List<vcm_prodcap> GetReportVcm_prodcap(int mes, int anio)
        {
            try
            {
                var lstReporte = _manejador_reportes.vcm_prodcap();
                if (mes != 0)
                {
                    lstReporte.Where(w => w.mes == mes);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                if (anio != 0)
                {
                    lstReporte.Where(w => w.anio == anio);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                return lstReporte;
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

        public List<vcm_comiefect> GetReportVcm_comiefect(int mes, int anio)
        {
            try
            {
                var lstReporte = _manejador_reportes.vcm_comiefect();
                if (mes != 0)
                {
                    lstReporte.Where(w => w.mes == mes);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                if (anio != 0)
                {
                    lstReporte.Where(w => w.anio == anio);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                return lstReporte;
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

        public List<vcm_comicobrada> GetReportVcm_comicobrada(int mes, int anio)
        {
            try
            {
                var lstReporte = _manejador_reportes.vcm_comicobrada();
                if (mes != 0)
                {
                    lstReporte.Where(w => w.mes == mes);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                if (anio != 0)
                {
                    lstReporte.Where(w => w.anio == anio);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                return lstReporte;
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

        public List<vcm_comicap> GetReportVcm_comicap(int mes, int anio)
        {
            try
            {
                var lstReporte = _manejador_reportes.vcm_comicap();
                if (mes != 0)
                {
                    lstReporte.Where(w => w.mes == mes);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                if (anio != 0)
                {
                    lstReporte.Where(w => w.anio == anio);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                return lstReporte;
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

        public List<vcm_prodtot> GetReportVcm_prodtot(int mes, int anio)
        {
            try
            {
                var lstReporte = _manejador_reportes.vcm_prodtot();
                if (mes != 0)
                {
                    lstReporte.Where(w => w.mes == mes);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                if (anio != 0)
                {
                    lstReporte.Where(w => w.anio == anio);
                    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                }

                return lstReporte;
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

        public List<GetReportContable1_Result> GetReportContable1(int mes, int anio,string strIdCompania )
        {
            try
            {
                var lstReporte = _manejador_reportes.GetReportContable1(mes, anio, strIdCompania);
                //if (mes != 0)
                //{
                //    lstReporte.Where(w => w.mes == mes);
                //    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                //}

                //if (anio != 0)
                //{
                //    lstReporte.Where(w => w.anio == anio);
                //    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                //}

                //if (!string.IsNullOrEmpty(strIdCompania) && strIdCompania != "0")
                //{
                //    lstReporte.Where(w => w.id_spvs == strIdCompania);
                //    //str1 = string.Concat(str1, " and {vcb_cuotasdias.id_gru} = ", base.Request.QueryString["gr"]);
                //}

                return lstReporte;
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

        public List<GetReportConcipagcia_Result> GetReportConcipagcia(string strFechaIni, string strFechaFin, string strIdCompania, long strIdSucursal)
        {
            try
            {
                var dtFechaInicio = (DateTime)SqlDateTime.MinValue;
                var dtFechaFin = (DateTime)SqlDateTime.MaxValue;
                if (!string.IsNullOrEmpty(strFechaIni))
                {
                    dtFechaInicio = Convert.ToDateTime(strFechaIni);
                }
                if (!string.IsNullOrEmpty(strFechaFin))
                {
                    dtFechaFin = Convert.ToDateTime(strFechaFin);
                }

                var lstReporte = _manejador_reportes.GetReportConcipagcia(dtFechaInicio, dtFechaFin, strIdCompania, strIdSucursal);

                return lstReporte;
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


        public List<GetReportComisionesxfecha_Result> GetReportComisionesxfecha(DateTime dtFechaIni, DateTime dtFechaFin)
        {
            try
            {
               
                
                var lstReporte = _manejador_reportes.GetReportComisionesxfecha(dtFechaIni, dtFechaFin);
                
                return lstReporte;
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
