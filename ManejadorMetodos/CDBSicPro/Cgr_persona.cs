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

        public bool ModificarPersona(gr_persona objPersona)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sql = _context.gr_persona.Where(w=>w.id_per == objPersona.id_per).FirstOrDefault();

                    if (sql == null)
                    {
                        return false;
                    }
                    else
                    {
                        sql.nomraz = objPersona.nomraz;
                        sql.id_tper = objPersona.id_tper;
                        sql.fechaaniv = objPersona.fechaaniv;
                        sql.id_sal = objPersona.id_sal;
                        sql.id_rol = objPersona.id_rol;
                        sql.id_tdoc = objPersona.id_tdoc;
                        sql.id_emis = objPersona.id_emis;
                        sql.nit_fac = objPersona.nit_fac;
                        sql.id_suc = objPersona.id_suc;
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


        public List<gr_persona> ObtenerListaPersona()
        {
            try
            {
                var sql = _context.gr_persona.ToList();
                return sql;
                //string sql = "SELECT * FROM gr_persona";               
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public gr_persona ObtenerPersona(string varbusqueda)
        {
            try
            {

                var sql = _context.gr_persona.Where(w=>w.id_per == varbusqueda).ToList();

                if (sql.Count > 0)
                {
                    return sql.First();
                }
                return null;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        //consulta en duro
        public List<gr_persona> ObtenerEjecutivoClientes()
        {
            try
            {

                var sql = _context.gr_persona.Where(w => w.id_rol == 30).OrderBy(o=>o.nomraz).ToList();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        //public void ObtenerEjecutivoClientes()
        //{
        //    try
        //    {
        //        string sql = "SELECT gr_persona.nomraz, gr_persona.id_per FROM gr_persona WHERE gr_persona.id_rol = 30 order by gr_persona.nomraz UNION SELECT 0, 'SELECCIONE UNA OPCIÓN'";
        //        Acceso db = new Acceso();
        //        db.Conectar();
        //        db.CrearComando(sql);
        //        DataTable dtgeneral = db.Consulta();
        //        this.id_rol.DataSource = dtgeneral;
        //        this.id_rol.DataTextField = "nomraz";
        //        this.id_rol.DataValueField = "id_per";
        //        this.id_rol.DataBind();
        //        db.Desconectar();
        //    }
        //    catch (SecureExceptions secureException)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", secureException);
        //    }
        //}


        //public string TablaPersona(string varbusqueda)
        //{
        //    DataTable dt = new DataTable();
        //    string var = "";
        //    dt = this.ObtenerTablaPersonasC(varbusqueda);
        //    decimal l2 = dt.Rows.Count / 10;
        //    var = "<div class=\"gridcontainer\" style=\"width: 350px\">";
        //    var = string.Concat(var, "<table class=\"grid\" width=\"350\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">");
        //    var = string.Concat(var, "<caption>Lista de Personas</caption>");
        //    decimal num = Math.Floor(l2);
        //    this.ll = int.Parse(num.ToString()) * 10;
        //    if (dt.Rows.Count < 10)
        //    {
        //        this.b.Value = dt.Rows.Count.ToString();
        //        this.bb = dt.Rows.Count;
        //        this.aa = 0;
        //        this.cc = 0;
        //        this.dd = dt.Rows.Count;
        //    }
        //    else if (int.Parse(this.b.Value) < 10)
        //    {
        //        this.b.Value = "10";
        //        this.bb = 10;
        //        this.cc = -10;
        //        this.a.Value = "0";
        //        this.aa = 0;
        //        this.dd = 0;
        //    }
        //    for (int i = int.Parse(this.a.Value); i <= int.Parse(this.b.Value) - 1; i++)
        //    {
        //        string str = var;
        //        string[] strArrays = new string[] { str, "<tr OnMouseOut=\"this.className = this.orignalclassName;\" OnMouseOver=\"this.orignalclassName = this.className;this.className = 'altoverow';\" onclick=\"mClk1('", dt.Rows[i][0].ToString(), "','", dt.Rows[i][1].ToString(), "');\"><td >" };
        //        var = string.Concat(strArrays);
        //        var = string.Concat(var, "<font color=\"#336699\" style=\" font-weight:bold ; size:12px\">");
        //        var = string.Concat(var, dt.Rows[i][1].ToString());
        //        var = string.Concat(var, "</font></td></tr>");
        //    }
        //    var = string.Concat(var, "</table></div>");
        //    this.aa = int.Parse(this.b.Value);
        //    if (this.aa + 10 <= dt.Rows.Count - 1)
        //    {
        //        this.bb = this.aa + 10;
        //    }
        //    else
        //    {
        //        this.bb = dt.Rows.Count - 1;
        //    }
        //    this.cc = this.aa - 20;
        //    this.dd = this.bb - 20; 
        //    int l3 = dt.Rows.Count;
        //    if (dt.Rows.Count >= 10)
        //    {
        //        if (int.Parse(this.a.Value) == 0)
        //        {
        //            var = string.Concat(var, "<div class=\"gridcontainer\" style=\"width: 350px\"><div style=\"width: 350px\" class=\"pagerstyle\"><center><a href='#' ><input type=\"submit\" class=\"pagfirst\" value=\"\" title='Primera Página Desactivado' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;");
        //            var = string.Concat(var, "<a href='#' ><input type=\"submit\" class=\"pagprev\" value=\"\" title='Anterior Página Desactivado' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;");
        //            object obj = var;
        //            object[] objArray = new object[] { obj, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = ", this.aa, "; document.forms.aspnetForm.ctl00_cpmaster_b.value = ", this.bb, ";f(); '><input type=\"submit\" value=\"\" class=\"pagnext\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Siguiente Página'/></a>&nbsp;&nbsp;" };
        //            var = string.Concat(objArray);
        //            object obj1 = var;
        //            object[] objArray1 = new object[] { obj1, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = ", this.ll, "; document.forms.aspnetForm.ctl00_cpmaster_b.value = ", l3, ";f(); '><input type=\"submit\" value=\"\" class=\"paglast\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Última Página'/></a></center></div></div>" };
        //            var = string.Concat(objArray1);
        //        }
        //        else if (int.Parse(this.a.Value) != this.ll)
        //        {
        //            var = string.Concat(var, "<div class=\"gridcontainer\" style=\"width: 350px\"><div style=\"width: 350px\" class=\"pagerstyle\"><center><a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = 0; document.forms.aspnetForm.ctl00_cpmaster_b.value = 10;f(); '><input type=\"submit\" class=\"pagfirst\" value=\"\" title='Primera Página' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;");
        //            object obj2 = var;
        //            object[] objArray2 = new object[] { obj2, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = ", this.cc, "; document.forms.aspnetForm.ctl00_cpmaster_b.value = ", this.dd, ";f(); '><input type=\"submit\" class=\"pagprev\" value=\"\" title='Anterior Página' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;" };
        //            var = string.Concat(objArray2);
        //            object obj3 = var;
        //            object[] objArray3 = new object[] { obj3, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = ", this.aa, "; document.forms.aspnetForm.ctl00_cpmaster_b.value = ", this.bb, ";f(); '><input type=\"submit\" value=\"\" class=\"pagnext\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Siguiente Página' /></a>&nbsp;&nbsp;" };
        //            var = string.Concat(objArray3);
        //            object obj4 = var;
        //            object[] objArray4 = new object[] { obj4, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = ", this.ll, "; document.forms.aspnetForm.ctl00_cpmaster_b.value = ", l3, ";f(); '><input type=\"submit\" value=\"\" class=\"paglast\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Última Página' /></a></center></div></div>" };
        //            var = string.Concat(objArray4);
        //        }
        //        else
        //        {
        //            var = string.Concat(var, "<div class=\"gridcontainer\" style=\"width: 350px\"><div style=\"width: 350px\" class=\"pagerstyle\"><center><a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = 0; document.forms.aspnetForm.ctl00_cpmaster_b.value = 10;f(); '><input type=\"submit\" class=\"pagfirst\" value=\"\" title='Primera Página' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;");
        //            object obj5 = var;
        //            object[] objArray5 = new object[] { obj5, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = ", this.cc, "; document.forms.aspnetForm.ctl00_cpmaster_b.value = ", this.dd, ";f(); '><input type=\"submit\" class=\"pagprev\" value=\"\" title='Anterior Página' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;" };
        //            var = string.Concat(objArray5);
        //            var = string.Concat(var, "<a href='#' ><input type=\"submit\" value=\"\" class=\"pagnext\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Siguiente Página Desactivado' /></a>&nbsp;&nbsp;");
        //            var = string.Concat(var, "<a href='#' ><input type=\"submit\" value=\"\" class=\"paglast\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Última Página Desactivado' /></a></center></div></div>");
        //        }
        //    }
        //    return var;
        //}
    }
}
