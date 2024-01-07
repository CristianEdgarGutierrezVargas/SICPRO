using DevExpress.Web.Bootstrap;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
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
                this.Buscar(idPoliza, idMovimiento);
                //this.fc_reg.Value = DateTime.Today.Date.ToShortDateString();
            }
        }

        #region Metodos

        private void Buscar(int par1, int par2)
        {
            try
            {
                var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
                cmbEjecutivo.DataSource = lstFuncionarios;
                cmbEjecutivo.TextField = "nomraz";
                cmbEjecutivo.ValueField = "id_per";
                cmbEjecutivo.DataBind();

                var itemLstFuncionarios = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
                cmbEjecutivo.Items.Add(itemLstFuncionarios);
                var objDataCompletaRenPoliza = _objConsumoRegistroProd.ObtenerDataCompletaRenPoliza(par1, par2);

                if (objDataCompletaRenPoliza != null)
                {
                    lblNroPoliza.Text = objDataCompletaRenPoliza.objRenovar.num_poliza;
                                        
                    txtNroLiquidacion.Text = string.Empty;
                    lblAsegurado.Text = objDataCompletaRenPoliza.objPersona.nomraz;
                    lblDireccion.Text = objDataCompletaRenPoliza.objDireccion.direccion;
                    lblGrupo.Text = objDataCompletaRenPoliza.objGrupo.desc_grupo;

                    lblProducto.Text = objDataCompletaRenPoliza.objProducto.desc_prod;

                    var itemFuncionario = cmbEjecutivo.Items.FindByValue(objDataCompletaRenPoliza.objRenovar.id_perejec);
                    if (itemFuncionario != null)
                    {
                        cmbEjecutivo.SelectedItem = itemFuncionario;
                    }

                    lblAgente.Text = objDataCompletaRenPoliza.objPersonaAgente.nomraz;
                    lblTipoPoliza.Text = objDataCompletaRenPoliza.objRenovar.clase_poliza == true ? "Normal" : "Flotante";
                    txtPrimaBruta.Text = string.Empty;
                    txtNumCuotas.Text = string.Empty;
                    lblDivisa.Text = objDataCompletaRenPoliza.objParametroDivisa.desc_param;

                    txtMatAseg.Text = string.Empty;
                }

            }
            catch
            {
            }
        }

        #endregion

        protected void btnCalcular_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnCuotas_Click(object sender, EventArgs e)
        {

        }
    }
}