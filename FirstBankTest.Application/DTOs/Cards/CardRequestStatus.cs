using FirstBankTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBankTest.Application.DTOs.Cards
{
    public class CardRequestStatus
    {
        public class Request
        {
            public Guid RequestId { get; set; }
        }
        public class Response
        {
            public Guid RequestId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Currency { get; set; }
            public string Status { get; set; }
            public string CardType { get; set; }
        }
    }
}
