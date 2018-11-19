using Store.Shared.Commands;
using System;

namespace Store.Domain.Commands.Inputs
{
    public class PlaceOrderItemCommand : ICommand
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}
