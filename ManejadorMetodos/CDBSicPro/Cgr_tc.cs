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
    public class Cgr_tc
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cgr_tc(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public List<gr_tc> Tasa(out List<gr_parametro> list_parametro)
        {
            try
            {
                //string sql = "SELECT gr_tc.fecha, gr_tc.tcambio, gr_parametro.abrev_param FROM gr_parametro INNER JOIN gr_tc ON (gr_parametro.id_par = gr_tc.id_div) ORDER BY gr_tc.fecha DESC LIMIT 10";
                var listtc = (from para in _context.gr_parametro
                            join tc in _context.gr_tc on para.id_par equals tc.id_div
                            orderby tc.fecha descending
                            select tc).Take(10).ToList();
                
                 list_parametro = (from para in _context.gr_parametro
                                    join tc in _context.gr_tc on para.id_par equals tc.id_div
                                    orderby tc.fecha descending
                                    select para).Take(10).ToList();
                return listtc;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }

        public void InsertarTC(gr_tc item)
        {
            try
            {
                //string[] strArrays = new string[] { "INSERT INTO gr_tc (fecha,tcambio,id_div) VALUES ('", Funciones.fc(this.fecha.Text), "', ", this.tcambio.Text.Replace(".", "").Replace(",", "."), ", ", this.id_div.SelectedValue, ")" };
                _context.gr_tc.Add(item);
                _context.SaveChanges();

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
    }
}
