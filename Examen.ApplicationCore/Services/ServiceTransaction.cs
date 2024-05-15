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
    public class ServiceTransaction : Service<Transaction>, IServiceTransaction
    {
        public ServiceTransaction(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Transaction> GetTransactions(DateTime StartDate)
        {
            return GetMany(t => t.Compte.Type == TypeCompte.Epargne && t.Date == StartDate);
        }
    }
}
