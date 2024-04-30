using Common;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesClases.ModelSicPro;
using EntidadesClases.CustomModelEntities;
using System.Data.SqlTypes;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_poliza
    {
        #region Constructor Principal
        readonly sicproEntities _context;
        public Cpr_poliza(sicproEntities dbContex)
        {
            _context = dbContex;
        }

        #endregion
        public bool ExistePol(string numpoliza, string no_liquida)
        {
            bool flag = false;
            using (var dbContextTransaccion = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_poliza.Join(_context.pr_polmov, x => x.id_poliza, s => s.id_poliza, ((x, s) => new { x.num_poliza, s.no_liquida })).Where(x => x.num_poliza == numpoliza.ToUpper() && x.no_liquida == no_liquida);
                    if (sql != null && sql.Count() > 0)
                    {
                        flag = true;
                        return flag;
                    }
                    return flag;
                    //string[] strArrays = new string[] { "SELECT pr_poliza.num_poliza, pr_polmov.no_liquida FROM pr_poliza INNER JOIN pr_polmov ON (pr_poliza.id_poliza = pr_polmov.id_poliza) WHERE pr_poliza.num_poliza = upper('", numpoliza, "') AND pr_polmov.no_liquida = upper('", this.no_liquida.Text, "')" };
                    //string sql = string.Concat(strArrays);
                    //Acceso db = new Acceso();
                    //db.Conectar();
                    //db.CrearComando(sql);
                    //DataTable dtgeneral = db.Consulta();
                    //db.Desconectar();
                    //flag = (dtgeneral.Rows.Count <= 0 ? false : true);
                }
                catch (SecureExceptions secureException)
                {
                    throw new SecureExceptions("Error al Generar la Transacción", secureException);
                }

            }
        }

        public pr_poliza InsertarPoliza(pr_poliza objPoliza)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_poliza.Add(objPoliza);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return objPoliza;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        public bool UpdatePoliza(pr_poliza objPoliza)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_poliza.Where(w => w.id_poliza == objPoliza.id_poliza).FirstOrDefault();

                    if (sql == null)
                    {
                        return false;
                    }
                    else
                    {
                        sql.num_poliza = objPoliza.num_poliza;
                        sql.id_producto = objPoliza.id_producto;
                        sql.id_perclie = objPoliza.id_perclie;
                        sql.id_spvs = objPoliza.id_spvs;
                        sql.id_gru = objPoliza.id_gru;
                        sql.clase_poliza = objPoliza.clase_poliza;
                        sql.id_percart = objPoliza.id_percart;
                       
                        _context.SaveChanges();
                        dbContextTransaction.Commit();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        //public void InsertarPoliza(string variable)
        //{
        //    try
        //    {
        //        string[] upper = new string[] { "INSERT INTO " +
        //            "pr_poliza(num_poliza,id_producto,id_perclie,id_spvs,id_gru,clase_poliza,fc_reg,id_percart,id_suc) " +
        //            "VALUES ('", this.num_poliza.Text.ToUpper(), "','", this.id_prod.SelectedValue, "','", this.id_perclie.Value, "','"
        //            , this.id_spvs.SelectedValue.ToString(), "',", this.id_gru.SelectedValue, ",'", variable, "','"
        //            , Funciones.fc(this.fc_reg.Value), "','", this.id_percart.SelectedValue.ToString(), "',", this.id_suc.Value, ")" };
        //        string sql = string.Concat(upper);
        //        Acceso db = new Acceso();
        //        db.Conectar();
        //        db.CrearComando(sql);
        //        db.EjecutarComando();
        //        db.Desconectar();
        //    }
        //    catch (SecureExceptions secureException)
        //    {
        //        throw new SecureExceptions("Error al Generar la Transaccion", secureException);
        //    }
        //}

        public List<vpr_polrenovar> ObtenerTablaPolizaR(OC_ObtenerTablaPolizaIn objObtTablaPolIn)
        {
            try
            {
                var sql1 = _context.vpr_polrenovar.Where(w => w.estado == true).ToList();

                if (objObtTablaPolIn.num_poliza != null & (objObtTablaPolIn.num_poliza.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.num_poliza.Contains(objObtTablaPolIn.num_poliza.ToUpper())).ToList();
                    // sql = string.Concat(sql, "AND num_poliza LIKE '%", num_poliza.ToUpper(), "%'");
                }
                if (!string.IsNullOrEmpty(objObtTablaPolIn.id_perclie))
                {
                    sql1 = sql1.Where(x => x.id_perclie.Contains(objObtTablaPolIn.id_perclie.ToUpper())).ToList();
                    //sql = string.Concat(sql, "AND id_perclie LIKE '%", id_per.ToUpper(), "%'");
                }

                if (!string.IsNullOrEmpty(objObtTablaPolIn.id_spvs))
                {
                    sql1 = sql1.Where(x => x.id_spvs.Contains(objObtTablaPolIn.id_spvs)).ToList();
                    //sql = string.Concat(sql, "AND id_spvs LIKE '%", id_spvs, "%'");
                }

                if (objObtTablaPolIn.id_producto != 0)
                {
                    sql1 = sql1.Where(x => x.id_producto == objObtTablaPolIn.id_producto).ToList();
                    //sql = string.Concat(sql, "AND id_producto=", id_producto);
                }

                if (objObtTablaPolIn.vigencia && objObtTablaPolIn.fc_inivig != null && objObtTablaPolIn.fc_finvig != null)
                {
                    sql1 = sql1.Where(x => x.fc_inivig >= objObtTablaPolIn.fc_inivig && x.fc_inivig <= objObtTablaPolIn.fc_finvig).ToList();
                    //string[] strArrays = new string[] { sql, "AND fc_inivig BETWEEN '", Funciones.fc(fc_inivig), "' AND '", Funciones.fc(fc_polizavencida), "'" };
                    //sql = string.Concat(strArrays);
                }
                if (objObtTablaPolIn.porvencer & objObtTablaPolIn.fc_polizavencida != null)
                {
                    sql1.Where(x => x.fc_finvig <= objObtTablaPolIn.fc_polizavencida).ToList();
                    //sql = string.Concat(sql, "AND fc_finvig <= '", Funciones.fc(fc_polizavencida), "'");
                }
                return sql1;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }

        public List<vpr_polaplivar> ObtenerTablaPolizaAp(OC_ObtenerTablaPolizaIn objObtTablaPolIn)
        {
            try
            {
                var sql1 = _context.vpr_polaplivar.Where(w => w.estado == true).ToList();

                if (objObtTablaPolIn.num_poliza != null & (objObtTablaPolIn.num_poliza.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.num_poliza.Contains(objObtTablaPolIn.num_poliza.ToUpper())).ToList();
                    // sql = string.Concat(sql, "AND num_poliza LIKE '%", num_poliza.ToUpper(), "%'");
                }
                if (!string.IsNullOrEmpty(objObtTablaPolIn.id_perclie))
                {
                    sql1 = sql1.Where(x => x.id_perclie.Contains(objObtTablaPolIn.id_perclie.ToUpper())).ToList();
                    //sql = string.Concat(sql, "AND id_perclie LIKE '%", id_per.ToUpper(), "%'");
                }

                if (!string.IsNullOrEmpty(objObtTablaPolIn.id_spvs))
                {
                    sql1 = sql1.Where(x => x.id_spvs.Contains(objObtTablaPolIn.id_spvs)).ToList();
                    //sql = string.Concat(sql, "AND id_spvs LIKE '%", id_spvs, "%'");
                }

                if (objObtTablaPolIn.id_producto != 0)
                {
                    sql1 = sql1.Where(x => x.id_producto == objObtTablaPolIn.id_producto).ToList();
                    //sql = string.Concat(sql, "AND id_producto=", id_producto);
                }

                if (objObtTablaPolIn.vigencia && objObtTablaPolIn.fc_inivig != null && objObtTablaPolIn.fc_finvig != null)
                {
                    sql1 = sql1.Where(x => x.fc_inivig >= objObtTablaPolIn.fc_inivig && x.fc_inivig <= objObtTablaPolIn.fc_finvig).ToList();
                    //string[] strArrays = new string[] { sql, "AND fc_inivig BETWEEN '", Funciones.fc(fc_inivig), "' AND '", Funciones.fc(fc_polizavencida), "'" };
                    //sql = string.Concat(strArrays);
                }
                if (objObtTablaPolIn.porvencer & objObtTablaPolIn.fc_polizavencida != null)
                {
                    sql1.Where(x => x.fc_finvig <= objObtTablaPolIn.fc_polizavencida).ToList();
                    //sql = string.Concat(sql, "AND fc_finvig <= '", Funciones.fc(fc_polizavencida), "'");
                }
                return sql1;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }


        public List<vpr_polincluvar> ObtenerTablaPolizaI(OC_ObtenerTablaPolizaIn objObtTablaPolIn)
        {
            try
            {
                var sql1 = _context.vpr_polincluvar.Where(w => w.estado == true).ToList();

                if (objObtTablaPolIn.num_poliza != null & (objObtTablaPolIn.num_poliza.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.num_poliza.Contains(objObtTablaPolIn.num_poliza.ToUpper())).ToList();
                    // sql = string.Concat(sql, "AND num_poliza LIKE '%", num_poliza.ToUpper(), "%'");
                }
                if (!string.IsNullOrEmpty(objObtTablaPolIn.id_perclie))
                {
                    sql1 = sql1.Where(x => x.id_perclie.Contains(objObtTablaPolIn.id_perclie.ToUpper())).ToList();
                    //sql = string.Concat(sql, "AND id_perclie LIKE '%", id_per.ToUpper(), "%'");
                }

                if (!string.IsNullOrEmpty(objObtTablaPolIn.id_spvs))
                {
                    sql1 = sql1.Where(x => x.id_spvs.Contains(objObtTablaPolIn.id_spvs)).ToList();
                    //sql = string.Concat(sql, "AND id_spvs LIKE '%", id_spvs, "%'");
                }

                if (objObtTablaPolIn.id_producto != 0)
                {
                    sql1 = sql1.Where(x => x.id_producto == objObtTablaPolIn.id_producto).ToList();
                    //sql = string.Concat(sql, "AND id_producto=", id_producto);
                }

                if (objObtTablaPolIn.vigencia && objObtTablaPolIn.fc_inivig != null && objObtTablaPolIn.fc_finvig != null)
                {
                    sql1 = sql1.Where(x => x.fc_inivig >= objObtTablaPolIn.fc_inivig && x.fc_inivig <= objObtTablaPolIn.fc_finvig).ToList();
                    //string[] strArrays = new string[] { sql, "AND fc_inivig BETWEEN '", Funciones.fc(fc_inivig), "' AND '", Funciones.fc(fc_polizavencida), "'" };
                    //sql = string.Concat(strArrays);
                }
                if (objObtTablaPolIn.porvencer & objObtTablaPolIn.fc_polizavencida != null)
                {
                    sql1.Where(x => x.fc_finvig <= objObtTablaPolIn.fc_polizavencida).ToList();
                    //sql = string.Concat(sql, "AND fc_finvig <= '", Funciones.fc(fc_polizavencida), "'");
                }
                return sql1;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }

        public List<vpr_polexcluvar> ObtenerTablaPolizaEx(OC_ObtenerTablaPolizaIn objObtTablaPolIn)
        {
            try
            {
                var sql1 = _context.vpr_polexcluvar.Where(w => w.estado == true).ToList();

                if (objObtTablaPolIn.num_poliza != null & (objObtTablaPolIn.num_poliza.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.num_poliza.Contains(objObtTablaPolIn.num_poliza.ToUpper())).ToList();
                    // sql = string.Concat(sql, "AND num_poliza LIKE '%", num_poliza.ToUpper(), "%'");
                }
                if (!string.IsNullOrEmpty(objObtTablaPolIn.id_perclie))
                {
                    sql1 = sql1.Where(x => x.id_perclie.Contains(objObtTablaPolIn.id_perclie.ToUpper())).ToList();
                    //sql = string.Concat(sql, "AND id_perclie LIKE '%", id_per.ToUpper(), "%'");
                }

                if (!string.IsNullOrEmpty(objObtTablaPolIn.id_spvs))
                {
                    sql1 = sql1.Where(x => x.id_spvs.Contains(objObtTablaPolIn.id_spvs)).ToList();
                    //sql = string.Concat(sql, "AND id_spvs LIKE '%", id_spvs, "%'");
                }

                if (objObtTablaPolIn.id_producto != 0)
                {
                    sql1 = sql1.Where(x => x.id_producto == objObtTablaPolIn.id_producto).ToList();
                    //sql = string.Concat(sql, "AND id_producto=", id_producto);
                }

                if (objObtTablaPolIn.vigencia && objObtTablaPolIn.fc_inivig != null && objObtTablaPolIn.fc_finvig != null)
                {
                    sql1 = sql1.Where(x => x.fc_inivig >= objObtTablaPolIn.fc_inivig && x.fc_inivig <= objObtTablaPolIn.fc_finvig).ToList();
                    //string[] strArrays = new string[] { sql, "AND fc_inivig BETWEEN '", Funciones.fc(fc_inivig), "' AND '", Funciones.fc(fc_polizavencida), "'" };
                    //sql = string.Concat(strArrays);
                }
                if (objObtTablaPolIn.porvencer & objObtTablaPolIn.fc_polizavencida != null)
                {
                    sql1.Where(x => x.fc_finvig <= objObtTablaPolIn.fc_polizavencida).ToList();
                    //sql = string.Concat(sql, "AND fc_finvig <= '", Funciones.fc(fc_polizavencida), "'");
                }
                return sql1;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }

        public List<vpr_polanuvar> ObtenerTablaPolizaAn(OC_ObtenerTablaPolizaIn objObtTablaPolIn)
        {
            try
            {
                var sql1 = _context.vpr_polanuvar.Where(w => w.estado == true).ToList();

                if (objObtTablaPolIn.num_poliza != null & (objObtTablaPolIn.num_poliza.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.num_poliza.Contains(objObtTablaPolIn.num_poliza.ToUpper())).ToList();
                    // sql = string.Concat(sql, "AND num_poliza LIKE '%", num_poliza.ToUpper(), "%'");
                }
                if (!string.IsNullOrEmpty(objObtTablaPolIn.id_perclie))
                {
                    sql1 = sql1.Where(x => x.id_perclie.Contains(objObtTablaPolIn.id_perclie.ToUpper())).ToList();
                    //sql = string.Concat(sql, "AND id_perclie LIKE '%", id_per.ToUpper(), "%'");
                }

                if (!string.IsNullOrEmpty(objObtTablaPolIn.id_spvs))
                {
                    sql1 = sql1.Where(x => x.id_spvs.Contains(objObtTablaPolIn.id_spvs)).ToList();
                    //sql = string.Concat(sql, "AND id_spvs LIKE '%", id_spvs, "%'");
                }

                if (objObtTablaPolIn.id_producto != 0)
                {
                    sql1 = sql1.Where(x => x.id_producto == objObtTablaPolIn.id_producto).ToList();
                    //sql = string.Concat(sql, "AND id_producto=", id_producto);
                }

                if (objObtTablaPolIn.vigencia && objObtTablaPolIn.fc_inivig != null && objObtTablaPolIn.fc_finvig != null)
                {
                    sql1 = sql1.Where(x => x.fc_inivig >= objObtTablaPolIn.fc_inivig && x.fc_inivig <= objObtTablaPolIn.fc_finvig).ToList();
                    //string[] strArrays = new string[] { sql, "AND fc_inivig BETWEEN '", Funciones.fc(fc_inivig), "' AND '", Funciones.fc(fc_polizavencida), "'" };
                    //sql = string.Concat(strArrays);
                }
                if (objObtTablaPolIn.porvencer & objObtTablaPolIn.fc_polizavencida != null)
                {
                    sql1.Where(x => x.fc_finvig <= objObtTablaPolIn.fc_polizavencida).ToList();
                    //sql = string.Concat(sql, "AND fc_finvig <= '", Funciones.fc(fc_polizavencida), "'");
                }
                return sql1;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }


        public pr_poliza GetPolizaById(long idPoliza)
        {

            try
            {
                var sql = _context.pr_poliza.FirstOrDefault(x => x.id_poliza == idPoliza);

                return sql;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }

        }

        public GetDataVeriPoliza_Result GetDataVeriPoliza(long id_poliza, long id_movimiento)
        {
            try
            {
                var sql = _context.GetDataVeriPoliza(id_poliza, id_movimiento).FirstOrDefault();

                return sql;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool ActualizarEstadoPoliza(long id_poliza, bool bolEstado)
        {
            using (var dbContextTransaccion = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_poliza.Where(w => w.id_poliza == id_poliza).FirstOrDefault();
                    if (sql != null)
                    {
                        sql.estado = bolEstado;
                        _context.SaveChanges();
                        return true;
                    }
                    return false;

                }
                catch (SecureExceptions secureException)
                {
                    throw new SecureExceptions("Error al Generar la Transacción", secureException);
                }

            }
        }

        public List<pr_poliza> GetListPoliza()
        {
            try
            {
                var sql = _context.pr_poliza.Select(w => w).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<GetFacturaNombreByIdSpvs_Result> GetFacturaNombreByIdSpvs(string id_spv)
        {
            try
            {
                var sql = _context.GetFacturaNombreByIdSpvs(id_spv).ToList();

                return sql;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }




        //string sql = string.Concat("SELECT public.pr_poliza.id_poliza
        //                                  ,public.pr_poliza.num_poliza
        //                            FROM pr_poliza
        //                            WHERE pr_poliza.id_perclie = '", id_per, "'
        //                            UNION SELECT 0, 'SELECCIONE UNA OPCIÓN' ORDER BY id_poliza");

        public List<pr_poliza> ObtenerPolizaP(string id_per)
        {
            try
            {

                var sql = (from poliza in _context.pr_poliza
                           where poliza.id_perclie == id_per
                           select poliza
                                   ).ToList();
                sql.Add(new pr_poliza { id_poliza = 0, num_poliza = "SELECCIONE UNA OPCIÓN" });
                sql = sql.OrderBy(x => x.id_poliza).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<OC_PolizaPP> ObtenerPolizaPP(long id_poliza)
        {
            try
            {
                //string sql = string.Concat("SELECT  pr_poliza.id_poliza
                //                                  , pr_poliza.num_poliza
                //                                  , pr_poliza.id_producto
                //                                  , pr_producto.desc_prod
                //                                  , pr_poliza.id_spvs
                //                                  , v_pr_cias_resum.nomraz
                //                           FROM pr_poliza
                //                           INNER JOIN pr_producto ON (pr_poliza.id_producto = pr_producto.id_producto)
                //                           INNER JOIN v_pr_cias_resum ON (pr_poliza.id_spvs = v_pr_cias_resum.id_spvs)
                //                           WHERE pr_poliza.id_poliza =", id_poliza);

                var sql = (from poliza in _context.pr_poliza
                           join producto in _context.pr_producto on poliza.id_producto equals producto.id_producto
                           join view in _context.v_pr_cias_resum on poliza.id_spvs equals view.id_spvs
                           where poliza.id_poliza == id_poliza
                           select  new OC_PolizaPP
                           {
                               id_poliza=poliza.id_poliza,
                               num_poliza=poliza.num_poliza,
                               id_producto=poliza.id_producto,
                               desc_prod=producto.desc_prod,
                               id_spvs=poliza.id_spvs,
                               nomraz=view.nomraz
                           }
                           ).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        
        public List<pr_poliza> ObtenerPoliza1(string id_per)
        {
            try
            {
                var sql = _context.pr_poliza.Where(s => s.estado == true && s.id_perclie == id_per).ToList();
                return sql;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public List<pr_poliza> ObtenerPolizaByIdEstado(long idPol, bool estado)
        {
            try
            {
                var sql = _context.pr_poliza.Where(s => s.estado == estado && s.id_poliza == idPol).ToList();

                return sql;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public List<ObtenerTablaFactura_Result> ObtenerTablaFactura(string id_spvs, string num_poliza)
        {
            try
            {
                var sql = _context.ObtenerTablaFactura(id_spvs, num_poliza).ToList();

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
