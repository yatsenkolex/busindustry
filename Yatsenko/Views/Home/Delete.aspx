<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KryzhevKersach.Models.Route>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Route</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.IdRoute) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.IdRoute) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.firstStop) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.firstStop) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.lastStop) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.lastStop) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.count) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.count) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.dateLimit) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.dateLimit) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Обратно к списку", "Index") %>
    </p>
<% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
