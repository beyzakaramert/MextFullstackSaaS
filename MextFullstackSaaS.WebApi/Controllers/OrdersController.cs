using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models.Auth;
using MextFullstackSaaS.Application.Features.Orders.Commands.Add;
using MextFullstackSaaS.Application.Features.Orders.Commands.Delete;
using MextFullstackSaaS.Application.Features.Orders.Commands.Update;
using MextFullstackSaaS.Application.Features.Orders.Queries.GetAll;
using MextFullstackSaaS.Application.Features.Orders.Queries.GetById;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.ForgotPassword;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.ResetPassword;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MextFullstackSaaS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _mediatr;

        public OrdersController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {

            return Ok(await _mediatr.Send(new OrderGetByIdQuery(id), cancellationToken));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(new OrderDeleteCommand(id), cancellationToken));
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(OrderAddCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(OrderUpdateCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(new OrderGetAllQuery(), cancellationToken));
        }
       


    }
}
