using Common;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
