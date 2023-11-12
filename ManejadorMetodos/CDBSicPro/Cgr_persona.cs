using Common;
using EntidadesClases.ModelSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cgr_persona
    {
        #region Contructor Principal

        readonly sicproEntities _context;
        public Cgr_persona(sicproEntities dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public bool EliminarPersona(string varbusqueda)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.gr_persona.Where(w => w.id_per == varbusqueda).FirstOrDefault();
                    _context.gr_persona.Remove(sql);
                    //_context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }               
            }
        }

        public bool ExistePersona(string varbusqueda)
        {
            try
            {
                var sql = _context.gr_persona.Where(w => w.id_per == varbusqueda).ToList();
                if (sql.Count<=0)
                {
                    return false;
                }
                else
                {
                    return true;
                }              
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public bool InsertarPersona(gr_persona objPersona)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.gr_persona.Add(objPersona);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        //public bool ModificarPersona(string varbusqueda)
        //{
        //    bool flag;
        //    try
        //    {
        //        string[] text = new string[] { "UPDATE gr_persona SET id_per='", this.id_per.Text, "', nomraz='", this.nomraz.Text.ToUpper(), "',id_tper=", this.id_tper.SelectedValue, ",fechaaniv='", Funciones.fc(this.fechaaniv.Text), "',id_sal=", this.id_sal.SelectedValue, ",id_rol=", this.id_rol.SelectedValue, ",id_tdoc=", this.id_tdoc.SelectedValue, ",id_emis=", this.id_emis.SelectedValue, ", nit_fac='", this.nit_fac.Text, "', id_suc=", this.id_suc.SelectedValue, " WHERE id_per='", varbusqueda, "'" };
        //        string sql = string.Concat(text);
        //        this.lblmensaje.Text = sql;
        //        Acceso db = new Acceso();
        //        db.Conectar();
        //        db.CrearComando(sql);
        //        db.EjecutarComando();
        //        db.Desconectar();
        //        flag = true;
        //    }
        //    catch
        //    {
        //        flag = false;
        //    }
        //    return flag;
        //}
    }
}
