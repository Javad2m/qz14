using QZ14.Contract;
using QZ14.Entity;
using QZ14.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QZ14.Services;

public class TransactionServices : ITransactionServices
{
    ITransactionRepository _TransactionRepository;
    public TransactionServices()
    {
        _TransactionRepository = new TransactionRepository();
    }
    public void CreatT(string Fcard, string Scard, float amount, bool isSucces)
    {
        try
        {

            var tra = new Entity.Transaction
            {
                SourceCardNumber = Fcard,
                DestinationCardNumber = Scard,
                Amount = amount,
                isSuccessful = isSucces

            };
            _TransactionRepository.Create(tra);


        }

        catch (Exception ex)
        {
            throw new Exception($"Error : {ex.Message}", ex);
        }
    }
}
