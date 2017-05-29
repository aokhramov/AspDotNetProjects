namespace PetShop.Models
{
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;
    using System.Collections.Generic;
    public class Product
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Категория товара
        /// </summary>
        public virtual Category Category { get; set; }

        private IList<ProductImage> _productImages;

        /// <summary>
        /// Фотографии товара
        /// </summary>
        public virtual IList<ProductImage> ProductImages
        {
            get
            {
                return _productImages ?? (_productImages = new List<ProductImage>());
            }
            set { _productImages = value; }
        }

        /// <summary>
        /// Цена товара
        /// </summary>
        public virtual decimal Price { get; set; }

        /// <summary>
        /// Количество товара на складе
        /// </summary>
        public virtual int Quantity { get; set; }


        private IList<OrderItem> _ordersItems;

        /// <summary>
        /// Товар в заказах
        /// </summary>
        public virtual IList<OrderItem> OrdersItems
        {
            get
            {
                return _ordersItems ?? (_ordersItems = new List<OrderItem>());
            }
            set { _ordersItems = value; }
        }
        public Product() { }

    }

    //MAP
    public class ProductMap : ClassMapping<Product>
    {
        public ProductMap ()
        {
            Table("Product");
            Id(product => product.Id, 
                map => map.Generator(Generators.Identity));

            Property(x => x.Name);
            Property(x => x.Description);
            Property(x => x.Price);
            Property(x => x.Quantity);

            ManyToOne(x => x.Category, c =>
            {
                c.Cascade(Cascade.None);
                c.Column("Category");
                c.ForeignKey("FK_Product_Category");
            });

            Bag(product => product.ProductImages,
                map => map.Key(k => k.Column("ProductId")), 
                rel => rel.OneToMany());

            Bag(product => product.OrdersItems,
                map => map.Key(k => k.Column("ProductId")),
                rel => rel.OneToMany());
        }
    }
}