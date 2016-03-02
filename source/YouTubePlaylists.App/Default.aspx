<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YouTubePlaylists.App._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Most popular playlists</h2>
    <div class="row">
        <asp:Repeater ID="rpPopularPlaylists" runat="server"
            ItemType="YouTubePlaylists.App.Models.ViewModels.PlaylistHomePageViewModel"
            SelectMethod="rpPopularPlaylists_GetData">
            <ItemTemplate>
                <div class="col-md-6">
                    <h3><%#: Item.Title %> by <i><a href="UserInfo.aspx?username=<%# Item.Creator %>"><%#: Item.Creator %></a></i></h3>
                    <p>Rating: <%# Item.Rating %></p>
                    <p>Category: <i><a href="Category.aspx?id=<%# Item.CategoryId %>"><%#: Item.Category %></a></i></p>
                    <iframe width="560" height="315" src="https://www.youtube.com/embed/<%# Item.FirstVideoId %>" frameborder="0" allowfullscreen></iframe>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>