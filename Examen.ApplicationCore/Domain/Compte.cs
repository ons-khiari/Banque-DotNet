﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public enum TypeCompte
    {
        Epargne , Courant
    }
    public class Compte
    {
        [Key]
        public string NumeroCompte { get; set; }
        public double Solde { get; set; }
        public TypeCompte Type { get; set; }

        public string Proprietaire { get; set; }
        public virtual int BanqueFk { get; set; }

        [ForeignKey("BanqueFk")]
        public virtual Banque Banque { get; set; }

        public virtual IList<Transaction> Transactions { get; set; }
    }
}
