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

        public List<v_pr_cias_resum> ObtenerListaCompania()
        {
            try
            {
                var sql = _context.v_pr_cias_resum.ToList();
                return sql;
                
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }
        //public void ObtenerListaCompania()
        //{
        //    try
        //    {
        //        string sentenciaSQL = "SELECT v_pr_cias_resum.id_spvs, v_pr_cias_resum.nomraz FROM v_pr_cias_resum UNION SELECT '0' as spvs, ' SELECCIONE UNA OPCIÓN' as nomraz order by nomraz";
        //        Acceso acceso = new Acceso();
        //        acceso.Conectar();
        //        acceso.CrearComando(sentenciaSQL);
        //        DataTable dataSource = acceso.Consulta();
        //        ddlgeneral.DataSource = dataSource;
        //        ddlgeneral.DataTextField = "nomraz";
        //        ddlgeneral.DataValueField = "id_spvs";
        //        ddlgeneral.DataBind();
        //        acceso.Desconectar();
        //    }
        //    catch (SecureExceptions original)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", original);
        //    }
        //}
        public List<gr_compania> ListaCompania()
        {
            try
            {
                var sql = _context.gr_compania.ToList();
                return sql;

            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }
        public gr_compania GetCompaniaById(string idCompania)
        {
            try
            {                
                var sql = _context.gr_compania.AsEnumerable().FirstOrDefault(x=>x.id_spvs== idCompania);
                return sql;

            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al Generar la Consulta", original);
            }
        }
    }
}
