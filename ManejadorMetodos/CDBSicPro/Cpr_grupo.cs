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

        public pr_grupo ObtenerGrupo(long? id_gru)
        {
            try
            {
                var sql = _context.pr_grupo.Where(w=>w.id_gru == id_gru).FirstOrDefault();
                return sql;
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

    }
}
