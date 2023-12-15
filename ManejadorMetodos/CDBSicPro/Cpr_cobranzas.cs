using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_cobranzas
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_cobranzas(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion


        //public double Calculo1(object monto)
        //{
        //    double num = double.Parse(monto.ToString());
        //    DataTable dataTable = Formula1();
        //    double value;
        //    if ((bool)dataTable.Rows[0]["opera"])
        //    {
        //        value = num / double.Parse(dataTable.Rows[0]["evaluar"].ToString());
        //        return Math.Round(value, 2);
        //    }

        //    value = num * double.Parse(dataTable.Rows[0]["evaluar"].ToString());
        //    return Math.Round(value, 2);
        //}
        public decimal Com3(decimal primaBruta, long id_producto, string id_spvs1, bool tipoCuota)
        {
            decimal num = Calculo2(primaBruta, id_producto, id_spvs1, tipoCuota);
            var lstFormRiesgo = Formula1(id_producto, id_spvs1);
            decimal num2 = lstFormRiesgo.Select(s => s.comis_riesgo).FirstOrDefault();
            decimal plus_neta = Convert.ToDecimal(lstFormRiesgo.Select(s => s.plus_neta).FirstOrDefault());
            num2 = (num + plus_neta) * (num2 / 100);
            //DataTable dataTable = Formula1();
            //double num2 = double.Parse(dataTable.Rows[0]["comis_riesgo"].ToString());
            //num2 = (num + double.Parse(dataTable.Rows[0]["plus_neta"].ToString())) * (num2 / 100.0);
            num2 = Math.Round(num2, 2);
            return decimal.Parse($"{num2:n}");
        }

        public pr_polmov ValCom(int id_poliza, int id_mov)
        {
            try
            {
                var sql = _context.pr_polmov.Where(w => w.id_poliza == id_poliza && w.id_movimiento == id_mov).FirstOrDefault();
                return sql;

                //string sentenciaSQL = "SELECT * FROM pr_polmov WHERE id_poliza = " + id_poliza + " AND id_movimiento = " + id_mov;
                //Acceso acceso = new Acceso();
                //acceso.Conectar();
                //acceso.CrearComando(sentenciaSQL);
                //DataTable dataTable = acceso.Consulta();
                //acceso.Desconectar();
                //if (dataTable.Rows.Count > 0)
                //{
                //    prima_bruta.Text = string.Format("{0:n}", double.Parse(dataTable.Rows[0]["prima_bruta"].ToString()));
                //    prima_neta.Text = string.Format("{0:n}", double.Parse(dataTable.Rows[0]["prima_neta"].ToString()));
                //    por_comision.Text = string.Format("{0:n}", double.Parse(dataTable.Rows[0]["por_comision"].ToString()));
                //    comision.Text = string.Format("{0:n}", double.Parse(dataTable.Rows[0]["comision"].ToString()));
                //    return true;
                //}

                
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }

        public string Porco1(long idProducto, string idSpvs)
        {
            var lstFormula = Formula1(idProducto, idSpvs);
            string arg = Convert.ToString(lstFormula.Select(s => s.comis_riesgo).FirstOrDefault());
            //string arg = dataTable.Rows[0]["comis_riesgo"].ToString();
            return $"{arg:n}";
        }

        private List<vpr_formriesgo> Formula1(long idProducto, string idSpvs)
        {
            try
            {
                var sql = _context.vpr_formriesgo.Where(w => w.id_producto == idProducto && w.id_spvs == idSpvs).ToList();
                //string sentenciaSQL = "SELECT vpr_formriesgo.opera, evaluar, vpr_formriesgo.comis_riesgo, vpr_formriesgo.por_cred, vpr_formriesgo.plus_neta " +
                //    "FROM vpr_formriesgo WHERE vpr_formriesgo.id_producto = " + id_producto.Value + " " +
                //    "AND vpr_formriesgo.id_spvs = '" + id_spvs1.Value + "'";              
                return sql;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }

        public decimal Calculo2(decimal primaBruta, long id_producto, string id_spvs1, bool tipoCuota)
        {
            try
            {
                //double num = double.Parse(prima_bruta.Text.Replace(".", "").Replace(",", ""));
                if (id_spvs1 == "109" && id_producto == 32)
                {
                    primaBruta -= Convert.ToDecimal(232.56);
                }

                var response = _context.pr_calcfrmcred(id_producto, id_spvs1, primaBruta, tipoCuota).FirstOrDefault();
                return response == null ? 0: response.Value;
            }
            catch (Exception)
            {
                throw;
            }

            //double num = double.Parse(prima_bruta.Text.Replace(".", "").Replace(",", ""));
            //if (id_spvs1.Value == "109" && id_producto.Value == "32")
            //{
            //    num -= 232.56;
            //}

            //string sentenciaSQL = "SELECT pr_calcfrmcred(" + id_producto.Value + ",'" + id_spvs1.Value + "'," + num + "," + tipo_cuota.SelectedValue + ") AS prima_neta";
            //Acceso acceso = new Acceso();
            //acceso.Conectar();
            //acceso.CrearComando(sentenciaSQL);
            //DataTable dataTable = acceso.Consulta();
            //acceso.Desconectar();
            //double num2 = double.Parse(dataTable.Rows[0]["prima_neta"].ToString()) / 100.0;
            //return double.Parse($"{num2:n}");
        }

        //public bool InsertarPolizaIA(string variable)
        //{
        //    try
        //    {
        //        if (variable == "Normal")
        //        {
        //            variable = "True";
        //        }
        //        else if (variable == "Flotante")
        //        {
        //            variable = "False";
        //        }

        //        string sentenciaSQL = "UPDATE pr_poliza SET num_poliza='" + num_poliza1.Text + "', id_producto=" + id_producto.Value + ", id_perclie='" + id_perclie.Value + "', id_spvs='" + id_spvs1.Value + "', id_gru=" + id_gru1.Value + ", clase_poliza='" + variable + "', id_percart='" + id_percart1.Value + "' WHERE id_poliza=" + id_poliza.Value;
        //        Acceso acceso = new Acceso();
        //        acceso.Conectar();
        //        acceso.CrearComando(sentenciaSQL);
        //        acceso.EjecutarComando();
        //        acceso.Desconectar();
        //        return true;
        //    }
        //    catch (SecureExceptions original)
        //    {
        //        throw new SecureExceptions("Error al Generar la Transaccion", original);
        //    }
        //}

        //public bool InsertarPolizaMovIA(string variable, int id_movimiento)
        //{
        //    try
        //    {
        //        string sentenciaSQL = "UPDATE pr_polmov SET id_perejec='" + id_perejec.SelectedValue.ToString() + "', " +
        //            "fc_emision='" + Funciones.fc(fc_emision.Text) + "', fc_inivig='" + Funciones.fc(fc_inivig.Text) + "'" +
        //            ", fc_finvig='" + Funciones.fc(fc_finvig1.Text) + "'" +
        //            ", prima_bruta=" + prima_bruta.Text.Replace(".", "").Replace(",", ".") + "" +
        //            ", prima_neta=" + prima_neta.Text.Replace(".", "").Replace(",", ".") + ", por_comision=" + por_comision.Text.Replace(".", "").Replace(",", ".") + ", comision=" + comision.Text.Replace(".", "").Replace(",", ".") + ", id_div=" + id_div1.Value + ", tipo_cuota='" + variable + "', num_cuota=" + num_cuota.Text + ", id_clamov=" + id_clamov.Value + ", estado='" + estado.Value + "', id_dir=" + id_dir.Value + ", fc_recepcion='" + Funciones.fc(fc_recepcion.Text) + "', mat_aseg='" + mat_aseg.Text.ToUpper() + "', no_liquida='" + no_liquida.Text.ToUpper() + "', id_mom=" + id_mom.Value + " WHERE id_poliza=" + id_poliza.Value + " AND id_movimiento=" + id_movimiento;
        //        Acceso acceso = new Acceso();
        //        acceso.Conectar();
        //        acceso.CrearComando(sentenciaSQL);
        //        acceso.EjecutarComando();
        //        acceso.Desconectar();
        //        return true;
        //    }
        //    catch (SecureExceptions original)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", original);
        //    }
        //}


        public vcb_veripoliza1 ObtenerPolizaI(long id_poliza, long id_movimiento)
        {
            try
            {
                var sql = _context.vcb_veripoliza1.Where(w => w.id_poliza == id_poliza && w.id_movimiento == id_movimiento).FirstOrDefault();

                return sql;                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        

    }
} 
