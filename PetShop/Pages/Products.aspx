<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" 
    MasterPageFile="~/Pages/PetShop.Master"
    Inherits="PetShop.Pages.Products" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id ="content">
        <table>
        <% foreach(PetShop.Models.Product prod in GetProducts())
            {

                Response.Write("<tr>");
                Response.Write(string.Format("<td>{0}</td>", prod.Name));
                Response.Write(string.Format("<td>Стоимость:<b>{0:c}</b></td><td rowspan='2' width='130'>", prod.Price));

                if(prod.Quantity>0)
                    Response.Write(string.Format("<button name='add' type='submit' value='{0}'>Добавить в корзину</button>", prod.Id));
                else
                    Response.Write(string.Format("<h3>Нет в наличии</h3>"));

                Response.Write("</td></tr><tr><td colspan='2'><table><tr><td>");
                foreach(var image in prod.ProductImages)
                {
                    Response.Write(string.Format("<td><img src='/Content/ProductsImages/{0}' width=100 height =100/></td>",image.Name));
                }
                Response.Write("</td></tr></table></td></tr><tr class='border_bottom'><td colspan ='3'>");
                Response.Write(prod.Description);
                Response.Write(string.Format("</td></tr>"));
            }
          %>

        </table>
    </div>
    <div class="pager">
        <%
            for(int i = 1; i <= MaxPage; i++)
            {
                Response.Write(string.Format("<a href='/Pages/Products.aspx?category={0}&page={1}' {2}>{3}</a>"
                    ,CurrentCategory,i,i==CurrentPage?"class='selected'":"",i));
            }
             %>
    </div>
</asp:Content>