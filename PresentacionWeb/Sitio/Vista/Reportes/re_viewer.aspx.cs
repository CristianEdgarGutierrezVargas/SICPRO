using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using DevExpress.Web.Internal.XmlProcessor;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using PresentacionWeb.Sitio.Vista.Reportes.datasets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.Reportes
{
    public partial class re_viewer : System.Web.UI.Page
    {
        ConsumoReportes _objConsumoReportes = new ConsumoReportes();
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (int.Parse(base.Request.QueryString["r"].ToString()))
            {
                case 1:
                    {
                        Memo();
                        return;
                    }
                case 2:
                    {
                        Reporteprod1();
                        return;
                    }
                case 3:
                    {
                        RecDetallado();
                        return;
                    }
                case 4:
                    {
                        RecResum();
                        return;
                    }
                case 5:
                    {
                        this.LiqRep();
                        return;
                    }
                case 6:
                    {
                        Reppc();
                        return;
                    }
                case 7:
                    {
                        Repc();
                        return;
                    }
                case 8:
                    {
                        Rascii();
                        return;
                    }
                case 9:
                    {
                        Memo2(1);
                        return;
                    }
                case 10:
                    {
                        Memo2(2);
                        return;
                    }
                case 11:
                    {
                        this.Estcta1();
                        return;
                    }
                case 12:
                    {
                        this.Listadias();
                        return;
                    }
                case 13:
                    {
                        Clientes();
                        return;
                    }
                case 14:
                    {
                        this.CarteraComi();
                        return;
                    }
                case 15:
                    {
                        Grupos();
                        return;
                    }
                case 16:
                    {
                        ProyCartera();
                        return;
                    }
                case 17:
                    {
                        this.ProdCaptada(17);
                        return;
                    }
                case 18:
                    {
                        this.ProdCaptada(18);
                        return;
                    }
                case 19:
                    {
                        this.ProdCaptada(19);
                        return;
                    }
                case 20:
                    {
                        this.ProdCaptada(20);
                        return;
                    }
                //case 21:
                //    {
                //        this.Contable1();
                //        return;
                //    }
                case 22:
                    {
                        this.Cobfecha();
                        return;
                    }
                //case 23:
                //    {
                //        this.NotaCob();
                //        return;
                //    }
                case 24:
                    {
                        this.ProdCaptada(24);
                        return;
                    }
                case 25:
                    {
                        this.RecXCob();
                        return;
                    }
                //case 26:
                //    {
                //        this.ComiXFecha();
                //        return;
                //    }
                default:
                    {
                        return;
                    }
            }
        }

        private void Memo()
        {
            var idPoliza = Convert.ToInt64(Request.QueryString["np"]);
            var idMovimiento = Convert.ToInt64(Request.QueryString["nl"]);
            ReportDocument rptDoc = new ReportDocument();            
            
            List<GetReportMemo_Result> response = _objConsumoReportes.GetReportMemo(idPoliza, idMovimiento);
            List<pr_cuotapoliza> lstCuota = _objConsumoRegistroProd.GridCuotasC(idPoliza, idMovimiento);

            re_memo ds = new re_memo();
            DataTable dt = new DataTable();
            dt.TableName = "Crystal Report Example";
            dt = ToDataTable<GetReportMemo_Result>(response);
            //sqlCon = new SqlConnection(@"server='servername'; Initial Catalog='databasename';user id='userid';password='password'");
            //SqlDataAdapter da = new SqlDataAdapter(@"select Stud_Name, Class, Subject, Marks from stud_details", sqlCon);
            //da.Fill(dt);
            //ds.Tables[0].Merge(dt);
            ds.Tables[0].Merge(dt, true, MissingSchemaAction.Ignore);

            re_memocuotas ds1 = new re_memocuotas();
            DataTable dt1 = new DataTable();
            dt1.TableName = "Crystal Report Example";
            dt1 = ToDataTable<pr_cuotapoliza>(lstCuota);
            ds1.Tables[0].Merge(dt1, true, MissingSchemaAction.Ignore);

            

            //rptDoc.Load(Server.MapPath("SimpleCrystal.rpt"));
            string reportPath = base.Server.MapPath("reportes//re_memo.rpt");
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();
        }

        private void Reporteprod1()
        {
            ReportDocument rptDoc = new ReportDocument();
             
            List<GetReportMemo_Result> response = _objConsumoReportes.GetReportMemo(36165, 63452);
            List<pr_cuotapoliza> lstCuota = _objConsumoRegistroProd.GridCuotasC(36165, 63452);

            re_memo ds = new re_memo();
            DataTable dt = new DataTable();
            dt.TableName = "Crystal Report Example";
            dt = ToDataTable<GetReportMemo_Result>(response);
            //sqlCon = new SqlConnection(@"server='servername'; Initial Catalog='databasename';user id='userid';password='password'");
            //SqlDataAdapter da = new SqlDataAdapter(@"select Stud_Name, Class, Subject, Marks from stud_details", sqlCon);
            //da.Fill(dt);
            //ds.Tables[0].Merge(dt);
            ds.Tables[0].Merge(dt, true, MissingSchemaAction.Ignore);

            re_memocuotas ds1 = new re_memocuotas();
            DataTable dt1 = new DataTable();
            dt1.TableName = "Crystal Report Example";
            dt1 = ToDataTable<pr_cuotapoliza>(lstCuota);
            ds1.Tables[0].Merge(dt1, true, MissingSchemaAction.Ignore);



            //rptDoc.Load(Server.MapPath("SimpleCrystal.rpt"));
            string reportPath = base.Server.MapPath("reportes//re_resumprod2.rpt");
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();
        }

        protected void RecDetallado()
        {
            //string str = base.Server.MapPath("reportes//re_histreclamosh.rpt");
            //this.CrystalReportViewer1.ReportSource = str;
            //string str1 = string.Concat("{Comando.id_caso}=", base.Request.QueryString["ic"], " and");
            //str1 = string.Concat(str1, "{Comando.anio_caso}= ", base.Request.QueryString["ac"]);
            //this.CrystalReportViewer1.SelectionFormula = str1;
            //this.CrystalReportViewer1.RefreshReport();

            var id_caso = string.IsNullOrEmpty(Request.QueryString["ic"])? 0 : Convert.ToDecimal(Request.QueryString["ic"]);
            var anio_caso = string.IsNullOrEmpty(Request.QueryString["ac"])? 0 : Convert.ToDecimal(Request.QueryString["ac"]);           

            ReportDocument rptDoc = new ReportDocument();
            
            var responseReporte = _objConsumoReportes.GetReportHistreclamosh(id_caso, anio_caso);
            var responseSubReporte = _objConsumoReportes.GetReportHistreclamoshf();

            //Reporte Principal
            DS_SicPro ds = new DS_SicPro();
            DataTable dt = new DataTable();
            dt.TableName = "GetReportHistreclamosh";
            dt = ToDataTable(responseReporte);
            ds.Tables["GetReportHistreclamosh"].Merge(dt, true, MissingSchemaAction.Ignore);

            //Subreporte
            DS_SicPro ds1 = new DS_SicPro();
            DataTable dt1 = new DataTable();
            dt1.TableName = "GetReportHistreclamoshf";
            dt1 = ToDataTable(responseSubReporte);
            ds1.Tables["GetReportHistreclamoshf"].Merge(dt1, true, MissingSchemaAction.Ignore);

            //rptDoc.Load(Server.MapPath("SimpleCrystal.rpt"));
            string reportPath = base.Server.MapPath("reportes//re_histreclamosh.rpt");
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();
        }

        protected void RecResum()
        {
            var idOfiSucursal = Request.QueryString["s"];
            var idPer = Request.QueryString["ipc"];
            var numPoliza = Request.QueryString["np"];
            var idCompSpvs = Request.QueryString["sp"];
            var idProducto = Request.QueryString["ip"];
            var idCartera = Request.QueryString["ca"];
            var fechaDel = Request.QueryString["iv1"];
            var fechaAl = Request.QueryString["iv2"];
            var estadoCaso = Request.QueryString["ec"];
            
            ReportDocument rptDoc = new ReportDocument();
            
            var responseReporte = _objConsumoReportes.GetReportResumsiniestro(
                idOfiSucursal, idPer, numPoliza, idCompSpvs, idProducto, idCartera, fechaDel, fechaAl, estadoCaso
                );
            var responseSubReporte = _objConsumoReportes.GetReportResumsiniestro1();

            //Reporte Principal
            DS_SicPro ds = new DS_SicPro();
            DataTable dt = new DataTable();
            dt.TableName = "GetReportResumsiniestro";
            dt = ToDataTable(responseReporte);
            ds.Tables["GetReportResumsiniestro"].Merge(dt, true, MissingSchemaAction.Ignore);

            //Subreporte
            DS_SicPro ds1 = new DS_SicPro();
            DataTable dt1 = new DataTable();
            dt1.TableName = "GetReportResumsiniestro1";
            dt1 = ToDataTable(responseSubReporte);
            ds1.Tables["GetReportResumsiniestro1"].Merge(dt1, true, MissingSchemaAction.Ignore);

            //rptDoc.Load(Server.MapPath("SimpleCrystal.rpt"));
            string reportPath = base.Server.MapPath("reportes//re_resumsiniestro.rpt");
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            //rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();

        }

        //5
        protected void LiqRep()
        {
            //Acceso acceso = new Acceso();
            //acceso.Conectar();
            //string[] str = new string[] { "SELECT  pr_recibo.id_recibo,  pr_recibo.id_suc,  (SELECT gr_parametro.desc_param FROM gr_parametro WHERE gr_parametro.id_par = CAST(pr_recibo.id_suc as numeric)) AS \"Sucursal\",  pr_recibo.id_perucb,  (SELECT gr_persona.nomraz FROM gr_persona WHERE gr_persona.id_per = pr_recibo.id_perucb) AS cobrador,  pr_recibo.id_perclie,  (SELECT vpr_pergrup.nomraz FROM vpr_pergrup WHERE vpr_pergrup.id_per = pr_recibo.id_perclie) AS cliente,  pr_recibo.recibo_por,  (SELECT gr_parametro.desc_param FROM gr_parametro WHERE gr_parametro.id_par = pr_recibo.id_apli) AS aplicado,  (case when pr_recibo.id_div = 39 then pr_recibo.monto_cobro else 0 end) AS monto_cobros,  (case when pr_recibo.id_div = 37 then pr_recibo.monto_cobro else 0 end) AS monto_cobrob,  pr_recibo.id_liq,  pr_recibo.fecha_cobro,  pr_recibo.cont_bs,  pr_recibo.cont_sus,  pr_recibo.cheq_bs,  pr_recibo.cheq_sus FROM  pr_recibo WHERE  pr_recibo.id_perclie IS NOT NULL AND pr_recibo.id_suc = '", base.Request.QueryString["is"].ToString(), "' and  pr_recibo.id_liq = ", base.Request.QueryString["il"].ToString(), " ORDER BY  pr_recibo.anio_recibo,  pr_recibo.id_recibo" };
            //acceso.CrearComando(string.Concat(str));
            //DataTable dataTable = acceso.Consulta();
            //string str1 = base.Server.MapPath("reportes//re_liquidacion.rpt");
            //ReportDocument reportDocument = new ReportDocument();
            //reportDocument.Load(str1);
            //reportDocument.SetDataSource(dataTable);
            //this.CrystalReportViewer1.ReportSource = reportDocument;
            //this.CrystalReportViewer1.RefreshReport();

            var idSucursal = string.IsNullOrEmpty(Request.QueryString["is"]) ? "" : Convert.ToString(Request.QueryString["is"]);
            var idLiquidacion = string.IsNullOrEmpty(Request.QueryString["il"]) ? 0 : Convert.ToInt64(Request.QueryString["il"]);

            ReportDocument rptDoc = new ReportDocument();
            
            var responseReporte = _objConsumoReportes.GetReportLiquidacion(idSucursal, idLiquidacion);
            //var responseSubReporte = _objConsumoReportes.GetReportHistreclamoshf();

            //Reporte Principal
            DS_SicPro ds = new DS_SicPro();
            DataTable dt = new DataTable();
            dt.TableName = "GetReportLiquidacion";
            dt = ToDataTable(responseReporte);
            ds.Tables["GetReportLiquidacion"].Merge(dt, true, MissingSchemaAction.Ignore);

            ////Subreporte
            //DS_SicPro ds1 = new DS_SicPro();
            //DataTable dt1 = new DataTable();
            //dt1.TableName = "GetReportHistreclamoshf";
            //dt1 = ToDataTable(responseSubReporte);
            //ds1.Tables["GetReportHistreclamoshf"].Merge(dt1, true, MissingSchemaAction.Ignore);

            //rptDoc.Load(Server.MapPath("SimpleCrystal.rpt"));
            string reportPath = base.Server.MapPath("reportes//re_liquidacion.rpt");
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            //rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();
        }

        //6
        protected void Reppc()
        {
            //string str = base.Server.MapPath("reportes//re_pagopendcias.rpt");
            //this.CrystalReportViewer1.ReportSource = str;
            //string str1 = string.Concat("{Comando.id_suc}= ", base.Request.QueryString["is"]);
            //this.CrystalReportViewer1.SelectionFormula = str1;
            //this.CrystalReportViewer1.RefreshReport();

            var idSuc = string.IsNullOrEmpty(Request.QueryString["is"]) ? 0 : Convert.ToInt64(Request.QueryString["ic"]);
            
            ReportDocument rptDoc = new ReportDocument();
            
            var responseReporte = _objConsumoReportes.GetReportPagopendcias(idSuc);
            //var responseSubReporte = _objConsumoReportes.GetReportHistreclamoshf();

            //Reporte Principal
            DS_SicPro ds = new DS_SicPro();
            DataTable dt = new DataTable();
            dt.TableName = "GetReportPagopendcias";
            dt = ToDataTable(responseReporte);
            ds.Tables["GetReportPagopendcias"].Merge(dt, true, MissingSchemaAction.Ignore);

            ////Subreporte
            //DS_SicPro ds1 = new DS_SicPro();
            //DataTable dt1 = new DataTable();
            //dt1.TableName = "GetReportHistreclamoshf";
            //dt1 = ToDataTable(responseSubReporte);
            //ds1.Tables["GetReportHistreclamoshf"].Merge(dt1, true, MissingSchemaAction.Ignore);

            //rptDoc.Load(Server.MapPath("SimpleCrystal.rpt"));
            string reportPath = base.Server.MapPath("reportes//re_pagopendcias.rpt");
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            //rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();
        }

        //7
        protected void Repc()
        {
            //string str = base.Server.MapPath("reportes//re_pagoacia1.rpt");
            //this.CrystalReportViewer1.ReportSource = str;
            //string str1 = string.Concat("{Comando.id_suc}= ", base.Request.QueryString["s"]);
            //str1 = string.Concat(str1, " and {Comando.id_spvs} = '", base.Request.QueryString["sp"], "'");
            //this.CrystalReportViewer1.SelectionFormula = str1;
            //this.CrystalReportViewer1.RefreshReport();

            var idSucursal = string.IsNullOrEmpty(Request.QueryString["is"]) ? 0 : Convert.ToInt64(Request.QueryString["is"]);
            var idCompania = string.IsNullOrEmpty(Request.QueryString["sp"]) ? "" : Convert.ToString(Request.QueryString["sp"]);

            ReportDocument rptDoc = new ReportDocument();
            
            var responseReporte = _objConsumoReportes.GetReportPagoacia1(idSucursal, idCompania);
            //var responseSubReporte = _objConsumoReportes.GetReportHistreclamoshf();

            //Reporte Principal
            DS_SicPro ds = new DS_SicPro();
            DataTable dt = new DataTable();
            dt.TableName = "GetReportPagoacia1";
            dt = ToDataTable(responseReporte);
            ds.Tables["GetReportPagoacia1"].Merge(dt, true, MissingSchemaAction.Ignore);

            ////Subreporte
            //DS_SicPro ds1 = new DS_SicPro();
            //DataTable dt1 = new DataTable();
            //dt1.TableName = "GetReportHistreclamoshf";
            //dt1 = ToDataTable(responseSubReporte);
            //ds1.Tables["GetReportHistreclamoshf"].Merge(dt1, true, MissingSchemaAction.Ignore);

            //rptDoc.Load(Server.MapPath("SimpleCrystal.rpt"));
            string reportPath = base.Server.MapPath("reportes//re_pagoacia1.rpt");
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            //rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();
        }

        //8
        private void Rascii()
        { }

        //9
        private void Memo2(int tipo)
        {
            var numPoliza = Convert.ToString(Request.QueryString["np"]);
            var numLiquidacion = Convert.ToString(Request.QueryString["nl"]);
            var fechaDe = Convert.ToString(Request.QueryString["fc"]);
            var fechaA = Convert.ToString(Request.QueryString["fc2"]);
            var fechaMemo = Convert.ToString(Request.QueryString["fb"]);
            var cartera = Request.QueryString["ca"];

            ReportDocument rptDoc = new ReportDocument();
            
            var responseReporte = _objConsumoReportes.GetReportMemo1(numPoliza, numLiquidacion, fechaMemo, fechaDe, fechaA, cartera);
            var responseSubReporte  = _objConsumoRegistroProd.GridCuotas();

            //Reporte Principal
            re_memo ds = new re_memo();
            DataTable dt = new DataTable();
            dt.TableName = "Crystal Report Example";
            dt = ToDataTable(responseReporte);
            ds.Tables[0].Merge(dt, true, MissingSchemaAction.Ignore);

            //Subreporte
            re_memocuotas ds1 = new re_memocuotas();
            DataTable dt1 = new DataTable();
            dt1.TableName = "Crystal Report Example";
            dt1 = ToDataTable(responseSubReporte);
            ds1.Tables[0].Merge(dt1, true, MissingSchemaAction.Ignore);

            //rptDoc.Load(Server.MapPath("SimpleCrystal.rpt"));
            string reportPath = base.Server.MapPath("reportes//re_memo1.rpt");
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();
        }

        private void Estcta1()
        {
            var idPersona = Request.QueryString["ic"] == "" ? "%" : Request.QueryString["ic"].ToString();
            var idCompaniaSpvs = string.IsNullOrEmpty(Request.QueryString["ci"]) ? "%" : Request.QueryString["ci"].ToString();
            var idCartera = string.IsNullOrEmpty(Request.QueryString["ca"]) ? "%" : Request.QueryString["ca"].ToString();
            var numPoliza = Request.QueryString["np"] == "" ? "%" : Request.QueryString["np"].ToString();
            var numLiquidacion = Request.QueryString["nl"] == "" ? "%" : Request.QueryString["nl"];
           
            var reportHistorico = string.IsNullOrEmpty(Request.QueryString["h"]) ? true : Convert.ToBoolean(Request.QueryString["h"]);
            var reportNamePath = string.Empty;

            ReportDocument rptDoc = new ReportDocument();
                        
            //Reporte Principal
            DS_SicPro ds = new DS_SicPro();
            DataTable dt = new DataTable();
            if (reportHistorico)
            {
                var responseReporte = _objConsumoReportes.GetReportEstctaaseg1(idPersona, idCompaniaSpvs, idCartera, numPoliza, numLiquidacion);
                reportNamePath = string.Concat("reportes//re_estctaaseg1.rpt");
                dt.TableName = "GetReportEstctaaseg1";
                dt = ToDataTable(responseReporte);
                ds.Tables["GetReportEstctaaseg1"].Merge(dt, true, MissingSchemaAction.Ignore);
            }
            else
            {
                var responseReporte = _objConsumoReportes.GetReportEstctaaseg2(idPersona, idCompaniaSpvs, idCartera, numPoliza, numLiquidacion);
                reportNamePath = string.Concat("reportes//re_estctaaseg2.rpt");
                dt.TableName = "GetReportEstctaaseg2";
                dt = ToDataTable(responseReporte);
                ds.Tables["GetReportEstctaaseg2"].Merge(dt, true, MissingSchemaAction.Ignore);
            }

            var responseSubReporte = _objConsumoRegistroProd.GetListPolMov();

            //Subreporte
            DS_SicPro ds1 = new DS_SicPro();
            DataTable dt1 = new DataTable();
            dt1.TableName = "pr_polmov";
            dt1 = ToDataTable(responseSubReporte);
            ds1.Tables["pr_polmov"].Merge(dt1, true, MissingSchemaAction.Ignore);

            //rptDoc.Load(Server.MapPath("SimpleCrystal.rpt"));
            string reportPath = base.Server.MapPath(reportNamePath);
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();
        }

        private void Listadias()
        {
            var idCartera = Request.QueryString["ca"];
            var idSucursal = Request.QueryString["is"];
            var idCompaniaSpvs = Request.QueryString["ci"];            
            var idGrupo = Request.QueryString["gr"];

            var venc1 = Request.QueryString["e1"];
            var venc2 = Request.QueryString["e2"];

            var diasVcmto = Request.QueryString["vv"];
            var fechaListado = Request.QueryString["fc"];

            ReportDocument rptDoc = new ReportDocument();
            
            var responseReporte = _objConsumoReportes.GetReportCuotaadias(idCartera, idSucursal, idCompaniaSpvs, idGrupo, venc1, venc2, diasVcmto, fechaListado);
            //var responseSubReporte = _objConsumoReportes.GetReportHistreclamoshf();

            //Reporte Principal
            DS_SicPro ds = new DS_SicPro();
            DataTable dt = new DataTable();
            dt.TableName = "GetReportCuotaadias";
            dt = ToDataTable(responseReporte);
            ds.Tables["GetReportCuotaadias"].Merge(dt, true, MissingSchemaAction.Ignore);

            ////Subreporte
            //DS_SicPro ds1 = new DS_SicPro();
            //DataTable dt1 = new DataTable();
            //dt1.TableName = "GetReportHistreclamoshf";
            //dt1 = ToDataTable(responseSubReporte);
            //ds1.Tables["GetReportHistreclamoshf"].Merge(dt1, true, MissingSchemaAction.Ignore);

            //rptDoc.Load(Server.MapPath("SimpleCrystal.rpt"));
            string reportPath = base.Server.MapPath("reportes//re_cuotaadias.rpt");
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            //rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();
        }
        private void Clientes()
        {
            var mesAniv = Convert.ToInt32(Request.QueryString["fc"]);
            var nomcli = Request.QueryString["nc"];
            var suc = Convert.ToInt32(Request.QueryString["sc"]);

            ReportDocument rptDoc = new ReportDocument();
            
            var responseReporte = _objConsumoReportes.GetReportClientes(nomcli, mesAniv, suc);
            var responseSubReporte = _objConsumoReportes.GetReportDirecciones();

            //Reporte Principal
            re_clientes ds = new re_clientes();
            DataTable dt = new DataTable();
            dt.TableName = "Reporte";
            dt = ToDataTable(responseReporte);            
            ds.Tables[0].Merge(dt, true, MissingSchemaAction.Ignore);

            //Sub Reporte
            re_direcciones ds1 = new re_direcciones();
            DataTable dt1 = new DataTable();
            dt1.TableName = "SubReporte";
            dt1 = ToDataTable(responseSubReporte);
            ds1.Tables[0].Merge(dt1, true, MissingSchemaAction.Ignore);

            string reportPath = base.Server.MapPath("reportes//re_clientes.rpt");
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();
        }

        //14
            private void CarteraComi()
        { }

        //15
            private void Grupos()
        {
            var idGrupo = Convert.ToInt64(Request.QueryString["ig"]);
            var idSuc = Convert.ToInt64(Request.QueryString["sc"]);

            ReportDocument rptDoc = new ReportDocument();
            
            var responseReporte = _objConsumoReportes.GetReportGrupos(idGrupo, idSuc);
            //var responseSubReporte = _objConsumoReportes.GetReportDirecciones();

            //Reporte Principal
            re_clientes ds = new re_clientes();
            DataTable dt = new DataTable();
            dt.TableName = "Reporte";
            dt = ToDataTable(responseReporte);
            ds.Tables[0].Merge(dt, true, MissingSchemaAction.Ignore);

            ////Sub Reporte
            //re_direcciones ds1 = new re_direcciones();
            //DataTable dt1 = new DataTable();
            //dt1.TableName = "SubReporte";
            //dt1 = ToDataTable(responseSubReporte);
            //ds1.Tables[0].Merge(dt1, true, MissingSchemaAction.Ignore);

            string reportPath = base.Server.MapPath("reportes//re_grupos.rpt");
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            //rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();
        }

        private void ProyCartera()
        {            
            var suc = Convert.ToString(Request.QueryString["sc"]);

            ReportDocument rptDoc = new ReportDocument();
            
            var responseReporte = _objConsumoReportes.GetReportProyCartera().Where(x => x.sucursal.Contains(suc.ToUpper())).ToList();
            var responseSubReporte = _objConsumoReportes.GetReportDirecciones();

            //Reporte Principal
            re_clientes ds = new re_clientes();
            DataTable dt = new DataTable();
            dt.TableName = "Reporte";
            dt = ToDataTable(responseReporte);
            ds.Tables[0].Merge(dt, true, MissingSchemaAction.Ignore);

            //Sub Reporte
            re_direcciones ds1 = new re_direcciones();
            DataTable dt1 = new DataTable();
            dt1.TableName = "SubReporte";
            dt1 = ToDataTable(responseSubReporte);
            ds1.Tables[0].Merge(dt1, true, MissingSchemaAction.Ignore);

            string reportPath = base.Server.MapPath("reportes//re_proycartera.rpt");
            rptDoc.Load(reportPath);
            rptDoc.SetDataSource(ds);
            rptDoc.Subreports[0].SetDataSource(ds1);
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.RefreshReport();
        }
        //17 18 19 20 24
        private void ProdCaptada(int a)
        {
            string str = "";
            if (a == 17)
            {
                str = "re_prodcap1.rpt";
            }
            if (a == 18)
            {
                str = "re_comicap1.rpt";
            }
            if (a == 19)
            {
                str = "re_comiefect1.rpt";
            }
            if (a == 20)
            {
                str = "re_comicobr1.rpt";
            }
            if (a == 24)
            {
                str = "re_prodcap2.rpt";
            }
        }
            private void Cobfecha()
        { }
        private void RecXCob()
        { }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }


        //protected void Memo11()
        //{
        //    string str = base.Server.MapPath("reportes//re_memo.rpt");
        //    this.CrystalReportViewer1.ReportSource = str;
        //    string str1 = string.Concat("{Comando.id_poliza}=", base.Request.QueryString["p"], " and");
        //    str1 = string.Concat(str1, "{Comando.id_movimiento}= ", base.Request.QueryString["m"]);
        //    this.CrystalReportViewer1.SelectionFormula = str1;
            
        //    this.CrystalReportViewer1.RefreshReport();
        //}
        //public DataSet ToDataSet(List<GetReportMemo_Result> list)
        //{
        //    Type elementType = typeof(GetReportMemo_Result);
        //    DataSet ds = new DataSet();
        //    DataTable t = new DataTable();
        //    ds.Tables.Add(t);
        //    //add a column to table for each public property on T
        //    foreach (var propInfo in elementType.GetProperties())
        //    {
        //        t.Columns.Add(propInfo.Name, propInfo.PropertyType);
        //    }
        //    //go through each property on T and add each value to the table
        //    foreach (GetReportMemo_Result item in list)
        //    {
        //        DataRow row = t.NewRow();
        //        foreach (var propInfo in elementType.GetProperties())
        //        {
        //            row[propInfo.Name] = propInfo.GetValue(item, null);
        //        }
        //        //This line was missing:
        //        t.Rows.Add(row);
        //    }
        //    return ds;
        //}

        //    protected void Memo3()
        //{
        //    //List<GetReportMemo_Result> response = _objConsumoReportes.GetReportMemo(36165, 63452);

        //    //CrystalReport cr = new CrystalReport1();
        //    //CrystalReportViewer1.ReportSource = cr;

        //    //cr.SetDataSource(response);


        //    ////var ds = ToDataSet(response);


        //    //string reportPath = base.Server.MapPath("reportes//re_memo.rpt");
        //    ////https://stackoverflow.com/questions/8006245/how-to-set-datasource-of-sub-crystal-report-in-c-sharp-win-form-app
        //    //ReportDocument cryRpt = new ReportDocument();
        //    //cryRpt.Load(reportPath);
        //    //cryRpt.DataSourceConnections.Clear();
            
        //    //cryRpt.SetDataSource(ds);
        //    //cryRpt.SetParameterValue("clapol", "1");
        //    //cryRpt.SetParameterValue("tipocuota", "1");
        //    ////cryRpt.Subreports[0].DataSourceConnections.Clear();
        //    ////cryRpt.Subreports[0].SetDataSource(ds.Tables[0]);
        //    //CrystalReportViewer1.ReportSource = cryRpt;
        //    //CrystalReportViewer1.RefreshReport();
        //}


        //protected void Memo2()
        //{
        //    List<GetReportMemo_Result> response = _objConsumoReportes.GetReportMemo(36165, 63452);

        //    //var ds = ToDataSet(response);


        //    string reportPath = base.Server.MapPath("reportes//re_memo.rpt");
        //    //https://stackoverflow.com/questions/8006245/how-to-set-datasource-of-sub-crystal-report-in-c-sharp-win-form-app
        //    ReportDocument cryRpt = new ReportDocument();
        //    cryRpt.Load(reportPath);
        //    cryRpt.DataSourceConnections.Clear();

        //    cryRpt.SetDataSource(response);
        //    cryRpt.SetParameterValue("clapol", "1");
        //    cryRpt.SetParameterValue("tipocuota", "1");
        //    //cryRpt.Subreports[0].DataSourceConnections.Clear();
        //    //cryRpt.Subreports[0].SetDataSource(ds.Tables[0]);
        //    CrystalReportViewer1.ReportSource = cryRpt;
        //    CrystalReportViewer1.RefreshReport();
        //}
    }
}