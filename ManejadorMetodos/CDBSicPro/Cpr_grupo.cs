using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
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
                var sql = _context.pr_grupo.Select(x=>x).ToList();                
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public pr_grupo ObtenerGrupo(long? id_gru)
        {
            try
            {
                if (id_gru != 0)
                {
                    var sql = _context.pr_grupo.Where(w=>w.id_gru == id_gru).FirstOrDefault();
                return sql;
                }
                return null;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        //public void ObtenerGrupo(int id_gru)
        //{
        //    try
        //    {
        //        string sql = string.Concat("SELECT * FROM pr_grupo WHERE id_gru=", id_gru);
        //        Acceso db = new Acceso();
        //        db.Conectar();
        //        db.CrearComando(sql);
        //        DataTable dt = db.Consulta();
        //        if (dt.Rows.Count > 0)
        //        {
        //            this.id_gru.Value = dt.Rows[0][1].ToString();
        //            this.desc_grupo.Text = dt.Rows[0][0].ToString();
        //        }
        //    }
        //    catch (SecureExceptions secureException)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", secureException);
        //    }
        //}

        public List<pr_grupo> TablaGrupo()
        {
            try
            {                
                    var sql = _context.pr_grupo.OrderBy(ob=>ob.id_gru).OrderByDescending(o=>o.id_gru).ToList();
                    return sql;               
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        //public DataTable TablaGrupo()
        //{
        //    try
        //    {
        //        string sentenciaSQL = "SELECT * FROM pr_grupo ORDER BY id_gru";
        //        Acceso acceso = new Acceso();
        //        acceso.Conectar();
        //        acceso.CrearComando(sentenciaSQL);
        //        return acceso.Consulta();
        //    }
        //    catch (SecureExceptions original)
        //    {
        //        throw new SecureExceptions("Error al Genera la Consulta", original);
        //    }
        //}

        public pr_grupo InsertarGrupo(pr_grupo objGrupo)
        {
            try
            {
                var sql = _context.pr_grupo.Add(objGrupo);
                _context.SaveChanges();
                return sql;

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public pr_grupo ModificarGrupo(pr_grupo objGrupo)
        {
            try
            {
                var sql = _context.pr_grupo.Where(w=>w.id_gru == objGrupo.id_gru).FirstOrDefault();
                sql.desc_grupo = objGrupo.desc_grupo;
                _context.SaveChanges();
                return sql;

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public bool EliminarGrupo(decimal decIdGrupo)
        {
            try
            {
                var sql = _context.pr_grupo.Where(w => w.id_gru == decIdGrupo).FirstOrDefault();
                _context.pr_grupo.Remove(sql);
                _context.SaveChanges();
                return true;

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
       
    }
}
