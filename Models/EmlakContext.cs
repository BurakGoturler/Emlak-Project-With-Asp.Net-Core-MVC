using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Emlak.Models;

public partial class EmlakContext : DbContext
{
    public EmlakContext()
    {
    }

    public EmlakContext(DbContextOptions<EmlakContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Durum> Durums { get; set; }

    public virtual DbSet<Ilan> Ilans { get; set; }

    public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }

    public virtual DbSet<Mahalle> Mahalles { get; set; }

    public virtual DbSet<Resim> Resims { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sehir> Sehirs { get; set; }

    public virtual DbSet<Semt> Semts { get; set; }

    public virtual DbSet<SoruCevap> SoruCevaps { get; set; }

    public virtual DbSet<Tip> Tips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Durum>(entity =>
        {
            entity.ToTable("Durum");

            entity.Property(e => e.Durum1)
                .HasMaxLength(50)
                .HasColumnName("Durum");
        });

        modelBuilder.Entity<Ilan>(entity =>
        {
            entity.ToTable("Ilan");

            entity.Property(e => e.Aciklama).HasMaxLength(200);
            entity.Property(e => e.Adres).HasMaxLength(200);
            entity.Property(e => e.Tarih).HasColumnType("date");
            entity.Property(e => e.Telefon).HasMaxLength(11);

            entity.HasOne(d => d.DurumNavigation).WithMany(p => p.Ilans)
                .HasForeignKey(d => d.Durum)
                .HasConstraintName("FK_Ilan_Durum");

            entity.HasOne(d => d.MahalleNavigation).WithMany(p => p.Ilans)
                .HasForeignKey(d => d.Mahalle)
                .HasConstraintName("FK_Ilan_Mahalle");

            entity.HasOne(d => d.SehirNavigation).WithMany(p => p.Ilans)
                .HasForeignKey(d => d.Sehir)
                .HasConstraintName("FK_Ilan_Sehir");

            entity.HasOne(d => d.SemtNavigation).WithMany(p => p.Ilans)
                .HasForeignKey(d => d.Semt)
                .HasConstraintName("FK_Ilan_Semt");

            entity.HasOne(d => d.TipNavigation).WithMany(p => p.Ilans)
                .HasForeignKey(d => d.Tip)
                .HasConstraintName("FK_Ilan_Tip");
        });

        modelBuilder.Entity<Kullanicilar>(entity =>
        {
            entity.ToTable("Kullanicilar");

            entity.Property(e => e.Ad).HasMaxLength(50);
            entity.Property(e => e.KullaniciAdi).HasMaxLength(50);
            entity.Property(e => e.Sifre).HasMaxLength(50);
            entity.Property(e => e.Soyad).HasMaxLength(50);

            entity.HasOne(d => d.Rol).WithMany(p => p.Kullanicilars)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK_Kullanicilar_Rol1");
        });

        modelBuilder.Entity<Mahalle>(entity =>
        {
            entity.ToTable("Mahalle");

            entity.Property(e => e.Ad).HasMaxLength(50);
        });

        modelBuilder.Entity<Resim>(entity =>
        {
            entity.ToTable("Resim");

            entity.Property(e => e.Resim1)
                .HasColumnType("text")
                .HasColumnName("Resim");

            entity.HasOne(d => d.Ilan).WithMany(p => p.Resims)
                .HasForeignKey(d => d.IlanId)
                .HasConstraintName("FK_Resim_Ilan");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("Rol");

            entity.Property(e => e.Ad).HasMaxLength(15);
        });

        modelBuilder.Entity<Sehir>(entity =>
        {
            entity.ToTable("Sehir");

            entity.Property(e => e.Ad).HasMaxLength(50);
        });

        modelBuilder.Entity<Semt>(entity =>
        {
            entity.ToTable("Semt");

            entity.Property(e => e.Ad).HasMaxLength(50);
        });

        modelBuilder.Entity<SoruCevap>(entity =>
        {
            entity.ToTable("SoruCevap");

            entity.Property(e => e.Ad).HasMaxLength(50);
            entity.Property(e => e.Tarih).HasColumnType("date");
        });

        modelBuilder.Entity<Tip>(entity =>
        {
            entity.ToTable("Tip");

            entity.Property(e => e.Tip1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Tip");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
