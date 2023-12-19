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
    public class Cco_porcomi
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cco_porcomi(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public List<co_porcomi> ObtPorcart(string id_per)
        {
            try
            {
                //string sql = string.Concat("SELECT porcentaje, factura FROM co_porcomi WHERE id_percart = '", this.id_percart.SelectedValue.ToString(), "'");
                var sql=(from com in _context.co_porcomi
                        where com.id_percart == id_per
                        select com).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la consulta", secureException);
            }
        }

        public void InsPorcart(string id_per,decimal porcentaje,bool esfactura)
        {
            try
            {
                //string[] str = new string[] { "INSERT INTO co_porcomi values ('", this.id_percart.SelectedValue.ToString(), "',", this.porcentaje.Text.Replace(".", "").Replace(",", ""), "/100,'", f, "') " };
                co_porcomi item=new co_porcomi();
                item.factura = esfactura;
                item.porcentaje = porcentaje;
                item.id_percart = id_per;
                _context.co_porcomi.Add(item);  
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la consulta", secureException);
            }
        }

        public void UpdPorcart(string id_per, decimal porcentaje, bool esfactura)
        {
            try
            {
                //string[] strArrays = new string[] { "UPDATE co_porcomi SET porcentaje = ", this.porcentaje.Text.Replace(".", "").Replace(",", ""), "/100, factura = '", f, "' WHERE id_percart = '", this.id_percart.SelectedValue.ToString(), "'" };
                var sql = (from com in _context.co_porcomi
                           where com.id_percart == id_per
                           select com).FirstOrDefault();
                sql.factura = esfactura;
                sql.porcentaje = porcentaje;
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la consulta", secureException);
            }
        }
    }
}
