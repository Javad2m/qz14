using QZ14.Contract;
using QZ14.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZ14.Services;

public class ActionServices : IActionServices
{
    ICardRepository _CardRepository;
    ITransactionRepository _TransactionRepository;
    ICardServices cardServices = new CardServices();
    ITransactionServices transactionServices = new TransactionServices();
    public ActionServices()
    {
        _CardRepository = new CardRepository();
        _TransactionRepository = new TransactionRepository();
    }

    public void Transfer(string Fcard, string Scard, float amount)
    {
        if (Fcard.Length < 16 || Fcard.Length > 16)
        {
            throw new Exception("Shomareh Cart Mabda Sahih Nist");
        }
        if (Scard.Length < 16 || Scard.Length > 16)
        {
            throw new Exception("Shomareh Cart Maghsad Sahih Nist");
        }
        var card = _CardRepository.GetByNumber(Fcard);
        if (card.Balance <= 0)
        {
            throw new Exception("Mojodi Kafi Nist");
        }
        var cardd = _CardRepository.GetByNumber(Scard);
        if (cardd == null)
        {
            throw new Exception("Kart Maghsad Motabar Nist");
        }
        if (card.Balance < amount)
        {
            throw new Exception("Mojodi Kafi Nist");
        }

        cardServices.AddBalance(card.CardId, amount);
        cardServices.KasBalance(cardd.CardId, amount);


        transactionServices.CreatT(Fcard, Scard, amount, true);
    }

}
