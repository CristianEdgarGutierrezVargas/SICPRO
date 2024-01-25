using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
 using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cgr_parametro
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cgr_parametro(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public List<gr_parametro> ObtenerLista(string columna)
        {
            try
            {
                var sql = _context.gr_parametro.Where(w => w.columna == columna).OrderBy(ob => ob.id_par).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }

        public List<string> ObtenerListaParametro()
        {
            try
            {
                //string sql = "SELECT DISTINCT (gr_parametro.columna) AS columna FROM gr_parametro ORDER BY columna ASC";
                var sql = (
                            from para in _context.gr_parametro
                            orderby para.columna ascending
                            select para.columna
                          ).Distinct().ToList();//.ForEach(s => s.valor_param = 0);
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public gr_parametro ObtenerParametro(long id_par)
        {
            try
            {
                var sql = _context.gr_parametro.Where(w => w.id_par == id_par).FirstOrDefault();
                if (sql == null)
                {
                    return null;
                }
                else
                {
                    return sql;
                }
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public List<gr_parametro> ListRoles()
        {
            //metodo del decompilado
            //object[] objArray = new object[] { "SELECT gr_parametro.id_par, gr_parametro.desc_param FROM gr_parametro WHERE gr_parametro.columna LIKE '", columna, "' and gr_parametro.valor_param = ", valor_param, " UNION SELECT 0, 'SELECCIONE UNA OPCIÓN'" };
            try
            {
                var sql = from param in _context.gr_parametro
                          where param.columna == "id_rol" && param.valor_param == 0
                          select param;

                List<gr_parametro> resultado = sql.ToList();
                resultado.Add(new gr_parametro { id_par = 0, desc_param = "SELECCIONE UNA OPCIÓN" });
                return resultado;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public List<gr_parametro> ParametroA(string columna)
        {
            try
            {
                var sql = _context.gr_parametro.Where(w => w.columna == columna).ToList();
                if (sql == null)
                {
                    return null;
                }
                else
                {
                    return sql;
                }
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
            return null;
        }

        //public void ParametroA(string columna)
        //{
        //    try
        //    {
        //        string sentenciaSQL = "SELECT gr_parametro.id_par, gr_parametro.abrev_param FROM gr_parametro WHERE gr_parametro.columna LIKE '" + columna + "' UNION SELECT 0, 'SELECCIONE UNA OPCIÓN'";
        //        Acceso acceso = new Acceso();
        //        acceso.Conectar();
        //        acceso.CrearComando(sentenciaSQL);
        //        DataTable dataSource = acceso.Consulta();
        //        ddlgeneral.DataSource = dataSource;
        //        ddlgeneral.DataTextField = "abrev_param";
        //        ddlgeneral.DataValueField = "id_par";
        //        ddlgeneral.DataBind();
        //        acceso.Desconectar();
        //    }
        //    catch (SecureExceptions original)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", original);
        //    }
        //}
        public List<gr_parametro> ParametroRE(string columna)
        {
            try
            {
                //string sentenciaSQL = "SELECT gr_parametro.id_par, gr_parametro.desc_param as desc_param1
                //, gr_parametro.desc_param FROM gr_parametro
                //WHERE gr_parametro.columna
                //LIKE '" + columna + "' UNION SELECT 0,'', 'SELECCIONE UNA OPCIÓN' UNION SELECT 1,'*', 'SELECCIONE TODAS' ORDER BY id_par";
                var sql = _context.gr_parametro.Where(w => w.columna == columna).ToList();

                if (sql == null)
                {
                    return null;
                }
                else
                {
                    var objSelect = new gr_parametro();
                    objSelect.id_par = 0;
                    objSelect.desc_param = "SELECCIONE UNA OPCIÓN";
                    sql.Add(objSelect);

                    var objSelectTodas = new gr_parametro();
                    objSelectTodas.id_par = 1;
                    objSelectTodas.desc_param = "SELECCIONE TODAS";
                    sql.Add(objSelectTodas);

                    return sql.OrderBy(o => o.id_par).ToList();
                }
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }

        public void InsertarParametro(gr_parametro item)
        {
            try
            {
                //string[] lower = new string[] { "INSERT INTO gr_parametro VALUES (default,'", this.columna.Text.ToLower(), "',", this.desc_param.Text.ToUpper(), ",'", this.abrev_param.Text.ToUpper(), "',", this.valor_param.Text, ")" };
                _context.gr_parametro.Add(item);
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void ModificarParametro(gr_parametro item)
        {
            try
            {
                //string[] lower = new string[] { "UPDATE gr_parametro SET columna='", this.columna.Text.ToLower(), "',desc_param=", this.desc_param.Text.ToUpper(), ",abrev_param='", this.abrev_param.Text.ToUpper(), "', valor_param=", this.valor_param.Text, " WHERE id_par=", this.id_para.Value };
                var itemToUpdating = (from para in _context.gr_parametro
                                      where para.id_par == item.id_par
                                      select para).FirstOrDefault();
                itemToUpdating.id_par = item.id_par;
                itemToUpdating.columna = item.columna;
                itemToUpdating.valor_param = item.valor_param;
                itemToUpdating.desc_param = item.desc_param;
                itemToUpdating.abrev_param = item.abrev_param;

                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void EliminarParametro(long idPara)
        {
            try
            {
                //string sql = string.Concat("DELETE FROM gr_parametro WHERE id_par=", id_par);
                var itemToUpdating = (from para in _context.gr_parametro
                                      where para.id_par == idPara
                                      select para).FirstOrDefault();
                _context.gr_parametro.Remove(itemToUpdating);
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public List<gr_parametro> Parametro(string columna)
        {
            try
            {
                //string sql = string.Concat("SELECT gr_parametro.id_par, gr_parametro.desc_param FROM gr_parametro WHERE gr_parametro.columna LIKE '", columna, "' UNION SELECT 0, 'SELECCIONE UNA OPCIÓN'");
                var list = (from para in _context.gr_parametro
                           where para.columna.Contains(columna)
                           select para).ToList();
                list.Add(new gr_parametro { id_par = 0 ,desc_param= "SELECCIONE UNA OPCIÓN" }) ;
                return list;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
    }
}
