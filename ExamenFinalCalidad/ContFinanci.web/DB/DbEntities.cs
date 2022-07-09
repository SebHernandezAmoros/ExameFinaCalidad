using ContFinanci.web.DB.Mapping;
using ContFinanci.web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContFinanci.web.DB
{
    public class DbEntities : DbContext
    {
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Transaccion> Transaccions { get; set; }
        public virtual DbSet<TipoCambio> TipoCambios { get; set; }
        public DbEntities() { }
        public DbEntities(DbContextOptions<DbEntities> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CuentaMapping());
            modelBuilder.ApplyConfiguration(new TransaccionMapping());
            modelBuilder.ApplyConfiguration(new TipoCambioMapping());
        }
    }
}
