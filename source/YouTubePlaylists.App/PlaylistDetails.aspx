<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlaylistDetails.aspx.cs" Inherits="YouTubePlaylists.App.PlaylistDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Playlist details</h2>

    <asp:FormView ID="fvPlaylistDetails" runat="server"
        ItemType="YouTubePlaylists.App.Models.ViewModels.PlaylistDetailsViewModel"
        SelectMethod="fvPlaylistDetails_GetItem"
        RenderOuterTable="false">
        <ItemTemplate>
            <div class="row">
                <div class="col-md-6">
                    <h3>Title: <%#: Item.Title %> by <i><a href="UserDetails.aspx?username=<%# Item.CreatorUsername %>"><%#: Item.CreatorName %></a></i></h3>
                    <p>Description: <%#: Item.Description %></p>
                    <p>Rating: <%#: Item.Rating %></p>
                    <p>Category: <i><a href="Category.aspx?id=<%# Item.CategoryId %>"><%#: Item.Category %></a></i></p>
                    <p>Creation date: <%# Item.CreatedAt %></p>
                    <h4>Videos:</h4>
                    <asp:ListView ID="lvVideos" runat="server"
                        ItemType="System.string"
                        SelectMethod="lvVideos_GetData">
                        <LayoutTemplate>
                            <asp:DataPager ID="dpVideos" runat="server" PageSize="1" PagedControlID="lvVideos">
                                <Fields>
                                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ShowNextPageButton="true" ShowLastPageButton="true" ShowPreviousPageButton="false" />
                                </Fields>
                            </asp:DataPager>
                            <p id="itemPlaceholder" runat="server"></p>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div>
                                <iframe width="560" height="315" src="https://www.youtube.com/embed/<%# Item %>" frameborder="0" allowfullscreen></iframe>
                            </div>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <i>No videos</i>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </div>
                <div class="col-md-6">
                    <h4>Ratings:</h4>
                    <asp:ListView ID="lvRatings" runat="server"
                        DataKeyNames="Id"
                        SelectMethod="lvRatings_GetData"
                        ItemType="YouTubePlaylists.Models.Rating">
                        <LayoutTemplate>
                            <p id="itemPlaceholder" runat="server"></p>
                            <asp:DataPager ID="dpVideos" runat="server" PageSize="3" PagedControlID="lvRatings">
                                <Fields>
                                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ShowNextPageButton="true" ShowLastPageButton="true" ShowPreviousPageButton="false" />
                                </Fields>
                            </asp:DataPager>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <p>Vote: <%# Item.Value %>, Voter: <i><a href="UserDetails.aspx?username=<%# Item.Voter.UserName %>"><%#: Item.Voter.UserName %></a></i></p>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <i>No ratings</i>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>