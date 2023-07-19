using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; 

namespace ProjectOneASP
{
    public partial class Resolution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session.Contents["TicketID"] != null && Session.Contents["IncidentNo"] != null)
                {

                    lblTicketNo.Text = Session.Contents["TicketID"].ToString();

                    lblProblemNo.Text = Session.Contents["IncidentNo"].ToString();
                    lblResNum.Text = "1";
                }

                LoadTechnicianList();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //inserting or updating in DB
            if (ValidateInput())
            {
                //Check for Insert or Update
                if (DropDownTechnician.SelectedIndex == 0)
                {
                    InsertResolution();
                    ClearDataFields(); 
                }
                
            }
        }
        private void InsertResolution()
        {
            int intRetVal;
            int intTicketNo;
            lblError.Text = "";

            

            intRetVal = clsDatabase.InsertResolution(lblTicketNo.Text, lblProblemNo.Text, lblResNum.Text, txtDescription.Text, txtFixed.Text, txtOnsite.Text, Convert.ToInt32(DropDownTechnician.Text), txtHours.Text, txtMileage.Text, lblRate.Text, txtSupplies.Text, txtMisc.Text, CheckBoxCharge.Text);
            if (intRetVal == 0)
            {
                lblError.Text = "Resolution Inserted";
                Session.Contents["TicketNo"] = lblTicketNo.Text;
                LoadTechnicianList();

            }
            else
            {
                lblError.Text = "Error inserting Technician";
            }

        }
        private void LoadTechnicianList()
        {
            DataSet dsData;
            dsData = clsDatabase.GetTechnicianList();
            if (dsData == null)
            {
                lblError.Text = "Error retrieving technician list";
                DropDownTechnician.Items.Clear();
                DropDownTechnician.Items.Add(new ListItem("TECHNICIAN", "0"));
                DropDownTechnician.AppendDataBoundItems = true;
                DropDownTechnician.DataSource = dsData.Tables[0];
                DropDownTechnician.DataTextField = "TechName";
                DropDownTechnician.DataValueField = "TechnicianID";
                DropDownTechnician.DataBind();

                dsData.Dispose();

            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving technician list";
                dsData = null;
            }
            else if (dsData.Tables[0].Rows.Count < 1)
            {
                lblError.Text = "Error retrieving product list";
                dsData = null;
            }
            else
            {
                DropDownTechnician.Items.Clear();
                DropDownTechnician.Items.Add(new ListItem("--TECHNICIAN--", "0"));
                DropDownTechnician.AppendDataBoundItems = true;

                DropDownTechnician.DataSource = dsData.Tables[0];
                DropDownTechnician.DataTextField = "TechName";
                DropDownTechnician.DataValueField = "TechnicianID";
                DropDownTechnician.DataBind();

                dsData.Dispose();
            }
        }
        private void ClearDataFields()
        {
            txtDescription.Text = "";
            txtFixed.Text = "";
            txtOnsite.Text = "";
            txtHours.Text = "";
            CheckBoxCharge.Checked = false;
            txtMileage.Text = "";
            lblRate.Text = "";
            txtSupplies.Text = "";
            txtMisc.Text = ""; 
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearDataFields(); 
        }

        protected void buttonReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Menu.aspx");
        }

        protected void DropDownTechnician_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private Boolean ValidateInput()
        {
            Boolean blnOk = true;
            String strMessage = "";

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                blnOk = false;
                if (strMessage.Trim().Length > 0)
                {
                    strMessage += ";<br />";
                }
                strMessage += "Description is required";
            }
           
            

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtHours.Text, "[0-9]"))
            {
                blnOk = false;
                if (strMessage.Trim().Length > 0)
                {
                    strMessage += ";<br />";
                }
                strMessage += "Hours must be numeric";
            }
            if (string.IsNullOrWhiteSpace(txtHours.Text))
            {
                blnOk = false;
                if (strMessage.Trim().Length > 0)
                {
                    strMessage += ";<br />";
                }
                strMessage += "Hours are required";

            }
            if(DropDownTechnician.SelectedIndex == 0)
            {
                blnOk = false;
                strMessage = "Technician must be selected"; 
            }
            

            lblError.Text = strMessage;

            return blnOk;
        }
    }
    
}