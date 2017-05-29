namespace PetShop.Models
{
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;
    using System.Collections.Generic;
    public class Order
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// Имя покупателя
        /// </summary>
        public virtual string PurchaserName { get; set; }

        /// <summary>
        /// Почтовый адрес
        /// </summary>
        public virtual string PostAddress { get; set; }

        /// <summary>
        /// Комментарий к заказу
        /// </summary>
        public virtual string Comment { get; set; }

        private IList<OrderItem> _orderItems;

        /// <summary>
        /// Список товаров в заказе
        /// </summary>
        public virtual IList<OrderItem> OrderItems
        {
            get
            {
                return _orderItems ?? (_orderItems = new List<OrderItem>());
            }
            set { _orderItems = value; }
        }
        /// <summary>
        /// Состояние заказа
        /// </summary>
        public virtual OrderState State { get; set; }

        public Order() { }
    }
    //MAP
    public class OrderMap : ClassMapping<Order>
    {
        public OrderMap()
        {
            Table("Orders");
            Id(order => order.Id,
                map => map.Generator(Generators.Identity));

            Property(x => x.PurchaserName);
            Property(x => x.PostAddress);
            Property(x => x.Comment);

            ManyToOne(x => x.State, c =>
            {
                c.Cascade(Cascade.None);
                c.Column("StateId");
                c.ForeignKey("FK_Order_OrderState");
            });

            Bag(order => order.OrderItems,
                map => { map.Key(k => k.Column("OrderId")); map.Cascade(Cascade.All); },
                rel => rel.OneToMany());

        }
    }
}