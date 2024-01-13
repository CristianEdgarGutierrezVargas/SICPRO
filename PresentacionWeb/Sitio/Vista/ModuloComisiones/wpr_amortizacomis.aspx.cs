using DevExpress.Web.Bootstrap;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ModuloComisiones
{
    public partial class wpr_amortizacomis : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoModComision _objConsumoModComision = new ConsumoModComision();
        ConsumoValidarProd _objValidarProd= new ConsumoValidarProd();
        public bool sw;
        protected void Page_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }
        private void CargaInicial()
        {
            

            var lstDivisa = _objConsumoRegistroProd.ParametroA("id_div");
            id_div.DataSource = lstDivisa;
            id_div.TextField = "abrev_param";
            id_div.ValueField = "id_par";
            id_div.DataBind();

            var itemLstDivisa = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            id_div.Items.Add(itemLstDivisa);

            pc_anio.Items.Clear();
            int year = DateTime.Now.Year;
            this.pc_anio.Items.Add("Seleccione una opcion...");
            int num = year - 1;
            this.pc_anio.Items.Add(num.ToString());
            this.pc_anio.Items.Add(year.ToString());
            int num1 = year + 1;
            this.pc_anio.Items.Add(num1.ToString());
           
            var objTablaCompania = _objValidarProd.ObtenerTablaCompania("");
            
            id_spvs.DataSource= objTablaCompania;
            id_spvs.TextField = "nomraz";
            id_spvs.ValueField = "id_spvs";
            id_spvs.DataBind();
        }
        protected void btncuotas_Click(object sender, EventArgs e)
        {
            try
            {
                
                    pr_pagocompania prAmortizacione = new pr_pagocompania()
                    {
                        
                        cheque = this.cheque.Text,
                        id_spvs = id_spvs.Value.ToString(),
                        fecha = (DateTime)this.fecha.Value,
                        monto_pc =(decimal) this.monto_pc.Value,
                        comision_pc = (decimal)this.comision_pc.Value,
                        factura_pc = this.factura_pc.Text,
                        pc_mes =Convert.ToDecimal( this.pc_mes.Text),
                        pc_anio = Convert.ToDecimal(this.pc_anio.Text),
                        id_div = (long)this.id_div.Value
                    };
                    var pagoCompania= _objConsumoModComision.InsertarPagoComp(prAmortizacione);
                    //this.msgboxpanel.Visible = true;
                    //MessageBox messageBox = new MessageBox(base.Server.MapPath("msgbox.tpl"));
                    //messageBox.SetTitle("Confirmación");
                    //messageBox.SetIcon("msg_icon_1.png");
                    //messageBox.SetMessage("Cheque para pago de comisiones registrado correctamente ");
                    //MessageBoxButton messageBoxButton = new MessageBoxButton("Aceptar");
                    //messageBoxButton.SetLocation("wpr_amortizacomis.aspx");
                    //messageBoxButton.SetClass("msg_button_class");
                    //messageBox.AddButton(messageBoxButton.ReturnObject());
                    //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
              
            }
            catch
            {
            }
        }

       
    }
}