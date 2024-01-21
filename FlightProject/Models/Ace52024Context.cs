using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AirlineM> AirlineMs { get; set; }

    public virtual DbSet<AirportM> AirportMs { get; set; }

    public virtual DbSet<BookingsDetailM> BookingsDetailMs { get; set; }

    public virtual DbSet<CustomersM> CustomersMs { get; set; }

    public virtual DbSet<FlightsDetailM> FlightsDetailMs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AirlineM>(entity =>
        {
            entity.HasKey(e => e.AirlineId).HasName("PK__Airline___DC458213F5BED0D0");

            entity.ToTable("Airline_m");

            entity.Property(e => e.AirlineName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AirportM>(entity =>
        {
            entity.HasKey(e => e.AirportId).HasName("PK__Airport___E3DBE0EA12C0B01F");

            entity.ToTable("Airport_m");

            entity.Property(e => e.AirportName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BookingsDetailM>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951AEDDD1B074D");

            entity.ToTable("BookingsDetail_m");

            entity.Property(e => e.Cid).HasColumnName("CId");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.BookingsDetailMs)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__BookingsDet__CId__4E0988E7");

            entity.HasOne(d => d.Flight).WithMany(p => p.BookingsDetailMs)
                .HasForeignKey(d => d.FlightId)
                .HasConstraintName("FK__BookingsD__Fligh__4EFDAD20");
        });

        modelBuilder.Entity<CustomersM>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Customer__C1F8DC3966B5099A");

            entity.ToTable("Customers_m");

            entity.Property(e => e.Cid).HasColumnName("CId");
            entity.Property(e => e.Cemail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cpassword)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FlightsDetailM>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__FlightsD__8A9E14EE24D81194");

            entity.ToTable("FlightsDetail_m");

            entity.Property(e => e.Atime).HasColumnType("datetime");
            entity.Property(e => e.Dtime).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Airline).WithMany(p => p.FlightsDetailMs)
                .HasForeignKey(d => d.AirlineId)
                .HasConstraintName("FK__FlightsDe__Airli__4944D3CA");

            entity.HasOne(d => d.DestAirport).WithMany(p => p.FlightsDetailMDestAirports)
                .HasForeignKey(d => d.DestAirportId)
                .HasConstraintName("FK__FlightsDe__DestA__4B2D1C3C");

            entity.HasOne(d => d.SourceAirport).WithMany(p => p.FlightsDetailMSourceAirports)
                .HasForeignKey(d => d.SourceAirportId)
                .HasConstraintName("FK__FlightsDe__Sourc__4A38F803");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
