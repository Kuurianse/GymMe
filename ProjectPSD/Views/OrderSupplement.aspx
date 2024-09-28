<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBarCustomer.Master" AutoEventWireup="true" CodeBehind="OrderSupplement.aspx.cs" Inherits="ProjectPSD.Views.OrderSupplement1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Order Supplement</h1>
    </div>
    <div>
        <asp:GridView ID="orderSupplementGV" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="orderSupplementGV_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="SupplementID" SortExpression="SupplementID" />
                <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="MsSupplementType.SupplementTypeName" HeaderText="Type Name" SortExpression="MsSupplementType.SupplementTypeName" />
            
                <asp:TemplateField HeaderText="Quantity"> 
                    <ItemTemplate >
                        <asp:TextBox ID="quantityTB" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField> 

                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Order" />

            </Columns>
        </asp:GridView>
    </div>
    <div style="height: 2em;"></div>
    <div>
        <asp:Label ID="msgLbl" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="clearBtn" runat="server" Text="Clear Cart" OnClick="clearBtn_Click" style="margin-right:10px"/>
        <asp:Button ID="checkOutBtn" runat="server" Text="Checkout" OnClick="checkOutBtn_Click" />
        <div id="messages"></div> 
    </div>
    <div style="height: 2em;"></div>
    <div>
        <asp:GridView ID="cartGV" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="CartID" HeaderText="Cart ID" SortExpression="CartID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="SupplementID" HeaderText="Supplement ID" SortExpression="SupplementID" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
