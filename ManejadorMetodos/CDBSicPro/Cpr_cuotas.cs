using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_cuotas
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_cuotas(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public pr_cuotapoliza InsertarCuotaPoliza(pr_cuotapoliza objPrCuotaPoliza)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_cuotapoliza.Add(objPrCuotaPoliza);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return objPrCuotaPoliza;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        public bool InsertarLstCuotaPoliza(List<pr_cuotapoliza> lstPrCuotaPoliza)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_cuotapoliza.AddRange(lstPrCuotaPoliza);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public bool ActualizarCuotaPoliza(pr_cuotapoliza objPrCuotaPoliza)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_cuotapoliza.Where(w=>w.id_poliza == objPrCuotaPoliza.id_poliza
                    && w.id_movimiento == objPrCuotaPoliza.id_movimiento && w.cuota == objPrCuotaPoliza.cuota).FirstOrDefault();

                    sql.fecha_pago = objPrCuotaPoliza.fecha_pago;
                    sql.cuota_total = objPrCuotaPoliza.cuota_total;
                    sql.cuota_neta = 0;
                    sql.cuota_comis = 0;
                    sql.cuota_pago = 0;
                    sql.cuota_comicob = 0;

                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
    }
}
