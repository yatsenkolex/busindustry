<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KryzhevKersach.Models.Transport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Transport</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.IdTransport) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.IdTransport) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.idRoute) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idRoute) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.driver) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.driver) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.serialNumber) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.serialNumber) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Изменить", "Edit", new {  id=Model.IdTransport }) %> |
    <%: Html.ActionLink("Обратно к списку", "Index") %>
</p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
