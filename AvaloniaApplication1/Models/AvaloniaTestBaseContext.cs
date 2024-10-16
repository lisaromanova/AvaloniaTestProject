using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.Models;

public partial class AvaloniaTestBaseContext : DbContext
{
    public AvaloniaTestBaseContext()
    {
    }

    public AvaloniaTestBaseContext(DbContextOptions<AvaloniaTestBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Clientservice> Clientservices { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Servicephoto> Servicephotos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ngknn.ru;Port=5442;Database=AvaloniaTestBase;Username=Romanova;Password=9*EV6!mSZX^b");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pkey");

            entity.ToTable("client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Gendercode)
                .HasMaxLength(1)
                .HasColumnName("gendercode");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Photopath)
                .HasMaxLength(1000)
                .HasColumnName("photopath");
            entity.Property(e => e.Registrationdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("registrationdate");

            entity.HasOne(d => d.GendercodeNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Gendercode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_gendercode_fkey");
        });

        modelBuilder.Entity<Clientservice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clientservice_pkey");

            entity.ToTable("clientservice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Comment)
                .HasMaxLength(1000)
                .HasColumnName("comment");
            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Starttime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("starttime");

            entity.HasOne(d => d.Client).WithMany(p => p.Clientservices)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientservice_clientid_fkey");

            entity.HasOne(d => d.Service).WithMany(p => p.Clientservices)
                .HasForeignKey(d => d.Serviceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientservice_serviceid_fkey");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("gender_pkey");

            entity.ToTable("gender");

            entity.Property(e => e.Code)
                .HasMaxLength(1)
                .ValueGeneratedNever()
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("service_pkey");

            entity.ToTable("service");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Durationinseconds).HasColumnName("durationinseconds");
            entity.Property(e => e.Mainimagepath)
                .HasMaxLength(1000)
                .HasColumnName("mainimagepath");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Servicephoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("servicephoto_pkey");

            entity.ToTable("servicephoto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Photopath)
                .HasMaxLength(1000)
                .HasColumnName("photopath");
            entity.Property(e => e.Serviceid).HasColumnName("serviceid");

            entity.HasOne(d => d.Service).WithMany(p => p.Servicephotos)
                .HasForeignKey(d => d.Serviceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("servicephoto_serviceid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
