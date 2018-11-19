using Store.Shared.Commands;

namespace Store.Domain.Commands.Results
{
    public class PlaceOrderCommandResult : ICommandResult
    {
        public PlaceOrderCommandResult() { }

        public PlaceOrderCommandResult(string number)
        {
            Number = number;
        }

        public string Number { get; set; }
    }
}
