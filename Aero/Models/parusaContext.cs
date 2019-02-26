using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading;
using System.Data.SqlClient;

namespace Aero.Models
{
    public partial class parusaContext : DbContext
    {
        public virtual DbSet<Airports> Airports { get; set; }
        public virtual DbSet<Bonus> Bonus { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<FlightsInOrder> FlightsInOrder { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Planes> Planes { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
             optionsBuilder.UseSqlServer(@"Data Source=webparusa.database.windows.net;Initial Catalog=parusa;User ID=parusAdmin;Password=440827dimaS;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
         }
        //public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airports>(entity =>
            {
                entity.ToTable("airports");

                entity.HasIndex(e => e.CreatedAt)
                    .HasName("createdAt");

                entity.HasIndex(e => e.Iatacode)
                    .HasName("IATACode");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("CONVERT([nvarchar](255),newid(),(0))");

                entity.Property(e => e.CityId)
                    .HasColumnName("cityID")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetimeoffset(3)")
                    .HasDefaultValueSql("CONVERT([datetimeoffset](3),sysutcdatetime(),(0))");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Iatacode)
                    .HasColumnName("IATACode")
                    .HasMaxLength(450);

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Airports)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_airports_cities");
            });

            modelBuilder.Entity<Bonus>(entity =>
            {
                entity.HasIndex(e => e.CreatedAt)
                    .HasName("createdAt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("CONVERT([nvarchar](255),newid(),(0))");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetimeoffset(3)")
                    .HasDefaultValueSql("CONVERT([datetimeoffset](3),sysutcdatetime(),(0))");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Descript).HasColumnName("descript");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.PathImage)
                    .HasColumnName("pathImage")
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.ToTable("cities");

                entity.HasIndex(e => e.CreatedAt)
                    .HasName("createdAt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("CONVERT([nvarchar](255),newid(),(0))");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetimeoffset(3)")
                    .HasDefaultValueSql("CONVERT([datetimeoffset](3),sysutcdatetime(),(0))");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IdCountry)
                    .HasColumnName("idCountry")
                    .HasMaxLength(255);

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_cities_countries");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.ToTable("clients");

                entity.HasIndex(e => e.CreatedAt)
                    .HasName("createdAt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("CONVERT([nvarchar](255),newid(),(0))");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birthDate")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetimeoffset(3)")
                    .HasDefaultValueSql("CONVERT([datetimeoffset](3),sysutcdatetime(),(0))");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasMaxLength(255);

                entity.Property(e => e.NumbPassport).HasColumnName("numbPassport");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_clients_users");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.ToTable("countries");

                entity.HasIndex(e => e.CreatedAt)
                    .HasName("createdAt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("CONVERT([nvarchar](255),newid(),(0))");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetimeoffset(3)")
                    .HasDefaultValueSql("CONVERT([datetimeoffset](3),sysutcdatetime(),(0))");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Flights>(entity =>
            {
                entity.ToTable("flights");

                entity.HasIndex(e => e.CreatedAt)
                    .HasName("createdAt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("CONVERT([nvarchar](255),newid(),(0))");

                entity.Property(e => e.BonusId)
                    .HasColumnName("bonusID")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetimeoffset(3)")
                    .HasDefaultValueSql("CONVERT([datetimeoffset](3),sysutcdatetime(),(0))");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PlaneId)
                    .HasColumnName("planeID")
                    .HasMaxLength(255);

                entity.Property(e => e.Port1)
                    .HasColumnName("port1")
                    .HasMaxLength(255);

                entity.Property(e => e.Port2)
                    .HasColumnName("port2")
                    .HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.StatusId)
                    .HasColumnName("statusID")
                    .HasMaxLength(255);

                entity.Property(e => e.Time1)
                    .HasColumnName("time1")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.Time2)
                    .HasColumnName("time2")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.Bonus)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.BonusId)
                    .HasConstraintName("FK_flights_Bonus");

                entity.HasOne(d => d.Plane)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.PlaneId)
                    .HasConstraintName("FK_flights_planes");

                entity.HasOne(d => d.Port1Navigation)
                    .WithMany(p => p.FlightsPort1Navigation)
                    .HasForeignKey(d => d.Port1)
                    .HasConstraintName("FK_flights_airports");

                entity.HasOne(d => d.Port2Navigation)
                    .WithMany(p => p.FlightsPort2Navigation)
                    .HasForeignKey(d => d.Port2)
                    .HasConstraintName("FK_flights_airports1");
            });

            modelBuilder.Entity<FlightsInOrder>(entity =>
            {
                entity.ToTable("flightsInOrder");

                entity.HasIndex(e => e.CreatedAt)
                    .HasName("createdAt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("CONVERT([nvarchar](255),newid(),(0))");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetimeoffset(3)")
                    .HasDefaultValueSql("CONVERT([datetimeoffset](3),sysutcdatetime(),(0))");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FlightId)
                    .HasColumnName("flightID")
                    .HasMaxLength(255);

                entity.Property(e => e.OrderId)
                    .HasColumnName("orderID")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.FlightsInOrder)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK_flightsInOrder_flights");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.FlightsInOrder)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_flightsInOrder_order");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.CreatedAt)
                    .HasName("createdAt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("CONVERT([nvarchar](255),newid(),(0))");

                entity.Property(e => e.ClientId)
                    .HasColumnName("clientID")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetimeoffset(3)")
                    .HasDefaultValueSql("CONVERT([datetimeoffset](3),sysutcdatetime(),(0))");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_order_clients");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_order_status");
            });

            modelBuilder.Entity<Planes>(entity =>
            {
                entity.ToTable("planes");

                entity.HasIndex(e => e.CreatedAt)
                    .HasName("createdAt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("CONVERT([nvarchar](255),newid(),(0))");

                entity.Property(e => e.BortNumber).HasColumnName("bortNumber");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetimeoffset(3)")
                    .HasDefaultValueSql("CONVERT([datetimeoffset](3),sysutcdatetime(),(0))");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.HasIndex(e => e.CreatedAt)
                    .HasName("createdAt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("CONVERT([nvarchar](255),newid(),(0))");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetimeoffset(3)")
                    .HasDefaultValueSql("CONVERT([datetimeoffset](3),sysutcdatetime(),(0))");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.CreatedAt)
                    .HasName("createdAt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("CONVERT([nvarchar](255),newid(),(0))");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetimeoffset(3)")
                    .HasDefaultValueSql("CONVERT([datetimeoffset](3),sysutcdatetime(),(0))");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.FName).HasColumnName("fName");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.SName).HasColumnName("sName");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetimeoffset(3)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}