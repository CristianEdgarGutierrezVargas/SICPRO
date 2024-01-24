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
                //string sentenciaSQL = "SELECT pr_riesgo.id_riesgo, pr_riesgo.desc_riesgo FROM pr_riesgo
                //UNION SELECT '-1', ' SELECCIONE UNA OPCIÓN' ORDER BY desc_riesgo";
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
        public void InsertarProducto(string desc_prod,string abrev_prod)
        {
            try
            {
                //string[] upper = new string[] { "INSERT INTO pr_producto VALUES (default, '", this.desc_prod.Text.ToUpper(), "','", this.abrev_prod.Text.ToUpper(), "')" };
                pr_producto item=new pr_producto();
                item.desc_prod = desc_prod;
                item.abrev_prod= abrev_prod;
                _context.pr_producto.Add(item);
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
    }
}
