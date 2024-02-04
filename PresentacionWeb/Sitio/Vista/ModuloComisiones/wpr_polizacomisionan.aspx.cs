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
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ModuloComisiones
{
    public partial class wpr_polizacomisionan : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();
        ConsumoModComision _objConsumoModCom = new ConsumoModComision();
        private bool sw = false;
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



                var consumoValidar = _objConsumoModCom.VcoObtenerPolizaNRI3(num, num1);
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
                    cmbGrupo.Text = Grupo(consumoValidar.id_gru.ToString());
                    id_spvs.Text = CompaniaAseg( consumoValidar.id_spvs);
                    var objParametro = _objConsumoModCom.ObtenerParametro(Convert.ToInt32( consumoValidar.id_div.ToString()));
                    id_perejec.Text =Ejecutivo( consumoValidar.id_perejec);
                    id_percart.Text = AgenteCartera( consumoValidar.id_percart.ToString());
                    clase_poliza.Text = (bool)consumoValidar.clase_poliza?"Normal":"Flotante";
                    prima_bruta.Text = consumoValidar.prima_bruta.ToString();
                    num_cuota.Text = consumoValidar.num_cuota.ToString();
                    id_div.Text = objParametro.abrev_param;
                    prima_neta.Text= consumoValidar.prima_neta.ToString();
                    por_comision.Text= consumoValidar.por_comision.ToString();
                    comision.Text= consumoValidar.comision.ToString();
                    tipo_cuota.Text = (bool)consumoValidar.tipo_cuota ? "Contado" : "Crédito";
                    mat_aseg.Text = consumoValidar.mat_aseg;
                    id_producto.Text =NombreProducto( consumoValidar.id_producto.ToString());
                    Grid(num, num1);
                }
            }

        }
        private void Movimiento(string mov)
        {
          
            if (mov == "49")
            {
                titulo.Text = "Datos de Poliza Anulada (Módulo de Comisiones)";
                id_clamov.Value = "49";
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

  

        //private decimal ActualizaSessionCuotas()
        //{
        //    var lstCuotasSession = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
        //    decimal montoTotalSuma = 0;
        //    foreach (GridViewRow item in grdCuotasPoliza.Rows)
        //    {
        //        var cuota = Convert.ToDecimal(item.Cells[0].Text);
        //        var fechaPago = item.Cells[1].FindControl("dtFechaPago") as ASPxDateEdit;
        //        var cuotaTotal = item.Cells[2].FindControl("txtCuotaTotal") as ASPxSpinEdit;
        //        var itemSession = lstCuotasSession.Where(w => w.cuota == cuota).FirstOrDefault();

        //        itemSession.fecha_pago = fechaPago.Date;
        //        itemSession.cuota_total = Convert.ToDecimal(cuotaTotal.Text);

        //        montoTotalSuma += Convert.ToDecimal(cuotaTotal.Text);
        //    }
        //    Session["LST_CUOTAS"] = lstCuotasSession;
        //    return montoTotalSuma;
        //}
        #endregion
        private void Grid(long par1, long par2)
        {
            var lstcuotas=_objConsumoModCom.ObtenerGridA(par1, par2);
            
            this.grdCuotasPoliza.DataSource = lstcuotas;
            this.grdCuotasPoliza.DataBind();
        }
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



        public string Grupo(string num)
        {

            if (num == null)
                return "SIN GRUPO";
            if (Convert.ToInt32(num) == 0)
                return "SIN GRUPO";

            string descGrupo = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idGrupo = Convert.ToInt64(num.ToString());
                descGrupo = _objConsumoValidarProd.objGrupoById(idGrupo).desc_grupo;
            }
            return descGrupo;
        }
        public string CompaniaAseg(string num)
        {
            if (num == null)
                return "";
            string descCompania = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {

                descCompania = _objConsumoValidarProd.GetDescCompaniaById(num.ToString());
            }
            return descCompania;
        }
        public string NombreProducto(string num)
        {
            if (num == null)
                return "";
            string descProducto = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idProducto = Convert.ToInt64(num.ToString());
                descProducto = _objConsumoValidarProd.GetProductoById(idProducto).desc_prod;
            }
            return descProducto;
        }
        public string TipoPoliza(string num)
        {
            if (num == null)
                return "";
            string descProducto = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idProducto = Convert.ToInt64(num.ToString());
                var tipo = _objConsumoValidarProd.GetPolizaByIdPoliza(idProducto).clase_poliza;
                if ((bool)tipo)
                    descProducto = "Normal";
                else descProducto = "Flotante";

            }
            return descProducto;
        }
        public string FormaPago(string num)
        {
            if (num == null)
                return "";
            string formaPago = "";
            if (Convert.ToBoolean(num.ToString()))

                formaPago = "Contado";
            else formaPago = "Crédito";


            return formaPago;
        }
        public string Ejecutivo(string num)
        {
            if (num == null)
                return "";
            string nomEjecutivo = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idEjecutivo = num.ToString();
                nomEjecutivo = _objConsumoValidarProd.GetPersonaById(idEjecutivo).nomraz;
            }
            return nomEjecutivo;
        }

        public string AgenteCartera(string num)
        {
            if (num == null)
                return "";
            string nomEjecutivo = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idAgente = num.ToString();
                var lstPersona = _objConsumoModCom.Persona(60);
                 nomEjecutivo = lstPersona.Where(x => x.id_per == idAgente).FirstOrDefault().nomraz;
            }
            return nomEjecutivo;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BootstrapButton button = sender as BootstrapButton;
            var container = button.NamingContainer as GridViewDataItemTemplateContainer;
            string[] valores = container.KeyValue.ToString().Split('|');

            //TextBox str = (TextBox)item.FindControl("monto_anulada");
            //TextBox textBox = (TextBox)item.FindControl("neta_anulada");
            //TextBox str1 = (TextBox)item.FindControl("comision_anulada");

           BootstrapSpinEdit str = grdCuotasPoliza.FindRowCellTemplateControl(container.VisibleIndex, null, "txtCuotaTotal") as BootstrapSpinEdit;
            BootstrapSpinEdit textBox = grdCuotasPoliza.FindRowCellTemplateControl(container.VisibleIndex, null, "txtCuotaNeta") as BootstrapSpinEdit;
            BootstrapSpinEdit str1 = grdCuotasPoliza.FindRowCellTemplateControl(container.VisibleIndex, null, "txtCuotaComis") as BootstrapSpinEdit;


             
            pr_anulada opr_anulada = new pr_anulada()
                {
                    id_poliza = Convert.ToInt64( id_poliza.Value.ToString()),
                    id_movimiento = Convert.ToInt64( id_mov.Value.ToString()),
                    monto_anulada = Convert.ToDecimal( str.Text),
                    neta_anulada = Convert.ToDecimal(textBox),
                    comision_anulada = Convert.ToDecimal(str1)
                };
                _objConsumoModCom.ModificarCuotaPolizaCA(opr_anulada);
                
                this.btnsalir.Visible = true;
            

            //BootstrapButton button = sender as BootstrapButton;
            //var container = button.NamingContainer as GridViewDataItemTemplateContainer;
            //string[] valores = container.KeyValue.ToString().Split('|');

            //BootstrapDateEdit textBox = grdCuotasPoliza.FindRowCellTemplateControl(container.VisibleIndex, null, "dtFechaPago") as BootstrapDateEdit;
            //BootstrapSpinEdit textBox1 = grdCuotasPoliza.FindRowCellTemplateControl(container.VisibleIndex, null, "txtCuotaTotal") as BootstrapSpinEdit;
            //BootstrapSpinEdit textBox2 = grdCuotasPoliza.FindRowCellTemplateControl(container.VisibleIndex, null, "txtCuotaNeta") as BootstrapSpinEdit;
            //BootstrapSpinEdit textBox3 = grdCuotasPoliza.FindRowCellTemplateControl(container.VisibleIndex, null, "txtCuotaComis") as BootstrapSpinEdit;

            //ASPxGridView column = grdCuotasPoliza;
            //GridViewColumn columnTotal = column.Columns["cuota_total"];
            //GridViewColumn columnNeta = column.Columns["cuota_neta"];
            //GridViewColumn columnComis = column.Columns["cuota_comis"];
            //BootstrapSpinEdit textBox4 = column.FindFooterCellTemplateControl(columnTotal, "TotalCuotaTotal") as BootstrapSpinEdit;
            //BootstrapSpinEdit textBox5 = column.FindFooterCellTemplateControl(columnNeta,"TotalCuotaNeta") as BootstrapSpinEdit;
            //BootstrapSpinEdit textBox6 = column.FindFooterCellTemplateControl(columnComis,"TotalCuotaComis") as BootstrapSpinEdit;

            //var numcuota = valores[0];


            //pr_cuotapoliza prComisione = new pr_cuotapoliza()
            //{
            //    id_poliza = Convert.ToInt64(id_poliza.Value.ToString()),
            //    id_movimiento = Convert.ToInt64(id_mov.Value.ToString()),
            //    fecha_pago = textBox.Date,
            //    cuota_total = textBox1.Number,
            //    cuota_neta = textBox2.Number,
            //    cuota_comis = textBox3.Number,
            //    cuota= Convert.ToDecimal( numcuota)
            //};
            //if (_objConsumoModCom.ModificarCuotaPolizaC(prComisione))
            //{
            //    this.grdCuotasPoliza_DataBound(sender, e);
            //    string str = "";
            //    if (this.prima_bruta.Text != textBox4.Text)
            //    {
            //        //textBox4.ControlStyle.BackColor = Color.FromArgb(255, 196, 196);
            //        str = string.Concat(str, "<br/>La suma de las Cuotas no es igual al Total de la Prima");

            //        this.sw = false;
            //    }
            //    //else
            //    //{
            //    //    textBox4.ControlStyle.BackColor = Color.FromArgb(168, 255, 168);
            //    //}
            //    if (this.prima_neta.Text != textBox5.Text)
            //    {
            //       // textBox5.ControlStyle.BackColor = Color.FromArgb(255, 196, 196);
            //        str = string.Concat(str, "<br/>La suma de las Primas Netas no es igual al Total de la Prima Neta");
            //        this.sw = false;
            //    }
            //    //else
            //    //{
            //    //    textBox5.ControlStyle.BackColor = Color.FromArgb(168, 255, 168);
            //    //}
            //    if (this.comision.Text != textBox6.Text)
            //    {
            //        //textBox6.ControlStyle.BackColor = Color.FromArgb(255, 196, 196);
            //        str = string.Concat(str, "<br/>La suma de las Comisiones no es igual al Total de la Comisión");
            //        this.sw = false;
            //    }
            //    //else
            //    //{
            //    //    textBox6.ControlStyle.BackColor = Color.FromArgb(168, 255, 168);
            //    //}
            //    if ((this.prima_bruta.Text == textBox4.Text) & (this.prima_neta.Text == textBox5.Text) & (this.comision.Text == textBox6.Text))
            //    {
            //        this.sw = true;
            //    }
            //    if (this.sw)
            //    {

            //        var strmensaje="Se han registrado correctamente todos los valores para la Póliza";
            //      //mostrart popup de mensaje
            //        this.btnsalir.Visible = true;
            //    }
            //    else if (!this.sw && this.grdCuotasPoliza.VisibleRowCount == container.VisibleIndex + 1)
            //    {

            //        var strMensaje="Validación de Valores";

            //    }
            //    this.sw = false;
            //}
            //else
            //{
            //    return;
            //}


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                pr_polmov opr_polmov = new pr_polmov()
                {
                    estado = estado.Value,
                    id_movimiento = Convert.ToInt64(id_mov.Value.ToString()),
                    id_poliza = Convert.ToInt64(id_poliza.Value.ToString())
                };
                _objConsumoModCom.ActualizaPolizaMov(opr_polmov);

                this.lblmensaje.Text = "Póliza Verificada";
                this.grdCuotasPoliza.Columns[5].Visible = false;
            }
            catch
            {
            }
        }

        protected void grdCuotasPoliza_DataBound(object sender, EventArgs e)
        {

        }

        protected void btnsalir_Click1(object sender, EventArgs e)
        {

        }
        // var lstPersona = consumoMod.Persona(60);
        protected object GetGroupCuotaComisValue(GridViewGroupFooterCellTemplateContainer container)
        {
            var summaryItem = grdCuotasPoliza.GroupSummary.First(i => i.Tag == "GroupCuotaComis");
            return grdCuotasPoliza.GetGroupSummaryValue(container.VisibleIndex, summaryItem);
        }
        protected object GetTotalCuotaComisValue()
        {
            var summaryItem = grdCuotasPoliza.TotalSummary.First(i => i.Tag == "TotalCuotaComis");
            return grdCuotasPoliza.GetTotalSummaryValue(summaryItem);
        }

        protected object GetGroupCuotaNetaValue(GridViewGroupFooterCellTemplateContainer container)
        {
            var summaryItem = grdCuotasPoliza.GroupSummary.First(i => i.Tag == "GroupCuotaNeta");
            return grdCuotasPoliza.GetGroupSummaryValue(container.VisibleIndex, summaryItem);
        }
        protected object GetTotalCuotaNetaValue()
        {
            var summaryItem = grdCuotasPoliza.TotalSummary.First(i => i.Tag == "TotalCuotaNeta");
            return grdCuotasPoliza.GetTotalSummaryValue(summaryItem);
        }

        protected object GetGroupCuotaTotalValue(GridViewGroupFooterCellTemplateContainer container)
        {
            var summaryItem = grdCuotasPoliza.GroupSummary.First(i => i.Tag == "GroupCuotaTotal");
            return grdCuotasPoliza.GetGroupSummaryValue(container.VisibleIndex, summaryItem);
        }
        protected object GetTotalCuotaTotalValue()
        {
            var summaryItem = grdCuotasPoliza.TotalSummary.First(i => i.Tag == "TotalCuotaTotal");
            return grdCuotasPoliza.GetTotalSummaryValue(summaryItem);
        }
    }
}