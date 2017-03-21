<%@ Page Title="" Language="C#" MasterPageFile="~/EmailMaster.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="EmailApp.RegisterUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">

    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server" Width="188px"></asp:TextBox>
    <br />
    <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblPassOne" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="txtPassOne" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblPassTwo" runat="server" Text="Confirm:"></asp:Label>
    <asp:TextBox ID="txtPassTwo" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblSQ" runat="server" Text="Security Qestion:"></asp:Label>
    <asp:TextBox ID="txtSQ" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblSA" runat="server" Text="Security Answer:"></asp:Label>
    <asp:TextBox ID="txtSA" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create Account" />
    <br />
    <br />

</asp:Content>
