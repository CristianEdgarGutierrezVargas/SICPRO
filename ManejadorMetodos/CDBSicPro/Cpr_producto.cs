using Common;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
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
    }
}
