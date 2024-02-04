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
    public class Cpr_anulada
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_anulada(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public pr_anulada InsertarPrAnulada(pr_anulada objPrAnulada)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_anulada.Add(objPrAnulada);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return objPrAnulada;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }
        public List<pr_anulada> ObtenerGridA(long idPoliza, long idMov)
        {
            try
            {
                var sql = _context.pr_anulada.Where(w => w.id_poliza == idPoliza && w.id_movimiento == idMov).ToList();
                //string sentenciaSQL = "SELECT vpr_formriesgo.opera, evaluar, vpr_formriesgo.comis_riesgo, vpr_formriesgo.por_cred, vpr_formriesgo.plus_neta " +
                //    "FROM vpr_formriesgo WHERE vpr_formriesgo.id_producto = " + id_producto.Value + " " +
                //    "AND vpr_formriesgo.id_spvs = '" + id_spvs1.Value + "'";              
                return sql;
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }
        public bool ModificarCuotaPolizaCA(pr_anulada objAnulada)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_anulada.Where(w => w.id_poliza == objAnulada.id_poliza && w.id_movimiento== objAnulada.id_movimiento).FirstOrDefault();

                    if (sql == null)
                    {
                        return false;
                    }
                    else
                    {
                        sql.monto_anulada = objAnulada.monto_anulada;
                        sql.neta_anulada = objAnulada.neta_anulada;
                        sql.comision_anulada = objAnulada.comision_anulada;
                       
                        _context.SaveChanges();
                        dbContextTransaction.Commit();

                        return true;
                    }
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
