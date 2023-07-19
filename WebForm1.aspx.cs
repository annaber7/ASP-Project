using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectOneASP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonPageOne_Click(object sender, EventArgs e)
        {
            
        }

        protected void ButtonReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void ButtonInstitution_Click(object sender, EventArgs e)
        {
            Session.Contents["strReportSP"] = "uspProblemsByInstitution";
            Session.Contents["Title"] = "ProblemsByInstitution"; 

            Response.Redirect("WebForm2.aspx");

        }

        protected void ButtonClient_Click(object sender, EventArgs e)
        {
            Session.Contents["strReportSP"] = "uspProblemsByClient";
            Session.Contents["Title"] = "ProblemsByClient";

            Response.Redirect("WebForm2.aspx");
        }
    }
}