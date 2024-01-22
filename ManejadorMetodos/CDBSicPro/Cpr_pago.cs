using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_pago
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_pago(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public List<pr_pago> GetObjPagoByFactura(double factura)
        {
            try
            {
                var sql = _context.pr_pago.Where(w => w.factura == factura).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }


        }
        public bool ActualizarPago(double? nro_factura, DateTime fechaFactura, long id_pago)
        {
            using (var dbContextTransaccion = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_pago.Where(w => w.id_pago == id_pago).FirstOrDefault();
                    if (sql != null)
                    {
                        sql.factura = nro_factura;
                        sql.fecha_factura = fechaFactura;
                        _context.SaveChanges();
                        dbContextTransaccion.Commit();
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
        public bool ActualizarPagoM(double? nro_factura, double? nnro_factura, string id_spvs, DateTime fechaFactura)
        {
            using (var dbContextTransaccion = _context.Database.BeginTransaction())
            {
                try
                {
                    // "UPDATE pr_pago
                    // SET factura = this.nnro_factura.Text, 
                    // fecha_factura = fc_factura.Text)
                    // WHERE factura = ", this.nro_factura.Text, " AND  id_pago in
                    // (    SELECT id_pago FROM pr_pago
                    //          INNER JOIN pr_poliza ON (pr_pago.id_poliza = pr_poliza.id_poliza)
                    //          WHERE  pr_poliza.id_spvs = id_spvs.SelectedValue.ToString()
                    //          AND   pr_pago.factura = nro_factura.Text
                    //  )"
                    var sql = _context.UpdatePagosFactura(id_spvs, nro_factura, fechaFactura.Date, nnro_factura);
                    dbContextTransaccion
                        return true;
                  
                }
                catch (SecureExceptions secureException)
                {
                    return false;
                }

            }
        }



    }
}
