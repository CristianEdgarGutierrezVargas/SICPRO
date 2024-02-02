using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodosSql
{
    public class Connections
    {
        private string dbServer = ConfigurationSettings.AppSettings["SQLDB_SERVER"];
        private string dbName = ConfigurationSettings.AppSettings["SQLDB_DATABASE"];
        private string dbUser = ConfigurationSettings.AppSettings["SQLDB_USER"];
        private string dbPassword = ConfigurationSettings.AppSettings["SQLDB_PASSWORD"];

        private string dbServerExt = ConfigurationSettings.AppSettings["SQLDB_SERVER_EXT"];
        private string dbNameExt = ConfigurationSettings.AppSettings["SQLDB_DATABASE_EXT"];
        private string dbUserExt = ConfigurationSettings.AppSettings["SQLDB_USER_EXT"];
        private string dbPasswordExt = ConfigurationSettings.AppSettings["SQLDB_PASSWORD_EXT"];

        //string solicitudServer = ConfigurationSettings.AppSettings["SolicitudServer"].ToString();
        //string solicitudName = ConfigurationSettings.AppSettings["SolicitudName"].ToString();
        //string solicitudUser = ConfigurationSettings.AppSettings["SolicitudUser"].ToString();
        //string solicitudPassword = ConfigurationSettings.AppSettings["SolicitudPassword"].ToString();

        public Connections()
        {
            //encryptador encrypt = new encryptador("");
            //encrypt.EncryptDecryptPublic(false, dbPassword, ref dbPassword);

            //encrypt.EncryptDecryptPublic(false, solicitudPassword, ref solicitudPassword);
        }

        public string DefaultConnection()
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder("Server=" + dbServer + ";DataBase=" + dbName + "; User Id=" + dbUser + ";Password=" + dbPassword + ";");
            return conn.ConnectionString;
        }

        //public string DefaultStringConnection()
        //{
        //    string ConnectionString = ConfigurationManager.ConnectionStrings["sicproEntities"].ConnectionString.ToString();
        //    return ConnectionString;
        //}

        //public string Solicitud()
        //{
        //    SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder("Server=" + solicitudServer + ";DataBase=" + solicitudName + "; User Id=" + solicitudUser + ";Password=" + solicitudPassword + ";");
        //    return conn.ConnectionString;
        //}

        //public string Excel(string fileName)
        //{
        //    OleDbConnectionStringBuilder conn = new OleDbConnectionStringBuilder("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + "; Persist Security Info=False;Extended Properties=&quot;Excel 12.0 Xml;HDR=YES;IMEX=1&quot;");
        //    return conn.ConnectionString;
        //}

        public string ConnectionExt()
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder("Server=" + dbServerExt + ";DataBase=" + dbNameExt + "; User Id=" + dbUserExt + ";Password=" + dbPasswordExt + ";");
            return conn.ConnectionString;
        }
    }
}