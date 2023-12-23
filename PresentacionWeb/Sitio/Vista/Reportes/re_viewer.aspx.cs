using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.Reportes
{
    public partial class re_viewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (int.Parse(base.Request.QueryString["r"].ToString()))
            {
                case 1:
                    {
                        this.Memo();
                        return;
                    }
                //case 2:
                //    {
                //        this.Reporteprod1();
                //        return;
                //    }
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
                //case 9:
                //    {
                //        this.Memo2(1);
                //        return;
                //    }
                //case 10:
                //    {
                //        this.Memo2(2);
                //        return;
                //    }
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
                //case 13:
                //    {
                //        this.Clientes();
                //        return;
                //    }
                //case 14:
                //    {
                //        this.CarteraComi();
                //        return;
                //    }
                //case 15:
                //    {
                //        this.Grupos();
                //        return;
                //    }
                //case 16:
                //    {
                //        this.ProyCartera();
                //        return;
                //    }
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

        protected void Memo()
        {
            string str = base.Server.MapPath("reportes//re_memo.rpt");
            this.CrystalReportViewer1.ReportSource = str;
            string str1 = string.Concat("{Comando.id_poliza}=", base.Request.QueryString["p"], " and");
            str1 = string.Concat(str1, "{Comando.id_movimiento}= ", base.Request.QueryString["m"]);
            this.CrystalReportViewer1.SelectionFormula = str1;
            
            this.CrystalReportViewer1.RefreshReport();
        }

        protected void Memo11()
        {
            ////https://stackoverflow.com/questions/8006245/how-to-set-datasource-of-sub-crystal-report-in-c-sharp-win-form-app
            //ReportDocument cryRpt = new ReportDocument();
            //cryRpt.Load("reportes//re_memo.rpt");
            //cryRpt.DataSourceConnections.Clear();
            //cryRpt.SetDataSource(ds.Tables[0]);
            //cryRpt.Subreports[0].DataSourceConnections.Clear();
            //cryRpt.Subreports[0].SetDataSource(ds.Tables[0]);
            //CrystalReportViewer1.ReportSource = cryRpt;
            //CrystalReportViewer1.RefreshReport();
        }
    }
}