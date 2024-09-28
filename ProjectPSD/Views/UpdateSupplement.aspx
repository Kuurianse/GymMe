<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateSupplement.aspx.cs" Inherits="ProjectPSD.Views.UpdateSupplement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                Update Supplement
            </h1>
        </div>
        <div>
           
                <h1><%=Request.QueryString["suppId"] %></h1>
            
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
            <asp:Button ID="backBtn" runat="server" Text="Back" style="margin-right:10px" OnClick="backBtn_Click" />
            <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click"/>
        </div>

    </form>
</body>
</html>
