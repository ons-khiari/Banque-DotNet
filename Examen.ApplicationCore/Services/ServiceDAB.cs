using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ServiceDAB : Service<DAB>
    {
        public ServiceDAB(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public double MontantTotal(DAB dab)
        {
            return dab.Transactions.OfType<TransactionTransfert>().Sum(t => t.Prix);


        }

       

    } }