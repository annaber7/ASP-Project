using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProjectOneASP
{
    public partial class Technician : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTechnicianList();
                buttonAccept.Enabled = false;
                buttonCancel.Enabled = false;
                buttonClear.Enabled = false;
                buttonRemove.Enabled = false;
            }

        }

        private void LoadTechnicianList()
        {
            DataSet dsData;
            dsData = clsDatabase.GetTechnicianList();
            if (dsData == null)
            {
                labelError.Text = "Error retrieving technician list";
                dropDownTechnician.Items.Clear();
                dropDownTechnician.Items.Add(new ListItem("TECHNICIAN", "0"));
                dropDownTechnician.AppendDataBoundItems = true;
                dropDownTechnician.DataSource = dsData.Tables[0];
                dropDownTechnician.DataTextField = "TechName";
                dropDownTechnician.DataValueField = "TechnicianID";
                dropDownTechnician.DataBind();

                dsData.Dispose();

            }
            else if (dsData.Tables.Count < 1)
            {
                labelError.Text = "Error retrieving technician list";
                dsData = null;
            }
            else if (dsData.Tables[0].Rows.Count < 1)
            {
                labelError.Text = "Error retrieving product list";
                dsData = null;
            }
            else
            {
                dropDownTechnician.Items.Clear();
                dropDownTechnician.Items.Add(new ListItem("--TECHNICIAN--", "0"));
                dropDownTechnician.AppendDataBoundItems = true;

                dropDownTechnician.DataSource = dsData.Tables[0];
                dropDownTechnician.DataTextField = "TechName";
                dropDownTechnician.DataValueField = "TechnicianID";
                dropDownTechnician.DataBind();

                dsData.Dispose();
            }
        }

        private void DisplayTechnician(int intTechID)
        {
            DataSet dsData;
            labelError.Text = "";
            ClearDataFields();
            if (dropDownTechnician.SelectedIndex == 0)
            {
                ClearDataFields();
            }
            else
            {


                dsData = clsDatabase.GetTechnicianByID(intTechID);
                if (dsData == null)
                {
                    labelError.Text = "Error retrieving technician list";

                }
                else if (dsData.Tables.Count < 1)
                {
                    labelError.Text = "Error retrieving technician list";
                    dsData = null;
                }
                else if (dsData.Tables[0].Rows.Count < 1)
                {
                    labelError.Text = "Error retrieving technician list";
                    dsData = null;
                }
                else
                {
                    //FirstName
                    if (dsData.Tables[0].Rows[0]["FName"] == DBNull.Value)
                    {
                        textBoxFirst.Text = "";
                    }
                    else
                    {
                        textBoxFirst.Text = dsData.Tables[0].Rows[0]["FName"].ToString();
                    }
                    //LastName
                    if (dsData.Tables[0].Rows[0]["LName"] == DBNull.Value)
                    {
                        textBoxLast.Text = "";
                    }
                    else
                    {
                        textBoxLast.Text = dsData.Tables[0].Rows[0]["LName"].ToString();
                    }
                    //M Init
                    if (dsData.Tables[0].Rows[0]["MInit"] == DBNull.Value)
                    {
                        textBoxMiddle.Text = "";
                    }
                    else
                    {
                        textBoxMiddle.Text = dsData.Tables[0].Rows[0]["MInit"].ToString();
                    }
                    //Email
                    if (dsData.Tables[0].Rows[0]["EMail"] == DBNull.Value)
                    {
                        TextBoxEmail.Text = "";
                    }
                    else
                    {
                        TextBoxEmail.Text = dsData.Tables[0].Rows[0]["EMail"].ToString();
                    }
                    //Department
                    if (dsData.Tables[0].Rows[0]["Dept"] == DBNull.Value)
                    {
                        TextBoxDepartment.Text = "";
                    }
                    else
                    {
                        TextBoxDepartment.Text = dsData.Tables[0].Rows[0]["Dept"].ToString();
                    }
                    //Phone
                    if (dsData.Tables[0].Rows[0]["Phone"] == DBNull.Value)
                    {
                        TextBoxTelephone.Text = "";
                    }
                    else
                    {
                        TextBoxTelephone.Text = dsData.Tables[0].Rows[0]["Phone"].ToString();
                    }
                    //HRate
                    if (dsData.Tables[0].Rows[0]["HRate"] == DBNull.Value)
                    {
                        TextBoxRate.Text = "";
                    }
                    else
                    {
                        TextBoxRate.Text = dsData.Tables[0].Rows[0]["HRate"].ToString();
                    }
                }
            }
        }private void ClearDataFields()
        {
            textBoxFirst.Text = "";
            textBoxLast.Text = "";
            TextBoxEmail.Text = "";
            TextBoxDepartment.Text = "";
            TextBoxEmail.Text = "";
            TextBoxRate.Text = "";
            TextBoxTelephone.Text = "";
            textBoxMiddle.Text = "";

        }

        protected void buttonReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Menu.aspx");
        }

        //Clear Data Fields
        

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
            if (string.IsNullOrWhiteSpace(textBoxFirst.Text))
            {
                blnOk = false;
                if (strMessage.Trim().Length > 0)
                {
                    strMessage += ";<br />";
                }
                strMessage += "First name is required";

            }
            if (string.IsNullOrWhiteSpace(textBoxLast.Text))
            {
                blnOk = false;
                if (strMessage.Trim().Length > 0)
                {
                    strMessage += ";<br />";
                }
                strMessage += "Last name is required";

            }
            if (!string.IsNullOrWhiteSpace(textBoxMiddle.Text))
            {
                if (textBoxMiddle.Text.Length != 1)
                {
                    blnOk = false;

                    if (strMessage.Trim().Length > 0)
                    {
                        strMessage += ";<br />";
                    }
                    strMessage += "Middle Initial must be one character";
                }

            }
            if (!decimal.TryParse(TextBoxRate.Text, out decimal result))
            {
                blnOk = false;
                if (strMessage.Trim().Length > 0)
                {
                    strMessage += ";<br />";
                }
                strMessage += "Hourly rate is required, must be numeric";
            }

            labelError.Text = strMessage;

            return blnOk;
        }

        //SelectedIndexChanged Event Handler
        protected void dropDownTechnician_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTechnician(Convert.ToInt32(dropDownTechnician.SelectedValue));
            buttonAccept.Enabled = true;
            buttonCancel.Enabled = true;
            buttonClear.Enabled = true;
            buttonRemove.Enabled = true;
            buttonTechnician.Enabled = false;
            buttonRemove.Enabled = true;
        }

        protected void TextBoxFirst_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBoxDepartment_TextChanged(object sender, EventArgs e)
        {

        }

        protected void buttonClear_Click(object sender, EventArgs e)
        {
            //Reset Dropdown to index zero
            //dropDownTechnician.Items.Add(new ListItem("--TECHNICIAN--", "0"));
            LoadTechnicianList();
            ClearDataFields();
            buttonAccept.Enabled = false;
            buttonCancel.Enabled = false;
            buttonRemove.Enabled = false;
            buttonClear.Enabled = false;
            buttonTechnician.Enabled = true;
            //other buttons disabled
        }

        protected void buttonRemove_Click(object sender, EventArgs e)
        {
            DeleteTechnician();
        }

        protected void buttonAccept_Click(object sender, EventArgs e)
        {
            //inserting or updating in DB
            if (ValidateInput())
            {
                //Check for Insert or Update
                if (dropDownTechnician.SelectedIndex == 0)
                {
                    InsertTechnician();
                }
                else
                {
                    UpdateTech();
                }
            }
        }

        private void DeleteTechnician()
        {
            int intRetVal;
            string strTechID;
            labelError.Text = "";

            intRetVal = clsDatabase.DeleteTechnician(Convert.ToInt32(dropDownTechnician.SelectedValue));
            if (intRetVal == 0)
            {
                labelError.Text = "Technician Deleted";
                Session.Contents["TechnicianID"] = textBoxFirst.Text;
            }
            else
            {
                labelError.Text = "Error deleting Technician";
            }

        }
        private void InsertTechnician()
        {
            int intRetVal;
            string strTechID;
            labelError.Text = "";

            intRetVal = clsDatabase.InsertTechnician(textBoxFirst.Text, textBoxLast.Text, textBoxMiddle.Text, TextBoxEmail.Text, TextBoxDepartment.Text, TextBoxTelephone.Text, TextBoxRate.Text);
            if (intRetVal == 0)
            {
                labelError.Text = "Technician Inserted";
                Session.Contents["TechnicianID"] = textBoxFirst.Text;
                LoadTechnicianList();

            }
            else
            {
                labelError.Text = "Error inserting Technician";
            }

        }
        private void UpdateTech()
        {
            int intRetVal;
            string strTechID;
            labelError.Text = "";

            intRetVal = clsDatabase.UpdateTechnician(Convert.ToInt32(dropDownTechnician.SelectedValue), textBoxFirst.Text, textBoxLast.Text, textBoxMiddle.Text, TextBoxEmail.Text, TextBoxDepartment.Text, TextBoxTelephone.Text, TextBoxRate.Text);
            if (intRetVal == 0)
            {
                labelError.Text = "Technician Updated";
                Session.Contents["TechnicianID"] = textBoxFirst.Text;
                LoadTechnicianList();
            }
            else
            {
                labelError.Text = "Error updating Technician";
            }
        }

        protected void buttonTechnician_Click(object sender, EventArgs e)
        {
            dropDownTechnician.Items[0].Attributes["disabled"] = "disabled";
            buttonRemove.Enabled = false;
            buttonAccept.Enabled = true;
            buttonCancel.Enabled = true;
            buttonClear.Enabled = true;
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            DisplayTechnician(Convert.ToInt32(dropDownTechnician.SelectedValue));
        }
    }
}