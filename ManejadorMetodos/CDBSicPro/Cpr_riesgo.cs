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
    public class Cpr_riesgo
    {
        #region Contructor Principal
        readonly sicproEntities _context;
        public Cpr_riesgo(sicproEntities dbContext)
        {
            _context = dbContext;
        }
        #endregion
        public void InsertarRiesgo(string cod_mod, string cod_ram, string cod_pol, string desc_riesgo, string cobertura)
        {
            //string[] text = new string[] { this.cod_mod.Text, "-", this.cod_ram.Text, "-", this.cod_pol.Text };
            //string codigo = string.Concat(text);
            //string[] strArrays = new string[] { "INSERT INTO pr_riesgo VALUES ('", codigo, "','", this.cod_mod.Text, "','", this.cod_ram.Text, "','", this.cod_pol.Text, "','", this.desc_riesgo.Text.ToUpper(), "','", this.cobertura.SelectedValue, "')" };
            try
            {
                string[] text = new string[] { cod_mod, "-", cod_ram, "-", cod_pol };
                string codigo = string.Concat(text);
                pr_riesgo item= new pr_riesgo();
                item.cobertura = cobertura;
                item.cod_mod = cod_mod;
                item.cod_pol = cod_pol;
                item.cod_ram = cod_ram;
                item.desc_riesgo = desc_riesgo;
                item.id_riesgo = codigo;

                _context.pr_riesgo.Add(item);
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
    }
}
