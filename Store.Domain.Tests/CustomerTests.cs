using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.ValueObjects;

namespace Store.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly Name _name = new Name("Danilo", "Val");
        private readonly Email _email = new Email("danilodoval@gmail.com");
        private readonly Document _document = new Document("230.502.247-62");
        private readonly User _user = new User("danilodoval", "danilodoval", "danilodoval");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            var name = new Name("", "Val");
            var customer = new Customer(name, _email, _document, _user);

            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            var name = new Name("Danilo", "");
            var customer = new Customer(name, _email, _document, _user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnANotification()
        {
            var email = new Email("danilodoval.gmail.com");
            var customer = new Customer(_name, email, _document, _user);
            Assert.IsFalse(customer.IsValid());
        }
    }
}
