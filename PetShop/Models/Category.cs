namespace PetShop.Models
{
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;
    using System.Collections.Generic;
    public class Category
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// Наименование категории товаров
        /// </summary>
        public virtual string Name { get; set; }

        private IList<Product> _products;

        /// <summary>
        /// Товары текущей категории
        /// </summary>
        public virtual IList<Product> Products
        {
            get
            {
                return _products ?? (_products = new List<Product>());
            }
            set { _products = value; }
        }
        public Category() { }
    }

    //MAP
    public class CategoryMap : ClassMapping<Category>
    {
        public CategoryMap()
        {
            Table("Category");
            Id(category => category.Id, 
                map => map.Generator(Generators.Identity));

            Property(x => x.Name);

            Bag(category => category.Products,
            map => { map.Key(k => k.Column("Category")); },
            rel => rel.OneToMany());
        }
    }
}