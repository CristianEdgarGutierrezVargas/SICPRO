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
    public class Cgr_cierreregistro
    {
        #region Contructor Principal
        readonly sicproEntities _context;
        public Cgr_cierreregistro(sicproEntities dbContext)
        {
            _context = dbContext;
        }
        #endregion
        public List<gr_cierreregistro> TablaCierre(string anio)
        {
            try
            {
                //string sql = string.Concat("SELECT * FROM gr_cierreregistro WHERE anio = '", this.anio.SelectedValue, "' order by mes desc");
                var sql = from cierre in _context.gr_cierreregistro
                          where cierre.anio == anio
                          orderby cierre.mes descending
                          select cierre;

                return sql.ToList();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public void InsertarCierre( string mes,string anio,DateTime inireg, DateTime finreg, decimal tcambio)
        {
            try
            {
                //object[] selectedValue = new object[] { "INSERT INTO gr_cierreregistro VALUES ('", mes.SelectedValue, "','", this.anio.SelectedItem, "','", Funciones.fc(this.inireg.Text), "','", Funciones.fc(this.finreg.Text), "',", this.tcambio.Text.ToString().Replace(".", "").Replace(",", "."), ")" };
                //object[] selectedValue = new object[] { "INSERT INTO gr_cierreregistro VALUES ('", mes.SelectedValue, "','", this.anio.SelectedItem, "','", Funciones.fc(this.inireg.Text), "'   ,null                             ,"  , this.tcambio.Text.ToString().Replace(".", "").Replace(",", "."), ")" };
                string sql = "";
                //if (this.finreg.Text != "//")
                //{
                //    object[] selectedValue = new object[] { "INSERT INTO gr_cierreregistro VALUES ('", this.mes.SelectedValue, "','", this.anio.SelectedItem, "','", Funciones.fc(this.inireg.Text), "','", Funciones.fc(this.finreg.Text), "',", this.tcambio.Text.ToString().Replace(".", "").Replace(",", "."), ")" };
                //    sql = string.Concat(selectedValue);
                //}
                //else
                //{
                //    object[] objArray = new object[] { "INSERT INTO gr_cierreregistro VALUES ('", this.mes.SelectedValue, "','", this.anio.SelectedItem, "','", Funciones.fc(this.inireg.Text), "',null,", this.tcambio.Text.ToString().Replace(".", "").Replace(",", "."), ")" };
                //    sql = string.Concat(objArray);
                //}
                //Acceso db = new Acceso();
                //db.Conectar();
                //db.CrearComando(sql);
                //db.EjecutarComando();
                //db.Desconectar();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
    }
}
