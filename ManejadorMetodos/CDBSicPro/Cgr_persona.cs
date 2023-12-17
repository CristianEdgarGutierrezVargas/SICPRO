using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cgr_persona
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cgr_persona(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public bool EliminarPersona(string varbusqueda)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.gr_persona.Where(w => w.id_per == varbusqueda).FirstOrDefault();
                    _context.gr_persona.Remove(sql);
                    //_context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }               
            }
        }

        public bool ExistePersona(string varbusqueda)
        {
            try
            {
                var sql = _context.gr_persona.Where(w => w.id_per == varbusqueda).ToList();
                if (sql.Count<=0)
                {
                    return false;
                }
                else
                {
                    return true;
                }              
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public gr_persona InsertarPersona(gr_persona objPersona)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.gr_persona.Add(objPersona);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return objPersona;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        public bool ModificarPersona(gr_persona objPersona)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.gr_persona.Where(w=>w.id_per == objPersona.id_per).FirstOrDefault();

                    if (sql == null)
                    {
                        return false;
                    }
                    else
                    {
                        sql.nomraz = objPersona.nomraz;
                        sql.id_tper = objPersona.id_tper;
                        sql.fechaaniv = objPersona.fechaaniv;
                        sql.id_sal = objPersona.id_sal;
                        sql.id_rol = objPersona.id_rol;
                        sql.id_tdoc = objPersona.id_tdoc;
                        sql.id_emis = objPersona.id_emis;
                        sql.nit_fac = objPersona.nit_fac;
                        sql.id_suc = objPersona.id_suc;
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


        public List<gr_persona> ObtenerListaPersona()
        {
            try
            {
                var sql = _context.gr_persona.ToList();
                return sql;
                //string sql = "SELECT * FROM gr_persona";               
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public List<gr_persona> ObtenerListaPersonaByNombre(string strNombre)
        {
            try
            {
               

                var sql = _context.gr_persona.Where(w=>w.nomraz.ToUpper().Contains(strNombre.ToUpper())).ToList();
                return sql;
                //string sql = "SELECT * FROM gr_persona";               
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        private List<gr_persona> GetPersonaPaginacion(string strNombre)
        {
            //We want to display 4 Records Per page
            int RecordsPerPage = 500;
            //Set the Initial Page Number as 0
            int PageNumber = 0;

            do
            {
                Console.WriteLine("\nEnter the Page Number Between 1 and 4");
                //Read the Value and if its integer type, then store that value in the PageNumber variable
                if (int.TryParse(Console.ReadLine(), out PageNumber))
                {
                    //Check if PageNumber is > 0 and < 5
                    if (PageNumber > 0 && PageNumber < 5)
                    {
                        var sql = _context.gr_persona.Where(w => w.nomraz.ToUpper().Contains(strNombre.ToUpper()))
                            .Skip((PageNumber - 1) * RecordsPerPage) //Skip Logic
                            .Take(RecordsPerPage) //Take Logic
                            .ToList();
                        return sql;

                        ////Logic to Implement Paging
                        //var employees = Employee.GetAllEmployees() //Data Source
                        //            .Skip((PageNumber - 1) * RecordsPerPage) //Skip Logic
                        //            .Take(RecordsPerPage).ToList(); //Take Logic

                        //foreach (var emp in employees)
                        //{
                        //    Console.WriteLine($"ID : {emp.ID}, Name : {emp.Name}, Department : {emp.Department}");
                        //}
                    }
                    else
                    {
                        Console.WriteLine("\nPlease Enter a Valid Page Number");
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease Enter a Valid Page Number");
                }
            } while (true);
        }


        public gr_persona ObtenerPersona(string varbusqueda)
        {
            try
            {

                var sql = _context.gr_persona.Where(w=>w.id_per.TrimStart().TrimEnd() == varbusqueda.TrimStart().TrimEnd()).ToList();

                if (sql.Count > 0)
                {
                    return sql.First();
                }
                return null;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        //consulta en duro
        public List<gr_persona> ObtenerEjecutivoClientes()
        {
            try
            {

                var sql = _context.gr_persona.Where(w => w.id_rol == 30).OrderBy(o=>o.nomraz).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        //public void ObtenerEjecutivoClientes()
        //{
        //    try
        //    {
        //        string sql = "SELECT gr_persona.nomraz, gr_persona.id_per FROM gr_persona WHERE gr_persona.id_rol = 30 order by gr_persona.nomraz UNION SELECT 0, 'SELECCIONE UNA OPCIÓN'";
        //        Acceso db = new Acceso();
        //        db.Conectar();
        //        db.CrearComando(sql);
        //        DataTable dtgeneral = db.Consulta();
        //        this.id_rol.DataSource = dtgeneral;
        //        this.id_rol.DataTextField = "nomraz";
        //        this.id_rol.DataValueField = "id_per";
        //        this.id_rol.DataBind();
        //        db.Desconectar();
        //    }
        //    catch (SecureExceptions secureException)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", secureException);
        //    }
        //}


        public List<gr_persona> TablaPersona(string varbusqueda)
        {
            //string sql = string.Concat("SELECT gr_persona.id_per, gr_persona.nomraz FROM gr_persona WHERE gr_persona.nomraz LIKE '%", varbusqueda, "%' order by gr_persona.nomraz asc ");
            try
            {
                var sql = from persona in _context.gr_persona
                          where persona.nomraz.Contains(varbusqueda)
                          orderby persona.nomraz ascending
                          select persona;
                return sql.ToList();

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public List<gr_persona> Persona(int parametro)
        {
            try
            {
                //string sql = string.Concat("SELECT gr_persona.id_per, gr_persona.nomraz FROM gr_persona WHERE gr_persona.id_rol =", parametro, " UNION SELECT '0', ' SELECCIONE UNA OPCIÓN' order by nomraz");
                var sql = _context.gr_persona.Where(w => w.id_rol == parametro).OrderBy(o => o.nomraz).ToList();
                sql.Add(new gr_persona { id_per = "0", nomraz = "SELECCIONE UNA OPCIÓN" });
                //sql = sql.OrderBy(o => o.id_per).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        //public void Persona(int parametro)
        //{
        //    try
        //    {
        //        string sentenciaSQL = "SELECT gr_persona.id_per, gr_persona.nomraz FROM gr_persona WHERE gr_persona.id_rol =" + parametro + " UNION SELECT '0', ' SELECCIONE UNA OPCIÓN' order by nomraz";
        //        Acceso acceso = new Acceso();
        //        acceso.Conectar();
        //        acceso.CrearComando(sentenciaSQL);
        //        DataTable dataSource = acceso.Consulta();
        //        id_rol.DataSource = dataSource;
        //        id_rol.DataTextField = "nomraz";
        //        id_rol.DataValueField = "id_per";
        //        id_rol.DataBind();
        //        acceso.Desconectar();
        //    }
        //    catch (SecureExceptions original)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", original);
        //    }
        //}
        public List<gr_persona> ObtenerTablaPersonasC(string strNombre)
        {
            List<gr_persona> sql;
            try
            {

                if (string.IsNullOrEmpty(strNombre))
                    sql = _context.gr_persona.ToList();
                else
                    sql = _context.gr_persona.Where(w => w.nomraz.ToUpper().Contains(strNombre.ToUpper())).ToList();

                return sql;
                //string sql = "SELECT * FROM gr_persona";               
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
    }
}
