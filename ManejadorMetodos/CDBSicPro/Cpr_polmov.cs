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
    public class Cpr_polmov
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_polmov(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        //consulta en duro
        public List<gr_parametro> listas1()
        {
            try
            {
                var list = new long[] { 42, 43 };
                var sql = _context.gr_parametro.Where(w => w.columna == "id_clamov" && list.Contains(w.id_par)).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        //public void listas1()
        //{
        //    string sentenciaSQL = "SELECT gr_parametro.id_par, gr_parametro.desc_param FROM gr_parametro WHERE gr_parametro.columna = 'id_clamov' AND gr_parametro.id_par IN (42,43) UNION SELECT 0 as id_par, 'SELECCIONE UNA OPCIÓN' AS desc_param order by id_par asc";
        //    Acceso acceso = new Acceso();
        //    acceso.Conectar();
        //    acceso.CrearComando(sentenciaSQL);
        //    DataTable dataSource = acceso.Consulta();
        //    acceso.Desconectar();
        //    id_clamov1.DataSource = dataSource;
        //    id_clamov1.DataTextField = "desc_param";
        //    id_clamov1.DataValueField = "id_par";
        //    id_clamov1.DataBind();
        //}
        public List<pr_polmov> GetListPolMov()
        {
            try
            {
                var sql = _context.pr_polmov.ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public pr_polmov InsertarPolizaMovimiento(pr_polmov objPolizaMov)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_polmov.Add(objPolizaMov);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return objPolizaMov;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }
        public pr_polmov GetPolizaMovimiento(long idPoliza, long idMovimiento)
        {

            try
            {
                var sql = _context.pr_polmov.FirstOrDefault(x => x.id_poliza == idPoliza && x.id_movimiento == idMovimiento);


                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }

        //public string TempAP()
        //{
        //    try
        //    {
        //        var sql = _context.sq_aplitemp.FirstOrDefault(x => x.id_poliza == idPoliza && x.id_movimiento == idMovimiento);
        //        return sql;
        //    }
        //    catch (SecureExceptions secureException)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", secureException);
        //    }
        //    //string sentenciaSQL = "select nextval('sq_aplitemp')";
        //    //Acceso acceso = new Acceso();
        //    //acceso.Conectar();
        //    //acceso.CrearComando(sentenciaSQL);
        //    //DataTable dataTable = acceso.Consulta();
        //    //acceso.Desconectar();
        //    //return "PT" + dataTable.Rows[0][0].ToString().PadLeft(5, '0');
        //}

        public bool ActualizaPolizaMov(pr_polmov objPr_polmov)
        {
            using (var dbContextTransaccion = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.pr_polmov.Where(w => w.id_poliza == objPr_polmov.id_poliza && w.id_movimiento== objPr_polmov.id_movimiento).FirstOrDefault();
                    if (sql != null)
                    {
                        sql.estado = objPr_polmov.estado;
                        _context.SaveChanges();
                        return true;
                    }
                    return false;

                }
                catch (SecureExceptions secureException)
                {
                    throw new SecureExceptions("Error al Generar la Transacción", secureException);
                }

            }
        }
        public List<pr_polmov> DatosPolizaEA(long idPoliza, long id_mom)
        {
            try
            {
                var sql = _context.pr_polmov.Where(x=>x.id_poliza==idPoliza && x.id_mom==id_mom  && x.id_clamov !=46 &&  x.id_clamov != 49).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<pr_polmov> GetPolizaMovimientoByEstado(string estado)
        {

            try
            {
                var sql = _context.pr_polmov.Where(x => x.estado == estado ).ToList();


                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }

        }
    }
}
