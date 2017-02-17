<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KryzhevKersach.Models.Ticket>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

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
<p>
    <%: Html.ActionLink("Изменить", "Edit", new {  id=Model.IdTicket}) %> |
    <%: Html.ActionLink("Обратно к списку", "Index") %>
</p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
