<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductEditor.aspx.cs" 
    MasterPageFile="~/Pages/PetShop.Master"
    Inherits="PetShop.Pages.ProductEditor" %>

<asp:Content ID="ProductEditorContent" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
    <div id="ProductEditForm" class="ProductEditor" runat="server">
    <%
        Response.Write("<div><label for='Name'>Наименование:</label>");
        Response.Write(string.Format("<input type='text' name='Name' value='{0}' /><br/></div>", CurrentProduct.Name));

        Response.Write("<div><label for='Price'>Цена:</label>");
        Response.Write(string.Format("<input type='text' name='Price' value='{0}' /><br/></div>", CurrentProduct.Price));

        Response.Write("<div><label for='Description'>Описание:</label>");
        Response.Write(string.Format("<input type='text' name='Description' value='{0}' /><br/></div>", CurrentProduct.Description));

        Response.Write(string.Format("<td><button name='edit' type='submit' value='{0}'>Сохранить</button>",CurrentProduct.Id));
        
    %>
    </div>
    <div id="CompleteMessage" runat="server"> 
        <h2>Товар сохранен!</h2>
    </div>
    </div>
</asp:Content>
