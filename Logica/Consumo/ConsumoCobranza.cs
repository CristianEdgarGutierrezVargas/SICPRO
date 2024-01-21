using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using Common;
namespace Logica.Consumo
{
    public class ConsumoCobranza
    {
        #region Contructor Principal

        private readonly Cpr_poliza _manejador_pr_poliza;
        private readonly Cgr_persona _manejador_gr_persona;
        private readonly Cpr_cobranzas _manejador_pr_cobranzas;
        private readonly Cvcb_veripoliza1 _manejador_vcb_veripoliza1;
        private readonly Cpr_producto _manejador_pr_producto;
        private readonly Cpr_formriesgo _manejador_pr_formriesgo;
        private readonly Cgr_compania _manejador_gr_compania;
        private readonly Cpr_grupo _manejador_pr_grupo;
        private readonly Cgr_parametro _manejador_gr_parametro;
        private readonly Cpr_polmov _manejador_pr_polmov;
        private readonly Cpr_pago _manejador_pr_pago;
        public static sicproEntities dbContext;
        public ConsumoCobranza()
        {
            //if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_pr_poliza = new Cpr_poliza(dbContext);
            _manejador_pr_cobranzas = new Cpr_cobranzas(dbContext);
            _manejador_vcb_veripoliza1 = new Cvcb_veripoliza1(dbContext);
            _manejador_pr_producto = new Cpr_producto(dbContext);
            _manejador_pr_formriesgo = new Cpr_formriesgo(dbContext);
            _manejador_gr_persona = new Cgr_persona(dbContext);
            _manejador_gr_compania = new Cgr_compania(dbContext);
            _manejador_pr_grupo = new Cpr_grupo(dbContext);
            _manejador_gr_parametro = new Cgr_parametro(dbContext);
            _manejador_pr_polmov = new Cpr_polmov(dbContext);
            _manejador_pr_pago=new Cpr_pago(dbContext);
        }
        #endregion

        public DataTable RecuFacMod()
        {
            DataTable dataTable;
            try
            {
                string[] str = new string[] { "SELECT pr_pago.id_poliza, pr_pago.id_movimiento, pr_pago.cuota, pr_poliza.id_spvs, pr_pago.factura, pr_pago.fecha_factura, pr_pago.id_pago, pr_poliza.num_poliza FROM pr_pago INNER JOIN pr_poliza ON (pr_pago.id_poliza = pr_poliza.id_poliza) WHERE pr_poliza.id_spvs = '", this.id_spvs.SelectedValue.ToString(), "' and pr_pago.factura = ", this.nro_factura.Text, " order by pr_pago.id_pago asc" };
                string sql = string.Concat(str);
                Acceso db = new Acceso();
                db.Conectar();
                db.CrearComando(sql);
                dataTable = db.Consulta();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la transacción", secureException);
            }
            return dataTable;
        }
    }
}
