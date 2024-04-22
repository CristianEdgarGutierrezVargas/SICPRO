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
    public class Cre_histcaso
    {
        readonly sicproEntities _context;
        public Cre_histcaso(sicproEntities dbContext)
        {
            _context = dbContext;
        }
        public OcSerHistoCaso ser_histcaso(decimal id_caso,decimal anio_caso)
        {
            try
            {
                // string[] text = new string[] { "SELECT re_caso.id_caso
                //                                        , re_caso.anio_caso
                //                                        , re_caso.id_sucur
                //                                        , re_caso.id_perclie
                //                                        , gr_persona.nomraz
                //                                        , pr_poliza.id_poliza
                //                                        , pr_poliza.num_poliza
                //                                        ,  pr_producto.id_producto
                //                                        , pr_producto.desc_prod
                //                                        , v_pr_cias_resum.id_spvs
                //                                        , v_pr_cias_resum.nomraz AS nomraz2
                //                                        , re_siniestro.denunciante
                //                                        , re_siniestro.mat_aseg
                //                                        , re_siniestro.uniobj
                //                                        , re_siniestro.fc_denuncia
                //                                        , re_siniestro.circunstancia
                //                                        , re_histcaso.fc_iniestado
                //                                        , re_histcaso.id_estca
                //                                        , re_histcaso.obs_histcaso
                //                                        , gr_parametro.desc_param
                //                                        , re_caso.aprox_caso
                //                                        , (
                //                                               select abrev_param
                //                                               from gr_parametro
                //                                               where gr_parametro.id_par =  re_caso.id_divaprox
                //                                           ) as divisa
                //                                  FROM re_caso
                //                                  INNER JOIN gr_persona      ON (re_caso.id_perclie       = gr_persona.id_per)
                //                                  INNER JOIN pr_poliza       ON (re_caso.id_poliza        = pr_poliza.id_poliza)
                //                                  INNER JOIN pr_producto     ON (pr_poliza.id_producto    = pr_producto.id_producto)
                //                                  INNER JOIN v_pr_cias_resum ON (pr_poliza.id_spvs        = v_pr_cias_resum.id_spvs)
                //                                  INNER JOIN re_siniestro    ON (re_caso.id_caso          = re_siniestro.id_caso) AND (re_caso.anio_caso = re_siniestro.anio)
                //                                  INNER JOIN re_histcaso     ON (re_caso.id_caso          = re_histcaso.id_caso) AND (re_caso.anio_caso = re_histcaso.anio)
                //                                  INNER JOIN gr_parametro    ON (re_histcaso.id_estca = gr_parametro.id_par)
                //
                //                                  WHERE re_caso.id_caso = ", this.id_caso.Text, "
                //                                  AND re_caso.anio_caso = ", this.anio_caso.SelectedValue.ToString(), "
                //                                  AND re_histcaso.fc_finestado IS NULL" };

                var sql = 
                    (
                        from recaso          in _context.re_caso
                        join grpersona       in _context.gr_persona      on recaso.id_perclie    equals grpersona.id_per
                        join grpoliza        in _context.pr_poliza       on recaso.id_poliza     equals grpoliza.id_poliza
                        join grproducto      in _context.pr_producto     on grpoliza.id_producto equals grproducto.id_producto
                        join grpr_cias_resum in _context.v_pr_cias_resum on grpoliza.id_spvs     equals grpr_cias_resum.id_spvs
                        join grsiniestro     in _context.re_siniestro    on new { a = recaso.id_caso,b = recaso.anio_caso } equals new { a = grsiniestro.id_caso,b =  grsiniestro.anio }
                        join grhistcaso      in _context.re_histcaso     on new { a = recaso.id_caso,b = recaso.anio_caso } equals new { a = grhistcaso.id_caso, b = grhistcaso.anio }
                        join grparametro     in _context.gr_parametro    on grhistcaso.id_estca  equals grparametro.id_par
                        join grparametro2    in _context.gr_parametro    on recaso.id_divaprox equals grparametro2.id_par
                        
                        where recaso.id_caso == id_caso
                              & recaso.anio_caso == anio_caso
                              & grhistcaso.fc_finestado == null
                        select new OcSerHistoCaso
                        {
                            id_caso = recaso.id_caso,      
                            anio_caso = recaso.anio_caso,   
                            id_sucur = recaso.id_sucur,      
                            id_perclie = recaso.id_perclie,  
                            nomraz = grpersona.nomraz,       
                            id_poliza = grpoliza.id_poliza,   
                            num_poliza = grpoliza.num_poliza,   
                            id_producto = grproducto.id_producto,  
                            desc_prod = grproducto.desc_prod,   
                            id_spvs = grpr_cias_resum.id_spvs,    
                            nomraz2 = grpr_cias_resum.nomraz,
                            denunciante = grsiniestro.denunciante,
                            mat_aseg = grsiniestro.mat_aseg,
                            uniobj = grsiniestro.uniobj,
                            fc_denuncia = grsiniestro.fc_denuncia,
                            circunstancia = grsiniestro.circunstancia,
                            fc_iniestado = grhistcaso.fc_iniestado,  
                            id_estca = grhistcaso.id_estca,   
                            obs_histcaso = grhistcaso.obs_histcaso,  
                            desc_param = grparametro.desc_param,   
                            aprox_caso = recaso.aprox_caso,  
                            divisa = grparametro2.abrev_param,
                        }
                    ).FirstOrDefault();

                return sql;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public void ins_histcaso(decimal id_caso,decimal anio_caso, int id_sucur,double id_estcaso, string obs_histcaso)
        {
            try
            {
                //string[] text = new string[] { "insert into re_histcaso values(
                //                                                                  default,"
                //                                                                  , this.id_caso.Text, ","
                //                                                                  , this.anio_caso.SelectedValue.ToString(), ","
                //                                                                  , this.id_sucur.Value, "
                //                                                                  ,default
                //                                                                  ,default
                //                                                                  ,"
                //                                                                  , this.id_estcaso.SelectedValue.ToString(), ",'"
                //                                                                  , this.obs_histcaso.Text, "')" };
                re_histcaso item=new re_histcaso();
                item.id_caso = id_caso;
                item.anio = anio_caso; 
                item.id_sucur = id_sucur;
                item.id_estca =id_estcaso;
                item.obs_histcaso = obs_histcaso;
                item.fc_finestado=null;
                item.fc_iniestado=DateTime.Now; 

                _context.re_histcaso.Add(item);
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
        public void upd_histcaso1(decimal id_caso,decimal anio_caso)
        {
            try
            {
                var sql=(
                            from rhistcaso in _context.re_histcaso
                            where rhistcaso.id_caso == id_caso
                                & rhistcaso.anio == anio_caso
                                & rhistcaso.fc_finestado==null
                            select rhistcaso
                        ).FirstOrDefault();
                
                //string[] text = new string[] { "update re_histcaso set fc_finestado = current_date where id_caso = ", this.id_caso.Text, " and anio = ", this.anio_caso.SelectedValue.ToString(), " and fc_finestado is null" };
                sql.fc_finestado = DateTime.Now;
                _context.SaveChanges();
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
    }
}
