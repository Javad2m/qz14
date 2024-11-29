using QZ14.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZ14.Contract;

public interface ICardRepository
{
    public bool Login(string carnumber, string password);

    public List<Card> GetAll();

    public Card GetByNumber(string number);

    public void UpdateA(int cardid, float balance);
    public void Updateb(int cardid, float balance);


    public List<Transaction>? GetSentTransactions(string carnumber);

    public List<Transaction>? GetReceivedTransactions(string carnumber);






}
