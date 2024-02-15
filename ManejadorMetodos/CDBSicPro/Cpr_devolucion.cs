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
    public class Cpr_devolucion
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_devolucion(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public List<pr_devolucion> GetCuotasDev(long idPol, long idMov)
        {

           
            try
            {
                var sql = _context.pr_devolucion.Where(x=>x.id_poliza==idPol && x.id_movimiento==idMov && x.monto_devolucion > x.saldo_devolucion).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
           
        }
        public List<pr_devolucion> DatosDev(long idPol, long idMov, long idDev)
        {


            try
            {
                var sql = _context.pr_devolucion.Where(x => x.id_poliza == idPol && x.id_movimiento == idMov && x.id_devolucion==idDev).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public bool ActualizarDev(pr_devolucion objDev, decimal mCheque)
        {
            using (var dbContextTransaccion = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_devolucion.Where(w => w.id_poliza == objDev.id_poliza && w.id_movimiento== objDev.id_movimiento && w.id_devolucion== objDev.id_devolucion).FirstOrDefault();
                    if (sql != null)
                    {
                        //UPDATE pr_pago SET monto_comis=", this.monto_comis.Text.Replace(".", "").Replace(",", "."), ", cheque_comis='", this.cheque.Text, "', comis_mes=", this.pc_mes.SelectedValue, ", comis_anio=", this.pc_anio.SelectedItem, "
                        sql.saldo_devolucion = sql.saldo_devolucion - mCheque;
                        sql.cheque = objDev.cheque;
                        sql.devolucion_por=objDev.devolucion_por;
                        sql.banco=objDev.banco;
                        _context.SaveChanges();
                        return true;
                    }
                    return false;

                }
                catch (SecureExceptions secureException)
                {
                    throw new SecureExceptions("Error al Generar la Transacción", secureException);
                }

            }
        }
        public bool ActualizarSaldoDev(pr_devolucion objDev, decimal montoPago)
        {
            using (var dbContextTransaccion = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_devolucion.Where(w => w.id_poliza == objDev.id_poliza && w.id_devolucion == objDev.id_devolucion ).FirstOrDefault();
                    if (sql != null)
                    {
                        //UPDATE pr_pago SET monto_comis=", this.monto_comis.Text.Replace(".", "").Replace(",", "."), ", cheque_comis='", this.cheque.Text, "', comis_mes=", this.pc_mes.SelectedValue, ", comis_anio=", this.pc_anio.SelectedItem, "
                        sql.saldo_devolucion = sql.saldo_devolucion - montoPago;
                    
                        _context.SaveChanges();
                        return true;
                    }
                    return false;

                }
                catch (SecureExceptions secureException)
                {
                    throw new SecureExceptions("Error al Generar la Transacción", secureException);
                }

            }
        }
        public List<pr_devolucion> ObtenerDev()
        {
            try
            {
                var sql = _context.pr_devolucion.Select(x => x).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }
    }
}
