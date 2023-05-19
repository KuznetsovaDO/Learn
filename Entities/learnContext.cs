using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Learn
{
    public partial class learnContext : DbContext
    {
        public learnContext()
        {
        }

        public learnContext(DbContextOptions<learnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachedproduct> Attachedproducts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Clientservice> Clientservices { get; set; }
        public virtual DbSet<Documentbyservice> Documentbyservices { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productphoto> Productphotos { get; set; }
        public virtual DbSet<Productsale> Productsales { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Servicephoto> Servicephotos { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Tagofclient> Tagofclients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;persist security info=False;user=root;password=12345678;database=learn", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Attachedproduct>(entity =>
            {
                entity.HasKey(e => new { e.MainProductId, e.AttachedProductId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("attachedproduct");

                entity.HasIndex(e => e.AttachedProductId, "FK_AttachedProduct_Product1");

                entity.Property(e => e.MainProductId).HasColumnName("MainProductID");

                entity.Property(e => e.AttachedProductId).HasColumnName("AttachedProductID");

                entity.HasOne(d => d.AttachedProduct)
                    .WithMany(p => p.AttachedproductAttachedProducts)
                    .HasForeignKey(d => d.AttachedProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttachedProduct_Product1");

                entity.HasOne(d => d.MainProduct)
                    .WithMany(p => p.AttachedproductMainProducts)
                    .HasForeignKey(d => d.MainProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttachedProduct_Product");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.HasIndex(e => e.GenderCode, "FK_Client_Gender");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GenderCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhotoPath).HasMaxLength(1000);

                entity.Property(e => e.RegistrationDate).HasMaxLength(6);

                entity.HasOne(d => d.GenderCodeNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.GenderCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Gender");
            });

            modelBuilder.Entity<Clientservice>(entity =>
            {
                entity.ToTable("clientservice");

                entity.HasIndex(e => e.ClientId, "FK_ClientService_Client");

                entity.HasIndex(e => e.ServiceId, "FK_ClientService_Service");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.StartTime).HasMaxLength(6);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Clientservices)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientService_Client");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Clientservices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientService_Service");
            });

            modelBuilder.Entity<Documentbyservice>(entity =>
            {
                entity.ToTable("documentbyservice");

                entity.HasIndex(e => e.ClientServiceId, "FK_DocumentByService_ClientService");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientServiceId).HasColumnName("ClientServiceID");

                entity.Property(e => e.DocumentPath)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.ClientService)
                    .WithMany(p => p.Documentbyservices)
                    .HasForeignKey(d => d.ClientServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentByService_ClientService");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("gender");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("manufacturer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.ManufacturerId, "FK_Product_Manufacturer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasPrecision(19, 4);

                entity.Property(e => e.MainImagePath).HasMaxLength(1000);

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Product_Manufacturer");
            });

            modelBuilder.Entity<Productphoto>(entity =>
            {
                entity.ToTable("productphoto");

                entity.HasIndex(e => e.ProductId, "FK_ProductPhoto_Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PhotoPath)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productphotos)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPhoto_Product");
            });

            modelBuilder.Entity<Productsale>(entity =>
            {
                entity.ToTable("productsale");

                entity.HasIndex(e => e.ClientServiceId, "FK_ProductSale_ClientService");

                entity.HasIndex(e => e.ProductId, "FK_ProductSale_Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientServiceId).HasColumnName("ClientServiceID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SaleDate).HasMaxLength(6);

                entity.HasOne(d => d.ClientService)
                    .WithMany(p => p.Productsales)
                    .HasForeignKey(d => d.ClientServiceId)
                    .HasConstraintName("FK_ProductSale_ClientService");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productsales)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSale_Product");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("service");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasPrecision(19, 4);

                entity.Property(e => e.MainImagePath).HasMaxLength(1000);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Servicephoto>(entity =>
            {
                entity.ToTable("servicephoto");

                entity.HasIndex(e => e.ServiceId, "FK_ServicePhoto_Service");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PhotoPath)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Servicephotos)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePhoto_Service");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tag");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Tagofclient>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.TagId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("tagofclient");

                entity.HasIndex(e => e.TagId, "FK_TagOfClient_Tag");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Tagofclients)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagOfClient_Client");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Tagofclients)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagOfClient_Tag");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
