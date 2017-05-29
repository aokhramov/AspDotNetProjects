<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseView.aspx.cs" 
    MasterPageFile="~/Pages/PetShop.Master"
    Inherits="PetShop.Pages.PurchaseView" %>

<asp:Content ID="PurchaseViewContent" ContentPlaceHolderID="bodyContent" runat="server">
    
    <div id ="content">
        <h2>Товары в корзине</h2>
        <table id="purchaseTable">
            <thead><tr>
                <th>Товар</th>
                <th>Стоимость</th>
                <th>Количество</th>
                <th>Итоговая стоимость</th>
            </tr></thead>

            <tbody>
                <%
                    foreach(var item in GetPurchaseItems())
                    {
                        Response.Write(string.Format("<tr><td>{0}</td>", item.Product.Name));
                        Response.Write(string.Format("<td>{0}</td>", item.Product.Price.ToString("c")));
                        Response.Write(string.Format("<td>{0}</td>", item.Quantity));
                        Response.Write(string.Format("<td>{0}</td>", (item.Quantity * item.Product.Price).ToString("c")));
                        Response.Write(string.Format("<td><button type='submit' class='actionButtins' name='remove' value ='{0}'>Убрать из закупки</button></td></tr>",item.Product.Id));
                    }
                     %>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan ="3">Итого: </td>
                    <td><% Response.Write(PurchaseTotal.ToString("c")); %></td>
                </tr>
            </tfoot>
        </table>
        
            <a style="text-decoration:none" href="/Pages/Ordering.aspx">Перейти к оформлению закупки</a>
        
    </div>
    

</asp:Content>