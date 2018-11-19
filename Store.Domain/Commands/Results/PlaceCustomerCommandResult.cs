using Store.Shared.Commands;
using System;

namespace Store.Domain.Commands.Results
{
    public class PlaceCustomerCommandResult : ICommandResult
    {
        public PlaceCustomerCommandResult() { }

        public PlaceCustomerCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
