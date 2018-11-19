using Store.Shared.Commands;
using System;
using System.Collections.Generic;

namespace Store.Domain.Commands.Inputs
{
    public class PlaceOrderCommand : ICommand
    { 
        public Guid Customer { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<PlaceOrderItemCommand> Items { get; set; }
    }
}
