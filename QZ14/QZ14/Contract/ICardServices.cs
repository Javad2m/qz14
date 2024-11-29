using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZ14.Contract;

public interface ICardServices
{
    public void Login(string carnumber, string password);
    public void AddBalance(int cartid, float amount);
    public void KasBalance(int cartid, float amount);
    public List<Entity.Transaction> STransactions(string cardN);
    public List<Entity.Transaction> RTransactions(string cardN);
}
