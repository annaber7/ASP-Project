<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProjectOneASP.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet11.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ButtonDiv">
        <asp:Label ID="Label1" runat="server" Text="Report Selection"></asp:Label>
        <br />
        <asp:Button ID="ButtonReturn" runat="server" Text="Return to Main Menu" OnClick="ButtonReturn_Click" />
        <br />
        <asp:Button ID="ButtonClient" runat="server" Text="Costs by Client" OnClick="ButtonClient_Click" />
        <br />
        <asp:Button ID="ButtonInstitution" runat="server" Text="Costs by Institution" OnClick="ButtonInstitution_Click" />
        <br />
        <asp:Button ID="ButtonProduct" runat="server" Text="Costs by Product" />
        <br />
        <asp:Button ID="ButtonTechnician" runat="server" Text="Costs by Technician" />
    </div>
</asp:Content>
