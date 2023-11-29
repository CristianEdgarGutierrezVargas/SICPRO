using Common;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cgr_direccion
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cgr_direccion(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public List<OC_DIRECCION_PARAMETRO> ObtenerListaDireccion(string varBusqueda)
        {
            try
            {
                var query = _context.gr_parametro    // your starting point - table in the "from" statement
                   .Join(_context.gr_direccion, // the source table of the inner join
                      para => para.id_par,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                      dire => dire.id_tpdir,   // Select the foreign key (the second part of the "on" clause)
                      (para, dire) => new { Para = para, Dire = dire }) // selection
                   .Where(postAndMeta => postAndMeta.Dire.id_per == varBusqueda)// where statement
                   .Select(s=> new OC_DIRECCION_PARAMETRO
                   {
                       id_dir = s.Dire.id_dir,
                       direccion = s.Dire.direccion,
                       desc_param = s.Para.desc_param
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

        //public DataTable ObtenerListaDireccion(string varbusqueda)
        //{
        //    try
        //    {
        //        string sentenciaSQL = "SELECT gr_direccion.id_dir, gr_direccion.direccion, gr_parametro.desc_param " +
        //            "FROM gr_parametro " +
        //            "INNER JOIN gr_direccion ON (gr_parametro.id_par = gr_direccion.id_tpdir) " +
        //            "WHERE gr_direccion.id_per = '" + varbusqueda + "' ORDER BY gr_direccion.id_dir ASC";
        //        Acceso acceso = new Acceso();
        //        acceso.Conectar();
        //        acceso.CrearComando(sentenciaSQL);
        //        DataTable result = acceso.Consulta();
        //        acceso.Desconectar();
        //        return result;
        //    }
        //    catch (SecureExceptions original)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", original);
        //    }
        //}

        public gr_direccion ObtenerDireccion(long varBusqueda)
        {
            try
            {
                var sql = _context.gr_direccion.Where(w => w.id_dir == varBusqueda).FirstOrDefault();
                                
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
            return null;
        }

        //public bool ObtenerDireccion(int varbusqueda)
        //{
        //    try
        //    {
        //        string sentenciaSQL = "SELECT gr_persona.nomraz, gr_direccion.id_dir, gr_direccion.id_per, gr_direccion.direccion, gr_direccion.id_tpdir, gr_direccion.telf_dir, gr_direccion.int_dire, gr_direccion.telf_cel, gr_direccion.telf_fax, gr_direccion.email, gr_direccion.casilla, gr_direccion.web, gr_direccion.id_emis FROM gr_persona INNER JOIN gr_direccion ON (gr_persona.id_per = gr_direccion.id_per) WHERE gr_direccion.id_dir = " + varbusqueda + " ORDER BY gr_direccion.id_dir";
        //        Acceso acceso = new Acceso();
        //        acceso.Conectar();
        //        acceso.CrearComando(sentenciaSQL);
        //        DataTable dataTable = acceso.Consulta();
        //        acceso.Desconectar();
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            nombrepersona.Text = dataTable.Rows[0]["nomraz"].ToString();
        //            id_dir.Value = dataTable.Rows[0]["id_dir"].ToString();
        //            id_per.Value = dataTable.Rows[0]["id_per"].ToString();
        //            direccion.Text = dataTable.Rows[0]["direccion"].ToString();
        //            ObtenerTipoDireccion(int.Parse(id_dir.Value));
        //            telf_dir.Text = dataTable.Rows[0]["telf_dir"].ToString();
        //            int_dire.Text = dataTable.Rows[0]["int_dire"].ToString();
        //            telf_cel.Text = dataTable.Rows[0]["telf_cel"].ToString();
        //            telf_fax.Text = dataTable.Rows[0]["telf_fax"].ToString();
        //            email.Text = dataTable.Rows[0]["email"].ToString();
        //            casilla.Text = dataTable.Rows[0]["casilla"].ToString();
        //            web.Text = dataTable.Rows[0]["web"].ToString();
        //            ObtenerLugarEmision(int.Parse(id_dir.Value));
        //            return true;
        //        }

        //        return false;
        //    }
        //    catch (SecureExceptions original)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", original);
        //    }
        //}

        public gr_direccion InsertarDireccion(gr_direccion objDireccion)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.gr_direccion.Add(objDireccion);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return objDireccion;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        public bool ModificarDireccion(gr_direccion objDireccion)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.gr_direccion.Where(w => w.id_dir == objDireccion.id_dir).FirstOrDefault();

                    if (sql == null)
                    {
                        return false;
                    }
                    else
                    {
                        sql.direccion = objDireccion.direccion;
                        sql.id_tpdir = objDireccion.id_tpdir;
                        sql.telf_dir = objDireccion.telf_dir;
                        sql.int_dire = objDireccion.int_dire;
                        sql.telf_cel = objDireccion.telf_cel;

                        sql.telf_fax = objDireccion.telf_fax;
                        sql.email = objDireccion.email;
                        sql.casilla = objDireccion.casilla;
                        sql.web = objDireccion.web;
                        sql.id_emis = objDireccion.id_emis;
                                                                        
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

    }
}
