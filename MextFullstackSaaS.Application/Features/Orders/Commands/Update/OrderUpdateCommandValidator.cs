using FluentValidation;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateCommandValidator : AbstractValidator<OrderUpdateCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public OrderUpdateCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Order ID cannot be empty.")
                .MustAsync(IsOrderExists)
                .WithMessage("The order does not exist.");

            RuleFor(x => x.IconDescription)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("The icon description must be less than 200 characters.");

            RuleFor(x => x.ColourCode)
                .NotEmpty()
                .MaximumLength(15)
                .WithMessage("The colour code must be less than 15 characters.");

            RuleFor(x => x.Model)
                .IsInEnum()
                .WithMessage("Please select a valid model.");

            RuleFor(x => x.DesignType)
                .IsInEnum()
                .WithMessage("Please select a valid design type.");

            RuleFor(x => x.Size)
                .IsInEnum()
                .WithMessage("Please select a valid size.");

            RuleFor(x => x.Shape)
                .IsInEnum()
                .WithMessage("Please select a valid shape.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .LessThanOrEqualTo(6)
                .WithMessage("Please select a valid quantity.");
        }

        public async Task<bool> IsOrderExists(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Orders.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
