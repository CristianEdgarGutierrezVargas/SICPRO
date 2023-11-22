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
    public class Cgr_compania
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cgr_compania(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion


        //public List<pr_grupo> ObtenerGrupo()
        //{
        //    try
        //    {
        //        var sql = _context.v_pr_cias_resum.ToList();
        //        return sql;
        //    }
        //    catch (SecureExceptions secureException)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", secureException);
        //    }
        //}

    }
}
