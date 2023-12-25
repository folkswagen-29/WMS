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
        public wf_attributes getDefaultStep(string process_code, int version_no, int step_no)
        {
            var x = new wf_attributes();
            string sql = " select * from wf_routing_default where process_code = '" + process_code + "' and version_no = " + version_no.ToString() + " and step_no = " + step_no.ToString();
           
            var dt = zdb.ExecSql_DataTable(sql, zconnstr);
            if (dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
               
                x.process_code = dr["process_code"].ToString();
                try
                {
                    x.version_no = System.Convert.ToInt32(dr["version_no"].ToString());
                }
                catch
                {
                    x.version_no = 1;
                }
                try
                {
                    x.step_no = System.Convert.ToInt32(dr["step_no"].ToString());
                }
                catch
                {
                    x.step_no = 1;
                }
                x.step_name = dr["step_name"].ToString();
                x.assto_login = dr["assto_login"].ToString();
                x.attr_apv_value = dr["attr_apv_value"].ToString();
                try
                {
                    x.istrue_nextstep = System.Convert.ToInt32(dr["istrue_nextstep"].ToString());
                }
                catch { }
                try
                {
                    x.isfalse_nextstep = System.Convert.ToInt32(dr["isfalse_nextstep"].ToString());
                }
                catch { }
               
            }
            return x; 
        }
        public Boolean isExistingWFStep(string process_id, string process_code, int version_no, int step_no)
        {
            var x = false; 
            string sql = " select * from wf_routing where process_id = '"+ process_id + "' and process_code = '" + process_code + "' and version_no = " + version_no.ToString() + " and step_no = " + step_no.ToString();

            var dt = zdb.ExecSql_DataTable(sql, zconnstr);
            if (dt.Rows.Count > 0)
            {
                x = true; 
            }
            return x; 
        }
        public wf_attributes getCurrentStep(string process_id, string process_code, int version_no)
        {
            var x = new wf_attributes(); 
            string sql = " select * from wf_routing where process_id = '"+process_id+"' and process_code = '"+process_code+"' and version_no = " + version_no.ToString();
            sql += " order by step_no desc "; 
            var dt = zdb.ExecSql_DataTable(sql, zconnstr); 
            if (dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                x.process_id = dr["process_id"].ToString();
                x.process_code = dr["process_code"].ToString();
                try
                {
                    x.version_no = System.Convert.ToInt32(dr["version_no"].ToString());
                }
                catch
                {
                    x.version_no = 1; 
                }
                try
                {
                    x.step_no = System.Convert.ToInt32(dr["step_no"].ToString());
                }
                catch
                {
                    x.step_no = -1;
                }
                x.step_name = dr["step_name"].ToString();
                x.assto_login = dr["assto_login"].ToString();
                x.attr_apv_value = dr["attr_apv_value"].ToString(); 
                try
                {
                    x.istrue_nextstep = System.Convert.ToInt32(dr["istrue_nextstep"].ToString()); 
                }
                catch { }
                try
                {
                    x.isfalse_nextstep = System.Convert.ToInt32(dr["isfalse_nextstep"].ToString());
                }
                catch { }
                x.wf_status = dr["wf_status"].ToString();
                x.comment = dr["comment"].ToString();
                x.submit_answer = dr["submit_answer"].ToString(); 
                
                if  (dr["created_datetime"].ToString() != "")
                {
                    x.created_datetime = System.Convert.ToDateTime( dr["created_datetime"]);
                }
                if (dr["updated_datetime"].ToString() != "")
                {
                    x.updated_datetime = System.Convert.ToDateTime(dr["updated_datetime"]);
                }
            }
            else
            {
                sql = " select * from wf_routing_default where process_code = '" + process_code + "' and version_no = " + version_no.ToString();
                sql += " order by step_no  ";
                var dt2 = zdb.ExecSql_DataTable(sql, zconnstr);
                if (dt2.Rows.Count > 0)
                {
                    var dr = dt2.Rows[0];
                    x.process_id = process_id;
                    x.process_code = dr["process_code"].ToString();
                    try
                    {
                        x.version_no = System.Convert.ToInt32(dr["version_no"].ToString());
                    }
                    catch
                    {
                        x.version_no = 1;
                    }
                    try
                    {
                        x.step_no = System.Convert.ToInt32(dr["step_no"].ToString());
                    }
                    catch
                    {
                        x.step_no = -1;
                    }
                    x.step_name = dr["step_name"].ToString();
                    x.assto_login = dr["assto_login"].ToString();
                    x.attr_apv_value = dr["attr_apv_value"].ToString();
                    try
                    {
                        x.istrue_nextstep = System.Convert.ToInt32(dr["istrue_nextstep"].ToString());
                    }
                    catch { }
                    try
                    {
                        x.isfalse_nextstep = System.Convert.ToInt32(dr["isfalse_nextstep"].ToString());
                    }
                    catch { }
                    x.wf_status ="";
                    x.comment = "";
                }
            }
            return x ;
        }

        public wf_attributes updateProcess(wf_attributes wfA) //return next_step_attribute
        {
            string x = "";
            // Update Current Step
            string sql = " select * from wf_routing where process_id = '" + wfA.process_id + "' and process_code = '" + wfA.process_code + "' and version_no = " + wfA.version_no.ToString() + " and step_no = " + wfA.step_no.ToString();
            var dt = zdb.ExecSql_DataTable(sql, zconnstr);
            if (dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                string sqlupd = @"update wf_routing 
                set 
                    submit_answer = '" + wfA.submit_answer + @"' ,
                    submit_by = '" + wfA.submit_by + @"' ,
                    wf_status = '" + wfA.wf_status+@"' ,
                    attr_apv_value = '" + wfA.attr_apv_value + @"' 
                where process_id = '"+wfA.process_id+@"' and step_no = "+wfA.step_no+@"
                ";
                zdb.ExecNonQuery(sqlupd, zconnstr); 
            }
            else // in case start flow
            {
                string sqlins = @" insert into wf_routing (process_id, process_code, version_no, subject,
                                step_no, step_name, assto_login,
                                wf_status, attr_apv_value , istrue_nextstep, isfalse_nextstep, created_datetime, submit_answer, submit_by) 
                                values (
                                    '" + wfA.process_id+ @"', 
                                    '" + wfA.process_code + @"', 
                                    " + wfA.version_no.ToString() + @", 
                                    '" + wfA.subject + @"', 
                                    " + wfA.step_no.ToString() + @", 
                                    '" + wfA.step_name + @"', 
                                     '" + wfA.assto_login + @"', 
                                     '" + wfA.wf_status + @"', 
                                    '" + wfA.attr_apv_value + @"', 
                                    " + wfA.istrue_nextstep.ToString() + @", 
                                    " + wfA.isfalse_nextstep.ToString() + @", 
                                    '" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                                    '" + wfA.submit_answer + @"',
                                    '" + wfA.submit_by + @"'
                                    ) ";
                zdb.ExecNonQuery(sqlins, zconnstr);
            }
            //  Finding next step 
            int next_step = 0; 
            if (wfA.attr_apv_value == wfA.submit_answer)
            {
                next_step = wfA.istrue_nextstep; 
            }
            else
            {
                next_step = wfA.isfalse_nextstep;
            }
            // Insert new step into Inbox
            var wfDefault_step = getDefaultStep(wfA.process_code, wfA.version_no, next_step);
            wfDefault_step.subject = wfA.subject;
            wfDefault_step.process_id = wfA.process_id;
               
            
            return wfDefault_step; 
        }

        public string Insert_NextStep(wf_attributes wfDefault_step)
        {
            string x = "";
            if (wfDefault_step.step_name.ToUpper() != "")
            {
                if (!isExistingWFStep(wfDefault_step.process_id, wfDefault_step.process_code, wfDefault_step.version_no,wfDefault_step.step_no)) // Check used to add New Step already or not?
                {
                    string sqlins = @" insert into wf_routing (process_id, process_code, version_no, subject,
                                    step_no, step_name, assto_login,
                                    wf_status, attr_apv_value , istrue_nextstep, isfalse_nextstep, created_datetime, submit_answer, submit_by) 
                                    values (
                                        '" + wfDefault_step.process_id + @"', 
                                        '" + wfDefault_step.process_code + @"', 
                                        " + wfDefault_step.version_no.ToString() + @", 
                                        '" + wfDefault_step.subject + @"', 
                                        " + wfDefault_step.step_no.ToString() + @", 
                                        '" + wfDefault_step.step_name + @"', 
                                         '" + wfDefault_step.next_assto_login + @"', 
                                        '', 
                                        '" + wfDefault_step.attr_apv_value + @"', 
                                        " + wfDefault_step.istrue_nextstep.ToString() + @", 
                                        " + wfDefault_step.isfalse_nextstep.ToString() + @", 
                                        '" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                                        '',
                                        ''
                                        ) ";
                    zdb.ExecNonQuery(sqlins, zconnstr);
                }
               

            }
            return x = "Success";
        }
    }
  

    public class wf_attributes
    {
        public string process_id { get; set; }
        public string process_code { get; set; }
        public int version_no { get; set; }
        public int step_no { get; set; }
        public string subject { get; set; }
        public string step_name { get; set; }
        public string assto_login { get; set;  }
        public string next_assto_login { get; set; }
        public string wf_status { get; set; }
        public string comment { get; set; }
        public string attr_apv_value { get; set; }
        public int istrue_nextstep { get; set; }
        public int isfalse_nextstep { get; set; }
        public DateTime created_datetime { get; set; }
        public DateTime updated_datetime { get; set;  }
        public string submit_answer { get; set; }
        public string submit_by { get; set; }
    }
}