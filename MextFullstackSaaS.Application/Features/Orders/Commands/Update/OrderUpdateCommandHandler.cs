using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommand, ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;

        public OrderUpdateCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseDto<Guid>> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (order == null)
            {
                return new ResponseDto<Guid>
                {
                    Succeeded = false,
                    Message = "Order not found.",
                    Data = Guid.Empty
                };
            }

            order.IconDescription = request.IconDescription;
            order.ColourCode = request.ColourCode;
            order.Model = request.Model;
            order.DesignType = request.DesignType;
            order.Size = request.Size;
            order.Shape = request.Shape;
            order.Quantity = request.Quantity;
            order.ModifiedOn = DateTimeOffset.UtcNow;

            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<Guid>
            {
                Succeeded = true,
                Message = "Order updated successfully.",
                Data = order.Id
            };
        }
    }
}
