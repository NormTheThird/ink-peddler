using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InkPeddler.Data.Models;

#nullable disable

namespace InkPeddler.Data.Context
{
    public partial class InkPeddlerDbContext : DbContext
    {
        public InkPeddlerDbContext()
        {
        }

        public InkPeddlerDbContext(DbContextOptions<InkPeddlerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<BusinessAccountCrossLink> BusinessAccountCrossLinks { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        public virtual DbSet<InvoicePayment> InvoicePayments { get; set; }
        public virtual DbSet<Style> Styles { get; set; }
        public virtual DbSet<Tattoo> Tattoos { get; set; }
        public virtual DbSet<TattooComment> TattooComments { get; set; }
        public virtual DbSet<TattooImage> TattooImages { get; set; }
        public virtual DbSet<TattooReviewLog> TattooReviewLogs { get; set; }
        public virtual DbSet<TattooStyleCrossLink> TattooStyleCrossLinks { get; set; }
        public virtual DbSet<TattooTat> TattooTats { get; set; }
        public virtual DbSet<TattooView> TattooViews { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPasswordReset> UserPasswordResets { get; set; }
        public virtual DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AllowedOrigin).HasDefaultValueSql("('')");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasDefaultValueSql("('')");

                entity.Property(e => e.FirstName).HasDefaultValueSql("('')");

                entity.Property(e => e.LastName).HasDefaultValueSql("('')");

                entity.Property(e => e.Password).IsFixedLength(true);

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<ActivityLog>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ActivityType).HasDefaultValueSql("('')");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ActivityLogs)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityLog_Account");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address1).HasDefaultValueSql("('')");

                entity.Property(e => e.Address2).HasDefaultValueSql("('')");

                entity.Property(e => e.City).HasDefaultValueSql("('')");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.State).HasDefaultValueSql("('')");

