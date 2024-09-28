<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="ProfileAdmin.aspx.cs" Inherits="ProjectPSD.Views.ProfileAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
        <%-- ctrl A K F--%>
        <h1>
            <asp:Label ID="updateLbl" runat="server" Text="Update Profile"></asp:Label>
        </h1>
        <div>
            <asp:DetailsView ID="DetailsViewProfile" runat="server" Height="50px" Width="125px" AutoGenerateRows="False">
                <Fields>
                    <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="UserName" />
                    <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                    <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
                    <asp:BoundField DataField="UserDOB" HeaderText="Date of Birth" SortExpression="UserDOB" DataFormatString="{0:d MMMM yyyy}" />

                </Fields>
            </asp:DetailsView>
        </div>

        <div style="height: 2em;"></div>

        <div>
            <asp:Label ID="usernamelbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="usernameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="useremaillbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="useremailTB" runat="server"></asp:TextBox>
        </div>
        <div style="height: 2em;"></div>
        <div>
            <asp:Label ID="genderLbl" runat="server" Text="Gender"></asp:Label>
        </div>
        <div>
            <asp:RadioButtonList ID="radioGender" runat="server">
                <asp:ListItem Value="M">Male</asp:ListItem>
                <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div style="height: 1em;"></div>
        <div>
            <asp:Label ID="doblbl" runat="server" Text="Date of Birth"></asp:Label>
            <asp:Calendar ID="dobCalendar" runat="server"></asp:Calendar>
        </div>

        <div>
            <asp:Label ID="Msg" runat="server" Text=""></asp:Label>
        </div>
        <div style="height: 2em;"></div>
        <div>
            <asp:Button ID="updateProfileBtn" runat="server" Text="Update Profile" OnClick="updateBtn_Click" />
        </div>

        <h1>
            <asp:Label ID="passLbl" runat="server" Text="Update Password"></asp:Label>
        </h1>
        <div>
            <asp:Label ID="oldPassLbl" runat="server" Text="Old Password"></asp:Label>
            <asp:TextBox ID="oldPassTB" runat="server" placeholder="old password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="newPassLbl" runat="server" Text="New Password"></asp:Label>
            <asp:TextBox ID="newPassTB" runat="server" placeholder="new password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="msgPassLbl" runat="server" Text=""></asp:Label>
        </div>
        <div style="height: 2em;"></div>
        
        <div>
            <asp:Button ID="updatePasswordBtn" runat="server" Text="Update Password" OnClick="updatePasswordBtn_Click" />
        </div>

</asp:Content>
