using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesClases.ModelSicPro;
using ManejadorMetodosSql.CDBSicPro;
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
        private readonly Cgr_compania _manejador_gr_compania;
        private readonly Cpr_grupo _manejador_pr_grupo;
        private readonly Cgr_parametro _manejador_gr_parametro;
        private readonly Cpr_polmov _manejador_pr_polmov;
        public static sicproEntities dbContext;
        private readonly Cvcb_veripoliza2 _manejador_vcb_veripoliza2;
        private readonly Cvcb_veripoliza3 _manejador_vcb_veripoliza3;
        private readonly CSpr_calcfrmcred _manejadorSql_calcfrmCred;

        public ConsumoValidarProd()
        {
            //if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_pr_poliza = new Cpr_poliza(dbContext);
            _manejador_pr_cobranzas = new Cpr_cobranzas(dbContext);
            _manejador_vcb_veripoliza1 = new Cvcb_veripoliza1(dbContext);
            _manejador_pr_producto = new Cpr_producto(dbContext);
            _manejador_pr_formriesgo = new Cpr_formriesgo(dbContext);
            _manejador_gr_persona = new Cgr_persona(dbContext);
            _manejador_gr_compania = new Cgr_compania(dbContext);
            _manejador_pr_grupo = new Cpr_grupo(dbContext);
            _manejador_gr_parametro=new Cgr_parametro(dbContext);
            _manejador_pr_polmov=new Cpr_polmov(dbContext);
            _manejador_vcb_veripoliza2 = new Cvcb_veripoliza2(dbContext);
            _manejador_vcb_veripoliza3 = new Cvcb_veripoliza3(dbContext);
            _manejadorSql_calcfrmCred = new CSpr_calcfrmcred();
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
            List<OcTablaProductoL> sql = new List<OcTablaProductoL>();
            try
            {
                var producto = _manejador_pr_producto.GetListProducto(desc_prod);
                var formriesgo = _manejador_pr_formriesgo.GetListFormriesgo();
                var sql1 = formriesgo.Join(producto, x => x.id_producto, s => s.id_producto, (x, s) => new { s.id_producto, s.desc_prod, x.id_spvs }).Where(x => x.id_spvs == varbusqueda).OrderBy(x => x.desc_prod).Select(x => new { x.id_producto, x.desc_prod });
                foreach (var dt in sql1)
                {
                    var dato = new OcTablaProductoL();
                    dato.id_producto = dt.id_producto;
                    dato.desc_prod = dt.desc_prod;
                    sql.Add(dato);
                }
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
            return sql;
        }
        public List<OcTablaCompaniaPersona> ObtenerTablaCompania(string varbusqueda)
        {
            List<OcTablaCompaniaPersona> sql = new List<OcTablaCompaniaPersona>();
            try
            {
                var persona = _manejador_gr_persona.ObtenerTablaPersonasC(varbusqueda);
                var compania = _manejador_gr_compania.ListaCompania();

                var sql1 = compania.Join(persona, x => x.id_per, s => s.id_per, (x, s) => new { s.nomraz, x.id_spvs }).Select(x => new { x.id_spvs, x.nomraz });
                foreach (var dt in sql1)
                {
                    var dato = new OcTablaCompaniaPersona();
                    dato.id_spvs = Convert.ToInt64(dt.id_spvs);
                    dato.nomraz = dt.nomraz;
                    sql.Add(dato);
                }
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
            return sql;
        }
        public pr_grupo objGrupoById(long? idGrupo)
        {
            try
            {
                var objGrupo = _manejador_pr_grupo.ObtenerGrupo(idGrupo);


                return objGrupo;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public string GetDescCompaniaById(string idSpvs)
        {
            var descCompania = "";
            try
            {
                var objCompania = _manejador_gr_compania.GetCompaniaById(idSpvs);
                if (objCompania != null)
                {
                    descCompania = _manejador_gr_persona.ObtenerPersona(objCompania.id_per).nomraz;
                }

                return descCompania;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public pr_producto GetProductoById(long idProducto)
        {

            try
            {
                var objProducto = _manejador_pr_producto.ObtenerProducto(idProducto);
                return objProducto;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public pr_poliza GetPolizaByIdPoliza(long idPoliza)
        {

            try
            {
                var objPoliza = _manejador_pr_poliza.GetPolizaById(idPoliza);
                return objPoliza;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public pr_polmov GetPolizaMovimiento(long idPoliza, long idmovimiento)
        {

            try
            {
                var objPolizaMov = _manejador_pr_polmov.GetPolizaMovimiento(idPoliza, idmovimiento);
                return objPolizaMov;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public gr_persona GetPersonaById(string idPersona)
        {

            try
            {
                var objPolizaMov = _manejador_gr_persona.ObtenerPersona(idPersona);
                return objPolizaMov;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public vcb_veripoliza1 ObtenerPolizaNRI(long id_poliza, long id_movimiento)
        {
            try
            {
                var objPolizaMov = _manejador_pr_cobranzas.ObtenerPolizaI(id_poliza,id_movimiento);

                return objPolizaMov;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<vcb_veripoliza2> ObtenerTablaPolizaAp(string id_clamov, string num_poliza, string id_per, string id_spvs, string id_producto, bool vigencia, DateTime fc_inivig, DateTime fc_finvig, DateTime fc_polizavencida, bool porvencer)
        {

            try
            {
                var sql1 = _manejador_vcb_veripoliza2.GetListVeripolizaByEstado(true).Where(x => x.id_clamov == Convert.ToInt64(id_clamov)).Select(x => x);
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
        public List<vcb_veripoliza3> ObtenerTablaPolizaEA(string id_clamov, string num_poliza, string id_per, string id_spvs, string id_producto, bool vigencia, DateTime fc_inivig, DateTime fc_finvig, DateTime fc_polizavencida, bool porvencer)
        {

            try
            {
                var sql1 = _manejador_vcb_veripoliza3.GetListVeripolizaByEstado(true).Where(x => x.id_clamov == Convert.ToInt64(id_clamov)).Select(x => x);
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
        public decimal CalcularPrimaNeta(OcCalFrmCred ocCalFrmCred)
        {
            decimal dcPrimaneta = 0;
            try
            {
                dcPrimaneta = _manejadorSql_calcfrmCred.Calcular(ocCalFrmCred);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
            return dcPrimaneta;
        }
    }
}
