using ContFinanci.web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContFinanci.web.DB.Mapping
{
    public class TipoCambioMapping : IEntityTypeConfiguration<TipoCambio>
    {
        public void Configure(EntityTypeBuilder<TipoCambio> builder)
        {
            builder.ToTable("TipoCambio", "dbo");
            builder.HasKey(o => o.TipoCambioId);
        }
    }
}
