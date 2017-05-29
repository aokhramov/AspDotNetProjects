<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsManager.aspx.cs" 
    MasterPageFile="~/Pages/PetShop.Master"
    Inherits="PetShop.Pages.ProductsManager" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <a href="/Pages/ProductEditor.aspx">Добавить новый товар</a>
        <table>
            <thead>
                <tr>
                    <th>Наименование товара</th>
                    <th>Категория</th>
                    <th>Стоимость</th>
                    <th>Заказано</th>
                    <th>На складе</th>
                    <th></th>
                </tr>
            </thead>
        <%
            foreach(var prod in GetProducts())
            {
                Response.Write(string.Format("<tr><td>{0}</td>",prod.Name));
                Response.Write(string.Format("<td>{0}</td>",prod.Category.Name));
                Response.Write(string.Format("<td>{0}</td>",prod.Price.ToString("c")));
                Response.Write(string.Format("<td>{0}</td>",TotalQuantityinOrders(prod.Id)));
                Response.Write(string.Format("<td>{0}</td>",prod.Quantity));
                Response.Write(string.Format("<td><button name='add' type='submit' value='{0}'>+</button>",prod.Id));
                Response.Write(string.Format("<button name='remove' type='submit' value='{0}'>-</button>",prod.Id));
                Response.Write(string.Format("<a href='/Pages/ProductEditor.aspx?item={0}'>Редактировать товар</a></td>",prod.Id));
            }
        %>
            
        </table>
    </div>
</asp:Content>
