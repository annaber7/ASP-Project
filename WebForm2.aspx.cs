using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; 

namespace ProjectOneASP
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if(Session.Contents["strReportSP"] != null && Session.Contents["Title"] != null)
                {
                    GetReport(Session.Contents["strReportSP"].ToString());
                    Label1.Text = Session.Contents["Title"].ToString();
                }
                
            }
            if (!IsPostBack)
            {
               // LoadReports(); 
            }
        }

        private void GetReport(string strSP)
        {

            DataSet dsData;
            lblError.Text = "";
            dsData = clsDatabase.GetReport(strSP);

            if (dsData == null)
            {
                lblError.Text = "Error retrieving report";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving report";
                dsData.Dispose();
            }
            else if (dsData.Tables[0].Rows.Count < 1)
            {
                lblError.Text = "Error retrieving problems";
                dsData.Dispose();
            }
            else
            {
                Session.Contents["DataTable"] = dsData.Tables[0];


                GridViewInstitution.DataSource = dsData.Tables[0];
                GridViewInstitution.DataBind();
                GridViewInstitution.Caption = Session.Contents["Title"].ToString();
                dsData.Dispose();
            }
        }
        private void LoadReports()
        {
            GridViewInstitution.DataSource = Session.Contents["DataTable"];
            GridViewInstitution.DataBind();
        }

        protected void ButtonPageTwo_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx"); 
        }
    }
}