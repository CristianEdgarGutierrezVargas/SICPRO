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
    public class Cpr_grupo
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_grupo(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion


        public List<pr_grupo> ObtenerGrupo()
        {
            try
            {
                var sql = _context.pr_grupo.ToList();                
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        
    }
}
