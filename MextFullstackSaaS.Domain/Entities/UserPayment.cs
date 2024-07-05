using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Enums;
using MextFullstackSaaS.Domain.Identity;
using MextFullstackSaaS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Domain.Entities
{
    public class UserPayment:EntityBase<Guid>
    {
        public string ConversationId { get; set; }
        public string BasketId { get; set; }
        public string Token { get; set;}
        public string Price { get; set; }
        public string PaidPrice { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public string Ip { get; set; }
        public PaymentStatus Status { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string? Note { get; set; }
        public decimal? RefundedAmount { get; set; }
        public UserPaymentDetail userPaymentDetail { get; set; }
        public ICollection<UserBalanceHistory> Histories { get; set; }

    }
}
