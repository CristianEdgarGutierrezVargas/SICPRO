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
                var sql = _context.gr_parametro.Where(w => w.columna == columna).OrderBy(ob=>ob.id_par).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }

        public List<gr_parametro> ObtenerListaParametro()
        {
            try
            {
                var sql = _context.gr_parametro.GroupBy(g => g.columna).Select(s => s.First()).OrderBy(o => o.columna).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public gr_parametro ObtenerParametro(int id_par)
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
    }
}
