namespace PetShop.Controls
{
    using System;
    using Models;
    using Helpers;
    using System.Linq;
    public partial class PurchaseWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Purchase purchase = SessionHelper.GetPurchase(Session);
            quantity.InnerText = purchase.PurchaseItems.Sum(x => x.Quantity).ToString();
            total.InnerText = purchase.TotalSum().ToString("c");
            purchaseLink.HRef = "/Pages/PurchaseView.aspx";
        }
    }
}