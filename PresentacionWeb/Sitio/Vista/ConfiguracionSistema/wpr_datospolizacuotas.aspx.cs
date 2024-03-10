using Common;
using CrystalDecisions.ReportAppServer.DataDefModel;
using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace PresentacionWeb.Sitio.Vista.ConfiguracionSistema
{
    public partial class wpr_datospolizacuotas : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack || !(this.Request.QueryString["var"] != ""))
                return;

            int var = int.Parse(this.Request.QueryString["var"]);
            int val = int.Parse(this.Request.QueryString["val"]);
            this.Buscar(var, val);
            this.fc_reg.Value = DateTime.Today.Date.ToShortDateString();
            this.Grilla(var, val);
            this.id_poliza.Value = var.ToString();
            this.id_movimiento.Value = val.ToString();

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
                this.num_cuota.Text= poliza.num_cuota.ToString();
                
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
        protected void Grilla(int par1, int par2)
        {
            var listaCuotas = logicaConfiguracion.DatosGrid(par1, par2);
            Session["LST_CUOTAS"] = listaCuotas;
            this.gridcuotas.DataSource = listaCuotas;
            this.gridcuotas.DataBind();

            //this.gricuotas2.DataSource = listaCuotas;
            //this.gricuotas2.DataBind();
        }
        protected void gridcuotas_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<OcPolizasCuotas>)Session["LST_CUOTAS"];
            if (lstData != null)
            {
                this.gridcuotas.DataSource = lstData;
            }
        }
        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("wpr_listacuotas.aspx");
        }

        protected void img1_Click(object sender, EventArgs e)
        {
            ASPxButton boton = (ASPxButton)sender;
            var container = boton.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxDateEdit fecha = gridcuotas.FindRowCellTemplateControl(container.VisibleIndex, null, "fecha") as ASPxDateEdit;
            ASPxTextBox monto = gridcuotas.FindRowCellTemplateControl(container.VisibleIndex, null, "monto") as ASPxTextBox;
            var cuota = gridcuotas.GetRowValues(container.VisibleIndex, "cuota");

            if (!(fecha.Value is  DateTime))
            {
                lblerror.Text = "La fecha no es una fecha valida o correcta por favor verifiquelo antes de continuar";
                //lblerror.Text = "la fecha ingresada no esta en el formato correcto dd/mm/aaaa";
                popUpValidacion.ShowOnPageLoad = false;
                return;
            }

            string textControl2 = monto.Text;
            if (textControl2 != "0,00" && double.Parse(textControl2.Replace(".", "").Replace(",", ".")) > 0.0)
            {
                var id_poliza=int.Parse(this.id_poliza.Value);
                var id_movmiento=int.Parse(this.id_movimiento.Value);
                logicaConfiguracion.Cuotas(id_poliza, id_movmiento, (DateTime)fecha.Value ,decimal.Parse(textControl2),int.Parse(cuota.ToString()));
                Grilla(id_poliza, id_movmiento);
                ASPxSummaryItem cuotaTotal = gridcuotas.TotalSummary["cuota_total"];
                decimal sumatoriGrilla = Convert.ToDecimal(gridcuotas.GetTotalSummaryValue(cuotaTotal));
                decimal totalCampo = decimal.Parse(this.prima_bruta.Text);

                if (totalCampo == sumatoriGrilla)
                {
                    lblMensaje.Text= "Prima Total Igual a Prima cuotas\nSe han registrado correctamente todos los valores para la póliza ahora puede proceder a la verificación de la misma";
                    popUpConfirmacion.ShowOnPageLoad = true;
                }
                else
                {
                    lblerror.Text = "La Prima total es diferente de la suma\nLa Prima total es diferente de la suma de las cuotas por favor verifique este dato";
                    popUpValidacion.ShowOnPageLoad = true;
                }
            }
            else
            {
                lblerror.Text = "El monto para cuota debe ser mayor a cero";
                popUpValidacion.ShowOnPageLoad = false;
            }
        }

        protected void btncuotas_Click(object sender, EventArgs e)
        {
            try
            {
                string str = string.Empty;
                bool sw = false;
                if (this.num_cuota.Text.Trim().Length == 0)
                {
                    str += "Debe Registrar un valor para número de cuotas comprendido entre 1 y 12\n";
                    sw = true;
                }
                else if (!(int.Parse(this.num_cuota.Text) >= 1 &&  int.Parse(this.num_cuota.Text) <= 12))
                {
                    str += "Debe Registrar un valor para número de cuotas comprendido entre 1 y 12\n";
                    sw = true;
                }
                if (sw)
                {
                    lblerror.Text = "Los siguientes valores deben ser verificados antes de proseguir\n"+ str;
                    popUpValidacion.ShowOnPageLoad = true;
                }
                else
                {

                    logicaConfiguracion.ModificaCuota(int.Parse(this.id_poliza.Value), int.Parse(this.id_movimiento.Value), this.estado.Value.ToString(),int.Parse(this.num_cuota.Text));
                    this.lblmensajePantalla.Text = "Poliza Modificada";
                    this.Grilla(int.Parse(this.id_poliza.Value), int.Parse(this.id_movimiento.Value));
                }
            }
            catch (SecureExceptions secureException)
            {
                //this.lblmensaje.Text = "Verifique los Datos";
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
    }
}