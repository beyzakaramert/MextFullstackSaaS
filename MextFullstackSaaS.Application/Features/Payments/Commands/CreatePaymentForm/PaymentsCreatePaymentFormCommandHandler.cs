using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.Payments;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Enums;
using MextFullstackSaaS.Domain.ValueObjects;

namespace MextFullstackSaaS.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentsCreatePaymentFormCommandHandler : IRequestHandler<PaymentsCreatePaymentFormCommand, ResponseDto<PaymentsCreatePaymentFormDto>>
    {
        private readonly IPaymentService _paymentService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public PaymentsCreatePaymentFormCommandHandler(IPaymentService paymentService, ICurrentUserService currentUserService , IIdentityService identityService)
        {
            _paymentService = paymentService;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<ResponseDto<PaymentsCreatePaymentFormDto>> Handle(PaymentsCreatePaymentFormCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _identityService.GetProfileAsync(cancellationToken);

            var paymentDetail = userProfile.MapToPaymentDetail();

            var userRequest = new PaymentsCreateCheckoutFormRequest(paymentDetail, request.Credits);

            var checkoutFormResponse =  _paymentService.CreateCheckoutForm(userRequest);



            return new ResponseDto<PaymentsCreatePaymentFormDto>();
        }

        private UserPayment MapUserPayment(UserPaymentDetail paymentDetail, PaymentsCreateCheckoutFormResponse checkoutFromResponse)
        {
            var userPaymentId = Guid.NewGuid();

            return new UserPayment()
            {
                Id = userPaymentId,
                UserId = _currentUserService.UserId,
                BasketId = checkoutFromResponse.BasketId,
                Price = checkoutFromResponse.Price,
                PaidPrice = checkoutFromResponse.PaidPrice,
                CurrencyCode = CurrencyCode.TRY,
                CreatedOn = DateTimeOffset.UtcNow,
                Token = checkoutFromResponse.Token,
                UserPaymentDetail = paymentDetail,
                Status = PaymentStatus.Initiated,
                CreatedByUserId = _currentUserService.UserId.ToString(),
                Histories = new List<UserPaymentHistory>()
                {
                    new UserPaymentHistory()
                    {
                        Id = Guid.NewGuid(),
                        Status = PaymentStatus.Initiated,
                        UserPaymentId = userPaymentId,
                        ConversationId = checkoutFromResponse?.ConversationId,
                        CreatedOn = DateTimeOffset.UtcNow,
                        CreatedByUserId = _currentUserService.UserId.ToString(),
                    }
                }
            };
        }
    }
}