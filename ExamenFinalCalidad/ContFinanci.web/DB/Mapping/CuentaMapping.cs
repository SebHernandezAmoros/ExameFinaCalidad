using ContFinanci.web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContFinanci.web.DB.Mapping
{
    public class CuentaMapping : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.ToTable("Cuenta", "dbo");
            builder.HasKey(o => o.CuentaId);
        }
    }
}
