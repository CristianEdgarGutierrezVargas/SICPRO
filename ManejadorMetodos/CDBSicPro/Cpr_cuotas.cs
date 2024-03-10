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
                datosCuotas.NomCliente = (
                                         from persona in _context.gr_persona
                                         where persona.id_per == sql.id_perclie
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
                                         where persona.id_rol == 30 & persona.id_per == sql.id_perejec
                                         select persona.nomraz
                                        ).FirstOrDefault();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }

        public List<OcPolizasCuotas> DatosGrid(int id_poliza, int id_movimiento)
        {
            try
            {
                //object[] idPoliza = new object[] { "SELECT vpr_listasinpago.num_poliza
                //                                          , pr_cuotapoliza.cuota
                //                                          , pr_cuotapoliza.fecha_pago
                //                                          , pr_cuotapoliza.cuota_total
                //                                    FROM vpr_listasinpago
                //                                    INNER JOIN pr_cuotapoliza ON (vpr_listasinpago.id_poliza = pr_cuotapoliza.id_poliza)
                //                                                                  AND (vpr_listasinpago.id_movimiento = pr_cuotapoliza.id_movimiento)
                //                                    WHERE vpr_listasinpago.id_poliza = ", id_poliza, "
                //                                          AND vpr_listasinpago.id_movimiento = ", id_movimiento };
                var sql = (
                            from listasinpago in _context.vpr_listasinpago
                            join cuotapoliza in _context.pr_cuotapoliza on new { a = listasinpago.id_poliza, listasinpago.id_movimiento } equals new { a = cuotapoliza.id_poliza, cuotapoliza.id_movimiento }
                            where listasinpago.id_poliza == id_poliza
                                & listasinpago.id_movimiento == id_movimiento
                            select new OcPolizasCuotas
                            {
                                cuota= cuotapoliza.cuota,
                                cuota_total= cuotapoliza.cuota_total,
                                fecha_pago= cuotapoliza.fecha_pago,
                                num_poliza= listasinpago.num_poliza
                            }
                        ).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public void Cuotas(int id_poliza, int id_movimiento, DateTime fecha_pago,decimal cuota_total,int cuota)
        {
            try
            {
                //object[] objArray = new object[] { "UPDATE pr_cuotapoliza SET fecha_pago='", Funciones.fc(this.fecha_pago.Text), "'
                //                                                              , cuota_total=", this.cuota_total.Text.Replace(".", "").Replace(",", "."), "
                //                                    WHERE id_poliza= ", id_poliza, "
                //                                          AND id_movimiento= ", id_movimiento, "
                //                                          AND pr_cuotapoliza.cuota=", this.ncuota.Text };
                var sql =   (
                                from cuotapoliza in _context.pr_cuotapoliza
                                where cuotapoliza.id_poliza== id_poliza
                                      & cuotapoliza.id_movimiento==id_movimiento
                                      & cuotapoliza.cuota==cuota
                                select cuotapoliza
                            ).FirstOrDefault();
                sql.fecha_pago = fecha_pago;
                sql.cuota_total = cuota_total;

                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void ModificaCuota(int id_poliza, int id_movimiento, string estado, int cuota)
        {
            try
            {
                //object[] value = new object[] { "UPDATE pr_polmov SET estado='", this.estado.Value, "', num_cuota=", this.cuotas.Text, " WHERE id_poliza=", id_poliza, " AND id_movimiento=", id_movimiento };
                var itempolmov=( 
                                from polmov in _context.pr_polmov
                                where polmov.id_poliza == id_poliza
                                & polmov.id_movimiento == id_movimiento
                                select polmov
                                ).FirstOrDefault();
                itempolmov.estado = estado;
                itempolmov.num_cuota = cuota;

                //object[] idPoliza = new object[] { "DELETE FROM pr_cuotapoliza WHERE id_poliza=", id_poliza, " AND id_movimiento=", id_movimiento };
                var listCuotas = (
                                  from cuotas in _context.pr_cuotapoliza
                                  where cuotas.id_poliza == id_poliza
                                  & cuotas.id_movimiento == id_movimiento
                                  select cuotas
                                ).ToList();
                _context.pr_cuotapoliza.RemoveRange(listCuotas);

                for (int i = 0; i < cuota; i++)
                {
                    // object[] objArray = new object[] { "INSERT INTO pr_cuotapoliza VALUES(", id_poliza, ",", id_movimiento, ",", i, ")" };
                    _context.pr_cuotapoliza.Add(new pr_cuotapoliza { id_movimiento = id_movimiento, id_poliza= id_poliza, cuota=i,cuota_total=0,cuota_pago=0 });
                }

                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
    }
}
