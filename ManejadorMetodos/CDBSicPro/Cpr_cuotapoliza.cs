using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_cuotapoliza
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_cuotapoliza(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public pr_cuotapoliza InsertarCuotaPoliza(pr_cuotapoliza objPrCuotaPoliza)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_cuotapoliza.Add(objPrCuotaPoliza);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return objPrCuotaPoliza;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        public bool InsertarLstCuotaPoliza(List<pr_cuotapoliza> lstPrCuotaPoliza)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_cuotapoliza.AddRange(lstPrCuotaPoliza);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool ActualizarCuotaPoliza(pr_cuotapoliza objPrCuotaPoliza)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_cuotapoliza.Where(w => w.id_poliza == objPrCuotaPoliza.id_poliza
                    && w.id_movimiento == objPrCuotaPoliza.id_movimiento && w.cuota == objPrCuotaPoliza.cuota).FirstOrDefault();

                    sql.fecha_pago = objPrCuotaPoliza.fecha_pago;
                    sql.cuota_total = objPrCuotaPoliza.cuota_total;
                    sql.cuota_neta = 0;
                    sql.cuota_comis = 0;
                    sql.cuota_pago = 0;
                    sql.cuota_comicob = 0;

                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public List<pr_cuotapoliza> GridCuotasC(long idPoliza, long IdMovimiento)
        {
            try
            {
                var sql = _context.pr_cuotapoliza.Where(w => w.id_poliza == idPoliza && w.id_movimiento == IdMovimiento).ToList()

                    .Select(s => new pr_cuotapoliza()
                    {
                        id_poliza = s.id_poliza,
                        id_movimiento = s.id_movimiento,
                        cuota = s.cuota,
                        fecha_pago = s.fecha_pago,
                        cuota_total = s.cuota_total,
                        cuota_neta = s.cuota_neta == null ? 0 : s.cuota_neta,
                        cuota_comis = s.cuota_comis == null ? 0 : s.cuota_comis,
                        cuota_pago = s.cuota_pago == null ? 0 : s.cuota_pago,
                        cuota_comicob = s.cuota_comicob == null ? 0 : s.cuota_comicob,
                    }).ToList();
                //string sentenciaSQL = "SELECT pr_cuotapoliza.cuota, pr_cuotapoliza.fecha_pago, pr_cuotapoliza.cuota_total, " +
                //    "pr_cuotapoliza.cuota_neta, pr_cuotapoliza.cuota_comis FROM pr_cuotapoliza " +
                //    "WHERE pr_cuotapoliza.id_poliza = " + id_poliza.Value + " " +
                //    "AND pr_cuotapoliza.id_movimiento = " + id_movimiento.Value + " ORDER BY pr_cuotapoliza.cuota";

                return sql;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }

        public List<pr_cuotapoliza> GridCuotas()
        {
            try
            {
                var sql = _context.pr_cuotapoliza.ToList();
                return sql;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }

        public bool ModificarCuotaPolizaC(pr_cuotapoliza objPrCuotaPoliza)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_cuotapoliza.Where(w => w.id_poliza == objPrCuotaPoliza.id_poliza
                    && w.id_movimiento == objPrCuotaPoliza.id_movimiento
                    && w.cuota == objPrCuotaPoliza.cuota
                    ).FirstOrDefault();

                    if (sql != null)
                    {
                        sql.fecha_pago = objPrCuotaPoliza.fecha_pago;
                        sql.cuota_total = objPrCuotaPoliza.cuota_total;
                        sql.cuota_neta = objPrCuotaPoliza.cuota_neta;
                        sql.cuota_comis = objPrCuotaPoliza.cuota_comis;
                    }
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public List<pr_polmov> DatosPolizaEA(long id_mom, long longIdPoliza)
        {
            try
            {
                var sql = _context.pr_polmov.Where(w => w.id_mom == id_mom && w.id_poliza == longIdPoliza
                //&& w.id_clamov != 46 &&w.id_clamov != 49 
                ).OrderBy(ob => ob.id_movimiento).ToList();
                return sql;
                //string sentenciaSQL = "SELECT pr_polmov.no_liquida, pr_polmov.id_movimiento FROM pr_polmov " +

            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al generear la Consulta", original);
            }
        }

        public List<pr_cuotapoliza> ListaC(long id_poliza, long id_mov)
        {
            try
            {
                var sql = _context.pr_cuotapoliza.Where(w => w.id_poliza == id_poliza && w.id_movimiento == id_mov).OrderBy(ob => ob.cuota).ToList();
                return sql;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al generear la Consulta", original);
            }
            //string sentenciaSQL = "SELECT to_char(pr_cuotapoliza.cuota,'99') AS cuota1, pr_cuotapoliza.cuota FROM pr_cuotapoliza" +
            //    " WHERE id_poliza =" + id_poliza + " AND id_movimiento=" + id_mov + " " +
            //    "UNION SELECT 'SEL. UNA OPCIÓN', -1 order by cuota";

        }

        public GetBuscarCuotaPolizaC_Result BuscarCuotaPolizaC(long id_poliza, long id_mov, int cuota)
        {
            try
            {
                var sql = _context.GetBuscarCuotaPolizaC(id_poliza, id_mov, cuota).FirstOrDefault();
                return sql;

                //string sentenciaSQL = "SELECT pr_cuotapoliza.cuota, pr_cuotapoliza.fecha_pago" +
                //    ", pr_cuotapoliza.cuota_total, pr_cuotapoliza.cuota_neta, pr_cuotapoliza.cuota_comis" +
                //    ", pr_cuotapoliza.cuota_pago, COALESCE(sum(pr_devolucion.monto_devolucion),0) AS monto_devolucion" +
                //    ", COALESCE(sum(pr_excluida.monto_exclusion),0) AS monto_exclusion" +
                //    ", COALESCE(SUM(pr_excluida.neta_exclusion),0) AS neta_exclusion" +
                //    ", COALESCE(SUM(pr_excluida.comision_exclusion),0) AS comision_exclusion " +
                //    "FROM pr_cuotapoliza LEFT OUTER JOIN pr_excluida " +
                //    "ON (pr_cuotapoliza.id_poliza = pr_excluida.id_poliza) " +
                //    "AND (pr_cuotapoliza.id_movimiento = pr_excluida.id_movimiento)" +
                //    " AND (pr_cuotapoliza.cuota = pr_excluida.excluye_cuota) " +
                //    "LEFT OUTER JOIN pr_devolucion ON (pr_excluida.id_poliza = pr_devolucion.id_poliza) " +
                //    "AND (pr_excluida.id_movimiento = pr_devolucion.id_movimiento) " +
                //    "AND (pr_excluida.id_excluye = pr_devolucion.id_devolucion) " +
                //    "AND (pr_excluida.excluye_cuota = pr_devolucion.cuota_devolucion) " +
                //    "WHERE pr_cuotapoliza.id_poliza =" + id_poliza + " " +
                //    "AND pr_cuotapoliza.id_movimiento=" + id_mov + " AND pr_cuotapoliza.cuota = " + cuota + " GROUP BY pr_cuotapoliza.cuota, pr_cuotapoliza.fecha_pago, pr_cuotapoliza.cuota_total, pr_cuotapoliza.cuota_neta, pr_cuotapoliza.cuota_comis,  pr_cuotapoliza.cuota_pago";
                //Acceso acceso = new Acceso();
                //acceso.Conectar();
                //acceso.CrearComando(sentenciaSQL);
                //DataTable dataTable = acceso.Consulta();
                //acceso.Desconectar();
                //if (dataTable.Rows.Count > 0)
                //{
                //    fecha_pago.Text = dataTable.Rows[0]["fecha_pago"].ToString().Substring(0, 10);
                //    cuota_total.Text = (double.Parse(dataTable.Rows[0]["cuota_total"].ToString()) + double.Parse(dataTable.Rows[0]["monto_exclusion"].ToString())).ToString();
                //    cuota_neta1.Value = (double.Parse(dataTable.Rows[0]["cuota_neta"].ToString()) + double.Parse(dataTable.Rows[0]["neta_exclusion"].ToString())).ToString();
                //    cuota_comis1.Value = (double.Parse(dataTable.Rows[0]["cuota_comis"].ToString()) + double.Parse(dataTable.Rows[0]["comision_exclusion"].ToString())).ToString();
                //    cuota_pago.Text = (double.Parse(dataTable.Rows[0]["cuota_pago"].ToString()) + double.Parse(dataTable.Rows[0]["monto_devolucion"].ToString())).ToString();
                //}
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Transacción", original);
            }
        }

        public List<vpr_listasinpago> ObtenerTablaPoliza(string _num_poliza, string _id_perclie, string _id_spvs, long _id_producto, bool _flagVigencia, DateTime? _fc_inivig, DateTime? _fc_finivig, bool _flagPorVencer, DateTime? _fc_finvig)
        {
            //string sql = "";
            //if (this.num_poliza.Text != null & (this.num_poliza.Text != ""))
            //{
            //    sql = string.Concat(sql, "AND num_poliza LIKE '%", this.num_poliza.Text.ToUpper(), "%'");
            //}
            //if (this.id_perclie.Value != null & (this.id_perclie.Value != ""))
            //{
            //    sql = string.Concat(sql, "AND id_perclie LIKE '%", this.id_perclie.Value.ToUpper(), "%'");
            //}
            //if (this.id_spvs.Value != null & (this.id_spvs.Value != ""))
            //{
            //    sql = string.Concat(sql, "AND id_spvs LIKE '%", this.id_spvs.Value, "%'");
            //}
            //if (this.id_producto.Value != "0")
            //{
            //    sql = string.Concat(sql, "AND id_producto=", this.id_producto.Value);
            //}
            //if (this.vigencia.Checked & this.fc_inivig.Text != null & (this.fc_inivig.Text != "") & this.fc_finivig.Text != null & (this.fc_finivig.Text != ""))
            //{
            //    string[] strArrays = new string[] { sql, "AND fc_inivig BETWEEN '", Funciones.fc(this.fc_inivig.Text), "' AND '", Funciones.fc(this.fc_finivig.Text), "'" };
            //    sql = string.Concat(strArrays);
            //}
            //if (this.porvencer.Checked & this.fc_finvig.Text != null & (this.fc_finvig.Text != ""))
            //{
            //    sql = string.Concat(sql, "AND fc_finvig <= '", Funciones.fc(this.fc_finvig.Text), "'");
            //}
            //string sql1 = string.Concat("SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vpr_listasinpago WHERE estado='true'", sql);
            try
            {
                var sql = (
                           from vpago in _context.vpr_listasinpago
                           where vpago.estado == true
                           //& vpago.num_poliza.Contains(_num_poliza.ToUpper())  /// EL CONTAINS NO FUNCIONA EN ESTE QUERY
                           select vpago
                        ).ToList();

                if (_num_poliza != null && _num_poliza != string.Empty)
                    sql = sql.Where(vpago => vpago.num_poliza.Contains(_num_poliza.ToUpper())).ToList();
                if (_id_perclie != null && _id_perclie != string.Empty)
                    sql = sql.Where(vpago => vpago.id_perclie.Contains(_id_perclie.ToUpper())).ToList();
                if (_id_spvs != null && _id_spvs != string.Empty)
                    sql = sql.Where(vpago => vpago.id_spvs.Contains(_id_spvs.ToUpper())).ToList();

                if (_id_producto != 0)
                    sql=sql.Where(x => x.id_producto == _id_producto).ToList();
                if(_flagVigencia)
                {
                    if(_fc_inivig != null && _fc_finivig != null)
                        sql=sql.Where(x =>     x.fc_inivig >= _fc_inivig     &&      x.fc_inivig <= _fc_finivig    ).ToList();
                }
                if(_flagPorVencer)
                {
                    if (_fc_finvig != null)
                        sql=sql.Where(x => x.fc_finvig <= _fc_finvig).ToList();
                }

                return sql;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Transacción", original);
            }
        }


        public bool ActualizarCuotaPago(pr_cuotapoliza objPrCuotaPoliza)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_cuotapoliza.Where(w => w.id_poliza == objPrCuotaPoliza.id_poliza
                    && w.id_movimiento == objPrCuotaPoliza.id_movimiento && w.cuota == objPrCuotaPoliza.cuota).FirstOrDefault();
                                     
                    sql.cuota_pago = sql.cuota_pago+ objPrCuotaPoliza.cuota_pago;
               

                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
    }
}
