<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBarCustomer.Master" AutoEventWireup="true" CodeBehind="DetailTransaction.aspx.cs" Inherits="ProjectPSD.Views.DetailTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>
        Detail Transaction
    </h1>

    <div>
        <asp:GridView ID="TransactionDetailGV" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="MsSupplement.SupplementName" HeaderText="Supplement Name" SortExpression="MsSupplement.SupplementName" />
                <asp:BoundField DataField="MsSupplement.MsSupplementType.SupplementTypeName" HeaderText="Type" SortExpression="TransactionDetail.MsSupplement.MsSupplementType.SupplementTypeName" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            </Columns>
        </asp:GridView>
    </div>
    
    <div style="height: 2em;"></div>
    <div>
        <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="backBtn_Click"/>
    </div>

</asp:Content>
