using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentacionWeb.Parametros
{
    public class CParametros
    {
        public List<keyValue> GetListMeses() 
        {
            var lstMeses = new List<keyValue>();

            var sel = new keyValue { key = 0, value = "Seleccione" };
            lstMeses.Add(sel);

            var enero = new keyValue { key = 1, value = "Enero" };
            lstMeses.Add(enero);

            var febrero = new keyValue { key = 2, value = "Febrero" };
            lstMeses.Add(febrero);

            var marzo = new keyValue {  key = 3, value = "Marzo" };
            lstMeses.Add(marzo);

            var abril = new keyValue { key = 4, value = "Abril" };
            lstMeses.Add(abril);

            var mayo = new keyValue { key = 5, value = "Mayo" };
            lstMeses.Add(mayo);

            var junio = new keyValue { key = 6, value = "Junio" };
            lstMeses.Add(junio);

            var julio = new keyValue { key = 7, value = "Julio" };
            lstMeses.Add(julio);

            var agosto = new keyValue { key = 8, value = "Agosto" };
            lstMeses.Add(agosto);

            var sept = new keyValue { key = 9, value = "Septiembre" };
            lstMeses.Add(sept);

            var oct = new keyValue { key = 10, value = "Octubre" };
            lstMeses.Add(oct);

            var nov = new keyValue { key = 11, value = "Noviembre" };
            lstMeses.Add(nov);

            var dic = new keyValue { key = 12, value = "Diciembre" };
            lstMeses.Add(dic);

            return lstMeses;
        }

        public List<keyValueS> GetListRangoFechas()
        {
            var lstCom = new List<keyValueS>();

            var sel = new keyValueS { key = "selected", value = "Seleccione" };
            lstCom.Add(sel);

            var val1 = new keyValueS { key = "fc_recepcion", value = "Recepcion" };
            lstCom.Add(val1);

            var val2 = new keyValueS { key = "fc_reg", value = "Producción" };
            lstCom.Add(val2);

            var val3 = new keyValueS { key = "fc_emision", value = "Emisión" };
            lstCom.Add(val3);

            var val4 = new keyValueS { key = "fc_inivig", value = "Inicio Vigencia" };
            lstCom.Add(val4);

            var val5 = new keyValueS { key = "fc_finvig", value = "Fin Vigencia" };
            lstCom.Add(val5);

            return lstCom;
        }
        public List<keyValue> GetListComparaPrima()
        {
            var lstCom = new List<keyValue>();

            var sel = new keyValue { key = 0, value = "Seleccione" };
            lstCom.Add(sel);

            var val1 = new keyValue { key = 1, value = "Igual a" };
            lstCom.Add(val1);

            var val2 = new keyValue { key = 2, value = "Mayor a" };
            lstCom.Add(val2);

            var val3 = new keyValue { key = 3, value = "Menor a" };
            lstCom.Add(val3);

            var val4 = new keyValue { key = 4, value = "Mayor igual a" };
            lstCom.Add(val4);

            var val5 = new keyValue { key = 5, value = "Menor Igual a" };
            lstCom.Add(val5);

            return lstCom;
        }
        public class keyValue
        {
            public int key { get; set; }

            public string value { get; set; }
        }

        public class keyValueS
        {
            public string key { get; set; }

            public string value { get; set; }
        }
    }
}