using Common;
using EntidadesClases.CustomModelEntities;
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
    public class Cpr_producto
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_producto(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public List<pr_producto> ObtenerTablaProducto(string varBusqueda)
        {
            try
            {
                var query = _context.pr_formriesgo
                   .Join(_context.pr_producto,
                      form => form.id_producto,
                      pro => pro.id_producto,
                      (form, pro) => new { Form = form, Pro = pro })
                   .Where(postAndMeta => postAndMeta.Form.id_spvs == varBusqueda)
                   .Select(s => s.Pro)
                   .ToList();

                return query;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
            return null;
        }
        //public DataTable ObtenerTablaProducto(int varbusqueda)
        //{
        //    try
        //    {
        //        string sentenciaSQL = "SELECT pr_producto.desc_prod, pr_producto.id_producto FROM pr_formriesgo INNER JOIN pr_producto ON (pr_formriesgo.id_producto = pr_producto.id_producto)
        //        WHERE pr_formriesgo.id_spvs = '" + varbusqueda + "' UNION SELECT ' SELECCIONE UNA OPCIÓN', -1 ORDER BY desc_prod";
        //        Acceso acceso = new Acceso();
        //        acceso.Conectar();
        //        acceso.CrearComando(sentenciaSQL);
        //        DataTable result = acceso.Consulta();
        //        acceso.Desconectar();
        //        return result;
        //    }
        //    catch (SecureExceptions original)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", original);
        //    }
        //}
        public List<pr_producto> GetListProducto(string vBusqueda)
        {
            List<pr_producto> sql = new List<pr_producto>();
            try
            {
                if (string.IsNullOrEmpty(vBusqueda))
                    sql = _context.pr_producto.ToList();
                else
                    sql = _context.pr_producto.Where(w => w.desc_prod.ToUpper().Contains(vBusqueda.ToUpper())).ToList();

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
            return sql;
        }
        public pr_producto ObtenerProducto(long varbusqueda)
        {
            try
            {
                var sql = _context.pr_producto.Where(w => w.id_producto == varbusqueda).FirstOrDefault();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<pr_riesgo> ObtenerRiesgo()
        {
            try
            {
                //string sql = "SELECT pr_riesgo.id_riesgo, pr_riesgo.desc_riesgo FROM pr_riesgo UNION SELECT '-1', ' SELECCIONE UNA OPCIÓN' ORDER BY desc_riesgo";
                var sql = _context.pr_riesgo.ToList();

                if (sql == null)
                {
                    return null;
                }
                else
                {
                    var objSelec = new pr_riesgo();
                    objSelec.id_riesgo = "-1";
                    objSelec.desc_riesgo = "SELECCIONE UNA OPCIÓN";
                    sql.Add(objSelec);
                    return sql.OrderBy(o => o.desc_riesgo).ToList();
                }
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }
        public bool ExisteProducto(string desc_prod, string abrev_prod)
        {
            bool flag;
            try
            {
                //string[] upper = new string[] { "SELECT * FROM pr_producto WHERE desc_prod='", this.desc_prod.Text.ToUpper(), "' AND abrev_prod='", this.abrev_prod.Text.ToUpper(), "'" };
                var list = (from prod in _context.pr_producto
                            where prod.desc_prod == desc_prod && prod.abrev_prod == abrev_prod
                            select prod
                            ).ToList();

                flag = (list.Count <= 0 ? false : true);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
            return flag;
        }
        public void InsertarProducto(string desc_prod, string abrev_prod)
        {
            try
            {
                //string[] upper = new string[] { "INSERT INTO pr_producto VALUES (default, '", this.desc_prod.Text.ToUpper(), "','", this.abrev_prod.Text.ToUpper(), "')" };
                pr_producto item = new pr_producto();
                item.desc_prod = desc_prod;
                item.abrev_prod = abrev_prod;
                _context.pr_producto.Add(item);
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<pr_producto> TablaProductoL(string id_spvs, string desc_prod)
        {
            try
            {
                //string[] strArrays = new string[] { "SELECT pr_producto.id_producto, pr_producto.desc_prod FROM pr_formriesgo INNER JOIN pr_producto ON (pr_formriesgo.id_producto = pr_producto.id_producto) WHERE pr_formriesgo.id_spvs = '", varbusqueda, "' AND pr_producto.desc_prod LIKE '%", desc_prod, "%' ORDER BY desc_prod" };
                //(string varbusqueda, string desc_prod)
                var list = (from formriesgo in _context.pr_formriesgo
                            join producto in _context.pr_producto on formriesgo.id_producto equals producto.id_producto
                            where formriesgo.id_spvs == id_spvs && producto.desc_prod.Contains(desc_prod)
                            orderby producto.desc_prod ascending
                            select producto
                           ).ToList();

                //pr_formriesgo.id_spvs = '", varbusqueda, "' AND pr_producto.desc_prod LIKE '%", desc_prod, "%' ORDER BY desc_prod"
                return list;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<pr_formriesgo> ObtenerFormRiesgo(string id_spvs, long id_producto)
        {
            try
            {
                //object[] idSpvs = new object[] { "SELECT pr_formriesgo.id_riesgo, pr_formriesgo.form_riesgo1, pr_formriesgo.form_riesgo2, pr_formriesgo.comis_riesgo, pr_formriesgo.opera, pr_formriesgo.evaluar, pr_formriesgo.por_cred, pr_formriesgo.plus_neta
                //FROM pr_formriesgo
                //WHERE pr_formriesgo.id_spvs = '", id_spvs, "' AND pr_formriesgo.id_producto = ", id_producto };
                var sql = (from riesgo in _context.pr_formriesgo
                           where riesgo.id_spvs == id_spvs && riesgo.id_producto == id_producto
                           select riesgo
                        ).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public void ModificarFormRiesgo(pr_formriesgo item)
        {
            try
            {
                //object[] selectedValue = new object[] { "UPDATE pr_formriesgo SET   id_riesgo='", this.id_riesgo.SelectedValue     , "'
                //                                                                  , comis_riesgo=", this.comis_riesgo.Text.Replace(".", "").Replace(",", "."), "
                //                                                                  , opera='", this.opera.SelectedValue, "'
                //                                                                  , evaluar=", this.evaluar.Text.Replace(".", "").Replace(",", "."), "
                //                                                                  , por_cred=", this.por_cred.Text.Replace(".", "").Replace(",", "."), "
                //                                                                  , plus_neta=", this.plus_neta.Text.Replace(".", "").Replace(",", "."), "
                //                                                                  , form_riesgo1 = '", this.form_riesgo1.Text, "'
                //                                                                  , form_riesgo2 = '", this.form_riesgo2.Text, "'
                //                                        WHERE  id_producto=", id_producto, " AND id_spvs='", this.id_spvs.SelectedValue, "'" };
                var bdItem = (from riesgo in _context.pr_formriesgo
                              where riesgo.id_producto == item.id_producto && riesgo.id_spvs == item.id_spvs
                              select riesgo
                            ).FirstOrDefault();

                bdItem.id_riesgo = item.id_riesgo;
                bdItem.comis_riesgo = item.comis_riesgo;
                bdItem.opera = item.opera;
                bdItem.evaluar = item.evaluar;
                bdItem.por_cred = item.por_cred;
                bdItem.plus_neta = item.plus_neta;
                bdItem.form_riesgo1 = item.form_riesgo1;
                bdItem.form_riesgo2 = item.form_riesgo2;

                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<pr_producto> TablaProductoP(string desc_prod)
        {
            try
            {
                //string sql = string.Concat("SELECT pr_producto.id_producto, pr_producto.desc_prod , abrev_prod FROM pr_producto WHERE pr_producto.desc_prod LIKE '%", desc_prod, "%' ORDER BY desc_prod");

                var list = (from producto in _context.pr_producto
                            where producto.desc_prod.Contains(desc_prod) == true
                            orderby producto.desc_prod ascending
                            select producto
                           ).ToList();
                return list;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public void InsertarFormRiesgo(string desc_prod, string abrev_prod, string id_riesgo, string id_spvs, bool? opera, decimal evaluar, decimal comis, decimal por_cred, decimal plus_neta)
        {
            try
            {
                //string[] upper = new string[] { "SELECT id_producto
                //                                  FROM pr_producto
                //                                  WHERE desc_prod='", this.desc_prod.Text.ToUpper(), "'
                //                                  AND abrev_prod='", this.abrev_prod.Text.ToUpper(), "'" };
                var idProducto = (
                            from producto in _context.pr_producto
                            where producto.desc_prod == desc_prod.ToUpper()
                            & producto.abrev_prod == abrev_prod.ToUpper()
                            select producto.id_producto
                          ).FirstOrDefault();

                //string[] selectedValue = new string[] { "INSERT INTO pr_formriesgo
                //                                          VALUES ('", this.id_riesgo.SelectedValue
                //                                             , "','", this.id_spvs.SelectedValue
                //                                             , "','", form
                //                                             , "',", this.comis_riesgo.Text.Replace(".", "").Replace(",", ".")
                //                                             , ",'", this.opera.SelectedValue
                //                                             , "',", this.evaluar.Text.Replace(".", "").Replace(",", ".")
                //                                             , ",", id
                //                                             , ",", this.por_cred.Text.Replace(".", "").Replace(",", ".")
                //                                             , ",", this.plus_neta.Text.Replace(".", "").Replace(",", "."), ")" };
                string form = string.Concat("PT", opera, evaluar);
                pr_formriesgo item = new pr_formriesgo();
                item.id_riesgo = id_riesgo;
                item.id_spvs = id_spvs;
                item.form_riesgo1 = form;
                item.comis_riesgo = comis;
                item.opera = opera;
                item.evaluar = evaluar;
                item.id_producto = idProducto;
                item.por_cred= por_cred;
                item.plus_neta = plus_neta;
                _context.pr_formriesgo.Add(item);
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
    }
}
