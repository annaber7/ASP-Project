<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ProjectOneASP.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Menu</title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 120px;
            left: 456px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 217px;
            left: 473px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 282px;
            left: 442px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 348px;
            left: 507px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 421px;
            left: 481px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="buttonReports" runat="server" CssClass="auto-style4" Text="Reports" OnClick="buttonReports_Click1" />

            <asp:Label ID="labelTitle" runat="server" CssClass="auto-style1" Font-size="XX-Large" Text="Main Menu"></asp:Label>

            <asp:Button ID="buttonService" runat="server" CssClass="auto-style2" Text="Service Event" OnClick="buttonService_Click" />

            <asp:Button ID="buttonProblem" runat="server" CssClass="auto-style3" Text="Problem Resolution" OnClick="buttonProblem_Click" />
            <asp:Button ID="buttonTechnicians" runat="server" CssClass="auto-style5" Text="Technicians" OnClick="buttonTechnicians_Click" />

        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
