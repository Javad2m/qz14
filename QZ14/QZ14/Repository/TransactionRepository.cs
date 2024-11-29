using QZ14.Contract;
using QZ14.DBContex;
using QZ14.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZ14.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDBContex _appContext;
    public TransactionRepository()
    {
        _appContext = new AppDBContex();
    }
    public void Create(Transaction transaction)
    {
        _appContext.Transactions.Add(transaction);
        _appContext.SaveChanges();
    }
}
