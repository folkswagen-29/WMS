using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

namespace onlineLegalWF.Class
{
   
    public class WFFunctions
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        //public string zconnstr = ConfigurationSettings.AppSettings["BPMDB"].ToString();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        #endregion


        public string iniPID(string app_name) 
        {
            string xpid = "";
            // PID_yyyy + running_no

            /* table [dbo].[m_doc_runno]
             prefix_name
            last_runno

             */
            int xnum = 0;
            string xprefix = "PID_"+ app_name +"_" + System.DateTime.Now.ToString("yyyy", new CultureInfo("en-US"))+ "_";
            string sql = " select * from m_doc_runno where prefix_name = '" + xprefix + "' ";
            var ds = zdb.ExecSql_DataSet(sql, zconnstr); 
            if (ds.Tables.Count > 0)
            {
             
                try
                {
                    xnum = System.Convert.ToInt32(ds.Tables[0].Rows[0]["last_runno"].ToString()) + 1;
                }
                catch
                {
                    xnum = 1; 
                }
                if ( ds.Tables[0].Rows.Count > 0)
                {
                // update data
                sql = " update m_doc_runno set last_runno = " + xnum + " where prefix_name = '" + xprefix + "' ";
                zdb.ExecNonQuery(sql, zconnstr); 
                }
                else
                {
                    xnum = 1;
                    sql = " insert into m_doc_runno (prefix_name, last_runno) values ('" + xprefix + "', " + xnum + ") ";
                    zdb.ExecNonQuery(sql, zconnstr);
                }
            }
           
            xpid = xprefix + xnum.ToString("000000"); 
            return xpid; 
        }
        public string genDocNo(string xprefix, int runno_length)
        {
            string xpid = "";
            // PID_yyyy + running_no

            /* table [dbo].[m_doc_runno]
             prefix_name
            last_runno

             */
            int xnum = 0;
           // string xprefix = "PID_" + System.DateTime.Now.ToString("yyyy");
            string sql = " select * from m_doc_runno where prefix_name = '" + xprefix + "' ";
            var ds = zdb.ExecSql_DataSet(sql, zconnstr);
            if (ds.Tables.Count> 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        xnum = System.Convert.ToInt32(ds.Tables[0].Rows[0]["last_runno"].ToString()) + 1;
                    }
                    catch
                    {
                        xnum = 1;
                    }
                    // update data
                    sql = " update m_doc_runno set last_runno = " + xnum + " where prefix_name = '" + xprefix + "' ";
                    zdb.ExecNonQuery(sql, zconnstr);
                }
                else
                {
                    xnum = 1;
                    sql = " insert into m_doc_runno (prefix_name, last_runno) values ('" + xprefix + "', " + xnum + ") ";
                    zdb.ExecNonQuery(sql, zconnstr);
                }
            }
           
            // convert xnum_length format
            var xlength = xnum.ToString().Length ;
            var xstrzero = ""; 
            for (int i = xlength; i < runno_length; i++) 
            {
                //ex  18 ; ml = 6; l = 2 
                xstrzero += "0"; 
            }
            xpid = xprefix + xstrzero + xnum.ToString();
            return xpid;
        }


    }
}