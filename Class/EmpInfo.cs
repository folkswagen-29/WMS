using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace onlineLegalWF.Class
{
    public class EmpInfo
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        //public string zconnstr = ConfigurationSettings.AppSettings["BMPDB"].ToString();
        public string zconnstr = ConfigurationManager.AppSettings["RPADB"].ToString();
        #endregion
       public EmpModel getEmpInfo(string xuser_login)
        {
            var empData = new EmpModel();
            // get query 
            // set values
            return empData; 
        }
        public List<EmpModel> getApprovalList(string xuser_login)
        {
            List<EmpModel> li = new List<EmpModel>();
            var empData = getEmpInfo(xuser_login);
            li.Add(empData);
            if (!String.IsNullOrEmpty(empData.next_line_mgr_login))
            {
                var supData = getEmpInfo(empData.next_line_mgr_login);
            }
            return li; 
        }
    }
    public class EmpModel
    {
        public string user_login { get; set; }
        public string user_name { get; set; }
        public string position { get; set; }
        public string divisiton { get; set; }   // แผนก
        public string department { get; set; }  // ฝ่าย
        public string bu { get; set; } // C ต่างๆ 
        public string property_name { get; set; } // project = ตึกอาหาร 
        public string next_line_mgr_login { get; set;  } // หัวหน้าถัดไปเป็นใคร?
        public string divisiton_head_login { get; set; }   // แผนก
        public string department_head_login { get; set; }  // ฝ่าย
        public string GM_Level_login { get; set; } // GM
        public string C_Level_login { get; set; } // Head of C นั้นๆ
    }
}