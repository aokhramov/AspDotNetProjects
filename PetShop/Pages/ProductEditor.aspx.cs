namespace PetShop.Pages
{
    using Helpers;
    using Models;
    using NHibernate;
    using System;
    using System.Linq;
    public partial class ProductEditor : System.Web.UI.Page
    {
        public Product CurrentProduct;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductEditForm.Visible = true;
            CompleteMessage.Visible = false;

            int selectedProductId;
            bool change = false;
            if (int.TryParse(Request["item"], out selectedProductId))
                CurrentProduct = GetProduct(selectedProductId);
            else
                CurrentProduct = new Product();

            if(IsPostBack)
            {
                if (int.TryParse(Request.Form["edit"], out selectedProductId))
                {
                    if(selectedProductId > 0)
                        CurrentProduct = GetProduct(selectedProductId);

                    CurrentProduct.Name = Request.Form["Name"];
                    string str = Request.Form["Price"].Replace(".",",");
                    CurrentProduct.Price = decimal.Parse(str);
                    CurrentProduct.Description = Request.Form["Description"];

                    ICriteria criteria = NHibernateHelper.Session.CreateCriteria<Category>();
                    Category category = criteria.List<Category>().Where(p => p.Id == 1).FirstOrDefault();

                    CurrentProduct.Category = category;
                    change = true;
                }
            }
            if(change)
            {
                using (ITransaction tran = NHibernateHelper.Session.BeginTransaction())
                {
                    NHibernateHelper.Session.Save(CurrentProduct);
                    tran.Commit();
                    ProductEditForm.Visible = false;
                    CompleteMessage.Visible = true;
                }
            }
        }
        protected Product GetProduct(int ProductId)
        {
            Product prd;
            using (NHibernateHelper.Session.BeginTransaction())
            {
                ICriteria criteria = NHibernateHelper.Session.CreateCriteria<Product>();
                prd = criteria.List<Product>().Where(p => p.Id == ProductId).FirstOrDefault();
            }
            return prd;
        }
    }
}