using EntidadesClases.ModelSicPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodosSql.CDBSicPro
{
    public class CSpr_numaplicas : CStoredProcedureBase
    {
        public pr_numaplicas InsertarNumAplicas(pr_numaplicas objNumAplicas)
        {
            //    Log.Inicio();
            try
            {
                string SqlStatement 
                    = "INSERT INTO [dbo].[pr_numaplicas] ([id_poliza],[id_movimiento],[del],[al],[id_mom]) VALUES (@id_poliza,@id_movimiento,@del,@al,@id_mom)";

                var parameterList = new List<CParameter>
                    {
                        new CParameter {Key = "@id_poliza", Value = objNumAplicas.id_poliza},
                        new CParameter {Key = "@id_movimiento", Value = objNumAplicas.id_movimiento},
                        new CParameter {Key = "@del", Value = objNumAplicas.del},
                        new CParameter {Key = "@al", Value = objNumAplicas.al},
                        new CParameter {Key = "@id_mom", Value = objNumAplicas.id_mom}
                    };

                var response = SelectObject(SqlStatement, objNumAplicas, parameterList);
                               
                return objNumAplicas;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        }
}
