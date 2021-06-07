using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace E_CommerceClient.Models
{
    public partial class Covid_EssentialsContext : DbContext
    {
        public Covid_EssentialsContext()
        {
        }

        public Covid_EssentialsContext(DbContextOptions<Covid_EssentialsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Covid_Essentials;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Order_De__C3905BCFE166357A");

                entity.ToTable("Order_Details");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Order_Det__Produ__49C3F6B7");
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Product___B40CC6CDCD1BB042");

                entity.ToTable("Product_Details");

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.ProductDescription).IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__User_Det__1788CC4C490D5444");

                entity.ToTable("User_Details");

                entity.HasIndex(e => e.UserEmail, "UQ__User_Det__08638DF8640A954D")
                    .IsUnique();

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserContact)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserDetails)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User_Deta__RoleI__5DCAEF64");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__User_Rol__8AFACE1A0DB7B85E");

                entity.ToTable("User_Role");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(55)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
