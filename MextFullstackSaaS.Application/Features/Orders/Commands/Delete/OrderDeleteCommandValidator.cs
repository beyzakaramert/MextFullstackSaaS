﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MextFullstackSaaS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandValidator : AbstractValidator<OrderDeleteCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        public OrderDeleteCommandValidator(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please select a valid order.");

            RuleFor(x => x.Id)
                .MustAsync(IsOrderExists)
                .WithMessage("The selected order does not exist in the database.");

            RuleFor(x => x.Id)
                .MustAsync(IsTheSameUserAsync)
                .WithMessage("The selected order does not exist in the database.");
        }

        private Task<bool> IsOrderExists(Guid id, CancellationToken cancellationToken)
        {
            // If the order exists we'll return true, otherwise we'll return false.
            // If we return true this will be a valid order.

            return _dbContext.Orders.AnyAsync(x => x.Id == id, cancellationToken);
        }

        private Task<bool> IsTheSameUserAsync(Guid id, CancellationToken cancellationToken) {

            return _dbContext
            .Orders
            .Where(x => x.UserId == _currentUserService.UserId)
            .AnyAsync(x => x.Id == id, cancellationToken);
    }
    }
}