using Common;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Consumo
{
    public class ConsumoReportes
    {
        private readonly CReportes _manejador_reportes;

        public static sicproEntities dbContext;
        public ConsumoReportes()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();

            _manejador_reportes = new CReportes(dbContext);           
        }

        public List<GetReportMemo_Result> GetReportMemo(long idPoliza, long idMovimiento)
        {
            try
            {
                return _manejador_reportes.GetReportMemo(idPoliza, idMovimiento);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
            finally
            {
                //dbContext.Dispose();
            }
        }

        public List<GetReportMemo1_Result> GetReportMemo1(long idPoliza, long idMovimiento, string strTipoFecha, string strFechaDe, string strFechaA, string strIdCartera)
        {
            try
            {
                return _manejador_reportes.GetReportMemo1();

                //var sql1 = _manejador_vcb_veripoliza1.GetListVeripolizaByEstado(true).Where(x => x.id_clamov == Convert.ToInt64(id_clamov)).Select(x => x);
                ////  string sql1 = string.Concat("SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vcb_veripoliza1 WHERE estado='true'", sql);

                ////string sql = "";
                //if (num_poliza != null & (num_poliza.Replace("%", "") != ""))
                //{
                //    sql1 = sql1.Where(x => x.num_poliza.Contains(num_poliza.ToUpper())).Select(x => x);
                //    // sql = string.Concat(sql, "AND num_poliza LIKE '%", num_poliza.ToUpper(), "%'");
                //}
                //if (id_per != null & (id_per != ""))
                //{
                //    sql1 = sql1.Where(x => x.id_perclie.Contains(id_per.ToUpper())).Select(x => x);
                //    //sql = string.Concat(sql, "AND id_perclie LIKE '%", id_per.ToUpper(), "%'");
                //}
                //if (id_spvs != null & (id_spvs != ""))
                //{
                //    sql1 = sql1.Where(x => x.id_spvs.Contains(id_spvs)).Select(x => x);
                //    //sql = string.Concat(sql, "AND id_spvs LIKE '%", id_spvs, "%'");
                //}
                //if (id_producto != "0")
                //{
                //    sql1 = sql1.Where(x => x.id_producto == Convert.ToInt64(id_producto)).Select(x => x);
                //    //sql = string.Concat(sql, "AND id_producto=", id_producto);
                //}
                //if (vigencia && fc_inivig != null && fc_finvig != null)
                //{
                //    sql1 = sql1.Where(x => x.fc_inivig >= fc_inivig && x.fc_inivig <= fc_finvig).Select(x => x);
                //    //string[] strArrays = new string[] { sql, "AND fc_inivig BETWEEN '", Funciones.fc(fc_inivig), "' AND '", Funciones.fc(fc_polizavencida), "'" };
                //    //sql = string.Concat(strArrays);
                //}
                //if (porvencer & fc_polizavencida != null)
                //{
                //    sql1.Where(x => x.fc_finvig <= fc_polizavencida).Select(x => x);
                //    //sql = string.Concat(sql, "AND fc_finvig <= '", Funciones.fc(fc_polizavencida), "'");
                //}

               // return sql1.ToList();

            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
            finally
            {
                //dbContext.Dispose();
            }
        }

        public List<GetReportClientes_Result> GetReportClientes(string strNombre, int intMesAniv, int intSuc)
        {
            try
            {
                return _manejador_reportes.GetReportClientes(strNombre, intMesAniv, intSuc);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
            finally
            {
                //dbContext.Dispose();
            }
        }


        public List<GetReportDirecciones_Result> GetReportDirecciones()
        {
            try
            {
                return _manejador_reportes.GetReportDirecciones();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
            finally
            {
                //dbContext.Dispose();
            }
        }
    }
}
