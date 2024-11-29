using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZ14.Entity;

public class Transaction
{
    public int TransactionId { get; set; }
    public string SourceCardNumber { get; set; }
    public string DestinationCardNumber { get; set; }
    public float Amount { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.Now;
    public bool isSuccessful { get; set; }
}
