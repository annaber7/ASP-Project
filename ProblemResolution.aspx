<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProblemResolution.aspx.cs" Inherits="ProjectOneASP.ProblemResolution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 187px;
            left: 277px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 128px;
            left: 575px;
            z-index: 1;
        }
        .auto-style3 {
            width: 719px;
            height: 152px;
            position: absolute;
            top: 251px;
            left: 227px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 432px;
            left: 252px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnReturn" runat="server" CssClass="auto-style1" Text="Return to Main Menu" OnClick="btnReturn_Click" />
            <asp:Label ID="lblOpenProblem" runat="server" CssClass="auto-style2" Text="Open Problem"></asp:Label>

            
            <asp:GridView ID="GridViewProblems" runat="server" CssClass="auto-style3" OnRowCommand="GridView1_RowCommand" AllowPaging="true" AutoGenerateColumns ="false" AllowSorting="true" OnPageIndexChanging="GridViewProblems_PageIndexChanging" OnSorting="GridViewProblems_Sorting" PageSize="2" OnSelectedIndexChanged="GridViewProblems_SelectedIndexChanged">

                <Columns>
                    <asp:ButtonField CommandName="SELECT" Text="Select" />
                    <asp:BoundField DataField="TicketID" HeaderText ="Ticket ID" SortExpression="TicketID" />
                    <asp:BoundField DataField="IncidentNo" HeaderText="Incident Number" SortExpression="IncidentNo" />
                    <asp:BoundField DataField="ProblemDesc" HeaderText="Problem Description" SortExpression="ProblemDesc" />
                    <asp:BoundField DataField="EventDate" HeaderText="Event Date" SortExpression="EventDate" />
                    <asp:BoundField DataField="Institution" HeaderText="Institution" SortExpression="Institution" /> 


                </Columns>
                <PagerSettings Mode="NextPreviousFirstLast" />
                

            </asp:GridView>

            
            <asp:Label ID="lblError" runat="server" CssClass="auto-style4" Text="error"></asp:Label>

            
        </div>
    </form>
</body>
</html>
