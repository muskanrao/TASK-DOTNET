using System;
using System.Collections.Generic;

namespace BankDbProject.Models;

public partial class SbaccountM
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public decimal? CurrentBalance { get; set; }

    public virtual ICollection<SbtransactionM> SbtransactionMs { get; set; } = new List<SbtransactionM>();
}
