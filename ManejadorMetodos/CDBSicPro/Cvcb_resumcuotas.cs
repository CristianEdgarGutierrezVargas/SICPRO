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
    public class Cvcb_resumcuotas
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cvcb_resumcuotas(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public vcb_resumcuotas Cuotas(long idPol, long idMov)
        
        {
            try
            {
                //SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vcb_veripoliza1 WHERE estado = 'true'
                var sql = _context.vcb_resumcuotas.Where(x=>x.id_poliza== idPol && x.id_movimiento==idMov && x.cuotatotal > x.cuotapago).FirstOrDefault();
                
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<vcb_respolpago1> ObtenerMovimiento(long idPoliza)

        {
            try
            {
                //SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vcb_veripoliza1 WHERE estado = 'true'
                var sql = _context.vcb_respolpago1.Where(x => x.id_poliza == idPoliza).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List< vcb_resumcuotas> DatosCuota(long idPol, long idMov, long cuota)

        {
            try
            {
                //SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vcb_veripoliza1 WHERE estado = 'true'
                var sql = _context.vcb_resumcuotas.Where(x => x.id_poliza == idPol && x.id_movimiento == idMov && x.cuota== cuota).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
    }
}
