<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersManager.aspx.cs" 
    MasterPageFile="~/Pages/PetShop.Master"
    Inherits="PetShop.Pages.OrdersManager" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <table>
            <thead>
                <tr>
                    <th>Номер заказа</th>
                    <th>Заказчик</th>
                    <th>Почтовый адрес</th>
                    <th>Комментарий</th>
                    <th>Количество товаров</th>
                    <th>Стоимость</th>
                    <th></th>
                </tr>
            </thead>
        <%
            foreach(var order in GetNewOrders())
            {
                Response.Write(string.Format("<tr><td>{0}</td>",order.Id));
                Response.Write(string.Format("<td>{0}</td>",order.PurchaserName));
                Response.Write(string.Format("<td>{0}</td>",order.PostAddress));
                Response.Write(string.Format("<td>{0}</td>",order.Comment));
                Response.Write(string.Format("<td>{0}</td>",TotalQuantity(order)));
                Response.Write(string.Format("<td>{0}</td>",TotalPrice(order)));
                Response.Write(string.Format("<td width='100'><button name='done' type='submit' value='{0}'>Выполнить</button>",order.Id));
                Response.Write(string.Format("<button name='remove' type='submit' value='{0}'>Отменить</button>",order.Id));

                Response.Write("</tr><tr class='border_bottom'><td colspan='7'><table id='items'><thead><tr>");
                Response.Write("<th>Наименование товара</th>");
                Response.Write("<th>Количество</th>");
                Response.Write("<th>Стоимость</th></tr><tr>");
                foreach(var orderitem in order.OrderItems)
                {
                    Response.Write(string.Format("<tr><td>{0}</td>",orderitem.Product.Name));
                    Response.Write(string.Format("<td>{0}</td>",orderitem.Quantity));
                    Response.Write(string.Format("<td>{0}</td></tr>",(orderitem.Quantity*orderitem.Product.Price).ToString("c")));
                }
                Response.Write("</tr></table></td></tr>");


            }
        %>
            
        </table>
    </div>
</asp:Content>

