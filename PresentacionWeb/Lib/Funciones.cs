using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentacionWeb.Lib
{
    public class Funciones
    {
        public static string anio(string fc_reg)
        {
            string str;
            try
            {
                str = fc_reg.Substring(6, 4);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("", secureException);
            }
            return str;
        }

        public static string fc(string fc_reg)
        {
            string str;
            try
            {
                string dia = fc_reg.Substring(0, 2);
                string mes = fc_reg.Substring(3, 2);
                string año = fc_reg.Substring(6, 4);
                string[] strArrays = new string[] { año, "/", mes, "/", dia };
                str = string.Concat(strArrays);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("", secureException);
            }
            return str;
        }

        public static string mes(string fc_reg)
        {
            string str;
            try
            {
                str = fc_reg.Substring(3, 2);
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("", secureException);
            }
            return str;
        }
    }
}