                entity.Property(e => e.ZipCode).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AzureMapsSearchId).HasDefaultValueSql("('')");

                entity.Property(e => e.AzureMapsSearchType).HasDefaultValueSql("('')");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FacebookUrl).HasDefaultValueSql("('')");

                entity.Property(e => e.GoogleMapId).HasDefaultValueSql("('')");

                entity.Property(e => e.GoogleMapPlaceId).HasDefaultValueSql("('')");

                entity.Property(e => e.InstagramUrl).HasDefaultValueSql("('')");

                entity.Property(e => e.Name).HasDefaultValueSql("('')");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("('')");

                entity.Property(e => e.RegistrationCode).HasDefaultValueSql("('')");

                entity.Property(e => e.TwitterUrl).HasDefaultValueSql("('')");

                entity.Property(e => e.ValidFrom)
                    .HasPrecision(2)
                    .HasDefaultValueSql("(dateadd(second,(-1),sysutcdatetime()))");

                entity.Property(e => e.ValidTo)
                    .HasPrecision(2)
                    .HasDefaultValueSql("('9999.12.31 23:59:59.99')");

                entity.Property(e => e.ValidatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.WebsiteUrl).HasDefaultValueSql("('')");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Business_Address");
            });

            modelBuilder.Entity<BusinessAccountCrossLink>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BusinessAccountCrossLinks)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessAccountCrossLink_Account");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.BusinessAccountCrossLinks)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessAccountCrossLink_Business");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateReviwed).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExceptionMessage).HasDefaultValueSql("('')");

                entity.Property(e => e.ExceptionType).HasDefaultValueSql("('')");

                entity.Property(e => e.InnerExceptionMessage).HasDefaultValueSql("('')");

                entity.Property(e => e.Parameters).HasDefaultValueSql("('')");

                entity.Property(e => e.ReviewedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.ReviewedComments).HasDefaultValueSql("('')");

                entity.Property(e => e.Source).HasDefaultValueSql("('')");

                entity.Property(e => e.StackTrace).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscountCode).HasDefaultValueSql("('')");

                entity.HasOne(d => d.InvoicedAccount)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.InvoicedAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_InvoicedAccount");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetail_Invoice");

                entity.HasOne(d => d.InvoiceItem)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetail_InvoiceItem");
            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasDefaultValueSql("('')");

                entity.Property(e => e.Name).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<InvoicePayment>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentResponseId).HasDefaultValueSql("('')");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoicePayments)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoicePayment_Invoice");
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasDefaultValueSql("('')");

                entity.Property(e => e.Name).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Tattoo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasDefaultValueSql("('')");

                entity.Property(e => e.Name).HasDefaultValueSql("('')");

                entity.Property(e => e.ValidFrom)
                    .HasPrecision(2)
                    .HasDefaultValueSql("(dateadd(second,(-1),sysutcdatetime()))");

                entity.Property(e => e.ValidTo)
                    .HasPrecision(2)
                    .HasDefaultValueSql("('9999.12.31 23:59:59.99')");

                entity.HasOne(d => d.ArtistAccount)
                    .WithMany(p => p.TattooArtistAccounts)
                    .HasForeignKey(d => d.ArtistAccountId)
                    .HasConstraintName("FK_Tattoo_ArtistAccount");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Tattoos)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_Tattoo_Business");

                entity.HasOne(d => d.CanvasAccount)
                    .WithMany(p => p.TattooCanvasAccounts)
                    .HasForeignKey(d => d.CanvasAccountId)
                    .HasConstraintName("FK_Tattoo_CanvasAccount");

                entity.HasOne(d => d.UploadedByAccount)
                    .WithMany(p => p.TattooUploadedByAccounts)
                    .HasForeignKey(d => d.UploadedByAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tattoo_UploadedByAccount");
            });

            modelBuilder.Entity<TattooComment>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasDefaultValueSql("('')");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TattooComments)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooComment_Account");

                entity.HasOne(d => d.Tattoo)
                    .WithMany(p => p.TattooComments)
                    .HasForeignKey(d => d.TattooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooComment_Tattoo");
            });

            modelBuilder.Entity<TattooImage>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValidFrom)
                    .HasPrecision(2)
                    .HasDefaultValueSql("(dateadd(second,(-1),sysutcdatetime()))");

                entity.Property(e => e.ValidTo)
                    .HasPrecision(2)
                    .HasDefaultValueSql("('9999.12.31 23:59:59.99')");

                entity.HasOne(d => d.Tattoo)
                    .WithMany(p => p.TattooImages)
                    .HasForeignKey(d => d.TattooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooImage_Tattoo");
            });

            modelBuilder.Entity<TattooReviewLog>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReviewedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.ReviewedComment).HasDefaultValueSql("('')");

                entity.HasOne(d => d.FlaggedByAccount)
                    .WithMany(p => p.TattooReviewLogs)
                    .HasForeignKey(d => d.FlaggedByAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooReviewLog_FlaggedByAccount");

                entity.HasOne(d => d.Tattoo)
                    .WithMany(p => p.TattooReviewLogs)
                    .HasForeignKey(d => d.TattooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooReviewLog_Tattoo");
            });

            modelBuilder.Entity<TattooStyleCrossLink>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Style)
                    .WithMany(p => p.TattooStyleCrossLinks)
                    .HasForeignKey(d => d.StyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooStyleCrossLink_Style");

                entity.HasOne(d => d.Tattoo)
                    .WithMany(p => p.TattooStyleCrossLinks)
                    .HasForeignKey(d => d.TattooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooStyleCrossLink_Tattoo");
            });

            modelBuilder.Entity<TattooTat>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TattooTats)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooTat_Account");

                entity.HasOne(d => d.Tattoo)
                    .WithMany(p => p.TattooTats)
                    .HasForeignKey(d => d.TattooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooTat_Tattoo");
            });

            modelBuilder.Entity<TattooView>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TattooViews)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooView_Account");

                entity.HasOne(d => d.Tattoo)
                    .WithMany(p => p.TattooViews)
                    .HasForeignKey(d => d.TattooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooView_Tattoo");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasDefaultValueSql("('')");

                entity.Property(e => e.FirstName).HasDefaultValueSql("('')");

                entity.Property(e => e.LastName).HasDefaultValueSql("('')");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("('')");

                entity.Property(e => e.Salt).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<UserPasswordReset>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPasswordResets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPasswordReset_User");
            });

            modelBuilder.Entity<UserRefreshToken>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateExpired).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateIssued).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProtectedTicket).HasDefaultValueSql("('')");

                entity.Property(e => e.RefreshToken).HasDefaultValueSql("('')");

                entity.Property(e => e.TokenType).HasDefaultValueSql("('')");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRefreshToken_User");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .IsClustered(false);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserRole)
                    .HasForeignKey<UserRole>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
