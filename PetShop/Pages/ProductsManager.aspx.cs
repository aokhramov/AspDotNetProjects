namespace PetShop.Pages
{
    using Helpers;
    using Models;
    using NHibernate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public partial class ProductsManager : System.Web.UI.Page
    {
        private IList<Product> products;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                bool change = false;
                Product selectedProduct = new Product();
                int selectedProductId;
                if (int.TryParse(Request.Form["add"], out selectedProductId))
                {
                    selectedProduct = GetProducts().Where(product => product.Id == selectedProductId).FirstOrDefault();
                    selectedProduct.Quantity++;
                    change = true;
                }
                if (int.TryParse(Request.Form["remove"], out selectedProductId))
                {
                    selectedProduct = GetProducts().Where(product => product.Id == selectedProductId).FirstOrDefault();
                    if(selectedProduct.Quantity > 0)
                    { 
                        selectedProduct.Quantity--;
                        change = true;
                    }
                }
                if(change)
                {
                    using (ITransaction tran = NHibernateHelper.Session.BeginTransaction())
                    {
                        NHibernateHelper.Session.Save(selectedProduct);
                        tran.Commit();
                    }
                }
            }
        }
        protected IEnumerable<Product> GetProducts()
        {

            using (NHibernateHelper.Session.BeginTransaction())
            {
                ICriteria criteria = NHibernateHelper.Session.CreateCriteria<Product>();
                products = criteria.List<Product>();
            }
            return products;
        }

        /// <summary>
        /// Количество текущих товаров в неразобранных заказах
        /// </summary>
        /// <returns></returns>
        protected int TotalQuantityinOrders(int productId)
        {
            IList<OrderItem> items;
            using (NHibernateHelper.Session.BeginTransaction())
            {
                ICriteria criteria = NHibernateHelper.Session.CreateCriteria<OrderItem>();
                items = criteria.List<OrderItem>();
            }
            return items.Where(p=>p.Product.Id == productId).Where(p => p.Order.State.Id == 1).Count();
        }
    }
}