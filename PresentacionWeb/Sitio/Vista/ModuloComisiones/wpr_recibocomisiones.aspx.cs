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
    public partial class wpr_recibocomisiones : System.Web.UI.Page
    {
        ConsumoModComision consumoMod = new ConsumoModComision();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerarRecibo();
                this.anio.Text = DateTime.Now.Year.ToString();
                this.Limpiar();
            }
        }
        private void Limpiar()
        {
            al.Text = "";
            al.Focus();
        }
        private void GenerarRecibo()
        {
            var lstRecibo = consumoMod.GenerarRecibo(DateTime.Now.Year);

            if (lstRecibo.Count <= 1)
            {
                this.del.Text = Convert.ToString(1);
            }
            else
            {
                double reg = double.Parse(lstRecibo.FirstOrDefault().id_recibo.ToString());
                reg += 1;
                this.del.Text = reg.ToString();
            }
        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {

                int del1 = Convert.ToInt32(del.Text);
                int al1 = Convert.ToInt32(al.Text);

                if (consumoMod.InsertarRecibo(del1, al1, anio.Text))
                {
                    lblMensaje.Text = "Recibos Agregados Satisfactoriamente!";
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


            }
            catch
            {
            }
        }
    }
}