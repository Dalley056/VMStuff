<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="EmailApp.ForgotPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblEmail" runat="server" Text="Email Address:"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblSecurityQ" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lblAnswer" runat="server" Text="Answer"></asp:Label>
        <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblNewPass" runat="server" Text="New Password:"></asp:Label>
        <asp:TextBox ID="txtNewPass" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblConfirm" runat="server" Text="Confirm New Password:"></asp:Label>
        <asp:TextBox ID="txtConfirmNew" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnCreatePass" runat="server" OnClick="btnCreatePass_Click" Text="Create New Pass" />
    
    </div>
    </form>
</body>
</html>
