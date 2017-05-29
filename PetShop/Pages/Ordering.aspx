<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ordering.aspx.cs" 
    MasterPageFile="~/Pages/PetShop.Master"
    Inherits="PetShop.Pages.Ordering" %>

<asp:Content ID="OrderingContent" ContentPlaceHolderID="bodyContent" runat="server">
    
    <div id="content">
        <div id="orderingForm" class ="ordering" runat ="server">
            <h2>Оформление закупки</h2>
            Введите свои данные
            <div>
                <label for="PurchaserName">Покупатель:</label>
                <input type="text" name="PurchaserName" /><br />

            </div>
            <div>
                <label for="PostAddress">Почтовый адрес:</label>
                <input type="text" name="PostAddress" /><br />

            </div>
            <div>
                <label for="Comment">Комментарий к заказу:</label>
                <textarea name="Comment" rows ="5" cols ="30"> </textarea><br />

            </div>
            <button type="submit">Оформить заказ</button>
        </div>
        <div id="OrderCompleteMessage" runat="server"> 
            <h2>Заказ оформлен!</h2>
        </div>
    </div>

</asp:Content>