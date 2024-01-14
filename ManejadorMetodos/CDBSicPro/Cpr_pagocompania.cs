using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesClases.CustomModelEntities;


namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_pagocompania
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_pagocompania(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public pr_pagocompania InsertarPagoComp(pr_pagocompania objPr_Pagocompania)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var response = _context.pr_pagocompania.Add(objPr_Pagocompania);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return response;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }
    }
}
