using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using onlineLegalWF.Class; 

namespace onlineLegalWF.test
{
    public partial class testCSS1 : System.Web.UI.Page
    {
        public WFFunctions zwf = new WFFunctions(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                ini_objects(); 
            }
        }
        private void ini_objects()
        {
            ucMenulist1.bind_menu("");
            lblPID.Text = zwf.iniPID("LEGALWF");
            ucAttachment1.ini_object(lblPID.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (lblDocNo.Text.Trim() == "")
            {
                lblDocNo.Text = zwf.genDocNo("INS-" + System.DateTime.Now.ToString("yyyy", new CultureInfo("en-US")) + "-", 4);
            }

        }
    }
}