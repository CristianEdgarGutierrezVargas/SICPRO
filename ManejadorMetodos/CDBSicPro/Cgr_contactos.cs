using Common;
using EntidadesClases.CustomModelEntities;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cgr_contactos
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cgr_contactos(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public List<OC_DIRECCION_CONTACTO> ObtenerListaContactosByIdPer(string idPer)
        {
            try
            {
                var query = _context.gr_contacto    // your starting point - table in the "from" statement
                   .Join(_context.gr_direccion, // the source table of the inner join
                      para => para.id_dir,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                      dire => dire.id_dir,   // Select the foreign key (the second part of the "on" clause)
                      (para, dire) => new { Para = para, Dire = dire }) // selection
                   .Where(p => p.Dire.id_per == idPer)// where statement
                   .Select(s => new OC_DIRECCION_CONTACTO
                   {
                       id_dir = s.Dire.id_dir,
                       direccion = s.Dire.direccion,
                       id_per = s.Para.id_per,
                       relacion = s.Para.relacion
                   })
                   .ToList();

                return query;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
            return null;
        }

    }
}
