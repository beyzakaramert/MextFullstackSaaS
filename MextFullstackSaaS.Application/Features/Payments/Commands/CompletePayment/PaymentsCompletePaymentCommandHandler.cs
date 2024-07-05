using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Payments.Commands.CompletePayment
{
    public class PaymentsCompletePaymentCommandHandler:IRequestHandler<PaymentsCompletePaymentCommand,ResponseDto<bool>>
    {
        private readonly IPaymentService _paymentService;
        private readonly IApplicationDbContext _applicationDbContext;

        public PaymentsCompletePaymentCommandHandler(IPaymentService paymentService, IApplicationDbContext applicationDbContext)
        {
            _paymentService = paymentService;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<ResponseDto<bool>> Handle(PaymentsCompletePaymentCommand request, CancellationToken cancellationToken)
        {
            var userPayment = await _applicationDbContext
                 .UserPayments
                 .FirstOrDefaultAsync(x => x.Token == request.Token, cancellationToken);



            return new ResponseDto<bool> (true);
        }
    }
}
