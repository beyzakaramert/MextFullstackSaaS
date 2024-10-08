﻿using MediatR;
using MextFullstackSaaS.Application.Common.Models;

namespace MextFullstackSaaS.Application.Features.Payments.Commands.CompletePayment
{
    public class PaymentsCompletePaymentCommand : IRequest<ResponseDto<bool>>
    {
        public string Token {  get; set; }
        public PaymentsCompletePaymentCommand (string token)
        {
            Token = token;
        }

        public PaymentsCompletePaymentCommand()
        {

        }
    }
}
