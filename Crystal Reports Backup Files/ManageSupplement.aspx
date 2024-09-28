<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="ManageSupplement.aspx.cs" Inherits="ProjectPSD.Views.ManageSupplement1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1>
            Manage Supplement
        </h1>
    </div>
    <div>
        <asp:GridView ID="manageSupplementGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="manageSupplementGV_RowDeleting" OnRowEditing="manageSupplementGV_RowEditing" OnSelectedIndexChanged="manageSupplementGV_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="SupplementID" SortExpression="SupplementID" />
                <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="SupplementTypeID" HeaderText="Type ID" SortExpression="SupplementTypeID" />
                <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>
    <div style="height: 2em;"></div>
    <div>
        <asp:Button ID="insertBtn" runat="server" Text="Insert Supplement" OnClick="insertBtn_Click" />
    </div>

</asp:Content>
