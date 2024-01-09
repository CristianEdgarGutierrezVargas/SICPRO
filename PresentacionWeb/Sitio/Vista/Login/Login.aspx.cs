using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.Login
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly ConsumoAuth _consumoAuth=new ConsumoAuth();
        private long tiempo;
        protected void Page_Load(object sender, EventArgs e)
        {
            Principal aaa = Page.Master as Principal;
            var d= aaa.FindControl("Menu1");
            d.Visible = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            //Session["suc"] = 54;

            try
            {
                
                if (!_consumoAuth.VerificarUsuario(base.Server.HtmlEncode(this.txtusuario.Text.ToUpper()), base.Server.HtmlEncode(this.txtpassword.Text.ToUpper())))
                {
                    lblmensaje.Text = "Usuario Inválido o ha Iniciado sesión en otro equipo";
                }
                else
                {
                    string str = _consumoAuth.ObtenerSuc(this.txtusuario.Text.ToUpper(), this.txtpassword.Text.ToUpper());
                    this.Session["suc"] = str;
                    string str1 = _consumoAuth.ObtenerRol(this.txtusuario.Text.ToUpper(), this.txtpassword.Text.ToUpper());
                    this.Session["roles"] = str1;
                    string str2 = _consumoAuth.ObtenerId(this.txtusuario.Text.ToUpper(), this.txtpassword.Text.ToUpper());
                    this.Session["id"] = str2;
                    if (this.sesion.Value.ToString()!= "0")
                    {
                        this.tiempo = int.Parse(sesion.Value.ToString());
                    }
                    else
                    {
                        this.tiempo = 30;
                    }
                    string text = this.txtusuario.Text;
                    DateTime now = DateTime.Now;
                    DateTime dateTime = DateTime.Now;
                    FormsAuthenticationTicket formsAuthenticationTicket = new FormsAuthenticationTicket(2, text, now, dateTime.AddMinutes((double)this.tiempo), false, this.txtusuario.Text, FormsAuthentication.FormsCookiePath);
                    string str3 = FormsAuthentication.Encrypt(formsAuthenticationTicket);
                    HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, str3);
                    base.Response.Cookies.Add(httpCookie);
                    string str4 = this.Session["id"].ToString();
                    _consumoAuth.Logeo(str4);
                    if (!_consumoAuth.VerificarEstado(base.Server.HtmlEncode(this.txtusuario.Text.ToUpper()), base.Server.HtmlEncode(this.txtpassword.Text.ToUpper())))
                    {

                        //Principal aaa = Page.Master as Principal;
                        //var d = aaa.FindControl("Menu1");
                        //d.Visible = false;
                        Response.Redirect("../Default.aspx");
                    }
                    else
                    {
                        //Response.Redirect("~/Sitio/Vista/ConfiguracionSistema/wgr_pass.aspx");
                        Response.Redirect("../Default.aspx");
                    }
                }
            }
            catch
            {
            }

        }
    }
}