using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cvcb_repcobranzas1
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cvcb_repcobranzas1(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

       
    }
}
