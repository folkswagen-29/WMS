using WMS.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.test
{
    public partial class TestPasswordHash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var password = "";
            var verify = false;

            var encryptPassword = "";
            var decryptPassword = "";

            if (!IsPostBack)
            {
                password = "pw1234";

                var key = "iJLTaWhyqexThL3Qmj63qA==";

                encryptPassword = EmpInfo.EncryptString(key, password);
                decryptPassword = EmpInfo.DecryptString(key, encryptPassword);

                if (password.Trim() == decryptPassword.Trim()) 
                {
                    verify = true;
                }
            }
        }
    }
}