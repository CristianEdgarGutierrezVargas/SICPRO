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
    public class Cgr_componente
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cgr_componente(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public List<vgr_comprol> ObtenerTablaComp(decimal idComponente, long idRol)
        {
            try
            {
                var sql = _context.vgr_comprol.Where(w => w.dep_com == idComponente && w.id_rol == idRol).OrderBy(o => o.id_com).ToList();
                return sql;
                //string sentenciaSQL = "SELECT * FROM vgr_comprol WHERE vgr_comprol.dep_com = " + var1 + " " +
                //    "AND vgr_comprol.id_rol = " + var2 + " ORDER BY id_com ASC";
               
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }
    }
}
