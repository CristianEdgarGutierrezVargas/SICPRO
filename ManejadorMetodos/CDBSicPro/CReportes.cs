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
    public class CReportes
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public CReportes(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        #region wpr reportes - produccion

        public List<GetReportMemo_Result> GetReportMemo(long idPoliza, long idMovimiento)
        {
            try
            {
                var sql = _context.GetReportMemo(idPoliza, idMovimiento).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportMemo1_Result> GetReportMemo1()
        {
            try
            {
                var sql = _context.GetReportMemo1().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportClientes_Result> GetReportClientes()
        {
            try
            {
                var sql = _context.GetReportClientes().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportDirecciones_Result> GetReportDirecciones()
        {
            try
            {
                var sql = _context.GetReportDirecciones().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportGrupos_Result> GetReportGrupos()
        {
            try
            {
                var sql = _context.GetReportGrupos().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportProyCartera_Result> GetReportProyCartera()
        {
            try
            {
                var sql = _context.GetReportProyCartera().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        #endregion

        #region wre reportes - reclamos
        public List<GetReportHistreclamosh_Result> GetReportHistreclamosh()
        {
            try
            {
                var sql = _context.GetReportHistreclamosh().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportHistreclamoshf_Result> GetReportHistreclamoshf()
        {
            try
            {
                var sql = _context.GetReportHistreclamoshf().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportResumsiniestro_Result> GetReportResumsiniestro()
        {
            try
            {
                var sql = _context.GetReportResumsiniestro().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportResumsiniestro1_Result> GetReportResumsiniestro1()
        {
            try
            {
                var sql = _context.GetReportResumsiniestro1().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }
        #endregion

        #region wco reportes - cobranzas
        public List<GetReportCobsxrango_Result> GetReportCobsxrango(DateTime dtFechaIni, DateTime dtFechaFin)
        {
            try
            {
                var sql = _context.GetReportCobsxrango(dtFechaIni, dtFechaFin).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportCuotaadias_Result> GetReportCuotaadias()
        {
            try
            {
                var sql = _context.GetReportCuotaadias().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportEstctaaseg1_Result> GetReportEstctaaseg1(string strIdPer, string strIdCompSpvs, string strIdCartera, string strNumPoliza, string strNoLiq )
        {
            try
            {
                var sql = _context.GetReportEstctaaseg1(strIdPer, strIdCompSpvs, strIdCartera, strNumPoliza, strNoLiq).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportEstctaaseg2_Result> GetReportEstctaaseg2(string strIdPer, string strIdCompSpvs, string strIdCartera, string strNumPoliza, string strNoLiq)
        {
            try
            {
                var sql = _context.GetReportEstctaaseg2(strIdPer, strIdCompSpvs, strIdCartera, strNumPoliza, strNoLiq).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportLiquidacion_Result> GetReportLiquidacion()
        {
            try
            {
                var sql = _context.GetReportLiquidacion().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportPagoacia1_Result> GetReportPagoacia1()
        {
            try
            {
                var sql = _context.GetReportPagoacia1().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportPagopendcias_Result> GetReportPagopendcias()
        {
            try
            {
                var sql = _context.GetReportPagopendcias().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportRecibosnoaplicados_Result> GetReportRecibosnoaplicados(string strIdSuc)
        {
            try
            {
                var sql = _context.GetReportRecibosnoaplicados(strIdSuc).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        #endregion

        #region wcm reportes - comisiones

        public List<GetReportAscii_Result> GetReportAscii()
        {
            try
            {
                var sql = _context.GetReportAscii().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportLiqcomiejec3_Result> GetReportLiqcomiejec3()
        {
            try
            {
                var sql = _context.GetReportLiqcomiejec3().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<vcm_prodtot> vcm_prodtot()
        {
            try
            {
                var sql = _context.vcm_prodtot.ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<vcm_prodcap> vcm_prodcap()
        {
            try
            {
                var sql = _context.vcm_prodcap.ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<vcm_comiefect> vcm_comiefect()
        {
            try
            {
                var sql = _context.vcm_comiefect.ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<vcm_comicobrada> vcm_comicobrada()
        {
            try
            {
                var sql = _context.vcm_comicobrada.ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<vcm_comicap> vcm_comicap()
        {
            try
            {
                var sql = _context.vcm_comicap.ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        public List<GetReportConcipagcia_Result> GetReportConcipagcia(DateTime dtFechaIni,DateTime dtFechafin, string strIdCompania, long longIdSucursal)
        {
            try
            {
                var sql = _context.GetReportConcipagcia(dtFechaIni, dtFechafin, strIdCompania, longIdSucursal).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public List<GetReportContable1_Result> GetReportContable1()
        {
            try
            {
                var sql = _context.GetReportContable1().ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public List<GetReportComisionesxfecha_Result> GetReportComisionesxfecha(DateTime dtFechaIni, DateTime dtFechafin)
        {
            try
            {
                var sql = _context.GetReportComisionesxfecha(dtFechaIni, dtFechafin).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        
        #endregion
    }
}
