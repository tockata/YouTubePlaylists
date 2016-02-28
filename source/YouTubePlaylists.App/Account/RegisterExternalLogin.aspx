<%@ Page Title="Register an external login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterExternalLogin.aspx.cs" Inherits="YouTubePlaylists.App.Account.RegisterExternalLogin" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Register with your <%: ProviderName %> account</h3>

    <asp:PlaceHolder runat="server">
        <div class="form-horizontal">
            <h4>Association Form</h4>
            <hr />
            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
            <p class="text-info">
                You've authenticated with <strong><%: ProviderName %></strong>. Please enter an email below for the current site
                and click the Log in button.
            </p>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="username" CssClass="col-md-2 control-label">Username</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="username" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="username"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Username is required" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="username" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="email" CssClass="col-md-2 control-label">Email</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="email"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Email is required" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="email" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="firstName" CssClass="col-md-2 control-label">First name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="firstName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="firstName"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="First name is required" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="firstName" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="lastName" CssClass="col-md-2 control-label">Last name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="lastName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="lastName"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Last name is required" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="lastName" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Log in" CssClass="btn btn-default" OnClick="LogIn_Click" />
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>