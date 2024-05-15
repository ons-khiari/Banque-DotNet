using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ServiceCompte : Service<Compte>, IServiceCompte
    {
        public ServiceCompte(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public int GetNumberTransaction(Compte compte)
        {
          return compte.Transactions.Where(t=>(DateTime.Now - t.Date).TotalDays < 7).Count();
        }
        public IEnumerable<TransactionRetrait> GetTransactionRetraits(Compte compte,DateTime StartDate)
        {

            return compte.Transactions.OfType<TransactionRetrait>().Where(t => t.Compte.Type==0 && (t.Date).Equals(StartDate));

        }

    }
}
