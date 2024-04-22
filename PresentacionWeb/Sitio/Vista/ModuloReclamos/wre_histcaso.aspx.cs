using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ModuloReclamos
{
    public partial class wre_histcaso : System.Web.UI.Page
    {
        ConsumoReclamos logicaReclamos = new ConsumoReclamos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;

            this.anio_caso.DataSource = logicaReclamos.anio_list();
            this.anio_caso.DataTextField = "desc_param";
            this.anio_caso.DataValueField = "valor_param";
            this.anio_caso.DataBind();
            this.anio_caso.SelectedValue = "0";

            this.id_estca.DataSource = logicaReclamos.ParametroV("id_estca", 2);
            this.id_estca.DataTextField = "desc_param";
            this.id_estca.DataValueField = "id_par";
            this.id_estca.DataBind();
            this.id_estca.SelectedValue = "0";
        }
        protected void btnsalir_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Index.aspx");
        }
        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("wre_cierrecaso.aspx");
        }
        protected void busca()
        {
            /*
            
            
            
            this.obs_histcaso.Text = "";
            this.id_estca.SelectedIndex = -1;
            this.pago_caso.Text = "0,00";
            this.msgboxpanel.Visible = false;
            if (!new re_histcaso()
            {
                id_caso = this.id_caso,
                anio_caso = this.anio_caso,
                nomraz = this.nomraz,
                nomraz2 = this.nomraz2,
                desc_prod = this.desc_prod,
                num_poliza = this.num_poliza,
                mat_aseg = this.mat_aseg,
                uni_obj = this.uni_obj,
                fc_denuncia = this.fc_denuncia,
                circunstancia = this.circunstancia,
                fc_iniestado = this.fc_iniestado,
                desc_param = this.desc_param,
                obs_histcaso1 = this.obs_histcaso1,
                id_sucur = this.id_sucur,
                divisa = this.divisa,
                monto_aprox1 = this.monto_aprox1,
                lblmensaje = this.lblmensaje,
                id_per = this.id_per
            }.ser_histcaso())
            {
                this.msgboxpanel.Visible = true;
                MessageBox messageBox = new MessageBox(this.Server.MapPath("msgbox1.tpl"));
                messageBox.SetTitle("Reclamo No encontrado");
                messageBox.SetIcon("msg_icon_2.png");
                messageBox.SetMessage("<p style='color:#990000; font-weight:bold'>El número de caso no fue encontrado, es problable que el mismo se encuentre cerrado.<br /> Verifique el mismo mediante reportes</p>");
                messageBox.SetOKButton("msg_button_class1");
                this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                this.btnguardar.Visible = false;
                this.id_caso.Focus();
                this.divisa2.Text = this.divisa1.Text;
                this.divisa3.Text = this.divisa1.Text;
            }
            else
            {
                this.monto_aprox1.Text = string.Format("{0:n}", (object)double.Parse(this.monto_aprox1.Text));
                this.fc_denuncia.Text = string.Format("{0:D}", (object)DateTime.Parse(this.fc_denuncia.Text));
                this.fc_iniestado.Text = string.Format("{0:D}", (object)DateTime.Parse(this.fc_iniestado.Text));
                this.divisa1.Text = this.divisa.Text;
                this.id_estca.Focus();
                this.lblmensaje.Text = "Actualice los datos para el cierre del caso";
            }*/
        }

        protected void btnser_Click(object sender, ImageClickEventArgs e)
        {
            decimal idCaso = decimal.Parse(this.id_caso.Text);
            decimal idAnioCaso = decimal.Parse(this.anio_caso.SelectedValue);
            var item = logicaReclamos.ser_histcaso(idCaso,idAnioCaso);
            /*
           this.obs_histcaso.Text = "";
           this.id_estca.SelectedIndex = -1;
           this.pago_caso.Text = "0,00";
           this.msgboxpanel.Visible = false;
           if (!new re_histcaso()
           {
               id_caso = this.id_caso,
               anio_caso = this.anio_caso,
               nomraz = this.nomraz,
               nomraz2 = this.nomraz2,
               desc_prod = this.desc_prod,
               num_poliza = this.num_poliza,
               mat_aseg = this.mat_aseg,
               uni_obj = this.uni_obj,
               fc_denuncia = this.fc_denuncia,
               circunstancia = this.circunstancia,
               fc_iniestado = this.fc_iniestado,
               desc_param = this.desc_param,
               obs_histcaso1 = this.obs_histcaso1,
               id_sucur = this.id_sucur,
               divisa = this.divisa,
               monto_aprox1 = this.monto_aprox1,
               lblmensaje = this.lblmensaje,
               id_per = this.id_per
           }.ser_histcaso())
           {
               this.msgboxpanel.Visible = true;
               MessageBox messageBox = new MessageBox(this.Server.MapPath("msgbox1.tpl"));
               messageBox.SetTitle("Reclamo No encontrado");
               messageBox.SetIcon("msg_icon_2.png");
               messageBox.SetMessage("<p style='color:#990000; font-weight:bold'>El número de caso no fue encontrado, es problable que el mismo se encuentre cerrado.<br /> Verifique el mismo mediante reportes</p>");
               messageBox.SetOKButton("msg_button_class1");
               this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
               this.btnguardar.Visible = false;
               this.id_caso.Focus();
               this.divisa2.Text = this.divisa1.Text;
               this.divisa3.Text = this.divisa1.Text;
           }
           else
           {
               this.monto_aprox1.Text = string.Format("{0:n}", (object)double.Parse(this.monto_aprox1.Text));
               this.fc_denuncia.Text = string.Format("{0:D}", (object)DateTime.Parse(this.fc_denuncia.Text));
               this.fc_iniestado.Text = string.Format("{0:D}", (object)DateTime.Parse(this.fc_iniestado.Text));
               this.divisa1.Text = this.divisa.Text;
               this.id_estca.Focus();
               this.lblmensaje.Text = "Actualice los datos para el cierre del caso";
           }*/
        }
        protected void btncalcular_Click(object sender, EventArgs e)
        {
          /*  this.msgboxpanel.Visible = false;
            if (double.Parse(this.coafran.Text.Replace(".", "").Replace(",", "")) / 100.0 <= double.Parse(this.pago_caso.Text.Replace(".", "").Replace(",", ".")) / 100.0)
            {
                this.indem.Text = string.Format("{0:n}", (object)(double.Parse(this.pago_caso.Text.Replace(".", "").Replace(",", ".")) / 100.0 - double.Parse(this.coafran.Text.Replace(".", "").Replace(",", "")) / 100.0));
                this.btnguardar.Visible = true;
            }
            else
            {
                this.msgboxpanel.Visible = true;
                MessageBox messageBox = new MessageBox(this.Server.MapPath("msgbox1.tpl"));
                messageBox.SetTitle("Validación de Datos");
                messageBox.SetIcon("msg_icon_2.png");
                messageBox.SetMessage("<span>Los siguientes valores deben ser verificados antes de proseguir<br /></span><p style='color:#990000; font-weight:bold'> El valor del Coaseguro o Franquicia no debe sobrepasar el valor pagado</p>");
                messageBox.SetOKButton("msg_button_class1");
                this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                this.btnguardar.Visible = false;
            }
          */
        }
    }
}