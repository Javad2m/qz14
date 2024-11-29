using Microsoft.EntityFrameworkCore;
using QZ14.Contract;
using QZ14.DBContex;
using QZ14.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZ14.Repository;

public class CardRepository : ICardRepository
{
    private readonly AppDBContex _appContext;
    public CardRepository()
    {
        _appContext = new AppDBContex();
    }

    public List<Card> GetAll()
    {
        var cards = _appContext.Cards.AsNoTracking().ToList();
        return cards;
    }

    public bool Login(string carnumber, string password)
    {
        var isTrue = _appContext.Cards.Where(l => l.CardNumber == carnumber && l.Password == password).AsNoTracking().Any();

        if (isTrue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public Card GetByNumber(string number)
    {
        var card = _appContext.Cards.AsNoTracking().Where(t => t.CardNumber == number).FirstOrDefault();
        return card;
    }

    public void UpdateA(int cardid, float balance)
    {
        var card = _appContext.Cards.FirstOrDefault(p => p.CardId == cardid);
        card.Balance = card.Balance + balance;
        _appContext.SaveChanges();
    }

    public void Updateb(int cardid, float balance)
    {
        var card = _appContext.Cards.FirstOrDefault(p => p.CardId == cardid);
        card.Balance = card.Balance - balance;
        _appContext.SaveChanges();
    }

    public List<Transaction>? GetSentTransactions(string carnumber)
    {
        var list = _appContext.Transactions.AsNoTracking().Where(t=>t.SourceCardNumber ==carnumber ).ToList();
        return list;
    }

    public List<Transaction>? GetReceivedTransactions(string carnumber)
    {
        var list = _appContext.Transactions.AsNoTracking().Where(t => t.DestinationCardNumber == carnumber).ToList();
        return list;
    }
}
