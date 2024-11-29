using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZ14.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZ14.Configuration;

public class CardConfig : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(c => c.CardId);

        builder.Property(c => c.CardNumber)
                .IsRequired()
                .HasMaxLength(16);

        builder.HasIndex(c => c.CardNumber)
        .IsUnique();

        
       
    }
}
