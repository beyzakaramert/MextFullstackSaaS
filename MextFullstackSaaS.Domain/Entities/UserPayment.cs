using MextFullstackSaaS.Domain.Common;
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
    }
}
