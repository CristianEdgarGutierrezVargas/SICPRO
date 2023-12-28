using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cgr_pass
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cgr_pass(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public List<gr_persona> ListaPersonaConPass()
        {
            //metodo del decompilado
            //string sentenciaSQL = "SELECT gr_persona.nomraz, gr_persona.id_per FROM gr_persona INNER JOIN gr_pass ON (gr_persona.id_per = gr_pass.id_per)";
            try
            {
                var sql = from
                            persona in _context.gr_persona
                          join pass in _context.gr_pass on persona.id_per equals pass.id_per
                          select persona;
                return sql.ToList();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }

        }

        public void ResetPassword(string idPersona)
        {
            //metodo del decompilado
            //string[] strArrays = new string[] { "UPDATE gr_pass SET clave='", this.GenerarClave("12345".ToUpper()), "', cambio=true WHERE id_per='", this.id_per.SelectedValue, "'" };
            try
            {
                var sql = (from pass in _context.gr_pass
                           where pass.id_per == idPersona
                           select pass).FirstOrDefault();
                sql.clave = GenerarClave("12345".ToUpper());
                sql.cambio = true;

                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        private string GenerarClave(string contraseña)
        {
            byte[] data = (new UTF8Encoding()).GetBytes(contraseña);
            byte[] resultado = (new SHA1CryptoServiceProvider()).ComputeHash(data);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < (int)resultado.Length; i++)
            {
                if (resultado[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(resultado[i].ToString("X"));
            }
            return sb.ToString().ToUpper();
        }

        public void AgregaUsuario(string login, decimal id_rol, string id_pert)
        {
            try
            {
                //string[] value = new string[] { "INSERT INTO gr_pass VALUES ('", this.id_pert.Value, "','", this.GenerarClave("12345"), "','true','", this.login.Text.ToUpper(), "',default,", this.id_rol.SelectedValue, ")" };
                gr_pass item = new gr_pass();
                item.id_per = id_pert;
                item.clave = GenerarClave("12345".ToUpper());
                item.cambio = true;
                item.login = login;
                item.logged = default(bool);
                item.id_rol = id_rol;
                _context.gr_pass.Add(item);
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void ModificarUsuario1(string login, decimal id_rol, string id_pert)
        {
            try
            {
                //string[] str = new string[] { "UPDATE gr_pass SET login='", this.login.Text.ToUpper().ToString(), "', id_rol=", this.id_rol.SelectedValue, " WHERE id_per='", id_per, "'" };
                var sql = (from pass in _context.gr_pass
                           where pass.id_per == id_pert
                           select pass).FirstOrDefault();
                sql.login = login.ToUpper();
                sql.id_rol = id_rol;

                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public void ObtenerDatos(string id_per, out gr_persona personaOut, out gr_pass passOut)
        {
            personaOut = null; passOut = null;
            try
            {
                //string sql = string.Concat("SELECT gr_pass.id_per, gr_persona.nomraz, gr_pass.login, gr_pass.id_rol FROM gr_persona INNER JOIN gr_pass ON (gr_persona.id_per = gr_pass.id_per) WHERE gr_pass.id_per = '", id_per, "'");
                var sql = (from pass in _context.gr_pass
                           join persona in _context.gr_persona on pass.id_per equals persona.id_per
                           where pass.id_per == id_per
                           select new
                           {
                               personaOut = persona,
                               passOut = pass
                           }).FirstOrDefault();
                personaOut = sql.personaOut;
                passOut = sql.passOut;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public bool VerificarUsuario(string usuario, string contraseña)
        {

            try
            {
                var strClave = GenerarClave(contraseña);
                //var sql = _context.gr_persona.Join(_context.gr_pass, x => x.id_per, s => s.id_per, ((x, s) => new { s.login, s.clave })).Where( x =>x.login.ToUpper()== usuario.ToUpper() && x.clave== strClave).ToList();
                // var per = _context.gr_persona.ToList();
                var sql = from
                            persona in _context.gr_persona
                          join pass in _context.gr_pass on persona.id_per equals pass.id_per
                          where pass.clave == strClave && pass.login == usuario
                          select persona;
                //var t = sql.ToList();
                if (sql.ToList().Count() > 0)
                {
                    return true;
                }
                return false;

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }


        }
        public string ObtenerSuc(string usuario, string contraseña)
        {
            try
            {
                var strClave = GenerarClave(contraseña);
                var sql = from
                            persona in _context.gr_persona
                          join pass in _context.gr_pass on persona.id_per equals pass.id_per
                          where pass.clave == strClave && pass.login == usuario
                          select persona;
                if (sql.ToList().Count() == 0)
                {
                    return "";
                }
                else
                {
                    return sql.FirstOrDefault().id_suc.ToString();
                }


            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }

        }
        public string ObtenerRol(string usuario, string contraseña)
        {
            try
            {
                var strClave = GenerarClave(contraseña);
                var sql = from
                            persona in _context.gr_persona
                          join pass in _context.gr_pass on persona.id_per equals pass.id_per
                          where pass.clave == strClave && pass.login == usuario
                          select pass;
                if (sql.ToList().Count() == 0)
                {
                    return "";
                }
                else
                {
                    return sql.FirstOrDefault().id_rol.ToString();
                }
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }

        }
        public string ObtenerId(string usuario, string contraseña)
        {
            try
            {
                var strClave = GenerarClave(contraseña);
                var sql = from
                            persona in _context.gr_persona
                          join pass in _context.gr_pass on persona.id_per equals pass.id_per
                          where pass.clave == strClave && pass.login == usuario
                          select persona;
                if (sql.ToList().Count() == 0)
                {
                    return "";
                }
                else
                {
                    return sql.FirstOrDefault().id_per.ToString();
                }
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public bool Logeo(string id_per)
        {
            bool flag=false;
            try
            {
                var sql = (from pass in _context.gr_pass
                           where pass.id_per == id_per
                           select pass).FirstOrDefault();
                sql.logged = !sql.logged;

                _context.SaveChanges();
                flag= true;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
            return flag;


               // string sql = string.Concat("UPDATE gr_pass SET logged = NOT logged WHERE id_per='", id_per, "'");
        
          
        }

        public bool VerificarEstado(string usuario, string contraseña)
        {

            try
            {
                var strClave = GenerarClave(contraseña);
                var sql = from
                            persona in _context.gr_persona
                          join pass in _context.gr_pass on persona.id_per equals pass.id_per
                          where pass.cambio==true && pass.clave == strClave && pass.login == usuario
                          select pass;
                if (sql.ToList().Count > 0)
                {
                    return true;
                }
                return false;

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }

          
        }
    }
}
