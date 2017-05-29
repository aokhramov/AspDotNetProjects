namespace PetShop.Models
{
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;
    using System.Collections.Generic;

    public class OrderState
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// Наименование состояния заказа
        /// </summary>
        public virtual string Name { get; set; }

        private IList<Order> _orders;

        /// <summary>
        /// Список заказов с текущим состоянием
        /// </summary>
        public virtual IList<Order> Orders
        {
            get
            {
                return _orders ?? (_orders = new List<Order>());
            }
            set { _orders = value; }
        }

        public OrderState() { }
    }

    //MAP
    public class OrderStateMap : ClassMapping<OrderState>
    {
        public OrderStateMap()
        {
            Table("OrderState");
            Id(orderState => orderState.Id,
                map => map.Generator(Generators.Identity));

            Property(x => x.Name);

            Bag(order => order.Orders,
                map => map.Key(k => k.Column("StateId")),
                rel => rel.OneToMany());
        }
    }
}