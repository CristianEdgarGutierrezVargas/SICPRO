using EntidadesClases.ModelSicPro;
using EntidadesClases.CustomModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodosSql.CDBSicPro
{
    public class CSpr_calcfrmcred : CStoredProcedureBase
    {
        public decimal Calcular(OcCalFrmCred objCalFrmCred)
        {
            //    Log.Inicio();
            try
            {
                string SqlStatement
                    = "EXECUTE pr_calcfrmcred @idproducto,@idspvs, @primatotal, @tipocuota";

                var parameterList = new List<CParameter>
                    {
                        new CParameter {Key = "@idproducto", Value =objCalFrmCred.IdProducto },
                        new CParameter {Key = "@idspvs", Value = objCalFrmCred.IdSpvs},

                        new CParameter {Key = "@primatotal", Value = objCalFrmCred.PrimaTotal},
                        new CParameter {Key = "@tipocuota", Value = objCalFrmCred.TipoCuota}
                    };

                var response = SelectObject(SqlStatement, objCalFrmCred, parameterList).ToString();

                return Convert.ToDecimal(response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
