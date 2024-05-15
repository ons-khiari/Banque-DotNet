using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public double Prix { get; set; }
        public virtual string DabFK { get; set; }
        public virtual string NumeroCompteFk { get; set; }

        [ForeignKey("NumeroCompteFk")]
        public virtual Compte Compte { get; set; }
        [ForeignKey("DabFK")]
        public virtual DAB DAB { get; set; }
    }
}
