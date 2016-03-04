<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlaylistDetails.aspx.cs" Inherits="YouTubePlaylists.App.PlaylistDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Playlist details</h2>
    <asp:DetailsView ID="dvPlaylistDetails" runat="server"
        ItemType="YouTubePlaylists.App.Models.ViewModels.PlaylistDetailsViewModel"
        SelectMethod="dvPlaylistDetails_GetItem" />
</asp:Content>