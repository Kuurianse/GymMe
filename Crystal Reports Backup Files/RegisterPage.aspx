<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="ProjectPSD.Views.RegisterPage" %>

<!DOCTYPE html>
<head runat="server">
    <title>Register</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            margin: 0;
        }

        form {
            background-color: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        h1 {
            text-align: center;
            margin-bottom: 20px;
        }

        div {
            margin-bottom: 15px;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .radio-group {
            display: flex;
            align-items: center;
        }

        .radio-group label {
            margin-right: 10px;
        }

        button[type="submit"] {
            background-color: #007bff; 
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            margin-right: 10px;
        }

        button[type="submit"]:hover {
            background-color: #0069d9;
        }

        .error-message {
            color: red;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            <asp:Label ID="registerlbl" runat="server" Text="REGISTER"></asp:Label>
        </h1>
        <div>
            <asp:Label ID="usernamelbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="usernameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="useremaillbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="useremailTB" runat="server"></asp:TextBox>
        </div>
        <div class="radio-group">
            <asp:RadioButtonList ID="radioGender" runat="server">
                <asp:ListItem Value="M">Male</asp:ListItem>
                <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
            <asp:Label ID="passwordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="passwordTB" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="confirmpasswordLbl" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="confirmTB" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="doblbl" runat="server" Text="Date of Birth"></asp:Label>
            <asp:Calendar ID="dobCalendar" runat="server"></asp:Calendar> </div>

        <div class="error-message">
            <asp:Label ID="Msg" runat="server" Text=""></asp:Label>
        </div>

        <div>
            <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="backBtn_Click" />
            <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click" />
        </div>
    </form>
</body>
</html>

