<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PurchaseWidget.ascx.cs" Inherits="PetShop.Controls.PurchaseWidget" %>

<div id="PurchaseWidget">
    <span>
        <b>Корзина: </b>
        Товаров: <span id="quantity" runat="server"></span> шт.
        Стоимость: <span id="total" runat="server"></span>
    </span>
    <a id="purchaseLink" runat="server">Обзор</a>
</div>