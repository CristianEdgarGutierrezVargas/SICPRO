using Common;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static EntidadesClases.CustomModelEntities.OC_DATA_FORM;

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

                var response = _context.pr_calcfrmcred(id_producto, id_spvs1, primaBruta, tipoCuota);
                return response == null ? 0 :  1;
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

        public vcb_veripoliza2 ObtenerPolizaAp(long id_poliza, long id_movimiento)
        {
            try
            {
                var sql = _context.vcb_veripoliza2.Where(w => w.id_poliza == id_poliza && w.id_movimiento == id_movimiento);//.FirstOrDefault();
                //string sentenciaSQL = "SELECT * FROM vcb_veripoliza2 WHERE vcb_veripoliza2.id_poliza = " + id_poliza + " AND vcb_veripoliza2.id_movimiento=" + id_movimiento;
                return sql.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public vcb_veripoliza3 ObtenerPolizaEA(long id_poliza, long id_movimiento)
        {
            try
            {
                var sql = _context.vcb_veripoliza3.Where(w => w.id_poliza == id_poliza && w.id_movimiento == id_movimiento);//.FirstOrDefault();
                //string sentenciaSQL = "SELECT * FROM vcb_veripoliza3 WHERE vcb_veripoliza3.id_poliza = " + id_poliza + " AND vcb_veripoliza3.id_movimiento=" + id_movimiento;                
                return sql.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            
        }

        public GetBisa_Result Bisa(string id_spvs, long id_poliza, long id_movimiento)
        {
            try
            {
                var sql = _context.GetBisa(id_spvs, id_poliza, id_movimiento).FirstOrDefault();

                return sql;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            //string sentenciaSQL = "SELECT SUM(pr_cuotapoliza.cuota_total) AS cuota_total_t, pr_polmov.num_cuota " +
            //    "FROM pr_poliza INNER JOIN pr_cuotapoliza ON (pr_poliza.id_poliza = pr_cuotapoliza.id_poliza) " +
            //    "INNER JOIN pr_polmov ON (pr_cuotapoliza.id_poliza = pr_polmov.id_poliza) AND (pr_cuotapoliza.id_movimiento = public.pr_polmov.id_movimiento) WHERE pr_poliza.id_spvs = '" + id_spvs.SelectedValue + "' AND pr_poliza.id_poliza = " + id_poliza + " AND pr_cuotapoliza.id_movimiento = " + id_movimiento + " AND pr_cuotapoliza.cuota > 0 GROUP BY public.pr_polmov.num_cuota";
           
        }

        //private DataTable Bisa1(int id_poliza, int id_movimiento)
        //{        //  

        //    string sentenciaSQL = "SELECT SUM(pr_cuotapoliza.cuota_total) AS cuota_total_t, pr_polmov.num_cuota " +
        //        "FROM pr_poliza INNER JOIN pr_cuotapoliza ON (pr_poliza.id_poliza = pr_cuotapoliza.id_poliza) INNER JOIN pr_polmov ON (pr_cuotapoliza.id_poliza = pr_polmov.id_poliza) AND (pr_cuotapoliza.id_movimiento = public.pr_polmov.id_movimiento) WHERE pr_poliza.id_spvs = '" + id_spvs1.Value + "' AND pr_poliza.id_poliza = " + id_poliza + " AND pr_cuotapoliza.id_movimiento = " + id_movimiento + " AND pr_cuotapoliza.cuota > 0 GROUP BY public.pr_polmov.num_cuota";
        //    Acceso acceso = new Acceso();
        //    acceso.Conectar();
        //    acceso.CrearComando(sentenciaSQL);
        //    return acceso.Consulta();
        //}

        public decimal? Prima_Neta1(int id_poliza, int id_movimiento, string id_spvs, double numCuota, decimal primaNeta)
        {
            double num = numCuota;
            num += -1.0;
            decimal num2 = primaNeta;
            decimal? num3 = 0;
            if (num == 0.0)
            {
                num3 = num2;
            }
            else
            {
                var response  = Bisa(id_spvs,id_poliza, id_movimiento);
                decimal? num4 = response.cuota_total_t;// double.Parse(dataTable.Rows[0][0].ToString());
                num3 = num2 - num4;
            }

            return num3;
        }

        public double Comision_Neta1(int id_poliza, int id_movimiento, string id_spvs,double comision)
        {
            var dataTable = Bisa(id_spvs, id_poliza, id_movimiento);
            double num = dataTable.num_cuota;// double.Parse(dataTable.Rows[0][1].ToString());
            //return (num * double.Parse(por_comision.Text) / 100.0).ToString();
            return (num * comision / 100.0);
        }
        public pr_formriesgo ComisionTotal(string id_spvs, long id_producto)
        {
            try
            {
                var sql = _context.pr_formriesgo.Where(w => w.id_spvs == id_spvs && w.id_producto == id_producto).FirstOrDefault();
                                
                return sql;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        //public string ComisionTotal1(int id_poliza, int id_movimiento, int id_producto)
        //{
        //    string sentenciaSQL = "SELECT pr_formriesgo.plus_neta FROM pr_formriesgo WHERE pr_formriesgo.id_spvs = '" + id_spvs1.Value + "' AND pr_formriesgo.id_producto = " + id_producto;
        //    Acceso acceso = new Acceso();
        //    acceso.Conectar();
        //    acceso.CrearComando(sentenciaSQL);
        //    DataTable dataTable = acceso.Consulta();
        //    Bisa1(id_poliza, id_movimiento);
        //    string s = Prima_Neta1(id_poliza, id_movimiento);
        //    return ((double.Parse(s) + double.Parse(dataTable.Rows[0][0].ToString())) * double.Parse(por_comision.Text) / 100.0).ToString();
        //}

        //public string Comision_Neta(int id_poliza, int id_movimiento)
        //{
        //    DataTable dataTable = Bisa(id_poliza, id_movimiento);
        //    double num = double.Parse(dataTable.Rows[0][1].ToString());
        //    return (num * double.Parse(por_comision.Text) / 100.0).ToString();
        //}

        //public string Comision_Neta1(int id_poliza, int id_movimiento)
        //{
        //    DataTable dataTable = Bisa1(id_poliza, id_movimiento);
        //    double num = double.Parse(dataTable.Rows[0][1].ToString());
        //    return (num * double.Parse(por_comision.Text) / 100.0).ToString();
        //}

        public PorcentajeComisionAnulacion Porcentuales(long idMovimiento)
        {
            try
            {
                var sql = _context.pr_polmov.Where(w => w.id_movimiento == idMovimiento)
                    .Select(s => new PorcentajeComisionAnulacion
                    { 
                         por_neta = Math.Round((s.prima_neta.Value/ s.prima_bruta),5),
                         por_comision = s.por_comision.Value
                        }
                    ).FirstOrDefault();

                return sql;
                //string sentenciaSQL = "SELECT round(pr_polmov.prima_neta / pr_polmov.prima_bruta,5) as porneta" +
                //", pr_polmov.por_comision FROM pr_polmov WHERE  pr_polmov.id_movimiento = " + idmom;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            
        }

        public bool InsertarPolizaCEA(pr_poliza objPrPoliza)
        {
            try
            {
                var sql = _context.pr_poliza.Where(w => w.id_poliza == objPrPoliza.id_poliza).FirstOrDefault();
                if (sql != null)
                {
                    sql.num_poliza = objPrPoliza.num_poliza;
                    sql.id_producto = objPrPoliza.id_producto;
                    sql.id_perclie = objPrPoliza.id_perclie;
                    sql.id_spvs = objPrPoliza.id_spvs;
                    sql.id_gru = objPrPoliza.id_gru;
                    sql.clase_poliza = objPrPoliza.clase_poliza;
                    sql.id_percart = objPrPoliza.id_percart;

                    _context.SaveChanges();
                    return true;
                }
                return false;
                //string sentenciaSQL = "UPDATE pr_poliza SET " +
                //    "num_poliza='" + num_poliza1.Text + "'" +
                //    ", id_producto=" + id_producto.Value + "" +
                //    ", id_perclie='" + id_perclie.Value + "'" +
                //    ", id_spvs='" + id_spvs1.Value + "'" +
                //    ", id_gru=" + id_gru1.Value + "" +
                //    ", clase_poliza='" + variable + "'" +
                //    ", id_percart='" + id_percart1.Value + "' " +
                //    "WHERE id_poliza=" + id_poliza.Value;
              
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Transaccion", original);
            }
        }

        public bool InsertarPolizaMovCEA1(pr_polmov objPolMov)
        {
            try
            {
                var sql = _context.pr_polmov.Where(w => w.id_poliza == objPolMov.id_poliza && w.id_movimiento == objPolMov.id_movimiento).FirstOrDefault();
                if (sql != null)
                {
                    sql.id_perejec = objPolMov.id_perejec;
                    sql.fc_emision = objPolMov.fc_emision;
                    sql.fc_inivig = objPolMov.fc_inivig;
                    sql.fc_finvig = objPolMov.fc_finvig;
                    sql.prima_bruta = Math.Abs((objPolMov.prima_bruta)*(-1));
                    sql.prima_neta = Math.Abs((objPolMov.prima_neta.Value) * (-1));
                    sql.por_comision = Math.Abs((objPolMov.por_comision.Value) * (-1));

                    sql.comision = Math.Abs((objPolMov.comision.Value) * (-1));
                    //sql.id_div = objPolMov.clase_poliza;
                    //sql.id_percart = objPolMov.id_percart;

                    _context.SaveChanges();
                    return true;
                }
                return false;

                //string sentenciaSQL = "UPDATE pr_polmov SET " +
                //    "id_perejec='" + id_perejec.SelectedValue.ToString() + "'" +
                //    ", fc_emision='" + Funciones.fc(fc_emision.Text).ToString() + "'" +
                //    ", fc_inivig='" + Funciones.fc(fc_inivig.Text).ToString() + "'" +
                //    ", fc_finvig='" + Funciones.fc(fc_finvig.Text).ToString() + "'" +
                //    ", prima_bruta=abs(" + prima_bruta.Text.Replace(".", "").Replace(",", ".") + ")*(-1)" +
                //    ", prima_neta=abs(" + prima_neta.Text.Replace(".", "").Replace(",", ".") + ")*(-1)" +
                //    ", por_comision=" + por_comision.Text.Replace(".", "").Replace(",", ".") + "" +
                //    ", comision=abs(" + comision.Text.Replace(".", "").Replace(",", ".") + ")*(-1)" +
                //    ", id_div=" + id_div1.Value + "" +
                //    ", tipo_cuota='" + variable + "'" +
                //    ", num_cuota=0" +
                //    ", id_clamov=" + id_clamov.Value + "" +
                //    ", estado='" + estado.Value + "', id_dir=" + id_dir.Value + "" +
                //    ", fc_recepcion='" + Funciones.fc(fc_recepcion.Text).ToString() + "'" +
                //    ", mat_aseg='" + mat_aseg.Text.ToUpper() + "'" +
                //    ", no_liquida='" + no_liquida.Text.ToUpper() + "'" +
                //    ", id_mom=" + id_mom.Value + " " +
                //    "WHERE id_poliza=" + id_poliza.Value + " AND id_movimiento=" + id_movimiento;
              
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }
    }
} 
