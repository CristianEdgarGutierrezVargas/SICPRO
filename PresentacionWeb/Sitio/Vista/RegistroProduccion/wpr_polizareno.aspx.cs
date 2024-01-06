using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_polizareno : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack && base.Request.QueryString["var"] != "")
            {
                int idPoliza = int.Parse(base.Request.QueryString["var"]);
                int idMovimiento = int.Parse(base.Request.QueryString["val"]);
                //this.Buscar(num, num1);
                //this.fc_reg.Value = DateTime.Today.Date.ToShortDateString();
            }
        }

        #region Metodos

        private void Buscar(int par1, int par2)
        {
            try
            {
                //pr_movimientos prMovimiento = new pr_movimientos()
                //{
                //    numpoliza = this.numpoliza,
                //    num_poliza = this.num_poliza,
                //    id_perclie = this.id_per,
                //    nomraz = this.nomraz,
                //    id_gru = this.id_gru,
                //    desc_grupo = this.desc_grupo,
                //    id_producto = this.id_producto,
                //    desc_producto = this.desc_producto,
                //    id_spvs = this.id_spvs,
                //    nomco = this.nomco,
                //    id_percart = this.id_percart,
                //    nomcart = this.nomcart,
                //    id_perejec = this.id_perejec,
                //    id_dir = this.id_dir,
                //    nomdir = this.direccion,
                //    clase_poliza = this.clase_poliza,
                //    fc_finvig = this.fc_finvig,
                //    id_poliza = this.id_poliza,
                //    id_div1 = this.id_div,
                //    nomdiv = this.nomdiv
                //};
                var objRenPoliza = _objConsumoRegistroProd.ObtenerRenPoliza(par1, par2);

            }
            catch
            {
            }
        }

        #endregion

        protected void btnCalcular_Click(object sender, EventArgs e)
        {

        }
    }
}