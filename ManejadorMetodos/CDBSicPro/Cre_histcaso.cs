using Common;
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
        public bool ser_histcaso(string id_caso,string anio_caso)
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
               //                                  INNER JOIN gr_persona ON (re_caso.id_perclie = gr_persona.id_per)
               //                                  INNER JOIN pr_poliza ON (re_caso.id_poliza = pr_poliza.id_poliza)
               //                                  INNER JOIN pr_producto ON (pr_poliza.id_producto = pr_producto.id_producto)
               //                                  INNER JOIN v_pr_cias_resum ON (pr_poliza.id_spvs = v_pr_cias_resum.id_spvs)
               //                                  INNER JOIN re_siniestro ON (re_caso.id_caso = re_siniestro.id_caso) AND (re_caso.anio_caso = re_siniestro.anio)
               //                                  INNER JOIN re_histcaso ON (re_caso.id_caso = re_histcaso.id_caso) AND (re_caso.anio_caso = re_histcaso.anio)
               //                                  INNER JOIN gr_parametro ON (re_histcaso.id_estca = gr_parametro.id_par)
               //
               //                                  WHERE re_caso.id_caso = ", this.id_caso.Text, "
               //                                  AND re_caso.anio_caso = ", this.anio_caso.SelectedValue.ToString(), "
               //                                  AND re_histcaso.fc_finestado IS NULL" };
              
                
                //var sql=(
                //            from recaso in _context.re_caso
                //            join grpersona in _context.gr_persona on recaso.id_perclie equals grpersona.id_per
                //            join grpoliza in _context.pr_poliza on recaso.id_poliza equals proliza.
                //        )
                return true;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la consulta", secureException);
            }
        }
    }
}
