using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.ValueObjects;

namespace Store.Domain.Tests
{
    [TestClass]
    public class OrderTests
    {
        //private readonly static User _user = new User("danilodoval", "danilodoval");
        

        private readonly static Name _name = new Name("Danilo", "Val");
        private readonly static Email _email = new Email("danilodoval@gmail.com");
        private readonly static Document _document = new Document("230.502.247-62");
        private readonly static User _user = new User("danilodoval", "danilodoval", "danilodoval");

        private readonly Customer _customer = new Customer(_name, _email, _document, _user);

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnOutOfStockProductItShouldReturnAnError()
        {
            var mouse = new Product("Mouse", 25, "mouse.jpg", 0);

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsFalse(order.IsValid());
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnInStockProductItShouldUpdateQuantityOnHand()
        {
            var mouse = new Product("Mouse", 25, "mouse.jpg", 20);

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsTrue(mouse.QuantityOnHand.Equals(18));
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAValidOrderItShouldReturn()
        {
            var mouse = new Product("Mouse", 300, "mouse.jpg", 20);

            var order = new Order(_customer, 12, 2);
            order.AddItem(new OrderItem(mouse, 1));

            Assert.IsTrue(order.Total().Equals(310));
        }
    }
}
