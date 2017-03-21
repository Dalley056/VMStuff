<%@ Page Language="C#" MasterPageFile="~/EmailMaster.Master" AutoEventWireup="true" CodeBehind="ComposeEmail.aspx.cs" Inherits="EmailApp.ComposeEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <asp:Label ID="lblCTo" runat="server" Text="To:"></asp:Label>
    <asp:TextBox ID="txtCTo" runat="server" Width="169px"></asp:TextBox>
        <br />
    <asp:Label ID="lblCC" runat="server" Text="CC:"></asp:Label>
    <asp:TextBox ID="txtCC" runat="server" Width="166px"></asp:TextBox>
        <br />
        <asp:Label ID="lblCSubject" runat="server" Text="Subject:"></asp:Label>
        <asp:TextBox ID="txtCSubject" runat="server" Width="136px"></asp:TextBox>
        <br />
        <asp:Label ID="lblCBody" runat="server" Text="Body:"></asp:Label>
        <br />
        <asp:TextBox ID="txtComposeBody" runat="server" BorderStyle="Solid" Height="230px" Width="469px"></asp:TextBox>
        <br />
    <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" />
        <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>
        <br />
        </asp:Content>
