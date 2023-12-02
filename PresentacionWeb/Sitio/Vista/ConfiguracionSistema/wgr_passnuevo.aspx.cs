using Common;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ConfiguracionSistema
{
    public partial class wgr_passnuevo : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.Datos();
        }

        protected void Datos()
        {
            try
            {
                this.id_rol.DataSource = logicaConfiguracion.ListaRoles();
                this.id_rol.DataTextField = "desc_param";
                this.id_rol.DataValueField = "id_par";
                this.id_rol.DataBind();

            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }

            try
            {
                Session["LST_USUARIOS"] = logicaConfiguracion.ListaPersonaConPass().OrderBy(x => x.nomraz).ToList(); 
                this.grdusuarios.DataSource = Session["LST_USUARIOS"];
                this.grdusuarios.DataBind();
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void grdusuarios_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<gr_persona>)Session["LST_USUARIOS"];
            if (lstData != null)
            {
                this.grdusuarios.DataSource = lstData;
            }
        }

        //protected void btnguardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.msgboxpanel.Visible = false;
        //        string str = "";
        //        if (string.IsNullOrEmpty(this.login.Text))
        //        {
        //            str += "<br /> Debe registrar un Login(Nick)";
        //            this.sw = true;
        //        }
        //        if (this.id_rol.SelectedIndex == -1)
        //        {
        //            str += "<br /> Debe seleccionar un Rol";
        //            this.sw = true;
        //        }
        //        if (string.IsNullOrEmpty(this.nomraz.Text))
        //        {
        //            str += "<br /> Debe seleccionar un Usuario";
        //            this.sw = true;
        //        }
        //        if (this.sw)
        //        {
        //            this.msgboxpanel.Visible = true;
        //            MessageBox messageBox = new MessageBox(this.Server.MapPath("msgbox1.tpl"));
        //            messageBox.SetTitle("Validación de Datos");
        //            messageBox.SetIcon("msg_icon_2.png");
        //            messageBox.SetMessage("<span>Los siguientes valores deben ser verificados antes de proseguir<br /></span><p style='color:#990000; font-weight:bold'>" + str + "</p>");
        //            messageBox.SetOKButton("msg_button_class1");
        //            this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
        //            this.sw = false;
        //        }
        //        else
        //        {
        //            new gr_pass()
        //            {
        //                login = this.login,
        //                id_rol = this.id_rol,
        //                id_pert = this.id_per
        //            }.AgregarUsuario();
        //            this.lblmensaje.Text = "Usuario Agregado Satisfactoriamente";
        //            this.msgboxpanel.Visible = true;
        //            MessageBoxButton messageBoxButton = new MessageBoxButton("Aceptar");
        //            messageBoxButton.SetLocation("wgr_passnuevo.aspx");
        //            messageBoxButton.SetClass("msg_button_class");
        //            MessageBox messageBox = new MessageBox(this.Server.MapPath("msgbox.tpl"));
        //            messageBox.SetTitle("Confirmacion");
        //            messageBox.SetIcon("msg_icon_1.png");
        //            messageBox.SetMessage("Usuario Agregado Satisfactoriamente");
        //            messageBox.AddButton(messageBoxButton.ReturnObject());
        //            this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        //protected void btnexaminar_Click(object sender, EventArgs e)
        //{
        //    string msg_message = new gr_persona()
        //    {
        //        a = this.a,
        //        b = this.b
        //    }.TablaPersona(this.nomraz.Text.ToUpper());
        //    this.msgboxpanel.Visible = true;
        //    MessageBox messageBox = new MessageBox(this.Server.MapPath("msgbox2.tpl"));
        //    messageBox.SetTitle("Busqueda de Persona por Nombre o Razón Social");
        //    messageBox.SetIcon("search_user.png");
        //    messageBox.SetMessage(msg_message);
        //    messageBox.SetOKButton("msg_button_class");
        //    this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
        //}

      


        //protected void grdusuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Pager)
        //    {
        //        ((Label)e.Row.FindControl("lbltotalpaginas")).Text = this.grdusuarios.PageCount.ToString();
        //        ((TextBox)e.Row.FindControl("IraPag")).Text = (this.grdusuarios.PageIndex + 1).ToString();
        //    }
        //    if (e.Row.RowType != DataControlRowType.DataRow)
        //        return;
        //    e.Row.Attributes.Add("OnMouseOut", "this.className = this.orignalclassName;");
        //    e.Row.Attributes.Add("OnMouseOver", "this.orignalclassName = this.className;this.className = 'altoverow';");
        //}

        //protected void grdusuarios_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!new gr_pass()
        //        {
        //            login = this.login,
        //            id_rol = this.id_rol,
        //            id_pert = this.id_per,
        //            nomraz = this.nomraz
        //        }.ObtenerDatos(((Label)this.grdusuarios.SelectedRow.FindControl("id_per")).Text))
        //            return;
        //        this.btnguardar.Visible = false;
        //        this.btnmodificar.Visible = true;
        //    }
        //    catch
        //    {
        //    }
        //}

        //protected void btnmodificar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        new gr_pass()
        //        {
        //            login = this.login,
        //            id_rol = this.id_rol
        //        }.ModificarUsuario1(this.id_per.Value);
        //        this.lblmensaje.Text = "Usuario Modificado Satisfactoriamente";
        //        this.msgboxpanel.Visible = true;
        //        MessageBoxButton messageBoxButton = new MessageBoxButton("Aceptar");
        //        messageBoxButton.SetLocation("wgr_passnuevo.aspx");
        //        messageBoxButton.SetClass("msg_button_class");
        //        MessageBox messageBox = new MessageBox(this.Server.MapPath("msgbox.tpl"));
        //        messageBox.SetTitle("Confirmación");
        //        messageBox.SetIcon("msg_icon_1.png");
        //        messageBox.SetMessage("Usuario Modificado Satisfactoriamente");
        //        messageBox.AddButton(messageBoxButton.ReturnObject());
        //        this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
        //    }
        //    catch
        //    {
        //    }
        //}
    }
}