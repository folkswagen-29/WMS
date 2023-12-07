using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmLitigation
{
    public partial class LigitationWorkAssign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setData();
            }

        }
        private void setData()
        {
            string xmode = "";
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mode"]))
                {
                    xmode = Request.QueryString["mode"].ToString();
                }
            }
            catch
            {
                xmode = "VIEW";
            }
            ucHeader1.setHeader("Permit WorkAssign");
            // Bind Worklist
            //getData

            var dt = ucWorkflowlist1.iniDTStructure();
            var dr = dt.NewRow();
            dr["No"] = "1";
            dr["processid"] = "0001";
            dr["processname"] = "Ligitaion - Request";
            dr["documentno"] = "li2307001";
            dr["subject"] = "Request new Ligitaion";
            dr["requesteddate"] = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            dr["status"] = "New";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["No"] = "2";
            dr["processid"] = "0002";
            dr["processname"] = "Ligitaion - Request";
            dr["documentno"] = "li2307002";
            dr["subject"] = "Request new Ligitaion";
            dr["requesteddate"] = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            dr["status"] = "New";
            dt.Rows.Add(dr);
            ucWorkflowlist1.LoadData(dt, "admin");
        }
    }
}