using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorMilk.Models;

namespace BlazorMilk.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<detailofproductmaterial> detailofproductmaterial { get; set; } = null!;
        public virtual DbSet<material> material { get; set; } = null!;
        public virtual DbSet<orderdetail> orderdetail { get; set; } = null!;
        public virtual DbSet<ordervendor> ordervendor { get; set; } = null!;
        public virtual DbSet<product> product { get; set; } = null!;
        public virtual DbSet<vendor> vendor { get; set; } = null!;
        /*---*/
        public virtual DbSet<client> client { get; set; } = null!;
        public virtual DbSet<vproductscount> vproductscount { get; set; } = null!;
        public virtual DbSet<vtotalproduct> vtotalproduct { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<client>(entity =>
            {
                entity.HasKey(e => e.idClient)
                    .HasName("PRIMARY");

                entity.Property(e => e.login).HasMaxLength(45);

                entity.Property(e => e.password).HasMaxLength(45);
            });

            modelBuilder.Entity<detailofproductmaterial>(entity =>
            {
                entity.HasKey(e => new { e.idMaterial, e.idOrderDetails, e.idProduct })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("detailofproductmaterial");

                entity.HasIndex(e => e.idMaterial, "fk_material_has_orderdetails_material1_idx");

                entity.HasIndex(e => e.idOrderDetails, "fk_material_has_orderdetails_orderdetails1_idx");

                entity.HasIndex(e => e.idProduct, "fk_materialoforder_product1_idx");

                entity.HasOne(d => d.idMaterialNavigation)
                    .WithMany(p => p.detailofproductmaterials)
                    .HasForeignKey(d => d.idMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_material_has_orderdetails_material1");

                entity.HasOne(d => d.idOrderDetailsNavigation)
                    .WithMany(p => p.detailofproductmaterials)
                    .HasForeignKey(d => d.idOrderDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_material_has_orderdetails_orderdetails1");

                entity.HasOne(d => d.idProductNavigation)
                    .WithMany(p => p.detailofproductmaterials)
                    .HasForeignKey(d => d.idProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_materialoforder_product1");
            });

            modelBuilder.Entity<material>(entity =>
            {
                entity.HasKey(e => e.idMaterial)
                    .HasName("PRIMARY");

                entity.ToTable("material");

                entity.HasComment("Материал")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.idMaterial).HasComment("Идентификатор материала");

                entity.Property(e => e.codeMaterial)
                    .HasMaxLength(50)
                    .HasComment("Код материала");

                entity.Property(e => e.countMaterial).HasComment("Количество материала");

                entity.Property(e => e.nameMaterial)
                    .HasMaxLength(60)
                    .HasComment("Название материала");

                entity.Property(e => e.priceMaterial).HasComment("Цена материала");

                entity.Property(e => e.systemMaterial)
                    .HasMaxLength(5)
                    .HasComment("Система счисления материала (кг, г)");
            });

            modelBuilder.Entity<orderdetail>(entity =>
            {
                entity.HasKey(e => e.idOrderDetails)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.idOrder, "fk_orderdetails_ordervendor1_idx");

                entity.Property(e => e.nameProduct).HasMaxLength(45);

                entity.Property(e => e.systemProduct).HasMaxLength(5);

                entity.HasOne(d => d.idOrderNavigation)
                    .WithMany(p => p.orderdetails)
                    .HasForeignKey(d => d.idOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderdetails_ordervendor1");
            });

            modelBuilder.Entity<ordervendor>(entity =>
            {
                entity.HasKey(e => e.idOrder)
                    .HasName("PRIMARY");

                entity.ToTable("ordervendor");

                entity.HasComment("Заказ от вендора")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.idVendor, "fk_Order_Vendor1_idx");

                entity.Property(e => e.customer)
                    .HasMaxLength(50)
                    .HasComment("Заказчик");

                entity.Property(e => e.executor)
                    .HasMaxLength(50)
                    .HasComment("Исполнитель");

                entity.Property(e => e.idVendor)
                    .HasMaxLength(9)
                    .HasComment("Айди вендора")
                    .UseCollation("utf8mb4_bin");

                entity.Property(e => e.total).HasComment("Итого");

                entity.HasOne(d => d.idVendorNavigation)
                    .WithMany(p => p.ordervendors)
                    .HasForeignKey(d => d.idVendor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Order_Vendor1");
            });

            modelBuilder.Entity<product>(entity =>
            {
                entity.HasKey(e => e.idProduct)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.HasComment("Продукт")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.idProduct).HasComment("Идентификатор продукта");

                entity.Property(e => e.codeProduct)
                    .HasMaxLength(50)
                    .HasComment("Код продукта");

                entity.Property(e => e.countProduct).HasComment("Количество продукта");

                entity.Property(e => e.nameProduct)
                    .HasMaxLength(60)
                    .HasComment("Название продукта");

                entity.Property(e => e.percentProduct).HasComment("Процент продукта (Сметана 15%)");

                entity.Property(e => e.priceProduct).HasComment("Цена продукта");

                entity.Property(e => e.systemProduct)
                    .HasMaxLength(5)
                    .HasComment("Система счисления продукта (кг, г)");

                entity.Property(e => e.weightProduct).HasComment("Вес продукта");
            });

            modelBuilder.Entity<vendor>(entity =>
            {
                entity.ToTable("vendor");

                entity.HasComment("Вендор (заинтересованные лица)")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.id)
                    .HasMaxLength(9)
                    .HasComment("Идентификатор в строковом виде")
                    .UseCollation("utf8mb4_bin");

                entity.Property(e => e.addressVendor)
                    .HasMaxLength(50)
                    .HasComment("Адрес вендора ");

                entity.Property(e => e.buyer).HasComment("Покупатель");

                entity.Property(e => e.innVendor)
                    .HasMaxLength(12)
                    .HasComment("ИНН вендора");

                entity.Property(e => e.nameVendor)
                    .HasMaxLength(50)
                    .HasComment("Имя вендора");

                entity.Property(e => e.phoneVendor)
                    .HasMaxLength(12)
                    .HasComment("Телефон вендора");

                entity.Property(e => e.salesman).HasComment("Продавец");
            });

            modelBuilder.Entity<vproductscount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vproductscount");

                entity.Property(e => e.countProduct).HasPrecision(32);
            });

            modelBuilder.Entity<vtotalproduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vtotalproducts");

                entity.Property(e => e.Total).HasColumnType("double(22,0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
