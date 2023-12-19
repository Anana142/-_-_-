using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.DataBase;

public partial class TradeContext : DbContext
{
    public TradeContext()
    {
    }

    public TradeContext(DbContextOptions<TradeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Name> Names { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<PickupPoint> PickupPoints { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost;database=Trade;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.ToTable("Manufacturer");

            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Name>(entity =>
        {
            entity.ToTable("Name");

            entity.Property(e => e.NameId).HasColumnName("NameID");
            entity.Property(e => e.NameTitle)
                .HasMaxLength(80)
                .IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAF4078074F");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderDeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.OrderOrderData).HasColumnType("datetime");
            entity.Property(e => e.OrderPickupPointId).HasColumnName("OrderPickupPointID");
            entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");
            entity.Property(e => e.OrderUserId).HasColumnName("OrderUserID");

            entity.HasOne(d => d.OrderPickupPoint).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderPickupPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_PickupPoint1");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Status");

            entity.HasOne(d => d.OrderUser).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderUserId)
                .HasConstraintName("FK_Order_User");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductArticleNumber }).HasName("PK__OrderPro__817A266211F06D7E");

            entity.ToTable("OrderProduct");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductArticleNumber).HasMaxLength(100);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderProd__Order__403A8C7D");

            entity.HasOne(d => d.ProductArticleNumberNavigation).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductArticleNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderProd__Produ__412EB0B6");
        });

        modelBuilder.Entity<PickupPoint>(entity =>
        {
            entity.HasKey(e => e.PickupPointId).HasName("PK_PickupPoint_1");

            entity.ToTable("PickupPoint");

            entity.Property(e => e.PickupPointId).HasColumnName("PickupPointID");
            entity.Property(e => e.PickupPointHouseId).HasColumnName("PickupPointHouseID");

            entity.HasOne(d => d.PickupPointCity).WithMany(p => p.PickupPoints)
                .HasForeignKey(d => d.PickupPointCityId)
                .HasConstraintName("FK_PickupPoint_City1");

            entity.HasOne(d => d.PickupPointStreet).WithMany(p => p.PickupPoints)
                .HasForeignKey(d => d.PickupPointStreetId)
                .HasConstraintName("FK_PickupPoint_Street1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductArticleNumber).HasName("PK__Product__2EA7DCD55ECCEF86");

            entity.ToTable("Product");

            entity.Property(e => e.ProductArticleNumber).HasMaxLength(100);
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ProductCost).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.ProductManufacturerId).HasColumnName("ProductManufacturerID");
            entity.Property(e => e.ProductNameId).HasColumnName("ProductNameID");
            entity.Property(e => e.ProductPhoto).HasColumnType("image");
            entity.Property(e => e.ProductProviderId).HasColumnName("ProductProviderID");
            entity.Property(e => e.ProductUnitId).HasColumnName("ProductUnitID");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.ProductManufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Manufacturer");

            entity.HasOne(d => d.ProductName).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Name");

            entity.HasOne(d => d.ProductProvider).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Provider");

            entity.HasOne(d => d.ProductUnit).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Unit");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.ToTable("Provider");

            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.ProviderName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A85A35802");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.ToTable("Street");

            entity.Property(e => e.StreetId).HasColumnName("StreetID");
            entity.Property(e => e.StreetName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("Unit");

            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UnitName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC656A7E14");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserPatronymic).HasMaxLength(100);
            entity.Property(e => e.UserSurname).HasMaxLength(100);

            entity.HasOne(d => d.UserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__UserRole__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
