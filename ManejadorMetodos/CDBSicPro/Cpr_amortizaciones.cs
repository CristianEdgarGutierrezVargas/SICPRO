using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_amortizaciones
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_amortizaciones(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public List<pr_recibo> ObtenerRD_Recibo(string id_per, string id_gru, int id_apli)
        {
            try
            {
                //object[] idPer = new object[] { "SELECT   pr_recibo.id_recibo
                //                                          , pr_recibo.monto_resto
                //                                          , anio_recibo
                //                                          , id_liq
                //                                FROM pr_recibo
                //                                WHERE pr_recibo.monto_resto > 0
                //                                      AND (pr_recibo.id_perclie = '", id_per, "'
                //                                      OR pr_recibo.id_perclie = '", id_gru, "')
                //                                      and pr_recibo.id_apli = ", id_apli, "
                //                                      AND id_liq IS NOT NULL " };
                var sql = (from recibo in _context.pr_recibo
                          where recibo.monto_resto > 0
                              & recibo.id_apli == id_apli
                              & recibo.id_liq != null
                              & (
                                    recibo.id_perclie == id_per
                                    |
                                    recibo.id_perclie == id_gru
                                )
                          select recibo).ToList();
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
