<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ProjectOneASP.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet2.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Costs by Institution"></asp:Label>
    <br />
    <asp:Button ID="ButtonPageTwo" runat="server" Text="Back" OnClick="ButtonPageTwo_Click" />
    <br />
    <asp:GridView ID="GridViewInstitution" AutoGenerateColumns ="false" runat="server">
        <Columns>
                    
                    <asp:BoundField DataField="NumberOfProblems" HeaderText ="Number of Problems" SortExpression="NumberOfProblems" />
                    <asp:BoundField DataField="Institution" HeaderText="Institution" SortExpression="Institution" />
                    <asp:BoundField DataField="TotalExpense" HeaderText="Total Expense" SortExpression="TotalExpense" />
                    <asp:BoundField DataField="AverageExpense" HeaderText="Average Expense" SortExpression="AverageExpense" />
                     


                </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

</asp:Content>
