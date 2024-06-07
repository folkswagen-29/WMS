﻿using WMS.userControls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.frmInsurance
{
    public partial class InsuranceRenewRequestList : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setDataRenewRequestList();
            }
        }

        private void setDataRenewRequestList()
        {
            ucHeader1.setHeader("My Renew Request List");
            string sql = "select * from li_insurance_request where toreq_code='02'";

            var res = zdb.ExecSql_DataTable(sql, zconnstr);

            lvRenewReqList.DataSource = res;
            lvRenewReqList.DataBind();

        }
    }
}