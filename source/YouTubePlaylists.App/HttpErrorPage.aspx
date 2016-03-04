<%@ Page Title="Http error page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HttpErrorPage.aspx.cs" Inherits="YouTubePlaylists.App.HttpErrorPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Http Error Page</h2>
    <asp:Panel ID="InnerErrorPanel" runat="server" Visible="false">
        <asp:Label ID="innerMessage" runat="server" Font-Bold="true"
            Font-Size="Large" /><br />
        <pre>
        <asp:Label ID="innerTrace" runat="server" />
      </pre>
    </asp:Panel>
    Error Message:<br />
    <asp:Label ID="exMessage" runat="server" Font-Bold="true"
        Font-Size="Large" />
    <pre>
      <asp:Label ID="exTrace" runat="server" Visible="false" />
    </pre>
    <br />
    Return to the <a href='/'>Home Page</a>
</asp:Content>