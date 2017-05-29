namespace PetShop.Pages
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Web.ModelBinding;
    using Helpers;
    using NHibernate;
    using System.Linq;
    public partial class Ordering : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            orderingForm.Visible = true;
            OrderCompleteMessage.Visible = false;
            if(IsPostBack)
            {
                Order order = new Order();
                if(TryUpdateModel(order,new FormValueProvider(ModelBindingExecutionContext)))
                {
                    order.OrderItems = new List<OrderItem>();
                    IList<Product> products = new List<Product>();

                    Purchase purchase = SessionHelper.GetPurchase(Session);
                    foreach(PurchaseItem item in purchase.PurchaseItems)
                    {
                        order.OrderItems.Add(new OrderItem
                        {
                            Order = order,
                            Product = item.Product,
                            Quantity = item.Quantity,
                        });
                        products.Add(item.Product);
                        products[products.Count - 1].Quantity -= item.Quantity;
                    }

                    using (ITransaction tran = NHibernateHelper.Session.BeginTransaction())
                    {
                        ICriteria criteria = NHibernateHelper.Session.CreateCriteria<OrderState>();
                        OrderState state = criteria.List<OrderState>().Where(p=>p.Id == 1).FirstOrDefault();
                        order.State = state;

                        NHibernateHelper.Session.Save(order);

                        foreach (Product prod in products)
                            NHibernateHelper.Session.Save(prod);

                        tran.Commit();

                        purchase.Clear();
                    }

                    orderingForm.Visible = false;
                    OrderCompleteMessage.Visible = true;
                }
            }
        }
    }
}