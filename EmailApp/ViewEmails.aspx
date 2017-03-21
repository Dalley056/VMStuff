<%@ Page Language="C#" MasterPageFile="~/EmailMaster.Master" AutoEventWireup="true" CodeBehind="ViewEmails.aspx.cs" Inherits="EmailApp.ViewEmails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Inbox
    <br/>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <a href="ViewEmails.aspx?Version=1">Inbox</a>&nbsp;&nbsp;&nbsp;&nbsp; <a href="ViewEmails.aspx?Version=2">Deleted</a>&nbsp;&nbsp;&nbsp;&nbsp; <a href="ViewEmails.aspx?Version=3">Sent</a>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="eID" DataSourceID="SqlDataSource1" HorizontalAlign="Left">
    <Columns>
        <asp:templatefield HeaderText="Delete">
                    <itemtemplate>
                        <asp:checkbox ID="chkDelete" 
                        CssClass="gridCB" runat="server"></asp:checkbox>
                    </itemtemplate>
                </asp:templatefield>
        <asp:BoundField DataField="eID" HeaderText="eID" InsertVisible="False" ReadOnly="True" SortExpression="eID" Visible="False" />
               <%-- <asp:BoundField DataField="eID" HeaderText="eID" ReadOnly="True" SortExpression="eID" />--%>

        <asp:BoundField DataField="email_from" HeaderText="From" SortExpression="email_from" />
        <asp:HyperLinkField DataNavigateUrlFields="eID" DataNavigateUrlFormatString="DisplayEmail.aspx?eID={0}" DataTextField="email_subject" HeaderText="Subject" NavigateUrl="~/DisplayEmail.aspx" />
        <asp:BoundField DataField="email_date" HeaderText="Date" SortExpression="email_date" DataFormatString="{0:MM/dd/yyyy}" />
    </Columns>
</asp:GridView>
&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [user_emails] WHERE (([active] = @active) AND ([email_to] = @email_to))">
    <SelectParameters>
        <asp:Parameter DefaultValue="y" Name="active" Type="String" />
        <asp:SessionParameter Name="email_to" SessionField="email" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
<br />
    <br />
    <div id="containTable" runat="server">
    </div>
    <br />
    <br />
    <br />
    </asp:Content>  


