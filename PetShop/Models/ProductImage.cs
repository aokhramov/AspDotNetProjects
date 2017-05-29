namespace PetShop.Models
{
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;
    public class ProductImage
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual Product Product { get; set; }
        public ProductImage() { }
    }

    //MAP
    public class ProductImageMap : ClassMapping<ProductImage>
    {
        public ProductImageMap()
        {
            Table("ProductsImages");
            Id(productImage => productImage.Id, 
                map => map.Generator(Generators.Identity));

            Property(x => x.Name);

            ManyToOne(x => x.Product,
            c => {
                c.Cascade(Cascade.All);
                c.Column("ProductId");
                c.ForeignKey("FK_Product_Images");
            });
        }
    }
}