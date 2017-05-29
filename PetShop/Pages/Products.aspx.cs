namespace PetShop.Pages
{
    using NHibernate;
    using Helpers;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public partial class Products : System.Web.UI.Page
    {
        private int pageSize = 3;
        private IList<Product> products;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                int selectedProductId;
                if(int.TryParse(Request.Form["add"], out selectedProductId))
                {
                    Product selectedProduct = GetProducts().Where(product => product.Id == selectedProductId).FirstOrDefault();
                    if(selectedProduct != null)
                    {
                        SessionHelper.GetPurchase(Session).Add(selectedProduct, 1);
                    }
                }
            }
        }

        /// <summary>
        /// Список продуктов
        /// </summary>
        /// <returns>Продукты</returns>
        protected IEnumerable<Product> GetProducts()
        {
            
            using (NHibernateHelper.Session.BeginTransaction())
            {
                ICriteria criteria = NHibernateHelper.Session.CreateCriteria<Product>();
                products = criteria.List<Product>();
            }
            return Filter()
                .OrderBy(p => p.Id)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        /// <summary>
        /// Текущая страница
        /// </summary>
        protected int CurrentPage
        {
            get
            {
                int page;
                page = int.TryParse(Request.QueryString["page"], out page) ? page : 1;
                return page > MaxPage ? MaxPage : page;
            }
        }

        /// <summary>
        /// Максимальное количество страниц
        /// </summary>
        protected int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((decimal)Filter().Count() / pageSize);
            }
        }

        /// <summary>
        /// Текущая категория товаров
        /// </summary>
        protected string CurrentCategory
        {
            get
            {
                return Request.QueryString["category"];
            }
        }

        /// <summary>
        /// Фильтр товаров (по категории)
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Product> Filter()
        {
            string currentCategory = CurrentCategory;
            if (currentCategory == "")
                currentCategory = null;

            return currentCategory == null ? products : products.Where(p => p.Category.Id == Convert.ToInt16(currentCategory));
        }
    }
}