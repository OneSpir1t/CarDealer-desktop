using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarDealer_desktop.Models
{
    public partial class CDContext : DbContext
    {
        public CDContext()
        {
        }
        public static CDContext cdContext { get; set; } = new CDContext();
        

        public CDContext(DbContextOptions<CDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvailableCar> AvailableCars { get; set; } = null!;
        public virtual DbSet<Bodytype> Bodytypes { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Callrequest> Callrequests { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Drivetype> Drivetypes { get; set; } = null!;
        public virtual DbSet<Enginetype> Enginetypes { get; set; } = null!;
        public virtual DbSet<Equipment> Equipments { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Technicalinformation> Technicalinformations { get; set; } = null!;
        public virtual DbSet<Transmission> Transmissions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=cardealer;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));
                optionsBuilder.UseLazyLoadingProxies(true);
                    
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<AvailableCar>(entity =>
            {
                entity.ToTable("available_cars");

                entity.HasIndex(e => e.EquipmentId, "FK_AvailbleCars_Equipments_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

                entity.Property(e => e.MileAge).HasMaxLength(45);

                entity.Property(e => e.Vin)
                    .HasMaxLength(17)
                    .HasColumnName("VIN");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.AvailableCars)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AvailbleCars_Equipments");
            });

            modelBuilder.Entity<Bodytype>(entity =>
            {
                entity.ToTable("bodytypes");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(155);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brands");

                entity.HasIndex(e => e.CountryId, "FK_Brands_Countries");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Brands)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brands_Countries");
            });

            modelBuilder.Entity<Callrequest>(entity =>
            {
                entity.ToTable("callrequests");

                entity.HasIndex(e => e.AvailableCarId, "FK_CallRequests_AvailableCar_idx");

                entity.HasIndex(e => e.BuyerId, "FK_CallRequests_Buyers_idx");

                entity.HasIndex(e => e.EquipmentId, "FK_CallRequests_Equipments_idx");

                entity.HasIndex(e => e.ManagerId, "FK_CallRequests_Managers_idx");

                entity.HasIndex(e => e.StatusId, "FK_CallRequests_Statuses_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AvailableCarId).HasColumnName("AvailableCarID");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.AvailableCar)
                    .WithMany(p => p.Callrequests)
                    .HasForeignKey(d => d.AvailableCarId)
                    .HasConstraintName("FK_CallRequests_AvailableCar");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.CallrequestBuyers)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CallRequests_Buyers");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.Callrequests)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CallRequests_Equipments");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.CallrequestManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CallRequests_Managers");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Callrequests)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CallRequests_Statuses");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("colors");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(150);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .HasMaxLength(155)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Drivetype>(entity =>
            {
                entity.ToTable("drivetype");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Enginetype>(entity =>
            {
                entity.ToTable("enginetypes");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(150);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("equipments");

                entity.HasIndex(e => e.ModelId, "FK_Equipments_Models");

                entity.HasIndex(e => e.TechnicalInformationId, "FK_Equipments_TechnicalInformation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.TechnicalInformationId).HasColumnName("TechnicalInformationID");

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Equipments_Models");

                entity.HasOne(d => d.TechnicalInformation)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.TechnicalInformationId)
                    .HasConstraintName("FK_Equipments_TechnicalInformation");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("models");

                entity.HasIndex(e => e.BrandId, "FK_Models_Brands");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.Description).HasMaxLength(800);

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.Property(e => e.Video).HasMaxLength(150);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Models_Brands");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.BuyerId, "FK_CallRequests_Buyers_idx");

                entity.HasIndex(e => e.AvailableCarId, "FK_Orders_AvailableCars_idx");

                entity.HasIndex(e => e.EquipmentId, "FK_Orders_Equipments");

                entity.HasIndex(e => e.ManagerId, "FK_Orders_Users_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AvailableCarId).HasColumnName("AvailableCarID");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.HasOne(d => d.AvailableCar)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AvailableCarId)
                    .HasConstraintName("FK_Orders_AvailableCars");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.OrderBuyers)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_Buyer");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EquipmentId)
                    .HasConstraintName("FK_Orders_Equipments");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.OrderManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_Manager");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("statuses");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(70);
            });

            modelBuilder.Entity<Technicalinformation>(entity =>
            {
                entity.ToTable("technicalinformation");

                entity.HasIndex(e => e.BodyTypeId, "FK_TechnicalInformation_BodyTypes");

                entity.HasIndex(e => e.ColorId, "FK_TechnicalInformation_Colors");

                entity.HasIndex(e => e.DriveTypeId, "FK_TechnicalInformation_DriveType_idx");

                entity.HasIndex(e => e.EngineTypeId, "FK_TechnicalInformation_EngineTypes");

                entity.HasIndex(e => e.TransmissionId, "FK_TechnicalInformation_Transmission_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BodyTypeId).HasColumnName("BodyTypeID");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.DriveTypeId).HasColumnName("DriveTypeID");

                entity.Property(e => e.EngineTypeId).HasColumnName("EngineTypeID");

                entity.Property(e => e.Enginedisplacement).HasMaxLength(20);

                entity.Property(e => e.TransmissionId).HasColumnName("TransmissionID");

                entity.Property(e => e.Yearofmanufacture).HasMaxLength(100);

                entity.HasOne(d => d.BodyType)
                    .WithMany(p => p.Technicalinformations)
                    .HasForeignKey(d => d.BodyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechnicalInformation_BodyTypes");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Technicalinformations)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechnicalInformation_Colors");

                entity.HasOne(d => d.DriveType)
                    .WithMany(p => p.Technicalinformations)
                    .HasForeignKey(d => d.DriveTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechnicalInformation_DriveType");

                entity.HasOne(d => d.EngineType)
                    .WithMany(p => p.Technicalinformations)
                    .HasForeignKey(d => d.EngineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechnicalInformation_EngineTypes");

                entity.HasOne(d => d.Transmission)
                    .WithMany(p => p.Technicalinformations)
                    .HasForeignKey(d => d.TransmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechnicalInformation_Transmission");
            });

            modelBuilder.Entity<Transmission>(entity =>
            {
                entity.ToTable("transmissions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(60);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.UserRoleId, "FK_Users_UserRole_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.Login).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Patronymic).HasMaxLength(150);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UserRole");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(70);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
