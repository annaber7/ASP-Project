<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Technician.aspx.cs" Inherits="ProjectOneASP.Technician" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 105px;
            left: 422px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 181px;
            left: 334px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 246px;
            left: 342px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 244px;
            left: 469px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 236px;
            left: 697px;
            width:150px;
            z-index: 1;
            right: 812px;
        }
        .auto-style6 {
            position: absolute;
            top: 289px;
            left: 342px;
            z-index: 1;
        }
        .auto-style7 {
            position: absolute;
            top: 288px;
            left: 463px;
            z-index: 1;
        }
        .auto-style8 {
            position: absolute;
            top: 345px;
            left: 341px;
            z-index: 1;
        }
        .auto-style9 {
            position: absolute;
            top: 343px;
            left: 466px;
            z-index: 1;
        }
        .auto-style10 {
            position: absolute;
            top: 401px;
            left: 342px;
            z-index: 1;
        }
        .auto-style11 {
            position: absolute;
            top: 395px;
            left: 464px;
            z-index: 1;
        }
        .auto-style12 {
            position: absolute;
            top: 445px;
            left: 348px;
            z-index: 1;
        }
        .auto-style14 {
            position: absolute;
            top: 483px;
            left: 349px;
            z-index: 1;
        }
        .auto-style15 {
            position: absolute;
            top: 476px;
            left: 469px;
            z-index: 1;
        }
        .auto-style16 {
            position: absolute;
            top: 521px;
            left: 349px;
            z-index: 1;
        }
        .auto-style17 {
            position: absolute;
            top: 514px;
            left: 458px;
            z-index: 1;
        }
        .auto-style18 {
            position: absolute;
            top: 567px;
            left: 349px;
            z-index: 1;
        }
        .auto-style19 {
            position: absolute;
            top: 564px;
            left: 473px;
            z-index: 1;
        }
        .auto-style20 {
            position: absolute;
            top: 435px;
            left: 464px;
            z-index: 1;
        }
        .auto-style21 {
            position: absolute;
            top: 622px;
            left: 581px;
            z-index: 1;
        }
        .auto-style22 {
            position: absolute;
            top: 621px;
            left: 935px;
            z-index: 1;
        }
        .auto-style23 {
            position: absolute;
            top: 619px;
            left: 1206px;
            z-index: 1;
        }
        .auto-style24 {
            position: absolute;
            top: 632px;
            left: 214px;
            z-index: 1;
        }
        .auto-style25 {
            position: absolute;
            top: 698px;
            left: 270px;
            z-index: 1;
            color:red;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="labelError" runat="server" CssClass="auto-style25" Text="(error message)"></asp:Label>
            <asp:Button ID="buttonCancel" runat="server" CssClass="auto-style21" Text="Cancel" OnClick="buttonCancel_Click" />
            <asp:Button ID="buttonRemove" runat="server" CssClass="auto-style22" Text="Remove" OnClick="buttonRemove_Click" />
            <asp:TextBox ID="TextBoxRate" runat="server" CssClass="auto-style19"></asp:TextBox>
            <asp:TextBox ID="TextBoxTelephone" runat="server" CssClass="auto-style17"></asp:TextBox>
            <asp:Label ID="labelTelephone" runat="server" CssClass="auto-style16" Text="*Telephone: "></asp:Label>
            <asp:TextBox ID="TextBoxDepartment" runat="server" CssClass="auto-style15" OnTextChanged="TextBoxDepartment_TextChanged"></asp:TextBox>
            <asp:Label ID="labelDepartment" runat="server" CssClass="auto-style14" Text="Department:"></asp:Label>
            <asp:TextBox ID="textBoxLast" runat="server" CssClass="auto-style11"></asp:TextBox>
            <asp:TextBox ID="textBoxFirst" runat="server" CssClass="auto-style7" OnTextChanged="TextBoxFirst_TextChanged"></asp:TextBox>
            <asp:Label ID="labelTechnician" runat="server" CssClass="auto-style3" Text="Technician:"></asp:Label>
            <asp:Button ID="buttonReturn" runat="server" CssClass="auto-style2" Text="Return to Main Menu" OnClick="buttonReturn_Click" />
            <asp:Label ID="labelTechnicianMain" runat="server" CssClass="auto-style1" Font-size="XX-Large" Text="Technician Main"></asp:Label>
            <asp:Button ID="buttonTechnician" runat="server" CssClass="auto-style5" Text="New Technician" OnClick="buttonTechnician_Click" />
            <asp:DropDownList ID="dropDownTechnician" runat="server" CssClass="auto-style4" AutoPostBack="True" OnSelectedIndexChanged="dropDownTechnician_SelectedIndexChanged" style="height: 25px">
        </asp:DropDownList>
            <asp:Label ID="labelFirst" runat="server" CssClass="auto-style6" Text="*First Name:"></asp:Label>
            <asp:Label ID="labelMiddle" runat="server" CssClass="auto-style8" Text="Middle Name: "></asp:Label>
            <asp:TextBox ID="textBoxMiddle" runat="server" CssClass="auto-style9"></asp:TextBox>
            <asp:Label ID="labelLast" runat="server" CssClass="auto-style10" Text="*Last Name:"></asp:Label>
            <asp:Label ID="labelEmail" runat="server" CssClass="auto-style12" Text="EMail"></asp:Label>
            <asp:Label ID="labelRate" runat="server" CssClass="auto-style18" Text="*Hourly Rate:"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="auto-style20"></asp:TextBox>
            <asp:Button ID="buttonClear" runat="server" CssClass="auto-style23" Text="Clear" OnClick="buttonClear_Click" />
            <asp:Button ID="buttonAccept" runat="server" CssClass="auto-style24" Text="Accept" OnClick="buttonAccept_Click" />
        </div>
        
    </form>
</body>
</html>
