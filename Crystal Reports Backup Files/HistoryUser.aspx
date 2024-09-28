<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBarCustomer.Master" AutoEventWireup="true" CodeBehind="HistoryUser.aspx.cs" Inherits="ProjectPSD.Views.HistoryUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        History User
    </h1>

    <div>
        <asp:GridView ID="TransactionHeaderGV" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="TransactionHeaderGV_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Detail" />
            </Columns>
        </asp:GridView>
    </div>
    
</asp:Content>
