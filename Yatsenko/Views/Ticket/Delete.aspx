<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KryzhevKersach.Models.Ticket>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Ticket</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.IdTicket) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.IdTicket) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.condition) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.condition) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.idRoute) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idRoute) %>
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
