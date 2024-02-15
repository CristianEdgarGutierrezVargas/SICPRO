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
    public class Cvcb_respolpago1
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cvcb_respolpago1(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion
        public List<vcb_respolpago1> ObtenerPoliza(string idPerclie)
        
        {
            try
            {
                //SELECT num_poliza, nomraz, fc_inivig, fc_finvig, id_poliza, id_movimiento FROM vcb_veripoliza1 WHERE estado = 'true'
                var sql = _context.vcb_respolpago1.Where(x=>x.id_perclie== idPerclie).ToList();
                
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
    }
}
