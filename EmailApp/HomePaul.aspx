<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePaul.aspx.cs" Inherits="EmailApp.HomePaul" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body id="bHome" runat="server">
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="BtnLogIn" runat="server" OnClick="BtnLogIn_Click" Text="Login" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnRegister" runat="server" OnClick="BtnRegister_Click" Text="Register" />
        <br />
        <br />
        Page Colour:<br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="16px" Width="103px">
            <asp:ListItem>Red</asp:ListItem>
            <asp:ListItem>Blue</asp:ListItem>
            <asp:ListItem>Green</asp:ListItem>
            <asp:ListItem>Yellow</asp:ListItem>
        </asp:RadioButtonList>
    
    </div>
    </form>
</body>
</html>
