using Common;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public List<OC_DIRECCION_CONTACTO> ObtenerListaContactosByIdDir(long idDir)
        {
            try
            {
                var query = _context.gr_contacto    // your starting point - table in the "from" statement
                   .Join(_context.gr_direccion, // the source table of the inner join
                      para => para.id_dir,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                      dire => dire.id_dir,   // Select the foreign key (the second part of the "on" clause)
                      (para, dire) => new { Para = para, Dire = dire }) // selection
                   .Join(_context.gr_persona, // the source table of the inner join
                      cont => cont.Para.id_per,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                      per => per.id_per,   // Select the foreign key (the second part of the "on" clause)
                      (cont, per) => new { Cont = cont, Per = per }) // selection
                   .Where(p => p.Cont.Para.id_dir == idDir)// where statement
                   .Select(s => new OC_DIRECCION_CONTACTO
                   {
                       id_dir = s.Cont.Dire.id_dir,
                       direccion = s.Cont.Dire.direccion,
                       id_per = s.Cont.Para.id_per,
                       relacion = s.Cont.Para.relacion,
                       nomraz = s.Per.nomraz
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


        public OC_DIRECCION_CONTACTO ObtenerContactosByIdPerDir(string idPer, long longIdDir)
        {
            try
            {
                var query = _context.gr_contacto    // your starting point - table in the "from" statement
                   .Join(_context.gr_direccion, // the source table of the inner join
                      cont => cont.id_dir,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                      dire => dire.id_dir,   // Select the foreign key (the second part of the "on" clause)
                      (cont, dire) => new { Cont = cont, Dire = dire }) // selection
                   .Where(p => p.Dire.id_per == idPer && p.Cont.id_dir == longIdDir)// where statement
                   .Select(s => new OC_DIRECCION_CONTACTO
                   {
                       id_dir = s.Dire.id_dir,
                       direccion = s.Dire.direccion,
                       id_per = s.Cont.id_per,
                       relacion = s.Cont.relacion
                   })
                   .FirstOrDefault();

                return query;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
            return null;
        }


        public bool ModificarContacto(gr_contacto objContacto)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.gr_contacto.Where(w => w.id_dir == objContacto.id_dir && w.id_per == objContacto.id_per).FirstOrDefault();

                    if (sql == null)
                    {
                        return false;
                    }
                    else
                    {
                        sql.relacion = objContacto.relacion;

                        _context.SaveChanges();
                        dbContextTransaction.Commit();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public gr_contacto InsertarContacto(gr_contacto objContacto)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.gr_contacto.Add(objContacto);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return objContacto;
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
