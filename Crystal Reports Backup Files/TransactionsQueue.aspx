<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="TransactionsQueue.aspx.cs" Inherits="ProjectPSD.Views.TransactionsQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>
        Transaction Queue
    </h1>

    <div>
        <asp:GridView ID="TransactionHeaderGV" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="TransactionHeaderGV_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Handle" />
            </Columns>
        </asp:GridView>
    </div>
    
    <div style="height: 2em;"></div>
    <div>
        <asp:Label ID="msgLbl" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
