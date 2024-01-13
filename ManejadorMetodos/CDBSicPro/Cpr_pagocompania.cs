using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                var response = _context.pr_pagocompania.Add(objPr_Pagocompania);
                _context.SaveChanges();
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
