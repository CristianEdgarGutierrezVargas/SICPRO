using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
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
                          select  pass).FirstOrDefault() ;
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
    }
}
