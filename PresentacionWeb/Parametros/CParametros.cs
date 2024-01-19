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

        public class keyValue
        {
            public int key { get; set; }

            public string value { get; set; }
        } 
    }
}