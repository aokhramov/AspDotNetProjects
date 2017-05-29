namespace PetShop.Models
{
    using System.Collections.Generic;
    using System.Linq;
    public class Purchase
    {
        private List<PurchaseItem> purchaseItems = new List<PurchaseItem>();
        /// <summary>
        /// Добавляем продукт в закупку
        /// </summary>
        /// <param name="product">Продукт</param>
        /// <param name="quantity">Количество</param>
        public void Add(Product product, int quantity)
        {
            PurchaseItem item = purchaseItems
                .Where(items => items.Product.Id == product.Id)
                .FirstOrDefault();
            if (item == null)
            {
                purchaseItems.Add(new PurchaseItem { Product = product, Quantity = quantity });
            }
            else
                item.Quantity += quantity;
        }

        /// <summary>
        /// Удаляем продукт из закупки
        /// </summary>
        /// <param name="product">Продукт</param>
        public void Remove(Product product)
        {
            purchaseItems.RemoveAll(items => items.Product.Id == product.Id);
        }

        /// <summary>
        /// Итоговая сумма по продукту в закупке
        /// </summary>
        /// <returns>Сумма</returns>
        public decimal TotalSum()
        {
            return purchaseItems.Sum(items => items.Product.Price * items.Quantity);
        }

        /// <summary>
        /// Стереть закупку
        /// </summary>
        public void Clear()
        {
            purchaseItems.Clear();
        }

        /// <summary>
        /// Список товаров в закупке
        /// </summary>
        public IEnumerable<PurchaseItem> PurchaseItems
        {
            get { return purchaseItems; }
        }
    }

    public class PurchaseItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}