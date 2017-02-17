<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KryzhevKersach.Models.Transport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Transport</legend>

     <h4> Route number </h4>
        <div class="editor-field">
            <%: Html.DropDownList("idRoute") %>
            <%: Html.ValidationMessageFor(model => model.idRoute) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.driver) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.driver) %>
            <%: Html.ValidationMessageFor(model => model.driver) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.serialNumber) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.serialNumber) %>
            <%: Html.ValidationMessageFor(model => model.serialNumber) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Обратно к списку", "Index") %>
    <%: Html.ActionLink("Главная страница", "Home", "Index")%>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
