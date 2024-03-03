using Common;
using EntidadesClases.CustomModelEntities;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ConfiguracionSistema
{
    public partial class wpr_datospolizacuotas : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack || !(this.Request.QueryString["var"] != ""))
                return;
            this.Buscar(int.Parse(this.Request.QueryString["var"]), int.Parse(this.Request.QueryString["val"]));
        }
        private void Buscar(int par1, int par2)
        {
            try
            {
                var poliza = logicaConfiguracion.ObtenerDatosPoliza(par1, par2, out OC_DatosCuotas datosCuotas);
                if (poliza == null)
                    return;

                this.fc_inivig.Text = poliza.fc_inivig.ToString();
                this.fc_finvig.Text = poliza.fc_finvig.ToString();
                this.fc_emision.Text = poliza.fc_emision.ToString();
                this.num_poliza.Text = poliza.num_poliza;
                this.no_liquida.Text = poliza.no_liquida;
                this.prima_bruta.Text = poliza.prima_bruta.ToString();
                this.id_per.Value = poliza.id_perclie;
                this.id_gru.Value = poliza.id_gru.ToString();
                this.id_producto.Value = poliza.id_producto.ToString();
                this.id_spvs.Value = poliza.id_spvs;
                this.id_perejecu.Value = poliza.id_perejec;
                this.nomraz.Text = datosCuotas.NomCliente;
                this.desc_grupo.Text = datosCuotas.NomGrupo;
                this.desc_producto.Text = datosCuotas.NomProducto;
                this.nomco.Text = datosCuotas.NomCompania;
                this.nomejec.Text = datosCuotas.NombreEjecutivo;
                if (!(bool)poliza.clase_poliza)
                {
                    this.clase_poliza.Text = "Flotante";
                }
                else
                {
                    this.clase_poliza.Text = "Normal";
                }
                if (!(bool)poliza.tipo_cuota)
                {
                    this.tipo_cuota.Text = "Crédito";
                }
                else
                {
                    this.tipo_cuota.Text = "Contado";
                }
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
    }
}