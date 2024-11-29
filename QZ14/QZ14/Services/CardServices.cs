using QZ14.Contract;
using QZ14.Entity;
using QZ14.InMemory;
using QZ14.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZ14.Services;

public class CardServices : ICardServices
{
    ICardRepository _CardRepository;
    public CardServices()
    {
        _CardRepository = new CardRepository();
    }

    public void Login(string carnumber, string password)
    {
        try
        {
            var card = _CardRepository.GetAll().FirstOrDefault(u => u.CardNumber == carnumber && u.Password == password);

            if (card == null)
            {
                throw new Exception("Invalid CardNumber or password.");
            }
            else
            {
                InMemoryDB.CurrentCard = card;

            }
        }
        catch (Exception ex) { throw new Exception($"Error : {ex.Message}", ex); }
    }


    public void AddBalance(int cartid , float amount)
    {
        _CardRepository.UpdateA(cartid, amount);

    }

    public void KasBalance(int cartid, float amount)
    {
        _CardRepository.Updateb(cartid, amount);

    }


    public List<Transaction> STransactions(string cardN)
    {
        var lisr = _CardRepository.GetSentTransactions(cardN);
        return lisr;
    }

    public List<Transaction> RTransactions(string cardN)
    {
        var lisr = _CardRepository.GetReceivedTransactions(cardN);
        return lisr;
    }
}
