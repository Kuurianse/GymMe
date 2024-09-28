<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="ProjectPSD.Views.HomeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>
        This is Home Admin
    </h1>

        <div>
            <asp:Label ID="userLbl" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="idLbl" runat="server" Text=""></asp:Label>
        </div>

        <div id="ListUserContainer" runat="server">
            <h1>List Users</h1>
            <asp:ListBox ID="listUserLB" runat="server" Height="300px"></asp:ListBox>
        </div>

</asp:Content>
