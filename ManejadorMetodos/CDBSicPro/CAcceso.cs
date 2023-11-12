using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class CAcceso
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public CAcceso(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

       
    }
}
