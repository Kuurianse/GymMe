<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ProjectPSD.Views.LoginPage" %>

<!DOCTYPE html>
<head runat="server">
    <title>Login</title>
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

        input[type="checkbox"] {
            margin-right: 5px;
        }

        button[type="submit"] {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        button[type="submit"]:hover {
            background-color: #45a049;
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
            <asp:Label ID="loginlbl" runat="server" Text="LOGIN"></asp:Label>
        </h1>
        <div>
            <asp:Label ID="usernamelbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="usernameTB" runat="server" placeholder="username"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="passwordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="passwordTB" runat="server" TextMode="Password" placeholder="password"></asp:TextBox>
        </div>
        <div>
            <asp:CheckBox ID="checkBoxRemember" runat="server" />
            <asp:Label ID="cbxLbl" runat="server" Text="Remember Me"></asp:Label>
        </div>

        <div class="error-message">
            <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
        </div>

        <div>
            <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click" />
        </div>
        <div>
            <asp:Label ID="noAccLbl" runat="server" Text="Don't have an account?"></asp:Label>
            <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click" />
        </div>
    </form>
</body>
</html>
