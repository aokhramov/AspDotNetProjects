namespace PetShop.Models
{
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;
    public class OrderItem
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// Заказ с текущим товаром
        /// </summary>
        public virtual Order Order { get; set; } 

        /// <summary>
        /// Товар
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Количество едениц текущего товара в заказе
        /// </summary>
        public virtual int Quantity { get; set; }

        public OrderItem() { }
    }

    //MAP
    public class OrderItemMap : ClassMapping<OrderItem>
    {
        public OrderItemMap()
        {
            Table("OrderItem");
            Id(orderItem =>  orderItem.Id,
                map => { map.Generator(Generators.Identity); map.UnsavedValue(0); });

            Property(x => x.Quantity);

            ManyToOne(x => x.Product,
            c => {
                c.Cascade(Cascade.None);
                c.Column("ProductId");
                c.ForeignKey("FK_Product_OrdersItems");
            });

            ManyToOne(x => x.Order,
            c => {
                c.Cascade(Cascade.All);
                c.Column("OrderId");
                c.ForeignKey("FK_Order_OrderItem");
            });
        }
    }
}