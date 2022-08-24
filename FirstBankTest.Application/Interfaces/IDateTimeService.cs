using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBankTest.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
