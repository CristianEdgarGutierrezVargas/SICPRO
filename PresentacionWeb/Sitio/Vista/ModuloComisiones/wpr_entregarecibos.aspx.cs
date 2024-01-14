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
    public partial class wpr_entregarecibos : System.Web.UI.Page
    {
        ConsumoRegistroProd consumoRegPro=new ConsumoRegistroProd();
        ConsumoModComision consumoModComision = new ConsumoModComision();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Combos();
            }
        }
        private void Combos()
        {
            var sucursal = consumoRegPro.ObtenerLista("id_suc");
            id_suc.DataSource= sucursal;
            id_suc.TextField = "desc_param";
            id_suc.ValueField = "id_par";
            id_suc.DataBind();

            var sanio = consumoModComision.ObtenerAnio();
            anio.DataSource= sanio;
            anio.TextField = "anio_recibo";
            anio.ValueField = "anio_recibo";
            anio.DataBind();

        }

        protected void CallBCobrador_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var index = e.Parameter;
            var listaCobrador = consumoModComision.ObtenerCobrador(index);
            id_perucb.DataSource= listaCobrador;
            id_perucb.TextField = "nomraz";
            id_perucb.ValueField = "id_per";
            id_perucb.DataBind();
        }

        protected void CallBRecibos_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var index = e.Parameter;
            var listRecibo = consumoModComision.ObtenerRecibo(index);
            id_recibo.DataSource= listRecibo;
            id_recibo.TextField = "id_recibo";
            id_recibo.ValueField = "id_recibo";
            id_recibo.DataBind();

            id_recibo1.DataSource = listRecibo;
            id_recibo1.TextField = "id_recibo";
            id_recibo1.ValueField = "id_recibo";
            id_recibo1.DataBind();


        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            //this.lblmensaje.Text = "Espere mientras se registran los recibos";
            try
            {
                pr_recibo prRecibo = new pr_recibo()
                {
                    anio_recibo = Convert.ToDecimal(anio.Value),
                   
                    fecha_entregado =(DateTime)fecha_entregado.Value,
                    id_perucb = id_perucb.Value.ToString(),
                    id_suc = id_suc.Value.ToString(),
                    
                };
                var id_recibo = Convert.ToInt32(this.id_recibo.Value);
                 var   id_reciboa = Convert.ToInt32(id_recibo1.Value);
                var año = Convert.ToInt32(anio.Value);
                var update=consumoModComision.EntregarRecibo(prRecibo, año, id_recibo, id_reciboa);
                if(update)
                {

                    lblMensaje.Text = "Entrega Realizada con éxito!";
                    imagenFail.Visible = false;
                    imagenOk.Visible = true;
                    pnlMensaje.ShowOnPageLoad = true;
                }
                else
                {
                    imagenFail.Visible = true;
                    imagenOk.Visible = false;
                    lblMensaje.Text = "Hubo un error al registrar los datos!";
                    pnlMensaje.ShowOnPageLoad = true;
                }
                //this.lblmensaje.Text = "Entrega Realizada con éxito";
                //this.Limpiar();
                //this.msgboxpanel.Visible = true;
                //MessageBoxButton messageBoxButton = new MessageBoxButton("Salir");
                //messageBoxButton.SetLocation("index.aspx");
                //messageBoxButton.SetClass("msg_button_class");
                //MessageBoxButton messageBoxButton1 = new MessageBoxButton("Nueva Asignación");
                //messageBoxButton1.SetLocation("wpr_entregarecibos.aspx");
                //messageBoxButton1.SetClass("msg_button_class");
                //MessageBox messageBox = new MessageBox(base.Server.MapPath("msgbox.tpl"));
                //messageBox.SetTitle("Confirmación");
                //messageBox.SetIcon("msg_icon_1.png");
                //messageBox.SetMessage("Registro de Recibos Correctamente");
                //messageBox.AddButton(messageBoxButton.ReturnObject());
                //messageBox.AddButton(messageBoxButton1.ReturnObject());
                //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
            }
            catch
            {
            }
        }
    }
}