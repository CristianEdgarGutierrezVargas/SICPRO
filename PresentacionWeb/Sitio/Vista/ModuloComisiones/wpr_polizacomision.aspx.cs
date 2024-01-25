using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ModuloComisiones
{
    public partial class wpr_polizacomision : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            // CargaInicial();
            if (!IsPostBack && base.Request.QueryString["var"] != "")
            {
                int num = int.Parse(base.Request.QueryString["var"]);
                int num1 = int.Parse(base.Request.QueryString["val"]);
                Movimiento(base.Request.QueryString["ver"]);


                id_poliza.Value = num.ToString();
                id_mov.Value = num1.ToString();



                var consumoValidar = _objConsumoValidarProd.ObtenerPolizaNRI(num, num1);
                if (consumoValidar != null)
                {
                    fc_emision.Text = consumoValidar.fc_emision.ToString("dd/MM/yyyy");
                    fc_recepcion.Text = consumoValidar.fc_recepcion.ToString("dd/MM/yyyy");
                    fc_inivig.Text = consumoValidar.fc_inivig.ToString("dd/MM/yyyy");
                    fc_finvig.Text = consumoValidar.fc_finvig.ToString("dd/MM/yyyy");
                    num_poliza.Text = consumoValidar.num_poliza;
                    no_liquidacion.Text = consumoValidar.no_liquida;
                    nomraz.Text = consumoValidar.nomraz;
                    id_per.Value = consumoValidar.id_perclie;
                    desc_direccion.Text = consumoValidar.direccion;
                    //id_direccion.Text = consumoValidar.id_dir.ToString();
                    cmbGrupo.Text = consumoValidar.id_gru.ToString();
                    id_spvs.Text = consumoValidar.id_spvs;

                    //cmbEjecutivo.Text = consumoValidar.id_perejec;
                    id_percart.Text = consumoValidar.id_percart.ToString();
                    clase_poliza.Text = (bool)consumoValidar.clase_poliza?"Normal":"Flotante";
                    prima_bruta.Text = consumoValidar.prima_bruta.ToString();
                    num_cuota.Text = consumoValidar.num_cuota.ToString();
                    id_div.Text = consumoValidar.id_div.ToString();
                    tipo_cuota.Text = (bool)consumoValidar.tipo_cuota?"Contado":"Crédito";
                    mat_aseg.Text = consumoValidar.mat_aseg;
                    //cmbProducto.Text = consumoValidar.id_producto.ToString();

                }
            }

        }
        private void Movimiento(string mov)
        {
            if (mov == "42")
            {
                titulo.Text = "Datos de Poliza Nueva (Módulo de Cobranzas)";
                id_clamov.Value = "42";
                return;
            }
            if (mov == "43")
            {
                titulo.Text = "Datos de Poliza Renovada (Módulo de Cobranzas)";
                id_clamov.Value = "43";
            }
        }

        #region Metodos

      

        private List<pr_cuotapoliza> GetDataCuotas(double numeroCuotas)
        {
            var lstCuotas = new List<pr_cuotapoliza>();
            for (int i = 0; i < numeroCuotas; i++)
            {
                var objCuotasPoliza = new pr_cuotapoliza();
                objCuotasPoliza.cuota = i;
                objCuotasPoliza.fecha_pago = DateTime.Now;
                objCuotasPoliza.cuota_total = 0;

                lstCuotas.Add(objCuotasPoliza);
            }
            return lstCuotas;


            //var lstActual = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            //if (lstActual == null)
            //{
            //    var lstCuotas = new List<pr_cuotapoliza>();
            //    for (int i = 0; i < numeroCuotas; i++)
            //    {
            //        var objCuotasPoliza = new pr_cuotapoliza();
            //        objCuotasPoliza.cuota = i;
            //        objCuotasPoliza.fecha_pago = DateTime.Now;
            //        objCuotasPoliza.cuota_total = 0;

            //        lstCuotas.Add(objCuotasPoliza);
            //    }
            //    return lstCuotas;
            //}
            //else
            //{
            //    ActualizaSessionCuotas();
            //    if (lstActual.Count == numeroCuotas)
            //    {
            //        return lstActual;
            //    }
            //    if (lstActual.Count < numeroCuotas)
            //    {
            //        var diferencia = numeroCuotas - lstActual.Count;

            //        for (int i = 1;i < diferencia; i++)
            //        {
            //            var objCuotasPoliza = new pr_cuotapoliza();
            //            objCuotasPoliza.cuota = i + lstActual.Count;
            //            objCuotasPoliza.fecha_pago = DateTime.Now;
            //            objCuotasPoliza.cuota_total = 0;

            //            lstActual.Add(objCuotasPoliza);
            //        }
            //    }
            //    if (lstActual.Count > numeroCuotas)
            //    {
            //        var diferencia = lstActual.Count - numeroCuotas;
            //        for (int i = 0; i < diferencia; i++)
            //        {
            //            lstActual.RemoveAt(lstActual.Count - 1);
            //        }
            //        return lstActual;
            //    }
            //}
            ////Session["LST_CUOTAS"] = lstCuotas;

            ////grdCuotas.DataBind();

            //return null;
        }

        private void LimpiarFormulario()
        {
            fc_emision.Text = string.Empty;
            fc_recepcion.Text = string.Empty;
            fc_inivig.Text = string.Empty;
            fc_finvig.Text = string.Empty;
            num_poliza.Text = string.Empty;
            no_liquidacion.Text = string.Empty;

            //cmbAsegurado.Text = string.Empty;
            //cmbDireccion.Text = string.Empty;
            
            //cmbGrupo.SelectedItem = cmbGrupo.Items.FindByValue("");

            //this.id_per.Text = string.Empty;
            //this.nomraz.Text = string.Empty;
            //this.fechaNacimiento.Text = string.Empty;
            //this.nit_fac.Text = string.Empty;

            //cmb_id_suc.SelectedItem = cmb_id_suc.Items.FindByValue(0);
            //cmb_id_sal.SelectedItem = cmb_id_sal.Items.FindByValue(Convert.ToInt64(0));
            //cmb_tipodoc.SelectedItem = cmb_tipodoc.Items.FindByValue(Convert.ToInt64(0));
            //cmb_tper.SelectedItem = cmb_tper.Items.FindByValue(Convert.ToInt64(0));
            //cmb_id_rol.SelectedItem = cmb_id_rol.Items.FindByValue(Convert.ToInt64(0));
            //cmb_id_emis.SelectedItem = cmb_id_emis.Items.FindByValue(Convert.ToInt64(0));

            //btnDirecciones.Visible = false;
            //btnNuevo.Visible = false;
        }

  

        private decimal ActualizaSessionCuotas()
        {
            var lstCuotasSession = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            decimal montoTotalSuma = 0;
            foreach (GridViewRow item in grdCuotasPoliza.Rows)
            {
                var cuota = Convert.ToDecimal(item.Cells[0].Text);
                var fechaPago = item.Cells[1].FindControl("dtFechaPago") as ASPxDateEdit;
                var cuotaTotal = item.Cells[2].FindControl("txtCuotaTotal") as ASPxSpinEdit;
                var itemSession = lstCuotasSession.Where(w => w.cuota == cuota).FirstOrDefault();

                itemSession.fecha_pago = fechaPago.Date;
                itemSession.cuota_total = Convert.ToDecimal(cuotaTotal.Text);

                montoTotalSuma += Convert.ToDecimal(cuotaTotal.Text);
            }
            Session["LST_CUOTAS"] = lstCuotasSession;
            return montoTotalSuma;
        }
        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../RegistroProduccion/wpr_poliza.aspx");

        }

        protected void btnCuotas_Click(object sender, EventArgs e)
        {
            var numeroCuotas = Convert.ToDouble(num_cuota.Text);
            var lstCuotas = GetDataCuotas(numeroCuotas);
            Session["LST_CUOTAS"] = lstCuotas;

            grdCuotasPoliza.DataSource = lstCuotas;
            grdCuotasPoliza.DataBind();

            //int id = 0;
            //lstCoutasTest.ForEach(s =>
            //{
            //    s.id_movimiento = 3;                
            //    s.cuota = id++;
            //});           
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sitio/Vista/Default.aspx");
        }


        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    //if there is an error
        //    if (errorFound == true)
        //    {
        //        //cancel the edit by setting editindex to -1 and rebind the grid
        //        GridView1.EditIndex = -1;
        //        BindData();

        //        //display the error in a label placed outside the grid
        //        Label1.Text = "There was an error";
        //        Label1.Visible = true;

        //        //or display javascript error message
        //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('There was an error');", true);

        //        //or do not set the editindex back to -1, but show an error in the edititem template itself
        //        GridViewRow row = GridView1.Rows[e.RowIndex];
        //        Label label = row.FindControl("Label2") as Label;
        //        label.Text = "There was an error in the textbox";
        //        label.Visible = true;
        //    }
        //}
        //protected pr_cuotapoliza UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
        //{
        //    var id = Convert.ToInt32(keys["cuota"]);
        //    var lstCuotas = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
        //    var item = lstCuotas.First(i => i.cuota == id);
        //    LoadNewValues(item, newValues);
        //    return item;
        //}

        //protected void LoadNewValues(pr_cuotapoliza item, OrderedDictionary values)
        //{
        //    item.id_poliza = Convert.ToInt64(values["id_poliza"]);
        //    item.id_movimiento = Convert.ToInt64(values["id_movimiento"]);
        //    item.cuota = Convert.ToDecimal(values["cuota"]);
        //    item.fecha_pago = Convert.ToDateTime(values["fecha_pago"]);
        //    item.cuota_total = Convert.ToDecimal(values["cuota_total"]);

        //    item.cuota_neta = Convert.ToDecimal(values["cuota_neta"]);
        //    item.cuota_comis = Convert.ToDecimal(values["cuota_comis"]);
        //    item.cuota_pago = Convert.ToDecimal(values["cuota_pago"]);
        //    item.cuota_comicob = Convert.ToDecimal(values["cuota_comicob"]);
        //}


      

        //protected void btnCuotasPoliza_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtNumCuotas.Text) || Convert.ToDecimal(txtNumCuotas.Text) == 0)
        //    {
        //        lblmensaje.Text = "El Numero de Cuotas no es valido";
        //        return;
        //    }

        //    var montoTotalSuma = ActualizaSessionCuotas();
        //    var lstCuotasSession = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
        //    if (montoTotalSuma != Convert.ToDecimal(txtPrimaBruta.Text))
        //    {
        //        grdCuotasPoliza.DataSource = lstCuotasSession;
        //        grdCuotasPoliza.DataBind();
        //        lblmensaje.Text = "La Prima total es diferente de la suma de las cuotas por favor verifique este dato";
        //        return;
        //    }
        //    else
        //    {
        //        //ActualizaSessionCuotas();
        //        if (_objConsumoRegistroProd.ExistePol(txtNroPoliza.Text, txtNroLiquidacion.Text))
        //        {
        //            lblmensaje.Text = "Datos existentes, Debe Verificar el Número de Póliza y Liquidación";
        //            return;
        //        }
        //        //else
        //        //{
        //        //    var numeroCuotas = Convert.ToDouble(txtNumCuotas.Text);

        //        var objPoliza = new pr_poliza();
        //        objPoliza.num_poliza = txtNroPoliza.Text;
        //        objPoliza.id_producto = Convert.ToInt64(cmbProducto.SelectedItem.Value);
        //        objPoliza.id_perclie = id_per.Value;//Convert.ToString(cmbAsegurado.SelectedItem.Value);

        //        objPoliza.id_spvs = Convert.ToString(cmbCiaAseg.SelectedItem.Value);
        //        objPoliza.id_gru = Convert.ToInt64(cmbGrupo.SelectedItem.Value);
        //        objPoliza.clase_poliza = Convert.ToBoolean(rbTipoPoliza.SelectedItem.Value);
        //        objPoliza.estado = true;
        //        objPoliza.fc_reg = DateTime.Now;
        //        objPoliza.id_percart = Convert.ToString(cmbAgente.SelectedItem.Value);// Convert.ToString(cmbTipoCartera.SelectedItem.Value);

        //        objPoliza.id_suc = Convert.ToInt64(Session["suc"]);

        //        var objResponse = _objConsumoRegistroProd.InsertarPoliza(objPoliza);

        //        pr_polmov prPolmov = new pr_polmov();

        //        prPolmov.id_poliza = objResponse.id_poliza;
        //        prPolmov.id_perejec = Convert.ToString(cmbEjecutivo.SelectedItem.Value);
        //        prPolmov.fc_emision = fc_emision.Date;
        //        prPolmov.fc_inivig = fc_inivig.Date;
        //        prPolmov.fc_finvig = fc_finvig.Date;
        //        prPolmov.prima_bruta = Convert.ToDecimal(txtPrimaBruta.Text);
        //        //prima_neta =  this.prima_neta,
        //        //por_comision = this.por_comision,
        //        //comision = this.comision,
        //        prPolmov.id_div = Convert.ToInt64(cmbDivisa.SelectedItem.Value);
        //        //num_cuota = intNumeroCuotas,
        //        //prPolmov.id_clamov = Convert.ToInt64(cmbTipoCartera.SelectedItem.Value);
        //        prPolmov.estado = "PRODUCCION"; //this.estado,
        //        prPolmov.id_dir = Convert.ToInt64(id_direccion.Value);// Convert.ToInt64(cmbDireccion.SelectedItem.Value);
        //        prPolmov.fc_recepcion = fc_recepcion.Date;
        //        prPolmov.mat_aseg = txtMatAseg.Text;
        //        prPolmov.fc_reg = DateTime.Now;
        //        prPolmov.no_liquida = txtNroLiquidacion.Text;
        //        prPolmov.num_cuota = Convert.ToDouble(txtNumCuotas.Text);
        //        //id_mom = this.id_mom


        //        var responsePolMov = _objConsumoRegistroProd.InsertarPolizaMovimiento(prPolmov);

        //        //    int idx = 0;
        //        //    var lstCoutas = GetDataCuotas(numeroCuotas);
        //        lstCuotasSession.ForEach(s =>
        //        {
        //            s.id_movimiento = responsePolMov.id_movimiento;
        //            s.id_poliza = objPoliza.id_poliza;
        //        });

        //        var responseSaveCuotas = _objConsumoRegistroProd.InsertarLstCuotasPoliza(lstCuotasSession);
        //        //}
        //        Session["POLIZA"] = objPoliza;
        //        Session["POLIZA_MOVIMIENTO"] = prPolmov;
        //        Response.Redirect("~/Sitio/Vista/RegistroProduccion/wpr_polizacobranzain.aspx?var=" + objPoliza.id_poliza + "&val=" + responsePolMov.id_movimiento + "&ver=0");
        //    }
        //}



       

      

    }
}