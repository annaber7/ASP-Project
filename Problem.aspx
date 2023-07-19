<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Problem.aspx.cs" Inherits="ProjectOneASP.Problem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 192px;
            left: 228px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 109px;
            left: 104px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 187px;
            left: 351px;
            z-index: 1;
            bottom: 459px;
        }
        .auto-style4 {
            position: absolute;
            top: 58px;
            left: 357px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 232px;
            left: 359px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 233px;
            left: 225px;
            z-index: 1;
        }
        .auto-style7 {
            position: absolute;
            top: 280px;
            left: 379px;
            z-index: 1;
        }
        .auto-style8 {
            position: absolute;
            top: 282px;
            left: 237px;
            z-index: 1;
        }
        .auto-style9 {
            position: absolute;
            top: 337px;
            left: 233px;
            z-index: 1;
            height: 15px;
            right: 611px;
        }
        .auto-style10 {
            position: absolute;
            top: 334px;
            left: 372px;
            z-index: 1;
            width: 407px;
            height: 155px;
        }
        .auto-style11 {
            position: absolute;
            top: 519px;
            left: 378px;
            z-index: 1;
        }
        .auto-style12 {
            position: absolute;
            top: 523px;
            left: 244px;
            z-index: 1;
        }
        .auto-style13 {
            position: absolute;
            top: 564px;
            left: 229px;
            z-index: 1;
        }
        .auto-style14 {
            position: absolute;
            top: 612px;
            left: 459px;
            z-index: 1;
        }
        .auto-style15 {
            position: absolute;
            top: 612px;
            left: 273px;
            z-index: 1;
        }
        .auto-style16 {
            position: absolute;
            top: 526px;
            left: 611px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnReturn" runat="server" CssClass="auto-style2" Text="Return to Main Menu" OnClick="btnReturn_Click" />
            <asp:Label ID="lblError" runat="server" CssClass="auto-style16" Text="Label"></asp:Label>
            <asp:DropDownList ID="DropDownTechnician" runat="server" CssClass="auto-style11" OnSelectedIndexChanged="DropDownTechnician_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Label ID="lblTechnician" runat="server" CssClass="auto-style12" Text="*Technician: "></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="auto-style10"></asp:TextBox>
            <asp:DropDownList ID="DropDownProduct" runat="server" CssClass="auto-style7" OnSelectedIndexChanged="DropDownProduct_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Label ID="lblProblemNo" runat="server" CssClass="auto-style6" Text="Problem No: "></asp:Label>
            <asp:Label ID="lblProduct" runat="server" CssClass="auto-style8" Text="*Product: "></asp:Label>
            <asp:Label ID="lblEnterProblem" runat="server" CssClass="auto-style4" Text="Enter Problems"></asp:Label>
            <asp:Label ID="lblTicketNo" runat="server" CssClass="auto-style1" Text="Ticket No: "></asp:Label>
            <asp:Label ID="lblTNo" runat="server" CssClass="auto-style3" Text="(ticket number)"></asp:Label>
            <asp:Label ID="lblPNo" runat="server" CssClass="auto-style5" Text="(problem number)"></asp:Label>
            <asp:Label ID="lblDescription" runat="server" CssClass="auto-style9" Text="*Description"></asp:Label>
            <asp:Label ID="lblRequired" runat="server" CssClass="auto-style13" Text="* indicates a required field"></asp:Label>
            <asp:Button ID="btnSubmit" runat="server" CssClass="auto-style15" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnClear" runat="server" CssClass="auto-style14" Text="Clear" OnClick="btnClear_Click" />
        </div>
            
    </form>
</body>
</html>
