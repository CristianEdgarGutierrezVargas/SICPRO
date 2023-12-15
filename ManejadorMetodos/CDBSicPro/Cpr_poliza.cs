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
    }
}
