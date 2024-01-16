using System;
using System.Collections.Generic;

namespace BankDbProject.Models;

public partial class SbtransactionM
{
    public int TransactionId { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public int? AccountNumber { get; set; }

    public decimal? CurrentBalance { get; set; }

    public virtual SbaccountM? AccountNumberNavigation { get; set; }
}
