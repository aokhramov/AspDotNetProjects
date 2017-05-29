using NHibernate;
using PetShop.Helpers;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Controls
{
    public partial class Categories : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected IEnumerable<Category> GetCategories()
        {
            IList<Category> category;
            using (NHibernateHelper.Session.BeginTransaction())
            {
                ICriteria criteria = NHibernateHelper.Session.CreateCriteria<Category>();
                category = criteria.List<Category>();
            }
            return category
                .OrderBy(p => p.Id);
        }

        protected string CreateLink (Category category)
        {
            return string.Format("<a href='/Pages/Products.aspx?category={0}'>{1}</a>",category.Id,category.Name);
        }
    }
}