﻿using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ModuloComisiones
{
    public partial class wco_presprod : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();
        ConsumoModComision _objModComision=new ConsumoModComision();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var lstAgenteCartera = _objConsumoRegistroProd.Persona(60);
                id_percart.DataSource = lstAgenteCartera;
                id_percart.TextField = "nomraz";
                id_percart.ValueField = "id_per";
                id_percart.DataBind();

                var sucursal = _objConsumoRegistroProd.ObtenerLista("id_suc");
                id_suc.DataSource = sucursal;
                id_suc.TextField = "desc_param";
                id_suc.ValueField = "id_par";
                id_suc.DataBind();
            }
        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/wco_presprod.aspx");
        }

        protected void btn_insertar_Click(object sender, EventArgs e)
        {
            if (monto_proy.Text == "0,00")
            {

                imagenOk.Visible = false;
                imagenFail.Visible = true;
                lblMensaje.Text = "Debe Seleccionar todos los valores y asignar un valor diferente de cero en monto de presupuesto";
                pnlMensaje.ShowOnPageLoad = true;

               
            }
        
            co_presprod coPresprod = new co_presprod()
            {
                anio_proy = anio_proy.Text,
                id_percart = id_percart.Value.ToString(),
                monto_proy = Convert.ToDecimal(monto_proy.Text),
                monto_cproy = Convert.ToDecimal(monto_cproy.Text),
                id_suc = Convert.ToInt32(id_suc.Value.ToString()),
                mes_proy = mes_proy.Value.ToString(),

            };
          
            if (!_objModComision.InsertarPres(coPresprod))
            {
                imagenOk.Visible = false;
                imagenFail.Visible = true;
                lblMensaje.Text = "No Insertado";
                pnlMensaje.ShowOnPageLoad = true;
            }
         
            Grilla();
            pnlGrid.Visible = true;
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            co_presprod coPresprod = new co_presprod()
            {
                anio_proy = anio_proy.Text,
                id_percart = id_percart.Value.ToString(),
                monto_proy = Convert.ToDecimal( monto_proy.Text),
                monto_cproy = Convert.ToDecimal(monto_cproy.Text),
                id_suc =Convert.ToInt32(id_suc.Value.ToString()),
                mes_proy = mes_proy.Value.ToString(),
                
            };
            if( !_objModComision.modifPres(coPresprod))
            {
                imagenOk.Visible = false;
                imagenFail.Visible = true;
                lblMensaje.Text = "No Insertado";
                pnlMensaje.ShowOnPageLoad = true;
            }
          Grilla();
            pnlGrid.Visible = true;
        }

        protected void btnsalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }

        protected void Grilla()
        {
            return;
            //co_presprod coPresprod = new co_presprod()
            //{
            //    anio_proy = this.anio_proy,
            //    id_percart = this.id_percart,
            //    grdcuotas = this.grdproy
            //};
            //coPresprod.GridCuotas();
        }
    }
}