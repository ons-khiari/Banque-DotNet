

using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class ExamenContext:DbContext
    {
        public DbSet<Banque> Banques { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<DAB> DABs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
               optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                       Initial Catalog=ExamenImp;
                       Integrated Security=true;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                 .HasKey(t => new
                 {
                     t.DabFK,
                     t.NumeroCompteFk,
                     t.Date
                 });
            modelBuilder.Entity<Transaction>()
                 .HasOne(t=>t.Compte)
                 .WithMany(c=>c.Transactions)
                 .HasForeignKey(t=>t.NumeroCompteFk);

            modelBuilder.Entity<Transaction>()
                 .HasOne(t => t.DAB)
                 .WithMany(c => c.Transactions)
                 .HasForeignKey(t => t.DabFK);

            //TPT
            modelBuilder.Entity<TransactionRetrait>().ToTable("TransactionRetrait");
            modelBuilder.Entity<TransactionTransfert>().ToTable("TransactionTransfert");
        }
    
    }
}
