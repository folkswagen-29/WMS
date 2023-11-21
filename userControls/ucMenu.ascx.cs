using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.userControls
{
    public partial class ucMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn5_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmInsurance/InsuranceRequest.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmInsurance/InsuranceRenewRequest.aspx");
        }

        protected void lbtn6_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmInsurance/InsuranceClaim.aspx");
        }

        protected void lbtn17_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmInsurance/InsuranceTrackingRenew.aspx");
        }

        protected void lbtn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmInsurance/InsuranceRequestList.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmInsurance/InsuranceRenewRequestList.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmInsurance/InsuranceClaimList.aspx");
        }

        protected void lbtn9_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmCommregis/CommRegisRequest.aspx");
        }

        protected void lbtn10_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmCommregis/CommRegisWorkAssign.aspx");
        }

        protected void lbtn13_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmPermit/PermitLicense.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmPermit/PermitSignageTax.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmPermit/PermitLandTax.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmPermit/PermitTrademark.aspx");
        }
    }
}