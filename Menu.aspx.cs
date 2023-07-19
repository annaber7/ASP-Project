using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectOneASP
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void buttonService_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ServicePage.aspx");
        }

        protected void buttonTechnicians_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Technician.aspx");
        }

        protected void buttonReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Menu.aspx");
        }

        protected void buttonProblem_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ProblemResolution.aspx"); 
        }

        protected void buttonReports_Click1(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx"); 
        }
    }
}