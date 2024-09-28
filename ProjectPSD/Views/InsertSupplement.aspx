<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertSupplement.aspx.cs" Inherits="ProjectPSD.Views.InsertSupplement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                Insert Supplement
            </h1>
        </div>
        <div>
            <asp:Label ID="suppNameLbl" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="suppNameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="suppExpiryDateLbl" runat="server" Text="Expiry Date"></asp:Label>
            <asp:Calendar ID="expiryDateCalendar" runat="server"></asp:Calendar>
        </div>
        <div>
            <asp:Label ID="suppPriceLbl" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="suppPriceTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="suppTypeIDLbl" runat="server" Text="Type ID"></asp:Label>
            <asp:DropDownList ID="suppTypeDropDown" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Msg" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="backBtn" runat="server" Text="Back" style="margin-right:10px" OnClick="backBtn_Click"/>
            <asp:Button ID="insertBtn" runat="server" Text="Insert" OnClick="insertBtn_Click" />
        </div>
    </form>
</body>
</html>
