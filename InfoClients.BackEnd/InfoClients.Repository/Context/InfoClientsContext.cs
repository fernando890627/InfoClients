using System;
using System.Linq;
using InfoClients.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InfoClients.Repository
{
    public partial class InfoClientsContext : DbContext,IInfoClientsContext
    {

        public InfoClientsContext(DbContextOptions<InfoClientsContext> options)
    : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<SalePerson> SalePerson { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=P-FSERNA\SQLSERVER2014;Database=InfoClients;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__City__StateId__1B0907CE");
            });

            modelBuilder.Entity<Client>(entity =>
            {

                modelBuilder.Entity<Client>().HasMany(b => b.Visit).WithOne(p => p.Client)
                                .HasForeignKey(p => p.ClientId)
                                .OnDelete(DeleteBehavior.Cascade);


                //modelBuilder.Entity<Client>()
                //.HasMany<Visit>(g => g.Visit)
                //.WithOne(v => v.Client)
                //.IsRequired(true)
                //.OnDelete(DeleteBehavior.Cascade);
                //.WithRequired(s => s.CurrentGrade)
                //.WillCascadeOnDelete();
                //modelBuilder.Entity<Client>()
                //.HasOne(s => s.Visit)
                //.WithMany
                //.OnDelete(DeleteBehavior.SetNull);

               // modelBuilder.Entity<Client>()
               //.HasOptional(c => c.)
               //.WithOptionalDependent()
               //.WillCascadeOnDelete(true);
                //modelBuilder.Entity<Visit>()
                //.HasMany<Child>(c => c.)
                //.WithOptional(x => x.Parent)
                //.WillCascadeOnDelete(true);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.Property(e => e.VisitsPercentage).HasColumnType("decimal(5, 3)");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<SalePerson>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__State__CountryId__1BFD2C07");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                

                //modelBuilder.Entity<Visit>()
                //    .HasOne(i => i.Client)
                //    .WithMany(c => c.Visit)
                //    .IsRequired()
                //    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.VisitTotal).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Visit__ClientId__1DE57479");

                entity.HasOne(d => d.SalePerson)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.SalePersonId)
                    .HasConstraintName("FK__Visit__SalePerso__1CF15040");
            });
            
        }
    }
}
