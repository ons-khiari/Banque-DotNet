using AM.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IServiceTransaction:IService<Transaction>
    {
        public IEnumerable<Transaction> GetTransactions(DateTime StartDate);
        

    }
}
