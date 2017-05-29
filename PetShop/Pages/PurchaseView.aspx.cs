
namespace PetShop.Pages
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using Helpers;
    public partial class PurchaseView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                int productId;
                //убираем товар из закупки
                if(int.TryParse(Request.Form["remove"],out productId))
                {
                    Product product = SessionHelper.GetPurchase(Session).PurchaseItems
                        .Where(prod => prod.Product.Id == productId).FirstOrDefault().Product;
                    if (product != null)
                        SessionHelper.GetPurchase(Session).Remove(product);
                }
            }
        }

        /// <summary>
        /// Продукты в закупке
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseItem> GetPurchaseItems()
        {
            return SessionHelper.GetPurchase(Session).PurchaseItems;
        }

        /// <summary>
        /// Итоговая сумма закупки
        /// </summary>
        public decimal PurchaseTotal
        {
            get
            {
                return SessionHelper.GetPurchase(Session).TotalSum();
            }
        }
    }
}