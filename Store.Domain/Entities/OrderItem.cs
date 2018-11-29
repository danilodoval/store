using FluentValidator;
using Store.Shared.Entities;

namespace Store.Domain.Entities
{
    public class OrderItem : Entity
    {
        protected OrderItem()
        {

        }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            new ValidationContract<OrderItem>(this)
                .IsGreaterThan(x => x.Quantity, 0)
                .IsGreaterThan(x => x.Product.QuantityOnHand, Quantity + 1, $"We do not have so many { Product.Title }'s in stock");

            Product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public int Quantity{ get; set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;
    }
}
