using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankDbProject.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<SbaccountM> SbaccountMs { get; set; }

    public virtual DbSet<SbtransactionM> SbtransactionMs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SbaccountM>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__SBAccoun__BE2ACD6EF2F6C82C");

            entity.ToTable("SBAccount_m");

            entity.Property(e => e.AccountNumber).ValueGeneratedNever();
            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(22)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(22)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SbtransactionM>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__SBTransa__55433A6B7745C23A");

            entity.ToTable("SBTransaction_m");

            entity.Property(e => e.TransactionId).ValueGeneratedNever();
            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.SbtransactionMs)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK__SBTransac__Accou__2334397B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
