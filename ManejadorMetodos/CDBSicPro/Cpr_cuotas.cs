using Common;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_cuotas
    {
        readonly sicproEntities _context;
        public Cpr_cuotas(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        public vpr_listasinpago ObtenerDatosPoliza(int id_poliza, int id_movimiento, out OC_DatosCuotas datosCuotas)
        {
            try
            {
                //object[] idPoliza = new object[] { "SELECT * FROM vpr_listasinpago WHERE vpr_listasinpago.id_poliza = ", id_poliza, " AND vpr_listasinpago.id_movimiento=", id_movimiento };
                datosCuotas = null;
                var sql = (
                            from lista in _context.vpr_listasinpago
                            where lista.id_poliza == id_poliza
                            & lista.id_movimiento == id_movimiento
                            select lista
                          ).FirstOrDefault();

                if (sql == null)
                    return null;
                datosCuotas = new OC_DatosCuotas();
                //string sql = string.Concat("SELECT nomraz FROM gr_persona WHERE id_per ='", id_per, "'");
                datosCuotas.NomCliente=(
                                         from persona in _context.gr_persona
                                         where persona.id_per==sql.id_perclie
                                         select persona.nomraz
                                        ).FirstOrDefault();
                //string sql = string.Concat("SELECT desc_grupo FROM pr_grupo WHERE id_gru ='", id_gru, "'");
                datosCuotas.NomGrupo = (
                                         from grupo in _context.pr_grupo
                                         where grupo.id_gru == sql.id_gru
                                         select grupo.desc_grupo
                                        ).FirstOrDefault();
                //string sql = string.Concat("SELECT desc_prod FROM pr_producto WHERE id_producto ='", id_producto, "'");
                datosCuotas.NomProducto = (
                                         from producto in _context.pr_producto
                                         where producto.id_producto == sql.id_producto
                                         select producto.desc_prod
                                        ).FirstOrDefault();
                //string sql = string.Concat("SELECT gr_persona.nomraz FROM gr_persona INNER JOIN gr_compania ON (gr_persona.id_per = gr_compania.id_per) WHERE gr_compania.id_spvs = ", id_spvs);
                datosCuotas.NomCompania = (
                                         from persona in _context.gr_persona
                                         join compania in _context.gr_compania on persona.id_per equals compania.id_per
                                         where compania.id_spvs == sql.id_spvs
                                         select persona.nomraz
                                        ).FirstOrDefault();
                //string sql = string.Concat("SELECT gr_persona.nomraz FROM gr_persona WHERE gr_persona.id_rol = 30 AND gr_persona.id_per='", id_perejec, "'");
                datosCuotas.NombreEjecutivo = (
                                         from persona in _context.gr_persona
                                         where persona.id_rol == 30 & persona.id_per==sql.id_perejec
                                         select persona.nomraz
                                        ).FirstOrDefault();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
    }
}
