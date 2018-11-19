using Store.Domain.Commands.Results;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Store.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        IEnumerable<GetProductListCommandResult> Get();
    }
}
