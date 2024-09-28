<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBarCustomer.Master" AutoEventWireup="true" CodeBehind="HomeUser.aspx.cs" Inherits="ProjectPSD.Views.HomeUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>
        This is Home User
    </h1>

    <div>
        <asp:Label ID="userLbl" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="idLbl" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="userOnlineLbl" runat="server" Text="0 User(s) Online."></asp:Label>
    </div>

</asp:Content>
