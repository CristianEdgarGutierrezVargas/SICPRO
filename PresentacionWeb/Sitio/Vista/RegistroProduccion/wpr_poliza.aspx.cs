using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_poliza : System.Web.UI.Page
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
            var lstGrupo = _objConsumoRegistroProd.ObtenerGrupo();
            id_gru.DataSource = lstGrupo;
            id_gru.TextField = "desc_grupo";
            id_gru.ValueField = "id_gru";
            id_gru.DataBind();

            var lstTipoCartera = _objConsumoRegistroProd.listas1();
            id_clamov1.DataSource = lstTipoCartera;
            id_clamov1.TextField = "desc_param";
            id_clamov1.ValueField = "id_par";
            id_clamov1.DataBind();

            var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
            id_perejec.DataSource = lstFuncionarios;
            id_perejec.TextField = "nomraz";
            id_perejec.ValueField = "id_per";
            id_perejec.DataBind();

        }


        #endregion
    }
}