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
                //case 3:
                //    {
                //        this.RecDetallado();
                //        return;
                //    }
                //case 4:
                //    {
                //        this.RecResum();
                //        return;
                //    }
                //case 5:
                //    {
                //        this.LiqRep();
                //        return;
                //    }
                //case 6:
                //    {
                //        this.Reppc();
                //        return;
                //    }
                //case 7:
                //    {
                //        this.Repc();
                //        return;
                //    }
                //case 8:
                //    {
                //        this.Rascii();
                //        return;
                //    }
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
                //case 11:
                //    {
                //        this.Estcta1();
                //        return;
                //    }
                //case 12:
                //    {
                //        this.Listadias();
                //        return;
                //    }
                case 13:
                    {
                        Clientes();
                        return;
                    }
                //case 14:
                //    {
                //        this.CarteraComi();
                //        return;
                //    }
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
                //case 17:
                //    {
                //        this.ProdCaptada(17);
                //        return;
                //    }
                //case 18:
                //    {
                //        this.ProdCaptada(18);
                //        return;
                //    }
                //case 19:
                //    {
                //        this.ProdCaptada(19);
                //        return;
                //    }
                //case 20:
                //    {
                //        this.ProdCaptada(20);
                //        return;
                //    }
                //case 21:
                //    {
                //        this.Contable1();
                //        return;
                //    }
                //case 22:
                //    {
                //        this.Cobfecha();
                //        return;
                //    }
                //case 23:
                //    {
                //        this.NotaCob();
                //        return;
                //    }
                //case 24:
                //    {
                //        this.ProdCaptada(24);
                //        return;
                //    }
                //case 25:
                //    {
                //        this.RecXCob();
                //        return;
                //    }
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
            SqlConnection sqlCon;
            
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

            SqlConnection sqlCon;


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

        private void Memo2(int tipo)
        {
            var numPoliza = Convert.ToString(Request.QueryString["np"]);
            var numLiquidacion = Convert.ToString(Request.QueryString["nl"]);
            var fechaDe = Convert.ToString(Request.QueryString["fc"]);
            var fechaA = Convert.ToString(Request.QueryString["fc2"]);
            var fechaMemo = Convert.ToString(Request.QueryString["fb"]);
            var cartera = Request.QueryString["ca"];

            ReportDocument rptDoc = new ReportDocument();
            SqlConnection sqlCon;

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

        private void Clientes()
        {
            var mesAniv = Convert.ToInt32(Request.QueryString["fc"]);
            var nomcli = Request.QueryString["nc"];
            var suc = Convert.ToInt32(Request.QueryString["sc"]);

            ReportDocument rptDoc = new ReportDocument();
            SqlConnection sqlCon;

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

        private void Grupos()
        {
            var idGrupo = Convert.ToInt64(Request.QueryString["ig"]);
            var idSuc = Convert.ToInt64(Request.QueryString["sc"]);

            ReportDocument rptDoc = new ReportDocument();
            SqlConnection sqlCon;

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
            SqlConnection sqlCon;

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