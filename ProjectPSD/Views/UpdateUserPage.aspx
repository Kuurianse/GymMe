<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUserPage.aspx.cs" Inherits="ProjectPSD.Views.UpdateUserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%-- ctrl A K F--%>
        <h1>
            <asp:Label ID="updateLbl" runat="server" Text="UPDATE"></asp:Label>
        </h1>
        <h1><%=Request.QueryString["userId"] %></h1>
        <div>
            <asp:Label ID="usernamelbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="usernameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="useremaillbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="useremailTB" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="passwordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="passwordTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="confirmpasswordLbl" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="confirmTB" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="doblbl" runat="server" Text="Date of Birth"></asp:Label>
            <asp:Calendar ID="dobCalendar" runat="server"></asp:Calendar>
        </div>

        <div>
            <asp:Label ID="Msg" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />
        </div>
    </form>
</body>
</html>
