using Spire.Doc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace onlineLegalWF.Class
{
    public class EmpInfo
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["RPADB"].ToString();
        public string zconnstrbpm = ConfigurationManager.AppSettings["BPMDB"].ToString();
        #endregion
        public EmpModel getEmpInfo(string xuser_login)
        {
            var empData = new EmpModel();
            // get query 

            string sql = "select * from Rpa_Mst_HrNameList where Login = 'ASSETWORLDCORP-\\" + xuser_login + "' ";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);

            // set values check data from rpa and get data
            if (dt.Rows.Count > 0)
            {
                var userLogin = dt.Rows[0]["Login"].ToString().Split(new char[] { '\\' });
                empData.user_login = userLogin[1].Trim();
                empData.full_name_th = dt.Rows[0]["PrefixTH"].ToString() + " " + dt.Rows[0]["FirstNameTH"].ToString() + " " + dt.Rows[0]["LastNameTH"].ToString();
                empData.full_name_en = dt.Rows[0]["PrefixEN"].ToString() + " " + dt.Rows[0]["FirstNameEN"].ToString() + " " + dt.Rows[0]["LastNameEN"].ToString();
                empData.position_th = dt.Rows[0]["PositionNameTH"].ToString();
                empData.position_en = dt.Rows[0]["PositionNameEN"].ToString();
                empData.email = dt.Rows[0]["Email"].ToString();
                empData.division = dt.Rows[0]["DivisionEN"].ToString();
                empData.department = dt.Rows[0]["DepartmentEN"].ToString();
                empData.bu = dt.Rows[0]["FunctionCode"].ToString();
                empData.property_name = dt.Rows[0]["CompanyNameEN"].ToString();

                if (!string.IsNullOrEmpty(dt.Rows[0]["SupervisorCode"].ToString()))
                {
                    string sqlSupervisor = "select * from Rpa_Mst_HrNameList where EmployeeCode='" + dt.Rows[0]["SupervisorCode"].ToString() + "' ";
                    var resSupervisor = zdb.ExecSql_DataTable(sqlSupervisor, zconnstr);

                    if (resSupervisor.Rows.Count > 0)
                    {
                        var resUserLogin = resSupervisor.Rows[0]["Login"].ToString().Split(new char[] { '\\' });
                        empData.next_line_mgr_login = resUserLogin[1].Trim();
                    }

                }

            }
            else 
            {
                string sqlbpm = "select * from li_user where user_login = '" + xuser_login + "' ";
                DataTable dtbpm = zdb.ExecSql_DataTable(sqlbpm, zconnstrbpm);

                if (dtbpm.Rows.Count > 0) 
                {
                    empData.user_login = dtbpm.Rows[0]["user_login"].ToString();
                    //empData.full_name_th = dtbpm.Rows[0]["PrefixTH"].ToString() + " " + dtbpm.Rows[0]["FirstNameTH"].ToString() + " " + dtbpm.Rows[0]["LastNameTH"].ToString();
                    empData.full_name_en = dtbpm.Rows[0]["prefix_en"].ToString() + " " + dtbpm.Rows[0]["firstname_en"].ToString() + " " + dtbpm.Rows[0]["lastname_en"].ToString();
                    //empData.position_th = dtbpm.Rows[0]["PositionNameTH"].ToString();
                    empData.position_en = dtbpm.Rows[0]["position_en"].ToString();
                    empData.email = dtbpm.Rows[0]["email"].ToString();
                    empData.division = dtbpm.Rows[0]["division_en"].ToString();
                    //empData.department = dtbpm.Rows[0]["DepartmentEN"].ToString();
                    //empData.bu = dtbpm.Rows[0]["FunctionCode"].ToString();

                    //////get bu name by bu_code
                    string sqlbpmbu = "select * from li_business_unit where bu_code = '" + dtbpm.Rows[0]["bu_code"].ToString() + "' ";
                    DataTable dtbpmbu = zdb.ExecSql_DataTable(sqlbpmbu, zconnstrbpm);

                    if (dtbpmbu.Rows.Count > 0) 
                    {
                        empData.bu = dtbpm.Rows[0]["bu_desc"].ToString();
                    }
                    else
                    {
                        empData.bu = "";
                    }

                    //empData.property_name = dtbpm.Rows[0]["CompanyNameEN"].ToString();

                    if (!string.IsNullOrEmpty(dtbpm.Rows[0]["supervisor_login"].ToString()))
                    {
                        string sqlbpmSupervisor = "select * from li_user where supervisor_login='" + dtbpm.Rows[0]["supervisor_login"].ToString() + "' ";
                        var resbpmSupervisor = zdb.ExecSql_DataTable(sqlbpmSupervisor, zconnstrbpm);

                        if (resbpmSupervisor.Rows.Count > 0)
                        {
                            empData.next_line_mgr_login = resbpmSupervisor.Rows[0]["user_login"].ToString();
                        }

                    }
                }
                
            }

            
            return empData; 
        }
        public List<EmpModel> getApprovalList(string xuser_login)
        {
            List<EmpModel> li = new List<EmpModel>();
            var empData = getEmpInfo(xuser_login);
            li.Add(empData);
            if (!string.IsNullOrEmpty(empData.next_line_mgr_login))
            {
                var supData = getEmpInfo(empData.next_line_mgr_login);
                li.Add(supData);

                if (!string.IsNullOrEmpty(supData.next_line_mgr_login)) 
                {
                    var supData2 = getEmpInfo(supData.next_line_mgr_login);
                    li.Add(supData2);

                    if (!string.IsNullOrEmpty(supData2.next_line_mgr_login))
                    {
                        var supData3 = getEmpInfo(supData2.next_line_mgr_login);
                        li.Add(supData3);

                        if (!string.IsNullOrEmpty(supData3.next_line_mgr_login))
                        {
                            var supData4 = getEmpInfo(supData3.next_line_mgr_login);
                            li.Add(supData4);

                            if (!string.IsNullOrEmpty(supData4.next_line_mgr_login))
                            {
                                var supData5 = getEmpInfo(supData4.next_line_mgr_login);
                                li.Add(supData5);
                            }
                        }
                    }
                }
            }
            return li; 
        }
    }
    public class EmpModel
    {
        public string user_login { get; set; }
        public string full_name_th { get; set; }
        public string full_name_en { get; set; }
        public string position_en { get; set; }
        public string position_th { get; set; }
        public string email { get; set; }
        public string division { get; set; }   // แผนก
        public string department { get; set; }  // ฝ่าย
        public string bu { get; set; } // C ต่างๆ 
        public string property_name { get; set; } // project = ตึกอาคาร 
        public string next_line_mgr_login { get; set;  } // หัวหน้าถัดไปเป็นใคร?
        //public string divisiton_head_login { get; set; }   // แผนก
        //public string department_head_login { get; set; }  // ฝ่าย
        //public string GM_Level_login { get; set; } // GM
        //public string C_Level_login { get; set; } // Head of C นั้นๆ
    }
}