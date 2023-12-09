using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using Common;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Data;
using EntidadesClases.CustomModelEntities;

namespace Logica.Consumo
{
    public class ConsumoValidarProd
    {
        #region Contructor Principal

        private readonly Cpr_poliza _manejador_pr_poliza;
        private readonly Cgr_persona _manejador_gr_persona;
        private readonly Cpr_cobranzas _manejador_pr_cobranzas;
        private readonly Cvcb_veripoliza1 _manejador_vcb_veripoliza1;
        private readonly Cpr_producto _manejador_pr_producto;
        private readonly Cpr_formriesgo _manejador_pr_formriesgo;
        public static sicproEntities dbContext;
        public ConsumoValidarProd()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_pr_poliza = new Cpr_poliza(dbContext);
            _manejador_pr_cobranzas = new Cpr_cobranzas(dbContext);
            _manejador_vcb_veripoliza1 = new Cvcb_veripoliza1(dbContext);
            _manejador_pr_producto = new Cpr_producto(dbContext);
            _manejador_pr_formriesgo = new Cpr_formriesgo(dbContext);
            _manejador_gr_persona = new Cgr_persona(dbContext);
        }

        #endregion

        public List<vcb_veripoliza1> ObtenerTablaPolizaNRI(string id_clamov, string num_poliza, string id_per, string id_spvs, string id_producto, bool vigencia, DateTime fc_inivig, DateTime fc_finvig, DateTime fc_polizavencida, bool porvencer)
        {

            try
            {
                var sql1 = _manejador_vcb_veripoliza1.GetListVeripolizaByEstado(true).Where(x => x.id_clamov == Convert.ToInt64(id_clamov)).Select(x => x);
                //  string sql1 = string.Concat("SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vcb_veripoliza1 WHERE estado='true'", sql);

                //string sql = "";
                if (num_poliza != null & (num_poliza.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.num_poliza.Contains(num_poliza.ToUpper())).Select(x => x);
                    // sql = string.Concat(sql, "AND num_poliza LIKE '%", num_poliza.ToUpper(), "%'");
                }
                if (id_per != null & (id_per != ""))
                {
                    sql1 = sql1.Where(x => x.id_perclie.Contains(id_per.ToUpper())).Select(x => x);
                    //sql = string.Concat(sql, "AND id_perclie LIKE '%", id_per.ToUpper(), "%'");
                }
                if (id_spvs != null & (id_spvs != ""))
                {
                    sql1 = sql1.Where(x => x.id_spvs.Contains(id_spvs)).Select(x => x);
                    //sql = string.Concat(sql, "AND id_spvs LIKE '%", id_spvs, "%'");
                }
                if (id_producto != "0")
                {
                    sql1 = sql1.Where(x => x.id_producto == Convert.ToInt64(id_producto)).Select(x => x);
                    //sql = string.Concat(sql, "AND id_producto=", id_producto);
                }
                if (vigencia && fc_inivig != null && fc_finvig != null)
                {
                    sql1 = sql1.Where(x => x.fc_inivig >= fc_inivig && x.fc_inivig <= fc_finvig).Select(x => x);
                    //string[] strArrays = new string[] { sql, "AND fc_inivig BETWEEN '", Funciones.fc(fc_inivig), "' AND '", Funciones.fc(fc_polizavencida), "'" };
                    //sql = string.Concat(strArrays);
                }
                if (porvencer & fc_polizavencida != null)
                {
                    sql1.Where(x => x.fc_finvig <= fc_polizavencida).Select(x => x);
                    //sql = string.Concat(sql, "AND fc_finvig <= '", Funciones.fc(fc_polizavencida), "'");
                }

                return sql1.ToList();

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }
        public List<gr_persona> ObtenerTablaPersonasC(string varbusqueda)
        {
            List<gr_persona> dt;
            try
            {
                dt = _manejador_gr_persona.ObtenerTablaPersonasC(varbusqueda).OrderBy(x => x.nomraz).ToList();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }
            return dt;

        }


        public List<OcTablaProductoL> ObtenerTablaProductoL(string varbusqueda, string desc_prod)
        {
            List<OcTablaProductoL> sql;
            try
            {
                var producto = _manejador_pr_producto.GetListProducto();
                var formriesgo = _manejador_pr_formriesgo.GetListFormriesgo();
                sql = (List<OcTablaProductoL>)formriesgo.Join(producto, x => x.id_producto, s => s.id_producto, (x, s) => new { s.id_producto, s.desc_prod, x.id_spvs }).Where(x => x.id_spvs == varbusqueda && x.desc_prod.Contains(desc_prod)).OrderBy(x => x.desc_prod).Select(x => new { x.id_producto, x.desc_prod });
                // string[] strArrays = new string[] { "SELECT pr_producto.id_producto, pr_producto.desc_prod FROM pr_formriesgo INNER JOIN pr_producto ON (pr_formriesgo.id_producto = pr_producto.id_producto) WHERE pr_formriesgo.id_spvs = '", varbusqueda, "' AND pr_producto.desc_prod LIKE '%", desc_prod, "%' ORDER BY desc_prod" };
                //string sql = string.Concat(strArrays);
                //Acceso db = new Acceso();
                // db.Conectar();
                // db.CrearComando(sql);
                //DataTable dtgeneral = sql.Consulta();
                //db.Desconectar();
                //dataTable = dtgeneral;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
            return sql;
        }


    }
}
