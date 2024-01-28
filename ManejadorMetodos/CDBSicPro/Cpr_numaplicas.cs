using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_numaplicas
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_numaplicas(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion


        public pr_numaplicas InsertarNumAplicas(pr_numaplicas objNumAplicas)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_numaplicas.Add(objNumAplicas);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return objNumAplicas;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        public SavePrNumAplicas_Result InsertarSpNumAplicas(pr_numaplicas objNumAplicas)
        {
            //using (var dbContextTransaction = _context.Database.BeginTransaction())
            //{
                try
                {
                    var sql = _context.SavePrNumAplicas(
                        objNumAplicas.id_poliza
                        , objNumAplicas.id_movimiento
                        , objNumAplicas.del
                        , objNumAplicas.al
                        , objNumAplicas.id_mom
                        ).FirstOrDefault();
                    //dbContextTransaction.Commit();
                    return sql;
                }
                catch (Exception ex)
                {
                    //dbContextTransaction.Rollback();
                    return null;
                }
            //}
        }

    }
}
