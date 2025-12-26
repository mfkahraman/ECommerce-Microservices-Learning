using ECommerce.Order.Application.Features.CQRS.Queries;
using ECommerce.Order.Application.Features.CQRS.Results;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
    public class GetAddressByIdQueryHandler(IRepository<Address> repository)
    {
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var record = await repository.GetByIdAsync(query.Id);
            if (record is null)
            {
                throw new Exception("Address not found");
            }
            return record.Adapt<GetAddressByIdQueryResult>();
        }
    }
}
