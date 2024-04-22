using Common;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cre_caso
    {
        #region Contructor Principal
        readonly sicproEntities _context;
        public Cre_caso(sicproEntities dbContext)
        {
            _context = dbContext;
        }
        #endregion
        public decimal nextval(decimal anio)
        {
            try
            {
                decimal valor = 1;//valor por defecto si no se encuentra el correlativo en la base

                var item = (from caso in _context.re_caso
                           where caso.anio_caso==anio
                           //group caso by caso.id_caso into group_caso
                           select caso).OrderByDescending(X=>X.id_caso).FirstOrDefault();

                if (item == null)
                    return valor;

                decimal valorFinal = item.id_caso + 1;
                return valorFinal;   
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }

        public void add_recaso(re_caso item)
        {
            try
            {
                _context.re_caso.Add(item);
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public void add_siniestro(re_siniestro item)
        {
            try
            {
                _context.re_siniestro.Add(item);
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public void add_histcaso1(re_histcaso item)
        {
            try
            {
                _context.re_histcaso.Add(item);
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }

        public void upd_recaso(decimal id_caso,decimal anio_caso, string id_recibo,decimal pago_caso,decimal franq_caso,decimal indem_caso,decimal anio_recibo)
        {
            try
            {
                var sql=(
                            from rcaso in _context.re_caso
                            where rcaso.id_caso == id_caso
                                & rcaso.anio_caso == anio_caso
                            select rcaso
                        ).FirstOrDefault();

                double reci = id_recibo.Length == 0 ? 0 : double.Parse(id_recibo);

                sql.pago_caso = pago_caso;
                sql.franq_caso = franq_caso;
                sql.indem_caso = indem_caso;
                sql.id_recibo = reci;
                sql.anio_recibo = anio_recibo;

                //string[] strArrays = new string[] { "update re_caso set pago_caso = ", this.pago_caso.Text.Replace(".", "").Replace(",", "."), "" +
                //    "                                                   , franq_caso = ", this.coafran.Text.Replace(".", "").Replace(",", "."), "" +
                //    "                                                   , indem_caso = ", this.indem.Text.Replace(".", "").Replace(",", "."), "" +
                //    "                                                   , id_recibo=", reci, " " +
                //    "                                                   , anio_recibo=", this.anio_recibo.Value, " " +
                //    "                                where " +
                //    "                                       id_caso=", this.id_caso.Text, " " +
                //    "                                       and anio_caso = ", this.anio_caso.Text };
                
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
    }
}
