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
    public class Cco_presprod
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cco_presprod(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public bool InsertarPres(co_presprod objPresProd)
        {

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.co_presprod.Add(objPresProd);
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

            //string[] strArrays = new string[] { "UPDATE public.co_presprod SET monto_proy = ", this.monto_proy.Text.Replace(".", "").Replace(",", "."), ", monto_cproy = ", this.monto_cproy.Text.Replace(".", "").Replace(",", "."), " WHERE mes_proy = '", this.mes_proy.SelectedValue.ToString(), "' AND anio_proy = '", this.anio_proy.SelectedValue.ToString(), "' AND id_percart = '", this.id_percart.SelectedValue.ToString(), "' AND id_suc = ", this.id_suc.SelectedValue.ToString() };

        }

        public bool modifPres (co_presprod objPresProd)
        {

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.co_presprod.Where(w => w.mes_proy == objPresProd.mes_proy && w.anio_proy == objPresProd.anio_proy && w.id_percart == objPresProd.id_percart && w.id_suc == objPresProd.id_suc).FirstOrDefault();

                    if (sql == null)
                    {
                        return false;
                    }
                    else
                    {
                        sql.monto_proy = objPresProd.monto_proy;
                        sql.monto_cproy = objPresProd.monto_cproy;

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

            //string[] strArrays = new string[] { "UPDATE public.co_presprod SET monto_proy = ", this.monto_proy.Text.Replace(".", "").Replace(",", "."), ", monto_cproy = ", this.monto_cproy.Text.Replace(".", "").Replace(",", "."), " WHERE mes_proy = '", this.mes_proy.SelectedValue.ToString(), "' AND anio_proy = '", this.anio_proy.SelectedValue.ToString(), "' AND id_percart = '", this.id_percart.SelectedValue.ToString(), "' AND id_suc = ", this.id_suc.SelectedValue.ToString() };

        }

        public List<co_presprod> GetListPresProd(string strIdPerCart, string strAnioProy)
        {

            try
            {
                //SELECT co_presprod.mes_proy, co_presprod.anio_proy, co_presprod.id_percart, co_presprod.monto_proy, co_presprod.monto_cproy,
                //(SELECT gr_parametro.desc_param FROM gr_parametro WHERE gr_parametro.id_par = co_presprod.id_suc) AS sucursal  FROM co_presprod
                //WHERE id_percart = '", this.id_percart.SelectedValue, "' and anio_proy = '", this.anio_proy.SelectedValue, "' ORDER BY anio_proy, mes_proy" };

                var sql = _context.co_presprod.Where(w => w.id_percart == strIdPerCart && w.anio_proy == strAnioProy).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
            return null;
        }
    }
}
