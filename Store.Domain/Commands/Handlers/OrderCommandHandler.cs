using FluentValidator;
using Store.Domain.Commands.Inputs;
using Store.Domain.Commands.Results;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Shared.Commands;

namespace Store.Domain.CommandHandlers.Handlers
{
    public class OrderCommandHandler : Notifiable, ICommandHandler<PlaceOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(PlaceOrderCommand command)
        {
            var customer = _customerRepository.Get(command.Customer);
            var order = new Order(customer, command.DeliveryFee, command.Discount);

            foreach (var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));
            }

            AddNotifications(order.Notifications);

            if (IsValid())
                _orderRepository.Save(order);

            return new PlaceOrderCommandResult(order.Number);
        }
    }
}
