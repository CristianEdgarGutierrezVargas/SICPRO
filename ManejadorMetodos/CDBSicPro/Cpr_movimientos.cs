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

    }
}
