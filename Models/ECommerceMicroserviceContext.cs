using System;
using System.Collections.Generic;
using ECommerceBackend.Models.ProductService;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBackend.Models;

public partial class ECommerceMicroserviceContext : DbContext
{
    public ECommerceMicroserviceContext()
    {
    }

    public ECommerceMicroserviceContext(DbContextOptions<ECommerceMicroserviceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCart> TblCarts { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblProductCategory> TblProductCategories { get; set; }

    public virtual DbSet<TblProductDescription> TblProductDescriptions { get; set; }

    public virtual DbSet<TblProductImage> TblProductImages { get; set; }

    public virtual DbSet<TblProductVariant> TblProductVariants { get; set; }

    public virtual DbSet<TblStockLog> TblStockLogs { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserAdress> TblUserAdresses { get; set; }

    public virtual DbSet<TblUserDetail> TblUserDetails { get; set; }

    public virtual DbSet<TblVariantAttribute> TblVariantAttributes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCart>(entity =>
        {
            entity.ToTable("tbl_cart");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("_added_date");
            entity.Property(e => e.ProductId).HasColumnName("_product_id");
            entity.Property(e => e.Quanity)
                .HasDefaultValue(1)
                .HasColumnName("_quanity");
            entity.Property(e => e.UserId).HasColumnName("_user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.TblCarts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_cart__tbl_products");

            entity.HasOne(d => d.User).WithMany(p => p.TblCarts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_cart__tbl_users");
        });

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.ToTable("tbl_categories");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.Active)
                .HasDefaultValue(1)
                .HasColumnName("_active");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("_created_date");
            entity.Property(e => e.Description)
                .HasDefaultValue("")
                .HasColumnName("_description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .HasColumnName("_image_url");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("_name");
            entity.Property(e => e.ParentId)
                .HasDefaultValue(1)
                .HasColumnName("_parent_id");
            entity.Property(e => e.Slug)
                .HasMaxLength(255)
                .HasDefaultValue("")
                .HasColumnName("_slug");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.ToTable("tbl_products");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.Active)
                .HasDefaultValue(1)
                .HasColumnName("_active");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("_created_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("_name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("_price");
            entity.Property(e => e.Sku)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("_sku");
            entity.Property(e => e.StockQuanity).HasColumnName("_stock_quanity");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("_updated_date");
        });

        modelBuilder.Entity<TblProductCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_product_categories");

            entity.Property(e => e.CategoryId).HasColumnName("_category_id");
            entity.Property(e => e.ProductId).HasColumnName("_product_id");

            entity.HasOne(d => d.Category).WithMany()
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tbl_product_categories_tbl_categories");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tbl_product_categories_tbl_products");
        });

        modelBuilder.Entity<TblProductDescription>(entity =>
        {
            entity
                .ToTable("tbl_product_description")
                .HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("_id");

            entity.Property(e => e.Description)
                .HasDefaultValue("")
                .HasColumnName("_description");
            entity.Property(e => e.ProductId).HasColumnName("_product_id");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_product_description__tbl_products");
        });

        modelBuilder.Entity<TblProductImage>(entity =>
        {
            entity.ToTable("tbl_product_images");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .HasColumnName("_image_url");
            entity.Property(e => e.ProductId).HasColumnName("_product_id");
            entity.Property(e => e.UploadDate)
                .HasColumnType("datetime")
                .HasColumnName("_upload_date");

            entity.HasOne(d => d.Product).WithMany(p => p.TblProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_product_images__tbl_products");
        });

        modelBuilder.Entity<TblProductVariant>(entity =>
        {
            entity.ToTable("tbl_product_variants");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.Active)
                .HasDefaultValue(1)
                .HasColumnName("_active");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .HasColumnName("_image_url");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("_price");
            entity.Property(e => e.ProductId).HasColumnName("_product_id");
            entity.Property(e => e.Sku)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("_sku");
            entity.Property(e => e.StockQuanity).HasColumnName("_stock_quanity");
            entity.Property(e => e.VariantName)
                .HasMaxLength(255)
                .HasColumnName("_variant_name");

            entity.HasOne(d => d.Product).WithMany(p => p.TblProductVariants)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_product_variants__tbl_products");
        });

        modelBuilder.Entity<TblStockLog>(entity =>
        {
            entity.ToTable("tbl_stock_logs");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.ChangeAmount).HasColumnName("_change_amount");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("_created_date");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("_note");
            entity.Property(e => e.ProductId).HasColumnName("_product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.TblStockLogs)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_stock_logs__tbl_products");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.ToTable("tbl_users");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("_created_date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("_email");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(500)
                .HasColumnName("_password_hash");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("_role");
        });

        modelBuilder.Entity<TblUserAdress>(entity =>
        {
            entity.ToTable("tbl_user_adresses");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.AdressLine)
                .HasMaxLength(255)
                .HasColumnName("_adress_line");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("_city");
            entity.Property(e => e.IsDefault).HasColumnName("_is_default");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("_postal_code");
            entity.Property(e => e.UserId).HasColumnName("_user_id");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserAdresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_user_adresses__tbl_users");
        });

        modelBuilder.Entity<TblUserDetail>(entity =>
        {
            entity.ToTable("tbl_user_details");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(500)
                .HasColumnName("_avatar_url");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("_dob");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("_fullname");
            entity.Property(e => e.Gender).HasColumnName("_gender");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("_phone_number");
            entity.Property(e => e.UserId).HasColumnName("_user_id");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserDetails)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_user_details__tbl_users");
        });

        modelBuilder.Entity<TblVariantAttribute>(entity =>
        {
            entity.ToTable("tbl_variant_attributes");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.AttributeName)
                .HasMaxLength(100)
                .HasColumnName("_attribute_name");
            entity.Property(e => e.AttributeValue)
                .HasMaxLength(100)
                .HasColumnName("_attribute_value");
            entity.Property(e => e.VariantId).HasColumnName("_variant_id");

            entity.HasOne(d => d.Variant).WithMany(p => p.TblVariantAttributes)
                .HasForeignKey(d => d.VariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_variant_attributes__tbl_product_variants");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
