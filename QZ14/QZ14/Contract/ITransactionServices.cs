using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZ14.Contract;

public interface ITransactionServices
{
    public void CreatT(string Fcard, string Scard, float amount, bool isSucces);
}
