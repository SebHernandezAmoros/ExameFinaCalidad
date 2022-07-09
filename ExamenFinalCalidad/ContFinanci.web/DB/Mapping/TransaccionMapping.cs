using ContFinanci.web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContFinanci.web.DB.Mapping
{
    public class TransaccionMapping : IEntityTypeConfiguration<Transaccion>
    {
        public void Configure(EntityTypeBuilder<Transaccion> builder)
        {
            builder.ToTable("Transaccion", "dbo");
            builder.HasKey(o => o.TransaccionId);
        }
    }
}
