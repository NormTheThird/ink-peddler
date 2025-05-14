using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InkPeddler.GraphQL.API.Models
{
    public partial class InkPeddlerContext : DbContext
    {
        public InkPeddlerContext()
        {
        }

        public InkPeddlerContext(DbContextOptions<InkPeddlerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountRefreshToken> AccountRefreshToken { get; set; }
        public virtual DbSet<ActivityLog> ActivityLog { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<BusinessAccountCrossLink> BusinessAccountCrossLink { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItem { get; set; }
        public virtual DbSet<InvoicePayment> InvoicePayment { get; set; }
        public virtual DbSet<PasswordReset> PasswordReset { get; set; }
        public virtual DbSet<Style> Style { get; set; }
        public virtual DbSet<Tattoo> Tattoo { get; set; }
        public virtual DbSet<TattooComment> TattooComment { get; set; }
        public virtual DbSet<TattooImage> TattooImage { get; set; }
        public virtual DbSet<TattooReviewLog> TattooReviewLog { get; set; }
        public virtual DbSet<TattooStyleCrossLink> TattooStyleCrossLink { get; set; }
        public virtual DbSet<TattooTat> TattooTat { get; set; }
        public virtual DbSet<TattooView> TattooView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:ink-peddler.database.windows.net,1433;Initial Catalog=InkPeddler;Persist Security Info=False;User ID=ip-admin;Password=4!EoOl9F@MzR!l3uG;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AllowedOrigin)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AwsprofileImageId).HasColumnName("AWSProfileImageId");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FacebookUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InstagramUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Password).HasMaxLength(64);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TwitterUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("(dateadd(second,(-1),sysutcdatetime()))");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("('9999.12.31 23:59:59.99')");

                entity.Property(e => e.WebsiteUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Address");
            });

            modelBuilder.Entity<AccountRefreshToken>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateExpired).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateIssued).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProtectedTicket)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RefreshToken)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountRefreshToken)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountRefreshToken_Account");
            });

            modelBuilder.Entity<ActivityLog>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ActivityType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ActivityLog)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityLog_Account");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("(dateadd(second,(-1),sysutcdatetime()))");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("('9999.12.31 23:59:59.99')");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AwsprofileImageId).HasColumnName("AWSProfileImageId");

                entity.Property(e => e.AzureMapsSearchId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AzureMapsSearchType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FacebookUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoogleMapId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoogleMapPlaceId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InstagramUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RegistrationCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TwitterUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("(dateadd(second,(-1),sysutcdatetime()))");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("('9999.12.31 23:59:59.99')");

                entity.Property(e => e.ValidatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WebsiteUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Business)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Business_Address");
            });

            modelBuilder.Entity<BusinessAccountCrossLink>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("(dateadd(second,(-1),sysutcdatetime()))");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("('9999.12.31 23:59:59.99')");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BusinessAccountCrossLink)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessAccountCrossLink_Account");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.BusinessAccountCrossLink)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessAccountCrossLink_Business");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateReviwed).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExceptionMessage)
                    .IsRequired()
                    .HasMaxLength(3000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExceptionType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Hresult).HasColumnName("HResult");

                entity.Property(e => e.InnerExceptionMessage)
                    .IsRequired()
                    .HasMaxLength(3000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Parameters)
                    .IsRequired()
                    .HasMaxLength(3000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReviewedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReviewedComments)
                    .IsRequired()
                    .HasMaxLength(3000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StackTrace)
                    .IsRequired()
                    .HasMaxLength(3000)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscountCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.InvoicedAccount)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.InvoicedAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_InvoicedAccount");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceDetail)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetail_Invoice");

                entity.HasOne(d => d.InvoiceItem)
                    .WithMany(p => p.InvoiceDetail)
                    .HasForeignKey(d => d.InvoiceItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetail_InvoiceItem");
            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<InvoicePayment>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentResponseId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoicePayment)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoicePayment_Invoice");
            });

            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PasswordReset)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PasswordReset_Account");
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("(dateadd(second,(-1),sysutcdatetime()))");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("('9999.12.31 23:59:59.99')");
            });

            modelBuilder.Entity<Tattoo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("(dateadd(second,(-1),sysutcdatetime()))");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("('9999.12.31 23:59:59.99')");

                entity.HasOne(d => d.ArtistAccount)
                    .WithMany(p => p.TattooArtistAccount)
                    .HasForeignKey(d => d.ArtistAccountId)
                    .HasConstraintName("FK_Tattoo_ArtistAccount");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Tattoo)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_Tattoo_Business");

                entity.HasOne(d => d.CanvasAccount)
                    .WithMany(p => p.TattooCanvasAccount)
                    .HasForeignKey(d => d.CanvasAccountId)
                    .HasConstraintName("FK_Tattoo_CanvasAccount");

                entity.HasOne(d => d.UploadedByAccount)
                    .WithMany(p => p.TattooUploadedByAccount)
                    .HasForeignKey(d => d.UploadedByAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tattoo_UploadedByAccount");
            });

            modelBuilder.Entity<TattooComment>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("(dateadd(second,(-1),sysutcdatetime()))");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("('9999.12.31 23:59:59.99')");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TattooComment)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooComment_Account");

                entity.HasOne(d => d.Tattoo)
                    .WithMany(p => p.TattooComment)
                    .HasForeignKey(d => d.TattooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooComment_Tattoo");
            });

            modelBuilder.Entity<TattooImage>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AwsimageId).HasColumnName("AWSImageId");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("(dateadd(second,(-1),sysutcdatetime()))");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime2(2)")
                    .HasDefaultValueSql("('9999.12.31 23:59:59.99')");

                entity.HasOne(d => d.Tattoo)
                    .WithMany(p => p.TattooImage)
                    .HasForeignKey(d => d.TattooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooImage_Tattoo");
            });

            modelBuilder.Entity<TattooReviewLog>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReviewedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReviewedComment)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.FlaggedByAccount)
                    .WithMany(p => p.TattooReviewLog)
                    .HasForeignKey(d => d.FlaggedByAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooReviewLog_FlaggedByAccount");

                entity.HasOne(d => d.Tattoo)
                    .WithMany(p => p.TattooReviewLog)
                    .HasForeignKey(d => d.TattooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooReviewLog_Tattoo");
            });

            modelBuilder.Entity<TattooStyleCrossLink>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Style)
                    .WithMany(p => p.TattooStyleCrossLink)
                    .HasForeignKey(d => d.StyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooStyleCrossLink_Style");

                entity.HasOne(d => d.Tattoo)
                    .WithMany(p => p.TattooStyleCrossLink)
                    .HasForeignKey(d => d.TattooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooStyleCrossLink_Tattoo");
            });

            modelBuilder.Entity<TattooTat>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TattooTat)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooTat_Account");

                entity.HasOne(d => d.Tattoo)
                    .WithMany(p => p.TattooTat)
                    .HasForeignKey(d => d.TattooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooTat_Tattoo");
            });

            modelBuilder.Entity<TattooView>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TattooView)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooView_Account");

                entity.HasOne(d => d.Tattoo)
                    .WithMany(p => p.TattooView)
                    .HasForeignKey(d => d.TattooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TattooView_Tattoo");
            });
        }
    }
}
