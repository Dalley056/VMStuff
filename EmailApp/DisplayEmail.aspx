<%@ Page Language="C#" MasterPageFile="~/EmailMaster.Master" AutoEventWireup="true" CodeBehind="DisplayEmail.aspx.cs" Inherits="EmailApp.DisplayEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Email
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <div>
    
        <asp:Label ID="lblFrom" runat="server" Text="From:"></asp:Label>
        <asp:TextBox ID="txtFrom" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Label ID="lblSubject" runat="server" Text="Subject:"></asp:Label>
        <asp:TextBox ID="txtSubject" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Label ID="lblBody" runat="server" Text="Body:"></asp:Label>
        <br />
        <asp:TextBox ID="txtEmailBody" runat="server" BorderStyle="Solid" Height="230px" ReadOnly="True" TextMode="MultiLine" Width="469px" Wrap="False"></asp:TextBox>    
        <br />
        <br />
        <asp:Button ID="btnReply" runat="server" OnClick="btnReply_Click" Text="Reply" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
    </div>
</asp:Content>
