using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorMetodosSql
{
    public class CStoredProcedureBaseExt
    {
        //PERMITE SELECT DE UN FIELD ESPECIFICO ----ok ----
        public object SelectField(string sqlStatement, List<CParameter> lstParameters, string strConnectionString)
        {
            object o = null;

            SqlDataReader rdr = null;
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                using (con = new SqlConnection(strConnectionString))
                {
                    con.Open();

                    string commandText = sqlStatement;

                    cmd = new SqlCommand(commandText);
                    cmd.Connection = con;

                    if (lstParameters != null)
                    {
                        foreach (CParameter p in lstParameters)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                        }
                    }

                    // Execute the query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        if (rdr[0] != DBNull.Value)
                            o = rdr[0];
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // Close data reader object and database connection
                if (rdr != null)
                    rdr.Close();
                if (con != null)
                    con.Close();
                if (cmd != null)
                    cmd.Dispose();
            }

            return o;
        }

        //PERMITE SELECT DE UN OBJETO, OBJETO COMPLEJO ----OK----
        public object SelectObject(string sqlStatement, object objeto, List<CParameter> lstParameters, string strConnectionString)
        {
            object objectInstance = null;

            SqlDataReader rdr = null;
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                using (con = new SqlConnection(strConnectionString))
                {
                    con.Open();

                    string commandText = sqlStatement;

                    cmd = new SqlCommand(commandText);
                    cmd.Connection = con;

                    if (lstParameters != null)
                    {
                        foreach (CParameter p in lstParameters)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                        }
                    }

                    // Execute the query
                    rdr = cmd.ExecuteReader();
                    Type objectType = objeto.GetType();

                    //Instancia de objeto
                    objectInstance = Activator.CreateInstance(objectType);
                    while (rdr.Read())
                    {
                        foreach (var property in objectType.GetProperties())
                        {
                            //PropertyInfo propertyInfo = objectType.GetProperty(property.Name);
                            var propertyName = property.Name;

                            if (property.PropertyType.Namespace != null && property.PropertyType.Namespace.Equals("System"))
                            {
                                var value = rdr[propertyName];

                                Type t = Nullable.GetUnderlyingType(property.PropertyType) != null ? Nullable.GetUnderlyingType(property.PropertyType) : property.PropertyType;

                                object safeValue = (value == DBNull.Value) ? null : Convert.ChangeType(value, t);

                                property.SetValue(objectInstance, safeValue, null);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // Close data reader object and database connection
                if (rdr != null)
                    rdr.Close();
                if (con != null)
                    con.Close();
                if (cmd != null)
                    cmd.Dispose();
            }
            return objectInstance;
        }

        //PERMITE SELECT DE UNA LISTA, ---ok ----
        public List<object> SelectListObject(string sqlStatement, object objeto, List<CParameter> lstParameters, string strConnectionString)
        {
            object objectInstance = null;
            var lstInstance = new List<object>();
            SqlDataReader rdr = null;
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                using (con = new SqlConnection(strConnectionString))
                {
                    con.Open();

                    string commandText = sqlStatement;

                    cmd = new SqlCommand(commandText);
                    cmd.Connection = con;

                    if (lstParameters != null)
                    {
                        foreach (CParameter p in lstParameters)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                        }
                    }

                    // Execute the query
                    rdr = cmd.ExecuteReader();

                    Type objectType = objeto.GetType();

                    while (rdr.Read())
                    {
                        objectInstance = Activator.CreateInstance(objectType);

                        foreach (var property in objectType.GetProperties())
                        {
                            //PropertyInfo propertyInfo = objectType.GetProperty(property.Name);
                            var propertyName = property.Name;

                            if (property.PropertyType.Namespace != null && property.PropertyType.Namespace.Equals("System"))
                            {
                                var value = rdr[propertyName];
                                Type t = Nullable.GetUnderlyingType(property.PropertyType) != null ? Nullable.GetUnderlyingType(property.PropertyType) : property.PropertyType;
                                object safeValue = (value == DBNull.Value) ? null : Convert.ChangeType(value, t);

                                property.SetValue(objectInstance, safeValue, null);
                            }
                        }
                        lstInstance.Add(objectInstance);
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // Close data reader object and database connection
                if (rdr != null)
                    rdr.Close();
                if (con != null)
                    con.Close();
                if (cmd != null)
                    cmd.Dispose();
            }

            return lstInstance;
        }

        public DataTable SelectDatatable(string sqlStatement, List<CParameter> lstParameters, string strConnectionString)
        {
            SqlDataReader rdr = null;
            SqlDataAdapter rda = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            DataTable consult = new DataTable();

            try
            {
                using (con = new SqlConnection(strConnectionString))
                {
                    string commandText = sqlStatement;
                    using (cmd = new SqlCommand(commandText, con))
                    {
                        using (rda = new SqlDataAdapter(cmd))
                        {
                            if (lstParameters != null)
                            {
                                foreach (CParameter p in lstParameters)
                                {
                                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                                }
                            }

                            // Execute the query
                            con.Open();
                            rda.Fill(consult);
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // Close data reader object and database connection
                if (rdr != null)
                    rdr.Close();
                if (rda != null)
                    rda.Dispose();
                if (con != null)
                    con.Close();
                if (cmd != null)
                    cmd.Dispose();
            }

            return consult;
        }

        //PERMITE EJECUCION DE UN QUERY DE EJECUCION ---OK ----
        public bool RunQuery(string sqlStatement, List<CParameter> lstParameters, string strConnectionString)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                using (con = new SqlConnection(strConnectionString))
                {
                    using (cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = sqlStatement;

                        if (lstParameters != null)
                        {
                            foreach (CParameter p in lstParameters)
                            {
                                cmd.Parameters.AddWithValue(p.Key, p.Value);
                            }
                        }
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con != null)
                    con.Close();
                if (cmd != null)
                    cmd.Dispose();
            }
            return false;
        }

        //PERMITE EJECUCION DE SP DEVUELVE EJECUCION TRUE OR FALSE  ----ok-----
        public bool RunStoredProcedure(string sqlStoredProcedure, List<CParameter> lstParameters, string strConnectionString)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                using (con = new SqlConnection(strConnectionString))
                {
                    using (cmd = new SqlCommand(sqlStoredProcedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 900000;

                        if (lstParameters != null)
                        {
                            foreach (CParameter p in lstParameters)
                            {
                                cmd.Parameters.AddWithValue(p.Key, p.Value);
                            }
                        }
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con != null)
                    con.Close();
                if (cmd != null)
                    cmd.Dispose();
            }
            return false;
        }

        //PERMITE EJECUCION DE SP CON UN REPUESTA OBJECT DEL SP  ---ok--
        public object RunStoredProcedureField(string sqlStoredProcedure, List<CParameter> lstParameters, string strConnectionString)
        {
            object oField = null;

            SqlDataReader rdr = null;
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                using (con = new SqlConnection(strConnectionString))
                {
                    con.Open();
                    using (cmd = new SqlCommand(sqlStoredProcedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 3000;

                        if (lstParameters != null)
                        {
                            foreach (CParameter p in lstParameters)
                            {
                                cmd.Parameters.AddWithValue(p.Key, p.Value);
                            }
                        }
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            if (rdr[0] != DBNull.Value)
                                oField = rdr[0];
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con != null)
                    con.Close();
                if (rdr != null)
                    rdr.Close();
                if (cmd != null)
                    cmd.Dispose();
            }
            return oField;
        }

        //PERMITE EJECUCION DE SP CON UN REPUESTA OBJECT DEL SP  ---ok--
        public object RunStoredProcedureObj(string sqlStoredProcedure, object objeto, List<CParameter> lstParameters, string strConnectionString)
        {
            object objectInstance = null;

            SqlDataReader rdr = null;
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                using (con = new SqlConnection(strConnectionString))
                {
                    con.Open();
                    using (cmd = new SqlCommand(sqlStoredProcedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 3000;

                        if (lstParameters != null)
                        {
                            foreach (CParameter p in lstParameters)
                            {
                                cmd.Parameters.AddWithValue(p.Key, p.Value);
                            }
                        }
                        rdr = cmd.ExecuteReader();
                        Type objectType = objeto.GetType();

                        objectInstance = Activator.CreateInstance(objectType);
                        while (rdr.Read())
                        {
                            foreach (var property in objectType.GetProperties())
                            {
                                var propertyName = property.Name;

                                if (property.PropertyType.Namespace != null && property.PropertyType.Namespace.Equals("System"))
                                {
                                    var value = rdr[propertyName];

                                    Type t = Nullable.GetUnderlyingType(property.PropertyType) != null ? Nullable.GetUnderlyingType(property.PropertyType) : property.PropertyType;

                                    object safeValue = (value == DBNull.Value) ? null : Convert.ChangeType(value, t);

                                    property.SetValue(objectInstance, safeValue, null);
                                }
                                //PropertyInfo propertyInfo = objectType.GetProperty(property.Name);
                                //propertyInfo.SetValue(objectType, Convert.ChangeType(2, propertyInfo.PropertyType), null);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con != null)
                    con.Close();
                if (rdr != null)
                    rdr.Close();
                if (cmd != null)
                    cmd.Dispose();
            }
            return objectInstance;
        }

        //PERMITE EJECUCION DE SP CON UN REPUESTA LIST<OBJECT> DEL SP ---ok--
        public List<object> RunStoredProcedureList(string sqlStoredProcedure, object objeto, List<CParameter> lstParameters, string strConnectionString)
        {
            object objectInstance = null;
            var lstInstance = new List<object>();

            SqlDataReader rdr = null;
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                using (con = new SqlConnection(strConnectionString))
                {
                    con.Open();
                    using (cmd = new SqlCommand(sqlStoredProcedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 3000;

                        if (lstParameters != null)
                        {
                            foreach (CParameter p in lstParameters)
                            {
                                cmd.Parameters.AddWithValue(p.Key, p.Value);
                            }
                        }
                        rdr = cmd.ExecuteReader();
                        Type objectType = objeto.GetType();

                        while (rdr.Read())
                        {
                            objectInstance = Activator.CreateInstance(objectType);

                            foreach (var property in objectType.GetProperties())
                            {
                                var propertyName = property.Name;

                                if (property.PropertyType.Namespace != null && property.PropertyType.Namespace.Equals("System"))
                                {
                                    var value = rdr[propertyName];

                                    Type t = Nullable.GetUnderlyingType(property.PropertyType) != null ? Nullable.GetUnderlyingType(property.PropertyType) : property.PropertyType;

                                    object safeValue = (value == DBNull.Value) ? null : Convert.ChangeType(value, t);

                                    property.SetValue(objectInstance, safeValue, null);
                                }
                                //PropertyInfo propertyInfo = objectType.GetProperty(property.Name);
                                //propertyInfo.SetValue(objectType, Convert.ChangeType(2, propertyInfo.PropertyType), null);
                            }
                            lstInstance.Add(objectInstance);
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con != null)
                    con.Close();
                if (rdr != null)
                    rdr.Close();
                if (cmd != null)
                    cmd.Dispose();
            }
            return lstInstance;
        }

        //PERMITE EJECUCION DE SP CON RESPUESTA DATATABLE ---ok ---
        public DataTable GetDataTable(string sqlStoredProcedure, List<CParameter> lstParameters, string strConnectionString)
        {
            SqlDataAdapter rda = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            DataTable consult = new DataTable();

            try
            {
                using (con = new SqlConnection(strConnectionString))
                {
                    using (cmd = new SqlCommand(sqlStoredProcedure, con))
                    {
                        using (rda = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 3000;

                            if (lstParameters != null)
                            {
                                foreach (CParameter p in lstParameters)
                                {
                                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                                }
                            }
                            con.Open();
                            rda.Fill(consult);
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con != null)
                    con.Close();
                if (rda != null)
                    rda.Dispose();
                if (cmd != null)
                    cmd.Dispose();
            }
            return consult;
        }

        //PERMITE EJECUCION DE SP CON RESPUESTA EN DATASET --OK---
        public DataSet GetDataSet(string sqlStoredProcedure, List<CParameter> lstParameters, string strConnectionString)
        {
            SqlDataAdapter rda = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            DataSet consult = new DataSet();
            try
            {
                using (con = new SqlConnection(strConnectionString))
                {
                    using (cmd = new SqlCommand(sqlStoredProcedure, con))
                    {
                        using (rda = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 3000;

                            if (lstParameters != null)
                            {
                                foreach (CParameter p in lstParameters)
                                {
                                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                                }
                            }
                            con.Open();
                            rda.Fill(consult);
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con != null)
                    con.Close();
                if (rda != null)
                    rda.Dispose();
                if (cmd != null)
                    cmd.Dispose();
            }
            return consult;
        }
    }
}