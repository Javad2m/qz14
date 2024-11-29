using QZ14.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZ14.Contract;

public interface ITransactionRepository
{
    public void Create(Transaction transaction);
    

    
}
