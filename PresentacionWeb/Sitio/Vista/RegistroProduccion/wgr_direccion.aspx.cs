using Common;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wgr_direccion : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            CargaInicial();
        }

        #region Metodos

        private void CargaInicial()
        {
            var lstTipoDireccion = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tpdir);

            cmb_tpdir.DataSource = lstTipoDireccion;
            cmb_tpdir.DataValueField = "id_par";
            cmb_tpdir.DataValueField = "desc_param";
            cmb_tpdir.DataBind();

            var lstLugarEmision = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_emis);

            cmb_id_emis.DataSource = lstLugarEmision;
            cmb_id_emis.DataValueField = "id_par";
            cmb_id_emis.DataValueField = "desc_param";
            cmb_id_emis.DataBind();
        }

        #endregion
    }
}