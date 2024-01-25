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
    public partial class wgr_tc : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.Datos();
            this.Combo();
        }
        protected void Combo()
        {
            try
            {
                var list=logicaConfiguracion.Parametro("id_div");

                this.id_div.DataSource = list;
                this.id_div.DataTextField = "desc_param";
                this.id_div.DataValueField = "id_par";
                this.id_div.DataBind();
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void Datos()
        {
            try
            {
                List<gr_parametro> listParametro = new List<gr_parametro>();
                var list = logicaConfiguracion.Tasa(out listParametro);

                List<gridDivisa> listDivisa = new List<gridDivisa>();
                for (int i = 0; i < list.Count; i++)
                {
                    listDivisa.Add(new gridDivisa
                    {
                        divisa = listParametro[i].abrev_param,
                        fecha = list[i].fecha,
                        tasa = list[i].tcambio
                    });
                }

                this.gridtcambio.DataSource = listDivisa;
                this.gridtcambio.DataBind();
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            bool sw=false;
            string str = "";

            if (this.fecha.Text.Length < 10)
            {
                str += "<br /> La Fecha de emisión no esta en formato correcto (dd/mm/yyyy)";
                sw = true;
            }
            if (this.tcambio.Text == "0,00")
            {
                str += "<br /> Debe Registrar un Valor para la Tasa de Cambio";
                sw = true;
            }
            if (this.id_div.SelectedIndex == 0)
            {
                str += "<br /> Debe Seleccionar Una Divisa";
                sw = true;
            }
            if (sw)
            {
                lblerror.Text = str;
                popUpValidacion.ShowOnPageLoad = true;
            }
            else
            {
                gr_tc item=new gr_tc();
                item.tcambio = decimal.Parse(this.tcambio.Text);
                item.id_div = long.Parse( this.id_div.SelectedValue );
                item.fecha = DateTime.Parse(this.fecha.Text);

                logicaConfiguracion.InsertarTC(item);
                lblMensajePop.Text = "Tasa de Cambio Agregada Satisfactoriamente";
                popUpConfirmacion.ShowOnPageLoad = true;
                this.Datos();
            }
        }
    }
    public class gridDivisa
    {
        public DateTime fecha { get; set; }
        public decimal? tasa { get; set; }
        public string divisa { get; set; }
    }
}