using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration; 

namespace ProjectOneASP
{
    public partial class ProblemResolution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                LoadProblems(); 

            }
            lblError.Text = ""; 
            if (!IsPostBack)
            {
                GetProblems(); 
            }
            //use uspgetopenproblems
        }

        private void LoadProblems()
        {
            GridViewProblems.DataSource = Session.Contents["DataTable"];
            GridViewProblems.DataBind(); 
        }
        private void GetProblems()
        {
            DataSet dsData;
            lblError.Text = "";
            dsData = clsDatabase.GetOpenProblems(); 

            if(dsData == null)
            {
                lblError.Text = "Error retrieving problems"; 
            }
            else if(dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving problems";
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


                GridViewProblems.DataSource = dsData.Tables[0];
                GridViewProblems.DataBind();
                dsData.Dispose(); 
            }

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {

        }

        protected void Problem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Problem_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Boolean blnErrorOccurred = false;
            int intRetCode;
            string strTicketID = "";
            string strIncidentNo = ""; 
            lblError.Text = ""; 

            if(e.CommandName.Trim().ToUpper() == "SELECT")
            {
                try
                {
                    strTicketID = GridViewProblems.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.ToString();
                    strIncidentNo = GridViewProblems.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.ToString(); 
                }
                catch
                {
                    blnErrorOccurred = true;
                    lblError.Text = "Error  accessing Ticket ID"; 
                }
                if (!blnErrorOccurred)
                {
                    //Session variables
                    Session.Contents["TicketID"] = strTicketID;
                    Session.Contents["IncidentNo"] = strIncidentNo;
                    Response.Redirect("/Resolution.aspx"); 
                    //Using QuerySTrings

                }
            }
            
        }

        protected void GridViewProblems_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtSort;
            dtSort = (DataTable)Session.Contents["DataTable"];
            dtSort.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);

            GridViewProblems.DataSource = Session.Contents["DataTable"];
            GridViewProblems.DataBind(); 
        }
        private string GetSortDirection(string column)
        {
            Boolean blnUseViewState = false;
            string sortDirection = "ASC"; 
            if (ConfigurationManager.AppSettings["UseViewState"] != null)
            {
                blnUseViewState = Convert.ToBoolean(ConfigurationManager.AppSettings["UseViewState"]); 
            }
            if (blnUseViewState)
            {
                string sortExpression = ViewState["SortExpression"].ToString(); 

                if(sortExpression != null)
                {
                    //Check if same column being sorted , if yes reverse the sorting direction
                    if(sortExpression == column)
                    {
                        string lastDirection = ViewState["SortDirection"].ToString(); 
                        if(lastDirection != null && (lastDirection == "ASC"))
                        {
                            sortDirection = "DESC"; 
                        }
                    }
                }
                ViewState["SortDirection"] = sortDirection;
                ViewState["SortExpression"] = column;

            }
            else
            {
                //Use Session Variables
                if (Session.Contents["SortBy"] == null)
                {
                    //Automatically set to field passed in and asc
                    Session.Contents["SortBy"] = column;
                    Session.Contents["SortDir"] = "ASC"; 
                }
                else if(Session.Contents["SortBy"].ToString().ToUpper() == column.ToUpper())
                {
                    if( (Session.Contents["SortDir"].ToString().ToUpper() == "ASC"))
                    {
                        Session.Contents["SortDir"] = "DESC";
                    }
                    else
                    {
                        Session.Contents["SortDir"] = "ASC"; 
                    }
                }
                else
                {
                    ///*Sortiing on a new field
                    Session.Contents["SortBy"] = column;
                    Session.Contents["SortDir"] = "ASC"; 
                }
                sortDirection = Session.Contents["SortDir"].ToString(); 
            }
            return sortDirection;  

        }

        protected void GridViewProblems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if(e.NewPageIndex <= GridViewProblems.PageCount)
            {
                GridViewProblems.PageIndex = e.NewPageIndex; 

            }
            LoadProblems(); 
        }

        protected void GridViewProblems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           /* if(e.Row.RowType == DataControlRowType.DataRow)
            {
                if(e.Row.Cells[2].Text.ToString().ToUpper() == "H")
                {
                    e.Row.Cells[2].BackColor = System.Drawing.Color.ForestGreen;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Yellow; 
                    e.Row.Cells[2].Text = ""
                }
            }*/
        }

        protected void GridViewProblems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("./Resolution.aspx"); 
        }
    }
}