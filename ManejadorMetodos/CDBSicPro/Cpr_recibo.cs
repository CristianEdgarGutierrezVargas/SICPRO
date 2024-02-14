using Common;
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
    public class Cpr_recibo
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cpr_recibo(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public List<pr_recibo> ObtenerAnio()
        {
            try
            {
                var sql = _context.pr_recibo.GroupBy(x=>x.anio_recibo).Select(x=>x.FirstOrDefault()).Where(w => w.fecha_entregado !=null).OrderBy(x=>x.anio_recibo).ToList();
                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }

          
        }
        public List<pr_recibo> ObtenerRecibo(string anio)
        {
            try
            {
                var año = Convert.ToInt64(anio);
                var sql = _context.pr_recibo.Where(w => w.id_perclie == null && w.anio_recibo==año && w.fecha_entregado==null).OrderBy(x => x.id_recibo).ToList();
               // var sql = _context.pr_recibo.GroupBy(x => x.anio_recibo).Select(x => x.FirstOrDefault()).Where(w => w.id_perclie == null && w.anio_recibo==año && w.fecha_entregado==null).OrderBy(x => x.id_recibo).ToList();
                return sql;

                
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public bool EntregarRecibo(pr_recibo objRecibo, int anio_recibo,int i , int j)
        {
            try
            {
                var sql = (from com in _context.pr_recibo
                           where com.anio_recibo == anio_recibo && com.id_recibo >=  i && com.id_recibo <= j
                           select com).FirstOrDefault();
                sql.fecha_entregado = objRecibo.fecha_entregado;
                sql.id_perucb = objRecibo.id_perucb;
                sql.id_suc= objRecibo.id_suc;
                _context.SaveChanges();
                return true;

                //string i = this.id_recibo.SelectedValue;
                //string j = this.id_reciboa.SelectedValue;
                //object[] objArray = new object[] { "UPDATE pr_recibo SET fecha_entregado='", Funciones.fc(this.fecha_entregado.Text), "', id_suc='", this.id_suc.SelectedValue, "', id_perucb='", this.id_perucb.SelectedValue, "' WHERE anio_recibo=", anio_recibo, " AND id_recibo>=", i, " and id_recibo <= ", j };
                //string sql = string.Concat(objArray);
                //Acceso db = new Acceso();
                //db.Conectar();
                //db.CrearComando(sql);
                //db.EjecutarComando();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Ejecutar la Transacción", secureException);
            }
        }
        public List<pr_recibo> GenerarRecibo(int anio)
        {
            try
            {
                var sql = _context.pr_recibo.Where(w=> w.anio_recibo == anio ).OrderByDescending(x => x.id_recibo ).ToList();
             
                return sql;
 }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Consulta", secureException);
            }
        }
        public bool InsertRecibo(int j, string anio)
        {
            try 
            {
                var recibo = new pr_recibo()
                {
                    id_recibo = j,
                    anio_recibo =Convert.ToDecimal(anio)
                };
                //object[] text = new object[] { "INSERT INTO pr_recibo(id_recibo, anio_recibo) VALUES (", j, ",", this.anio.Text, ")" };
                //db.CrearComando(string.Concat(text));
                //db.EjecutarComando();
                _context.pr_recibo.Add(recibo);
                _context.SaveChanges();
                return true;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Consulta", secureException);
            }
        }

        public List<gr_persona> ObtenerCobrador(long id_suc)
        {
            try
            {
                var sql = _context.gr_persona.Where(w => w.id_suc == id_suc && w.id_rol == 41).ToList();
                 return sql;
                //string sentenciaSQL = "SELECT gr_persona.id_per, gr_persona.nomraz " +
                //    "FROM gr_persona WHERE gr_persona.id_rol = 41 AND gr_persona.id_suc = " + id_suc + " UNION SELECT '0', 'SELECCIONE UNA OPCIÓN'";
                
            }
            catch (SecureExceptions original)
            {
                throw new SecureExceptions("Error al generar la Consulta", original);
            }
        }
        public List<pr_recibo> ObtenerReciboA(string anio, string idPercb )
        {
            try
            {
                var año = Convert.ToInt64(anio);
                var sql = _context.pr_recibo.Where(w => w.id_perclie == null && w.anio_recibo == año && w.id_perucb== idPercb && w.fecha_entregado == null).OrderBy(x => x.id_recibo).ToList();
               return sql;


            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<pr_recibo> ObtenerReciboM(string anio, string idPercb)
        {
            try
            {
                var año = Convert.ToInt64(anio);
                var sql = _context.pr_recibo.Where(w => w.id_perclie != null && w.anio_recibo == año && w.id_perucb == idPercb && w.fecha_cobro != null && 
                w.monto_cobro==w.monto_resto && w.id_liq==null).OrderBy(x => x.id_recibo).ToList();
               return sql;


            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<pr_recibo> ObtenerReciboMF(pr_recibo obRecibo)
        {
            try
            {
                var sql = _context.pr_recibo.Where(w => w.anio_recibo == obRecibo.anio_recibo).OrderBy(x => x.id_recibo).ToList();

                return sql;


            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public bool ActualizarRecibo(pr_recibo objRecibo)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {

                  
                    var sql = _context.pr_recibo.Where(w => w.anio_recibo == objRecibo.anio_recibo && w.id_recibo== objRecibo.id_recibo).FirstOrDefault();

                    if (sql == null)
                    {
                        return false;
                    }
                    else
                    {
                        decimal? montoresto = 0;
                        if (objRecibo.id_apli != 87)
                        {
                            montoresto = objRecibo.monto_resto;
                        }

                        sql.id_perclie = objRecibo.id_perclie;
                        sql.fecha_cobro = objRecibo.fecha_cobro;
                        sql.monto_cobro = objRecibo.monto_cobro;
                        sql.monto_resto = montoresto;
                        sql.recibo_por = objRecibo.recibo_por;
                        sql.id_div = objRecibo.id_div;
                        sql.id_apli = objRecibo.id_apli;
                        sql.cont_bs = objRecibo.cont_bs;
                        sql.cont_sus = objRecibo.cont_sus;
                        sql.cheq_bs = objRecibo.cheq_bs;
                        sql.cheq_sus = objRecibo.cheq_sus;
                        _context.SaveChanges();
                        dbContextTransaction.Commit();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
        public bool ActualizarReciboM(pr_recibo objRecibo)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {


                    var sql = _context.pr_recibo.Where(w => w.anio_recibo == objRecibo.anio_recibo && w.id_recibo == objRecibo.id_recibo).FirstOrDefault();

                    if (sql == null)
                    {
                        return false;
                    }
                    else
                    {
                        decimal? montoresto = 0;
                        if (objRecibo.id_apli != 87)
                        {
                            montoresto = objRecibo.monto_cobro;
                        }

                        
                        sql.fecha_cobro = objRecibo.fecha_cobro;
                        sql.monto_cobro = objRecibo.monto_cobro;
                        sql.monto_resto = montoresto;
                       
                        sql.id_div = objRecibo.id_div;
                        sql.id_apli = objRecibo.id_apli;
                   
                        _context.SaveChanges();
                        dbContextTransaction.Commit();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
        public bool ActualizarReciboCob(pr_recibo objRecibo,decimal montoPago)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {


                    var sql = _context.pr_recibo.Where(w => w.anio_recibo == objRecibo.anio_recibo && w.id_recibo == objRecibo.id_recibo).FirstOrDefault();

                    if (sql == null)
                    {
                        return false;
                    }
                    else
                    {
                        sql.monto_resto=sql.monto_resto- montoPago;
                        sql.id_liq= objRecibo.id_liq;

                        _context.SaveChanges();
                        dbContextTransaction.Commit();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
        public List<pr_recibo> ObtenerRecibo(string idPer, string idGru, long idApli)
        {
            try
            {
                var sql = _context.pr_recibo.Where(w => w.monto_resto>0 && ( w.id_perclie == idPer || w.id_perclie == idGru) && w.id_apli== idApli && w.id_liq != null).ToList();
                return sql;


            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
    }
}
