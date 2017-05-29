namespace PetShop.Pages
{
    using Helpers;
    using Models;
    using NHibernate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public partial class OrdersManager : System.Web.UI.Page
    {
        IList<Order> orders;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                bool change = false;
                Order selectedOrder = new Order();
                int selectedOrderId;
                if (int.TryParse(Request.Form["done"], out selectedOrderId))
                {
                    selectedOrder = GetNewOrders().Where(product => product.Id == selectedOrderId).FirstOrDefault();

                    ICriteria criteria = NHibernateHelper.Session.CreateCriteria<OrderState>();
                    OrderState state = criteria.List<OrderState>().Where(p => p.Id == 2).FirstOrDefault();

                    selectedOrder.State = state;
                    foreach(var item in selectedOrder.OrderItems)
                    {
                        item.Product.Quantity -= item.Quantity;
                    }
                    change = true;
                }
                if (int.TryParse(Request.Form["remove"], out selectedOrderId))
                {
                    selectedOrder = GetNewOrders().Where(product => product.Id == selectedOrderId).FirstOrDefault();
                    ICriteria criteria = NHibernateHelper.Session.CreateCriteria<OrderState>();
                    OrderState state = criteria.List<OrderState>().Where(p => p.Id == 3).FirstOrDefault();

                    selectedOrder.State = state;
                    change = true;
                }
                if (change)
                {
                    using (ITransaction tran = NHibernateHelper.Session.BeginTransaction())
                    {
                        NHibernateHelper.Session.Save(selectedOrder);
                        tran.Commit();
                    }
                }
            }
        }
        protected IEnumerable<Order> GetNewOrders()
        {

            using (NHibernateHelper.Session.BeginTransaction())
            {
                ICriteria criteria = NHibernateHelper.Session.CreateCriteria<Order>();
                orders = criteria.List<Order>();
            }
            return orders.Where(p => p.State.Id == 1);
        }
        protected IEnumerable<Order> GetOldOrders()
        {

            using (NHibernateHelper.Session.BeginTransaction())
            {
                ICriteria criteria = NHibernateHelper.Session.CreateCriteria<Order>();
                orders = criteria.List<Order>();
            }
            return orders.Where(p => p.State.Id != 1);
        }

        protected int TotalQuantity(Order order)
        {
            return order.OrderItems.Sum(p => p.Quantity);
        }

        protected decimal TotalPrice(Order order)
        {
            return order.OrderItems.Sum(p => p.Quantity * p.Product.Price);
        }
    }
}