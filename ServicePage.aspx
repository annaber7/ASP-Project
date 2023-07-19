<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServicePage.aspx.cs" Inherits="ProjectOneASP.ServicePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 89px;
            left: 417px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 170px;
            left: 493px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 246px;
            left: 358px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 241px;
            left: 489px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 302px;
            left: 363px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 294px;
            left: 468px;
            z-index: 1;
        }
        .auto-style7 {
            position: absolute;
            top: 350px;
            left: 370px;
            z-index: 1;
        }
        .auto-style8 {
            position: absolute;
            top: 342px;
            left: 465px;
            z-index: 1;
        }
        .auto-style9 {
            position: absolute;
            top: 402px;
            left: 363px;
            z-index: 1;
        }
        .auto-style10 {
            position: absolute;
            top: 394px;
            left: 484px;
            z-index: 1;
        }
        .auto-style11 {
            position: absolute;
            top: 493px;
            left: 434px;
            z-index: 1;
        }
        .auto-style12 {
            position: absolute;
            top: 486px;
            left: 856px;
            z-index: 1;
        }
        .auto-style13 {
            position: absolute;
            top: 447px;
            left: 351px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="buttonClear" runat="server" CssClass="auto-style12" Text="Clear" />
            <asp:Label ID="labelTelephone" runat="server" CssClass="auto-style9" Text="*Telephone:"></asp:Label>
            <asp:Label ID="labelService" runat="server" CssClass="auto-style1" Font-size="XX-Large" Text="Service Event"></asp:Label>
            <asp:Button ID="buttonReturn" runat="server" CssClass="auto-style2" Text="Return to Main Menu" OnClick="buttonReturn_Click" />
            <asp:Label ID="labelEventDate" runat="server" CssClass="auto-style3" Text="Event Date:"></asp:Label>
            <asp:Label ID="labelDate" runat="server" CssClass="auto-style4" Text="(datetime)"></asp:Label>
            <asp:Label ID="labelClient" runat="server" CssClass="auto-style5" Text="*Client:"></asp:Label>
            <asp:DropDownList ID="DropDownClient" runat="server" CssClass="auto-style6" >
            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style7" Text="*Contact:"></asp:Label>
            <asp:TextBox ID="TextBoxContact" runat="server" CssClass="auto-style8"></asp:TextBox>
            <asp:TextBox ID="TextBoxTelephone" runat="server" CssClass="auto-style10"></asp:TextBox>
            <asp:Button ID="buttonNext" runat="server" CssClass="auto-style11" Text="Next" OnClick="buttonNext_Click" />
            <asp:Label ID="LabelError" runat="server" CssClass="auto-style13" Text="Error"></asp:Label>
        </div>
            
    </form>
</body>
</html>
