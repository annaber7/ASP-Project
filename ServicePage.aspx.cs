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
    public partial class ServicePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadClient(); 

            }
            labelDate.Text = DateTime.Now.ToShortDateString(); 
        }
        private void LoadTickets()
        {
            
        }
        private void InsertServiceEvent()
        {
            int intNewTicketID;
          
            LabelError.Text = "";

            intNewTicketID = clsDatabase.InsertServiceEvent(Convert.ToInt32(DropDownClient.SelectedValue), DateTime.Now, TextBoxTelephone.Text, TextBoxContact.Text);
            if(intNewTicketID > 0)
            {
                LabelError.Text = "Service Event Inserted";
                Session.Contents["NewTicketID"] = intNewTicketID;
                Response.Redirect("/Problem.aspx");
            }
            else
            {
                LabelError.Text = "Error inserting service event to DB ";
            }
        }
        private void LoadClient()
        {
            DataSet dsData;
            dsData = clsDatabase.GetClientList();
            if (dsData == null)
            {
                LabelError.Text = "Error retrieving client";
                

            }
            else if (dsData.Tables.Count < 1)
            {
                LabelError.Text = "Error retrieving client";
                dsData = null;
            }
            else
            {
                DropDownClient.Items.Clear();
                DropDownClient.Items.Add(new ListItem("--Select Client--", "0"));
                DropDownClient.AppendDataBoundItems = true;

                DropDownClient.DataSource = dsData.Tables[0];
                DropDownClient.DataTextField = "ClientName";
                DropDownClient.DataValueField = "ClientID";
                DropDownClient.DataBind();

                dsData.Dispose();
            }
        }

        protected void buttonReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Menu.aspx");
        }


        private Boolean ValidateInput()
        {
            Boolean blnOk = true;
            String strMessage = "";

            if (string.IsNullOrWhiteSpace(TextBoxTelephone.Text))
            {
                blnOk = false;
                if (strMessage.Trim().Length > 0)
                {
                    strMessage += ";<br />";
                }
                strMessage += "Telephone is required (10 digits required)";
            }
            else
            {
                if (TextBoxTelephone.Text.Length != 10)
                {
                    blnOk = false;
                    if (strMessage.Trim().Length > 0)
                    {
                        strMessage += ";<br />";
                    }
                    strMessage += "Telephone is required";
                }
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(TextBoxTelephone.Text, "[0-9]"))
            {
                blnOk = false;
                if (strMessage.Trim().Length > 0)
                {
                    strMessage += ";<br />";
                }
                strMessage += "Telephone must be 10 digits";
            }
            if (string.IsNullOrWhiteSpace(TextBoxContact.Text))
            {
                blnOk = false;
                if (strMessage.Trim().Length > 0)
                {
                    strMessage += ";<br />";
                }
                strMessage += "Contact information is required";

            }
            LabelError.Text = strMessage;

            return blnOk;
        }

        protected void buttonNext_Click(object sender, EventArgs e)
        {
            //inserting or updating in DB
            if (ValidateInput())
            {
                InsertServiceEvent(); 
                
                

            }
            
        }
    }
}
