using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZ14.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZ14.Configuration;

public class TransactionConfig : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.TransactionId);

        builder.Property(t => t.SourceCardNumber)
        .IsRequired()
        .HasMaxLength(16);

        builder.Property(t => t.DestinationCardNumber)
        .IsRequired()
        .HasMaxLength(16);

        builder.HasOne<Card>()
        .WithMany(c => c.SentTransactions)
        .HasForeignKey(t => t.SourceCardNumber)
        .HasPrincipalKey(c => c.CardNumber)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Card>()
        .WithMany(c => c.ReceivedTransactions)
        .HasForeignKey(t => t.DestinationCardNumber)
        .HasPrincipalKey(c => c.CardNumber)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
