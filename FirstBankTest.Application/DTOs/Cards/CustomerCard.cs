using FirstBankTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBankTest.Application.DTOs.Cards
{
    public class CustomerCard
    {
        public class Request
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string DOB { get; set; }
            public Currency Currency { get; set; }
            public AccountType AccountType { get; set; }
            public CardType CardType { get; set; }
        }
        public class Response
        {
            public Guid RequestId { get; set; }
        }
    }
}
