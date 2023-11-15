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
    public partial class RegistroPersonas : System.Web.UI.Page
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
            var lstSucursales = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_suc);

            var lstTipoPersona = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tper);

            var lstSalutacionPersonal = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_sal);

            var lstTipoRol = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_rol);

            var lstTipoDocumento = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tdoc);

            var lstEmisionDocumento = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_emis);
        }

        #endregion

    }
}