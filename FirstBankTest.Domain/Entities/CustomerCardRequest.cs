using FirstBankTest.Domain.Common;
using FirstBankTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBankTest.Domain.Entities
{
    public class CustomerCardRequest : AuditableBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public Currency Currency { get; set; }
        public Status Status { get; set; }
        public AccountType AccountType { get; set; }
        public CardType CardType { get; set; }
    }
}
