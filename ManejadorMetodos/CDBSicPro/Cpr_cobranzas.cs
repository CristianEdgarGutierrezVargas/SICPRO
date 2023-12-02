using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_cobranzas
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_cobranzas(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
       
    }
}
