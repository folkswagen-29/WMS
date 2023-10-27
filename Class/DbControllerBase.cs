using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace onlineLegalWF
{
    public class DbControllerBase
    {
        static SqlConnection conn = null;
        protected SqlCommand sqlCmd = null;
        protected SqlDataReader sqlReader;
        public string ConnectionString { get; set; }

        public DbControllerBase(string zconnstr)
        {
            ConnectionString = zconnstr;
            try
            {
                if (conn == null || conn.State == ConnectionState.Closed)
                {
                    // conn = new SqlConnection(ConfigurationManager.ConnectionStrings["zcsdb"].ToString());
                    conn = new SqlConnection(ConnectionString);

                    conn.Open();
                }
                sqlCmd = new SqlCommand();
            }
            catch (Exception e)
            {
                LogHelper.Write(zconnstr);
                LogHelper.WriteEx(e);
                //Logs
                throw;
            }
        }
        public DbControllerBase() // new Empty Construction Class
        {

        }
        public void Close()
        {
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                LogHelper.WriteEx(e);
                throw;
            }
        }
        public SqlConnection _getConnection(string xconnstr)
        {
            SqlConnection conn = new SqlConnection(xconnstr);

            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                LogHelper.Write(xconnstr);
                LogHelper.Write(e);
            }
            return conn;
        }
        public void _closeConnection(SqlConnection xconn)
        {
            try
            {
                xconn.Close();
            }
            catch (Exception e)
            {
                LogHelper.Write(e);
            }
        }
        public SqlDataReader ExecuteSql(string sql, CommandType cmdType = CommandType.Text)
        {
            try
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }

                sqlCmd.CommandText = sql;
                sqlCmd.CommandType = cmdType;
                sqlCmd.Connection = conn;
                sqlReader = sqlCmd.ExecuteReader();

            }
            catch (Exception e)
            {
                LogHelper.Write(sql);
                LogHelper.Write(e);
                throw;
            }

            return sqlReader;
        }

        public DataSet ExecSql_DataSet(string sql, string xconnstr)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection conn = new SqlConnection(xconnstr);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
                sqlDataAdapter.Fill(ds);
                conn.Close();
            }
            catch (Exception e)
            {
                LogHelper.Write(sql);
                LogHelper.Write(e);
            }
            return ds;
        }
        public DataSet ExecSql_DataSet(string sql, SqlConnection conn)
        {

            DataSet ds = new DataSet();
             
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
                sqlDataAdapter.Fill(ds);
            }
            catch (Exception e)
            {
                LogHelper.Write(sql);
                LogHelper.Write(e);
            }
            return ds;
        }
        public DataTable ExecSql_DataTable(string sql, string xconnstr)
        {
            SqlConnection conn = new SqlConnection(xconnstr);
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            sqlDataAdapter.Fill(ds);
            DataTable dt = new DataTable();
            try
            {
                dt = ds.Tables[0];
            }
            catch (Exception e)
            {
                LogHelper.Write(sql);
                LogHelper.Write(e);
            }
            conn.Close();
            return dt;
        } 

        public static DataTable ExecSql_DataTableStatic(string sql, string xconnstr)
        {
            SqlConnection conn = new SqlConnection(xconnstr);
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            sqlDataAdapter.Fill(ds);
            DataTable dt = new DataTable();
            try
            {
                dt = ds.Tables[0];
            }
            catch (Exception e)
            {
                LogHelper.Write(sql);
                LogHelper.Write(e);
            }
            conn.Close();
            return dt;
        }

        public DataTable ExecSql_DataTable(string sql, SqlConnection conn)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            sqlDataAdapter.Fill(ds);
            try
            {
                dt = ds.Tables[0];
            }
            catch (Exception e)
            {
                LogHelper.Write(sql);
                LogHelper.Write(e);
            }
            return dt;
        }

        public void ExecNonQuery(string sql, string xconnstr)
        {
            try
            {
                SqlConnection conn = new SqlConnection(xconnstr); 
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand SQLCmd = new SqlCommand(sql, conn);
                SQLCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                LogHelper.Write(sql);
                LogHelper.Write(e);
            }
        }
        public void ExecNonQuery(string sql, SqlConnection conn)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand SQLCmd = new SqlCommand(sql, conn);
                SQLCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                LogHelper.Write(sql);
                LogHelper.Write(e);
            }
        }
        public int ExecNonQueryReturnID(string sql, string xconnstr)
        {
            int modified = 0;
            try
            {
                SqlConnection conn = new SqlConnection(xconnstr);
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand SQLCmd = new SqlCommand(sql, conn);
                //SQLCmd.ExecuteNonQuery();
                modified = SQLCmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                LogHelper.Write(sql);
                LogHelper.Write(e);
            }
            return modified;
        }
        public int ExecuteScalar(string sql, string xconnstr)
        {
            int modified = 0;
            try
            {
                SqlConnection conn = new SqlConnection(xconnstr);
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand SQLCmd = new SqlCommand(sql, conn);
                //SQLCmd.ExecuteNonQuery();
                modified = Convert.ToInt32(SQLCmd.ExecuteScalar());
                conn.Close();

            }
            catch (Exception e)
            {
                LogHelper.Write(sql);
                LogHelper.Write(e);
            }
            return modified;
        }
    }
}