using Common;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Logica.Consumo
{
    public class ConsumoConfiguracionSistema
    {

        //private readonly Cgr_persona _manejador_gr_persona;
        private readonly Cgr_pass _manejador_gr_pass;
        private readonly Cgr_persona _manejador_gr_persona;
        private readonly Cgr_parametro _manejador_gr_parametro;
        private readonly Cco_porcomi _manejador_co_porcomi;
        private readonly Cpr_riesgo _manejador_pr_riesgo;
        private readonly Cgr_cierreregistro _manejador_gr_cierreregistro;
        private readonly Cgr_tc _manejador_gr_tc;
        private readonly Cpr_producto _manejador_pr_producto;
        private readonly Cgr_compania _manejador_gr_compania;
        private readonly Cpr_cuotapoliza _manejador_pr_cuotapoliza;
        private readonly Cpr_cuotas _manejador_pr_cuotas;
        public static sicproEntities dbContext;

        public ConsumoConfiguracionSistema()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            _manejador_gr_pass = new Cgr_pass(dbContext);
            _manejador_gr_parametro = new Cgr_parametro(dbContext);
            _manejador_gr_persona = new Cgr_persona(dbContext);
            _manejador_co_porcomi = new Cco_porcomi(dbContext);
            _manejador_pr_riesgo = new Cpr_riesgo(dbContext);
            _manejador_gr_cierreregistro = new Cgr_cierreregistro(dbContext);
            _manejador_gr_tc = new Cgr_tc(dbContext);
            _manejador_pr_producto = new Cpr_producto(dbContext);
            _manejador_gr_compania = new Cgr_compania(dbContext);
            _manejador_pr_cuotapoliza = new Cpr_cuotapoliza(dbContext);
            _manejador_pr_cuotas = new Cpr_cuotas(dbContext);
        }

        public List<gr_persona> ListaPersonaConPass()
        {
            try
            {
                return _manejador_gr_pass.ListaPersonaConPass();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public void ResetPassword(string idPersona)
        {
            try
            {
                _manejador_gr_pass.ResetPassword(idPersona);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<gr_parametro> ListaRoles()
        {
            try
            {
                return _manejador_gr_parametro.ListRoles();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<gr_persona> TablaPersona(string varbusqueda)
        {
            try
            {
                return _manejador_gr_persona.TablaPersona(varbusqueda);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void AgregarUsuario(string login, decimal id_rol, string id_pert)
        {
            try
            {
                _manejador_gr_pass.AgregaUsuario(login, id_rol, id_pert);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void ModificarUsuario1(string login, decimal id_rol, string id_pert)
        {
            try
            {
                _manejador_gr_pass.ModificarUsuario1(login, id_rol, id_pert);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void ObtenerDatos(string id_per, out gr_persona personaOut, out gr_pass passOut)
        {
            try
            {
                _manejador_gr_pass.ObtenerDatos(id_per, out personaOut, out passOut);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<gr_persona> Persona(int parametro)
        {
            try
            {
                return _manejador_gr_persona.Persona(parametro);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public List<co_porcomi> ObtPorcart(string id_per)
        {
            try
            {
                return _manejador_co_porcomi.ObtPorcart(id_per);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void InsPorcart(string id_per, decimal porcentaje, bool esfactura)
        {
            try
            {
                _manejador_co_porcomi.InsPorcart(id_per, porcentaje, esfactura);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void UpdPorcart(string id_per, decimal porcentaje, bool esfactura)
        {
            try
            {
                _manejador_co_porcomi.UpdPorcart(id_per, porcentaje, esfactura);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void InsertarRiesgo(string cod_mod, string cod_ram, string cod_pol, string desc_riesgo, string cobertura)
        {
            try
            {
                _manejador_pr_riesgo.InsertarRiesgo(cod_mod, cod_ram, cod_pol, desc_riesgo, cobertura);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public List<gr_cierreregistro> TablaCierre(string anio)
        {
            try
            {
                return _manejador_gr_cierreregistro.TablaCierre(anio);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }

        public void InsertarCierre(string mes, string anio, DateTime inireg, DateTime finreg, decimal tcambio)
        {
            try
            {
                _manejador_gr_cierreregistro.InsertarCierre(mes, anio, inireg, finreg, tcambio);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public void ModificarCierre(string mes, string anio, DateTime inireg, DateTime finreg, decimal tcambio)
        {
            try
            {
                _manejador_gr_cierreregistro.ModificarCierre(mes, anio, inireg, finreg, tcambio);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<string> ObtenerListaParametro()
        {
            try
            {
                return _manejador_gr_parametro.ObtenerListaParametro();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<gr_parametro> ObtenerLista(string columna)
        {
            try
            {
                return _manejador_gr_parametro.ObtenerLista(columna);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public gr_parametro ObtenerParametro(long id)
        {
            try
            {
                return _manejador_gr_parametro.ObtenerParametro(id);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public void InsertarParametro(gr_parametro item)
        {
            try
            {
                _manejador_gr_parametro.InsertarParametro(item);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public void ModificarParametro(gr_parametro item)
        {
            try
            {
                _manejador_gr_parametro.InsertarParametro(item);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public void EliminarParametro(long idPara)
        {
            try
            {
                _manejador_gr_parametro.EliminarParametro(idPara);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<gr_parametro> Parametro(string columna)
        {
            try
            {
                return _manejador_gr_parametro.Parametro(columna);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<gr_tc> Tasa(out List<gr_parametro> list_parametro)
        {
            try
            {
                return _manejador_gr_tc.Tasa(out list_parametro);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public void InsertarTC(gr_tc item)
        {
            try
            {
                _manejador_gr_tc.InsertarTC(item);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public bool ExisteProducto(string desc_prod, string abrev_prod)
        {
            try
            {
                return _manejador_pr_producto.ExisteProducto(desc_prod, abrev_prod);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public void InsertarProducto(string desc_prod, string abrev_prod)
        {
            try
            {
                _manejador_pr_producto.InsertarProducto(desc_prod, abrev_prod);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public pr_producto ObtenerProducto(long idProducto)
        {
            try
            {
                return _manejador_pr_producto.ObtenerProducto(idProducto);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<v_pr_cias_resum> ObtenerListaCompania()
        {
            try
            {
                return _manejador_gr_compania.ObtenerListaCompania();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<gr_persona> ObtenerListaCompania(string busqueda, out List<gr_compania> listCompania)
        {
            try
            {
                return _manejador_gr_compania.ObtenerListaCompania(busqueda, out listCompania);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<pr_producto> TablaProductoL(string busqueda, string desc_prod)
        {
            try
            {
                return _manejador_pr_producto.TablaProductoL(busqueda, desc_prod);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<pr_riesgo> ObtenerRiesgo()
        {
            try
            {
                return _manejador_pr_producto.ObtenerRiesgo();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<pr_producto> ObtenerTablaProducto(string varbusqueda)
        {
            try
            {
                return _manejador_pr_producto.ObtenerTablaProducto(varbusqueda);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Transacción", secureException);
            }
        }
        public List<pr_formriesgo> ObtenerFormRiesgo(string id_spvs, long id_producto)
        {
            try
            {
                var idSpvs = _manejador_pr_producto.ObtenerFormRiesgo(id_spvs, id_producto);
                return idSpvs;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public void ModificarFormRiesgo(pr_formriesgo item)
        {
            try
            {
                _manejador_pr_producto.ModificarFormRiesgo(item);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<vpr_listasinpago> ObtenerTablaPoliza(string num_poliza, string id_perclie, string id_spvs, long id_producto, bool flagVigencia, DateTime? fc_inivig, DateTime? fc_finivig, bool flagPorVencer, DateTime? fc_finvig)
        {
            try
            {
                return _manejador_pr_cuotapoliza.ObtenerTablaPoliza( num_poliza,  id_perclie,  id_spvs,  id_producto, flagVigencia,  fc_inivig,  fc_finivig, flagPorVencer,  fc_finvig);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<pr_producto> TablaProductoP(string desc_prod)
        {
            try
            {
                return _manejador_pr_producto.TablaProductoP(desc_prod);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<gr_componente> Componente()
        {
            try
            {
                return _manejador_gr_pass.Componentes();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public List<gr_componente> ListaComponentesNoAsig(long id_rol) 
        {
            try
            {
                return _manejador_gr_pass.ListaComponentesNoAsig(id_rol);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<gr_componente> ListaComponentesAsig(long id_rol)
        {
            try
            {
                return _manejador_gr_pass.ListaComponentesAsig(id_rol);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<gr_acceso> VerificarComponente(long idRol, int idCom)
        {
            try
            {
                return _manejador_gr_pass.VerificarComponente(idRol, idCom);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public void InsertarAcceso(long idRol, int idCom)
        {
            try
            {
                _manejador_gr_pass.InsertarAcceso(idRol, idCom);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public void AsignarAccesos(long idRol,int lstcomp)
        {
            try
            {
                _manejador_gr_pass.AsignarAccesos(idRol, lstcomp);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public List<gr_componente> ListaComponentes(long id_rol)
        {
            try
            {
                return _manejador_gr_pass.ListaComponentes(id_rol);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public void QuitarAccesos(long id_com, long id_rol) 
        {
            try
            {
                _manejador_gr_pass.QuitarAccesos(id_com, id_rol);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
        public vpr_listasinpago ObtenerDatosPoliza(int id_poliza, int id_movimiento, out OC_DatosCuotas datosCuotas)
        {
            try
            {
                return _manejador_pr_cuotas.ObtenerDatosPoliza(id_poliza, id_movimiento,out datosCuotas);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }

        public void InsertarFormRiesgo(string desc_prod, string abrev_prod, string id_riesgo, string id_spvs, bool? opera, decimal evaluar, decimal comis, decimal por_cred, decimal plus_neta)
        {
            try
            {
                 _manejador_pr_producto.InsertarFormRiesgo(desc_prod, abrev_prod, id_riesgo, id_spvs, opera, evaluar, comis, por_cred,  plus_neta);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);
            }
        }
    }
}
