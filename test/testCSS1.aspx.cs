using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.test
{
    public partial class testCSS1 : System.Web.UI.Page
    {
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
        }
    }
}