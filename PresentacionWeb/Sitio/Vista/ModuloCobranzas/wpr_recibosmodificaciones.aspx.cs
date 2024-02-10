using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ModuloCobranzas
{
    public partial class wpr_recibosmodificaciones : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoModComision _objConsumoModComision = new ConsumoModComision();
        ConsumoValidarProd _objValidarProd = new ConsumoValidarProd();
        ConsumoCobranza conCobranza = new ConsumoCobranza();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                Combo();
               // fc_liq.Text = DateTime.Now.ToShortDateString();

            }
        }
        private void Combo()
        {
            try
            {
                var sucursal = _objConsumoRegistroProd.ObtenerLista("id_suc");
                id_suc.DataSource = sucursal;
                id_suc.TextField = "desc_param";
                id_suc.ValueField = "id_par";
                id_suc.DataBind();

                var dt = _objConsumoModComision.ObtenerAnio();
                this.año.DataSource = dt;
                this.año.TextField = "anio_recibo";
                this.año.ValueField = "anio_recibo";
                this.año.DataBind();

                var divisa = _objConsumoRegistroProd.ObtenerLista("id_div");
                id_div.DataSource = divisa;
                id_div.TextField = "abrev_param";
                id_div.ValueField = "id_par";
                id_div.DataBind();

                var apli = _objConsumoRegistroProd.ObtenerLista("id_apli");
                id_apli.DataSource = apli;
                id_apli.TextField = "desc_param";
                id_apli.ValueField = "id_par";
                id_apli.DataBind();

            }
            catch
            {
            }
        }

        protected void id_suc_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_perucb.Text = "";
            id_perucb.Items.Clear();
            var cobrador =_objConsumoRegistroProd.ObtenerCobrador(Convert.ToInt64( id_suc.Value));
            id_perucb.Items.Clear();
            id_perucb.DataSource = cobrador;
            id_perucb.TextField = "nomraz";
            id_perucb.ValueField = "id_per";
            id_perucb.DataBind();
            id_perucb.Text = "";


            
        }

        protected void id_perucb_SelectedIndexChanged(object sender, EventArgs e)
        {
            año.Text = "";
        }

        protected void año_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                var vaño = this.año.Value.ToString();
            var vid_recibo=id_recibo.Value.ToString();
            var vid_perucb = this.id_perucb.Value.ToString();
           
            var lstREcibo= _objConsumoModComision.ObtenerReciboM(vaño, vid_perucb);
            this.id_recibo.DataSource = lstREcibo;
            this.id_recibo.TextField = "id_recibo";
            this.id_recibo.ValueField = "id_recibo";
            this.id_recibo.DataBind();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                 pr_recibo prRecibo = new pr_recibo()
                    {
                        anio_recibo =Convert.ToDecimal( año.Value),
                        id_recibo =Convert.ToInt64( id_recibo.Value.ToString()),
                        fecha_cobro = fecha_cobro.Date,
                        monto_cobro = monto_cobro.Number,
                        monto_resto = monto_cobro.Number,
                        //recibo_por = recibo_por,
                        id_div = Convert.ToInt64( id_div.Value.ToString()),
                        //id_perclie = id_perucb.Value,
                        id_apli =Convert.ToInt64( id_apli.Value.ToString()),
                      
                    };
                if(_objConsumoModComision.ActualizarReciboM(prRecibo))
                {
                    lblMensaje.Text = "Actualización Realizada con éxito!";
                    imagenFail.Visible = false;
                    imagenOk.Visible = true;
                    pnlMensaje.ShowOnPageLoad = true;
                }
                else
                {
                    imagenFail.Visible = true;
                    imagenOk.Visible = false;
                    lblMensaje.Text = "Hubo un error al Actualizar los datos!";
                    pnlMensaje.ShowOnPageLoad = true;
                }


            }
            catch
            {
                //this.lblmensaje.Text = "Verifique los Datos no se Registro ningun Dato";
            }
        }

        protected void id_recibo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            pr_recibo prRecibo = new pr_recibo()
            {
                id_recibo =Convert.ToInt64( id_recibo.Value.ToString()),
                anio_recibo =Convert.ToDecimal( this.año.Value.ToString()),
                monto_cobro =Convert.ToDecimal( this.monto_cobro.Text),
                id_div =Convert.ToInt64( this.id_div.Value.ToString()),
                fecha_cobro = fecha_cobro.Date,
                id_apli =Convert.ToInt64( this.id_apli.Value.ToString())
            };
           var lstRecibo= _objConsumoModComision.ObtenerReciboMF(prRecibo).FirstOrDefault();
            this.monto_cobro.Number =(decimal) lstRecibo.monto_cobro;
            this.id_div.Value = lstRecibo.id_div;
            this.fecha_cobro.Date =(DateTime) lstRecibo.fecha_cobro;
            this.id_apli.Value = lstRecibo.id_apli;
        }
    }
}