using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProjectOneASP
{
    public partial class Problem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProduct();
                LoadTechnician();
                lblPNo.Text = "1";
                if (Session.Contents["NewTicketID"] != null)
                {

                    lblTNo.Text = Session.Contents["NewTicketID"].ToString();
                }

            }
        }
        private void LoadProduct()
        {
            DataSet dsData;
            lblError.Text = "";
            dsData = clsDatabase.GetProductList();
            if (dsData == null)
            {
                lblError.Text = "Error retrieving Product";

            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Product";
                dsData.Dispose();
            }
            else if (dsData.Tables[0].Rows.Count < 1)
            {
                lblError.Text = "Error retrieving Product";
                dsData.Dispose();
            }
            else
            {

                DropDownProduct.Items.Clear();
                DropDownProduct.Items.Add(new ListItem("--Select Product--", "0"));
                DropDownProduct.AppendDataBoundItems = true;

                DropDownProduct.DataSource = dsData.Tables[0];
                DropDownProduct.DataTextField = "ProductID";
                DropDownProduct.DataValueField = "ProductID";
                DropDownProduct.DataBind();

                dsData.Dispose();

            }

        }
        private Boolean ValidateFields()
        {
            Boolean blnOk = true;
            string strMessage = "";
            lblError.Text = "";

            if (String.IsNullOrWhiteSpace(txtDescription.Text))
            {
                blnOk = false;
                strMessage = "Description must be filled out";
            }
            if (DropDownProduct.SelectedIndex == 0)
            {
                blnOk = false;
                strMessage = "Product must be selected";
            }
            if (DropDownTechnician.SelectedIndex == 0)
            {
                blnOk = false;
                strMessage = "Technician must be selected";
            }
            lblError.Text = strMessage;
            return blnOk;
        }
        private void ClearDataFields()
        {
            txtDescription.Text = "";
            DropDownProduct.SelectedIndex = 0;
            DropDownTechnician.SelectedIndex = 0;


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (ValidateFields())
            {
                InsertProblem();
                ClearDataFields();

                // increment problem number
            }
            else
            {
                lblError.Text = "Error inserting problem";
            }


        }
        private void InsertProblem()
        {
            int intRetValue;
            lblError.Text = "";

            if (Session.Contents["TicketID"] != null && Session.Contents["ProblemNo"] != null)
            {
                lblTNo.Text = Session.Contents["TicketID"].ToString();
                lblPNo.Text = Session.Contents["ProblemNo"].ToString();
            }

            Session.Contents["ProblemNo"] = lblPNo.Text;

            intRetValue = clsDatabase.InsertProblem(Convert.ToInt32(lblTNo.Text), Convert.ToInt32(lblPNo.Text), txtDescription.Text, Convert.ToInt32(DropDownTechnician.SelectedValue), DropDownProduct.SelectedValue);
            if (intRetValue == 0)
            {
                lblError.Text = "New problem inserted";
                lblPNo.Text = (Convert.ToInt32(lblPNo.Text) + 1).ToString();


            }
            else
            {
                lblError.Text = "Error inserting problem";
            }
        }
        private void LoadTechnician()
        {
            DataSet dsData;
            dsData = clsDatabase.GetTechnicianList();
            if (dsData == null)
            {
                lblError.Text = "Error retrieving client";


            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving technicians";
                dsData = null;
            }
            else
            {
                DropDownTechnician.Items.Clear();
                DropDownTechnician.Items.Add(new ListItem("--Select Technician--", "0"));
                DropDownTechnician.AppendDataBoundItems = true;

                DropDownTechnician.DataSource = dsData.Tables[0];
                DropDownTechnician.DataTextField = "TechName";
                DropDownTechnician.DataValueField = "TechnicianID";
                DropDownTechnician.DataBind();

                dsData.Dispose();
            }




        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            LoadProduct();


            txtDescription.Text = "";
            LoadTechnician();




        }

        protected void DropDownProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LoadProduct();
        }

        protected void DropDownTechnician_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LoadTechnician();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Menu.aspx");
        }
    }
}
