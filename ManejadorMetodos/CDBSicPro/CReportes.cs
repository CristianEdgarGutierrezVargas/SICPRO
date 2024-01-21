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

        public List<GetReportClientes_Result> GetReportClientes(string strNombre, int intMesAniv, int intSuc)
        {
            try
            {
                var sql = _context.GetReportClientes(strNombre, intMesAniv, intSuc).ToList();

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

        public List<GetReportGrupos_Result> GetReportGrupos(long idGrupo, long idSucursal)
        {
            try
            {
                var sql = _context.GetReportGrupos(idGrupo, idSucursal).ToList();

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
    }
}
