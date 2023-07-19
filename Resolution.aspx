<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resolution.aspx.cs" Inherits="ProjectOneASP.Resolution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 102px;
            left: 338px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 168px;
            left: 159px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 215px;
            left: 156px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 214px;
            left: 260px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 256px;
            left: 144px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 256px;
            left: 262px;
            z-index: 1;
        }
        .auto-style7 {
            position: absolute;
            top: 300px;
            left: 148px;
            z-index: 1;
        }
        .auto-style8 {
            position: absolute;
            top: 295px;
            left: 256px;
            z-index: 1;
        }
        .auto-style9 {
            position: absolute;
            top: 343px;
            left: 151px;
            z-index: 1;
        }
        .auto-style10 {
            position: absolute;
            top: 339px;
            left: 267px;
            z-index: 1;
            width: 343px;
            height: 90px;
        }
        .auto-style11 {
            position: absolute;
            top: 464px;
            left: 144px;
            z-index: 1;
        }
        .auto-style12 {
            position: absolute;
            top: 461px;
            left: 271px;
            z-index: 1;
        }
        .auto-style13 {
            position: absolute;
            top: 510px;
            left: 141px;
            z-index: 1;
        }
        .auto-style14 {
            position: absolute;
            top: 509px;
            left: 270px;
            z-index: 1;
        }
        .auto-style15 {
            position: absolute;
            top: 479px;
            left: 678px;
            z-index: 1;
            right: 169px;
        }
        .auto-style16 {
            position: absolute;
            top: 476px;
            left: 799px;
            z-index: 1;
        }
        .auto-style17 {
            position: absolute;
            top: 561px;
            left: 151px;
            z-index: 1;
        }
        .auto-style18 {
            position: absolute;
            top: 560px;
            left: 269px;
            z-index: 1;
        }
        .auto-style19 {
            position: absolute;
            top: 564px;
            left: 560px;
            z-index: 1;
        }
        .auto-style20 {
            position: absolute;
            top: 564px;
            left: 687px;
            z-index: 1;
        }
        .auto-style21 {
            position: absolute;
            top: 614px;
            left: 272px;
            z-index: 1;
        }
        .auto-style22 {
            position: absolute;
            top: 619px;
            left: 158px;
            z-index: 1;
        }
        .auto-style23 {
            position: absolute;
            top: 610px;
            left: 694px;
            z-index: 1;
        }
        .auto-style24 {
            position: absolute;
            top: 614px;
            left: 554px;
            z-index: 1;
        }
        .auto-style25 {
            position: absolute;
            top: 663px;
            left: 547px;
            z-index: 1;
        }
        .auto-style26 {
            position: absolute;
            top: 672px;
            left: 155px;
            z-index: 1;
        }
        .auto-style27 {
            position: absolute;
            top: 655px;
            left: 685px;
            z-index: 1;
        }
        .auto-style28 {
            position: absolute;
            top: 670px;
            left: 269px;
            z-index: 1;
        }
        .auto-style29 {
            position: absolute;
            top: 742px;
            left: 523px;
            z-index: 1;
        }
        .auto-style30 {
            position: absolute;
            top: 744px;
            left: 313px;
            z-index: 1;
        }
        .auto-style31 {
            position: absolute;
            top: 709px;
            left: 163px;
            z-index: 1;
            color: red; 
            font-size: 12px; 
        }
        .auto-style32 {
            position: absolute;
            top: 701px;
            left: 532px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTechnician" runat="server" CssClass="auto-style11" Text="*Technician: "></asp:Label>
            <asp:Label ID="lblError" runat="server" CssClass="auto-style32" Text="Error"></asp:Label>
            <asp:Label ID="lblRequired" runat="server" CssClass="auto-style31" Text="*indicates a required field"></asp:Label>
            <asp:Button ID="btnSubmit" runat="server" CssClass="auto-style30" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnClear" runat="server" CssClass="auto-style29" Text="Clear" OnClick="btnClear_Click" />
            <asp:TextBox ID="txtSupplies" runat="server" CssClass="auto-style28"></asp:TextBox>
            <asp:Label ID="lblMisc" runat="server" CssClass="auto-style25" Text="Miscellaneous: "></asp:Label>
            <asp:Label ID="lblMRate" runat="server" CssClass="auto-style24" Text="Mileage Rate: "></asp:Label>
            <asp:Label ID="lblRate" runat="server" CssClass="auto-style23" Text="(rate)"></asp:Label>
            <asp:TextBox ID="txtMileage" runat="server" CssClass="auto-style21"></asp:TextBox>
           
            <asp:TextBox ID="txtHours" runat="server" CssClass="auto-style18"></asp:TextBox>
            <asp:TextBox ID="txtFixed" runat="server" CssClass="auto-style14"></asp:TextBox>
            <asp:Label ID="lblFixed" runat="server" CssClass="auto-style13" Text="Date Fixed: "></asp:Label>
            <asp:Label ID="lblProblemNo" runat="server" CssClass="auto-style6" Text="(problem number)"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="auto-style10"></asp:TextBox>
            <asp:Label ID="lblDescription" runat="server" CssClass="auto-style9" Text="*Description:"></asp:Label>
            <asp:Label ID="lblTicket" runat="server" CssClass="auto-style3" Text="Ticket No: "></asp:Label>
            <asp:Label ID="lblProblem" runat="server" CssClass="auto-style5" Text="Problem No: "></asp:Label>
            <asp:Label ID="lblTicketNo" runat="server" CssClass="auto-style4" Text="(ticket number)"></asp:Label>
            <asp:Button ID="buttonReturn" runat="server" CssClass="auto-style2" Text="Return to Main Menu" OnClick="buttonReturn_Click" />
            <asp:Label ID="lblTitlej" runat="server" CssClass="auto-style1" Text="Enter Resolutions"></asp:Label>
            <asp:Label ID="lblResolution" runat="server" CssClass="auto-style7" Text="Resolution: "></asp:Label>
            <asp:Label ID="lblResNum" runat="server" CssClass="auto-style8" Text="(resolution)"></asp:Label>
            <asp:DropDownList ID="DropDownTechnician" runat="server" CssClass="auto-style12" OnSelectedIndexChanged="DropDownTechnician_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:TextBox ID="txtOnsite" runat="server" CssClass="auto-style16"></asp:TextBox>
            <asp:Label ID="lblHours" runat="server" CssClass="auto-style17" Text="*Hours:"></asp:Label>
            <asp:CheckBox ID="CheckBoxCharge" runat="server" CssClass="auto-style20" />
            <asp:Label ID="lblCharge" runat="server" CssClass="auto-style19" Text="No Charge: "></asp:Label>
            <asp:Label ID="lblMileage" runat="server" CssClass="auto-style22" Text="Mileage: "></asp:Label>
            <asp:Label ID="lblSupplies" runat="server" CssClass="auto-style26" Text="Supplies: "></asp:Label>
            <asp:TextBox ID="txtMisc" runat="server" CssClass="auto-style27"></asp:TextBox>
        </div>
        <p>
            
        </p>
        <p>
            &nbsp;</p>
            <asp:Label ID="lblOnsite" runat="server" CssClass="auto-style15" Text="Date Onsite: "></asp:Label>
    </form>
</body>
</html>
