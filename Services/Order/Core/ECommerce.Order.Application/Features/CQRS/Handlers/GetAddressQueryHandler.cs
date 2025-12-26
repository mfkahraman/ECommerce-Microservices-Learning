using ECommerce.Order.Application.Features.CQRS.Results;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
    public class GetAddressQueryHandler(IRepository<Address> repository)
    {
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            if (values is null)
                throw new Exception("No addresses found.");
            return values.Adapt<List<GetAddressQueryResult>>();
        }
    }
}
