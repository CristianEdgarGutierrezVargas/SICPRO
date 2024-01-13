using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using System.Data;
using Common;
namespace Logica.Consumo
{
    public class ConsumoModComision
    {
        #region Contructor Principal

        private readonly Cpr_pagocompania cpr_Pagocompania;
        
        public static sicproEntities dbContext;
        public ConsumoModComision()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            cpr_Pagocompania = new Cpr_pagocompania(dbContext);
          
        }

        #endregion

        public pr_pagocompania InsertarPagoComp(pr_pagocompania objPagoComision)
        {
            
            try
            {
                var dt = cpr_Pagocompania.InsertarPagoComp(objPagoComision);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }
           

        }
    }
}
