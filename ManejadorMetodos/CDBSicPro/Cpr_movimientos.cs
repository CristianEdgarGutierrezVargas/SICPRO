using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_movimientos
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_movimientos(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public vpr_polrenovar ObtenerDatosRenPoliza(int id_poliza, int id_movimiento)
        {
            try
            {
                var sql = _context.vpr_polrenovar.Where(w=>w.id_poliza == id_poliza && w.id_movimiento == id_movimiento).FirstOrDefault();

                return sql;                               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        //public bool ObtenerDatosRenPoliza(int id_poliza, int id_movimiento)
        //{
        //    try
        //    {
        //        string sentenciaSQL = "SELECT * FROM vpr_polrenovar WHERE vpr_polrenovar.id_poliza = " + id_poliza + " AND vpr_polrenovar.id_movimiento=" + id_movimiento;
        //        Acceso acceso = new Acceso();
        //        acceso.Conectar();
        //        acceso.CrearComando(sentenciaSQL);
        //        DataTable dataTable = acceso.Consulta();
        //        acceso.Desconectar();
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            fc_inivig1.Text = dataTable.Rows[0]["fc_inivig"].ToString().Substring(0, 10);
        //            fc_finvig1.Text = dataTable.Rows[0]["fc_finvig"].ToString().Substring(0, 10);
        //            fc_emision1.Text = dataTable.Rows[0]["fc_emision"].ToString().Substring(0, 10);
        //            num_poliza.Text = dataTable.Rows[0]["num_poliza"].ToString();
        //            no_liquida1.Text = dataTable.Rows[0]["no_liquida"].ToString();
        //            prima_bruta1.Text = dataTable.Rows[0]["prima_bruta"].ToString();
        //            id_perclie.Value = dataTable.Rows[0]["id_perclie"].ToString();
        //            NomCliente(id_perclie.Value);
        //            id_gru.Value = dataTable.Rows[0]["id_gru"].ToString();
        //            NomGrupo(id_gru.Value);
        //            id_producto.Value = dataTable.Rows[0]["id_producto"].ToString();
        //            NomProducto(id_producto.Value);
        //            id_spvs.Value = dataTable.Rows[0]["id_spvs"].ToString();
        //            NomCompania(int.Parse(id_spvs.Value));
        //            if ((bool)dataTable.Rows[0]["clase_poliza"])
        //            {
        //                clase_poliza.Text = "Normal";
        //            }
        //            else
        //            {
        //                clase_poliza.Text = "Flotante";
        //            }

        //            id_perejecu.Value = dataTable.Rows[0]["id_perejec"].ToString();
        //            NombreEjecutivo(id_perejecu.Value);
        //            if ((bool)dataTable.Rows[0]["tipo_cuota"])
        //            {
        //                tipo_cuota.Text = "Contado";
        //            }
        //            else
        //            {
        //                tipo_cuota.Text = "Crédito";
        //            }

        //            return true;
        //        }

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return false;
        //    }
        //}

        public vpr_polrenovar ObtenerRenPoliza(int id_poliza, int id_movimiento)
        {
            try
            {
                var sql = _context.vpr_polrenovar.Where(w => w.id_poliza == id_poliza && w.id_movimiento == id_movimiento).FirstOrDefault();

                return sql;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


        //public void InsertarPolizaMovR(pr_polmov objMovimiento, List<pr_cuotapoliza> lstCuotaPoliza)
        //{
        //    try
        //    {



        //        bool variable
        //        string sentenciaSQL = "INSERT INTO pr_polmov VALUES (" + id_poliza.Value + ",default,'" 
        //            + id_perejec.SelectedValue.ToString() + "','" + Funciones.fc(fc_emision.Text) + "','" 
        //            + Funciones.fc(fc_inivig.Text) + "','" + Funciones.fc(fc_finvig.Text) + "'," 
        //            + prima_bruta.Text.Replace(".", "").Replace(",", ".") + "," 
        //            + prima_neta.Value + "," + por_comision.Value + ","
        //            + comision.Value + "," + id_div1.Value + ",'" + variable + "'," 
        //            + num_cuota.Text + "," + id_clamov.Value + ",'" + estado.Value + "'," 
        //            + id_dir.Value + ",'" + Funciones.fc(fc_recepcion.Text) + "','" 
        //            + mat_aseg.Text.ToUpper() + "','" + Funciones.fc(fc_reg.Value) + "','" 
        //            + no_liquida.Text.ToUpper() + "'," + id_mom.Value + ")";
        //        Acceso acceso = new Acceso();
        //        acceso.Conectar();
        //        acceso.CrearComando(sentenciaSQL);
        //        acceso.EjecutarComando();
        //        acceso.Desconectar();
        //        for (int i = 0; i < int.Parse(num_cuota.Text); i++)
        //        {
        //            sentenciaSQL = "INSERT INTO pr_cuotapoliza VALUES(" + id_poliza.Value + "," +
        //                "(SELECT MAX(pr_polmov.id_movimiento) AS numpoliza " +
        //                "FROM pr_poliza INNER JOIN pr_polmov " +
        //                "ON (pr_poliza.id_poliza = pr_polmov.id_poliza) " +
        //                "WHERE pr_poliza.num_poliza = '" + num_poliza.Text.ToUpper() + "')," + i + ")";
        //            acceso.Conectar();
        //            acceso.CrearComando(sentenciaSQL);
        //            acceso.EjecutarComando();
        //            acceso.Desconectar();
        //        }
        //    }
        //    catch (SecureExceptions original)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", original);
        //    }
        //}

        public pr_polmov RegistrarMovimiento(pr_polmov objMovimiento) 
        {
            try
            {
                var response = _context.pr_polmov.Add(objMovimiento);
                _context.SaveChanges();                                
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public vpr_polaplivar ObtenerApPoliza(int id_poliza, int id_movimiento)
        {
            try
            {
                var response = _context.vpr_polaplivar.Where(w=>w.id_poliza == id_poliza & w.id_movimiento == id_movimiento).FirstOrDefault();
                _context.SaveChanges();
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        //    public bool ObtenerApPoliza(int id_poliza, int id_movimiento)
        //{
        //    try
        //    {
        //        string sentenciaSQL = "SELECT * FROM vpr_polaplivar WHERE vpr_polaplivar.id_poliza = " + id_poliza + " AND vpr_polaplivar.id_movimiento = " + id_movimiento;
        //        Acceso acceso = new Acceso();
        //        acceso.Conectar();
        //        acceso.CrearComando(sentenciaSQL);
        //        DataTable dataTable = acceso.Consulta();
        //        acceso.Desconectar();
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            num_poliza.Text = dataTable.Rows[0]["num_poliza"].ToString();
        //            numpoliza.Value = dataTable.Rows[0]["num_poliza"].ToString();
        //            id_perclie.Value = dataTable.Rows[0]["id_perclie"].ToString();
        //            NomCliente(id_perclie.Value);
        //            fc_finvig1.Text = dataTable.Rows[0]["fc_finvig"].ToString().Substring(0, 10);
        //            id_gru.Value = dataTable.Rows[0]["id_gru"].ToString();
        //            NomGrupo(id_gru.Value);
        //            id_producto.Value = dataTable.Rows[0]["id_producto"].ToString();
        //            NomProducto(id_producto.Value);
        //            id_spvs.Value = dataTable.Rows[0]["id_spvs"].ToString();
        //            NomCompania(int.Parse(id_spvs.Value));
        //            id_dir.Value = dataTable.Rows[0]["id_dir"].ToString();
        //            NomDireccion(int.Parse(id_dir.Value));
        //            gr_persona gr_persona2 = new gr_persona();
        //            id_percart.Value = dataTable.Rows[0]["id_percart"].ToString();
        //            NombreAgente(id_percart.Value);
        //            gr_persona2.id_rol = id_perejec;
        //            gr_persona2.Persona(30);
        //            id_perejec.Text = dataTable.Rows[0]["id_perejec"].ToString();
        //            id_div1.Value = dataTable.Rows[0]["id_div"].ToString();
        //            NomDivisa(int.Parse(id_div1.Value));
        //            id_mom.Value = dataTable.Rows[0]["id_mom"].ToString();
        //            this.id_poliza.Value = dataTable.Rows[0]["id_poliza"].ToString();
        //            if ((bool)dataTable.Rows[0]["clase_poliza"])
        //            {
        //                clase_poliza.Text = "Normal";
        //            }
        //            else
        //            {
        //                clase_poliza.Text = "Flotante";
        //            }

        //            return true;
        //        }

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return false;
        //    }
        //}

    }
}
