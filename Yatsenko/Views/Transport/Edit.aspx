<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KryzhevKersach.Models.Transport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Transport</legend>

        <%: Html.HiddenFor(model => model.IdTransport) %>



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


        <div style="visibility: hidden;" class="editor-label">
            <%: Html.LabelFor(model => model.idRoute) %>
        </div>
        <div style="visibility: hidden;" class="editor-field">
            <%: Html.EditorFor(model => model.idRoute) %>
            <%: Html.ValidationMessageFor(model => model.idRoute) %>
        </div>


        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>

    <div>
        <%: Html.ActionLink("Обратно к списку", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
