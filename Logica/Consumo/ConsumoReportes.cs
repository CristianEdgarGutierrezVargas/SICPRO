using Common;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
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

        public List<GetReportMemo1_Result> GetReportMemo1(string num_poliza, string numLiquidacion, string strTipoFecha, string strFechaDe, string strFechaA, string strIdCartera)
        {
            try
            {
                var sql1 = _manejador_reportes.GetReportMemo1().ToList();

                if (num_poliza != null & (num_poliza.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.num_poliza.Contains(num_poliza.ToUpper())).ToList();
                }

                if (numLiquidacion != null & (numLiquidacion.Replace("%", "") != ""))
                {
                    sql1 = sql1.Where(x => x.no_liquida.Contains(numLiquidacion.ToUpper())).ToList();
                }
                var dtFechaDe = (DateTime)SqlDateTime.MinValue;
                var dtFechaA = (DateTime)SqlDateTime.MaxValue;
                dtFechaDe = Convert.ToDateTime(dtFechaDe);
                dtFechaA = Convert.ToDateTime(dtFechaA);

                switch (strTipoFecha)
                {
                    case "fc_recepcion":
                        sql1 = sql1.Where(x => x.fc_recepcion >= dtFechaDe && x.fc_recepcion <= dtFechaA).ToList();
                        break;
                    case "fc_reg":
                        sql1 = sql1.Where(x => x.fc_reg >= dtFechaDe && x.fc_reg <= dtFechaA).ToList();
                        break;
                    case "fc_emision":
                        sql1 = sql1.Where(x => x.fc_emision >= dtFechaDe && x.fc_emision <= dtFechaA).ToList();
                        break;
                    case "fc_inivig":
                        sql1 = sql1.Where(x => x.fc_inivig >= dtFechaDe && x.fc_inivig <= dtFechaA).ToList();
                        break;
                    case "fc_finvig":
                        sql1 = sql1.Where(x => x.fc_finvig >= dtFechaDe && x.fc_finvig <= dtFechaA).ToList();
                        break;
                    default:
                        // code block
                        break;
                }

                if (strIdCartera != null & (strIdCartera != ""))
                {
                    sql1 = sql1.Where(x => x.id_percart.Contains(strIdCartera.ToUpper())).ToList();
                    //sql = string.Concat(sql, "AND id_perclie LIKE '%", id_per.ToUpper(), "%'");
                }                

                return sql1;

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

        public List<GetReportGrupos_Result> GetReportGrupos(long idGrupo, long idSucursal)
        {
            try
            {
                return _manejador_reportes.GetReportGrupos(idGrupo, idSucursal);
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

        public List<GetReportProyCartera_Result> GetReportProyCartera()
        {
            try
            {
                return _manejador_reportes.GetReportProyCartera();
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
