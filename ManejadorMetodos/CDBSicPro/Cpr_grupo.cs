using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodos.CDBSicPro
{
    public class Cpr_grupo
    {


        public void ObtenerGrupo()
        {
            //try
            //{
            //    string sql = "SELECT pr_grupo.id_gru, pr_grupo.desc_grupo FROM pr_grupo UNION SELECT -1, 'SELECCIONE UNA OPCIÓN'";
            //    Acceso db = new Acceso();
            //    db.Conectar();
            //    db.CrearComando(sql);
            //    DataTable dtgeneral = db.Consulta();
            //    this.ddlgeneral.DataSource = dtgeneral;
            //    this.ddlgeneral.DataTextField = "desc_grupo";
            //    this.ddlgeneral.DataValueField = "id_gru";
            //    this.ddlgeneral.DataBind();
            //}
            //catch (SecureExceptions secureException)
            //{
            //    throw new SecureExceptions("Error al Generar la Consulta", secureException);
            //}
        }
    }
}
