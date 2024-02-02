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
                           group caso by caso.id_caso into group_caso
                           select group_caso.Max()).FirstOrDefault();

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
    }
}
