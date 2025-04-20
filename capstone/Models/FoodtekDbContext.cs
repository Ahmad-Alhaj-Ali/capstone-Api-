using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace capstone.Models;

public partial class FoodtekDbContext : DbContext
{
    public FoodtekDbContext()
    {
    }

    public FoodtekDbContext(DbContextOptions<FoodtekDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Authentication> Authentications { get; set; }

    public virtual DbSet<Bookmark> Bookmarks { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemBadge> ItemBadges { get; set; }

    public virtual DbSet<ItemOption> ItemOptions { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<OptionCategory> OptionCategories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Otp> Otps { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<ProblemTicket> ProblemTickets { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<SuggestionTicket> SuggestionTickets { get; set; }

    public virtual DbSet<SuperAdmin> SuperAdmins { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=AHMAD-PC\\SQLEXPRESS;Initial Catalog=FoodtekDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3214EC074FE1A293");

            entity.Property(e => e.AddressName).HasMaxLength(255);
            entity.Property(e => e.ClientId).HasColumnName("CLientID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Hint).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Province).HasMaxLength(255);
            entity.Property(e => e.Region).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Addresses__CLien__02084FDA");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admins__3214EC0754010784");

            entity.HasOne(d => d.User).WithMany(p => p.Admins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Admins__UserId__4BAC3F29");
        });

        modelBuilder.Entity<Authentication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authenti__3214EC07C9D564E9");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ProviderLoginId).HasMaxLength(255);
            entity.Property(e => e.ProviderName).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.Authentications)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Authentic__Clien__14E61A24");
        });

        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookmark__3214EC077E549945");

            entity.HasIndex(e => new { e.ClientId, e.ItemId }, "UQ__Bookmark__4159F21D2B4C4DBE").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Client).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Bookmarks__Clien__51300E55");

            entity.HasOne(d => d.Item).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Bookmarks__ItemI__5224328E");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07BD5F7BBE");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(255)
                .HasColumnName("NameAR");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("NameEN");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Offer).WithMany(p => p.Categories)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Categorie__Offer__2DE6D218");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clients__3214EC0778427638");

            entity.Property(e => e.Birthdate).HasColumnType("datetime");
            entity.Property(e => e.ClientStatus).HasMaxLength(20);

            entity.HasOne(d => d.User).WithMany(p => p.Clients)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Clients__UserId__70DDC3D8");
        });

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conversa__3214EC0770E0FFC4");

            entity.HasIndex(e => new { e.DriverId, e.ClientId }, "UQ__Conversa__AFD62C85830E1CCE").IsUnique();

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");

            entity.HasOne(d => d.Client).WithMany(p => p.Conversations)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Conversat__Clien__76969D2E");

            entity.HasOne(d => d.Driver).WithMany(p => p.Conversations)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Conversat__Drive__75A278F5");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drivers__3214EC07217248FF");

            entity.HasOne(d => d.User).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Drivers__UserId__6C190EBB");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07FF14A646");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Employees__RoleI__68487DD7");

            entity.HasOne(d => d.User).WithMany(p => p.Employees)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Employees__UserI__693CA210");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Items__3214EC07C6375CD3");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemDescriptionAr)
                .HasMaxLength(255)
                .HasColumnName("ItemDescriptionAR");
            entity.Property(e => e.ItemDescriptionEn)
                .HasMaxLength(255)
                .HasColumnName("ItemDescriptionEN");
            entity.Property(e => e.ItemNameAr)
                .HasMaxLength(255)
                .HasColumnName("ItemNameAR");
            entity.Property(e => e.ItemNameEn)
                .HasMaxLength(255)
                .HasColumnName("ItemNameEN");
            entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Items)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Items__CategoryI__40058253");

            entity.HasOne(d => d.ItemBadge).WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemBadgeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Items__ItemBadge__40F9A68C");

            entity.HasOne(d => d.Offer).WithMany(p => p.Items)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Items__OfferId__3F115E1A");
        });

        modelBuilder.Entity<ItemBadge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemBadg__3214EC076BA71EFD");

            entity.Property(e => e.BadgeDescription).HasMaxLength(255);
            entity.Property(e => e.BadgeName).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ItemOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemOpti__3214EC07F37DF4DC");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemOptions)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__ItemOptio__ItemI__69FBBC1F");

            entity.HasOne(d => d.Option).WithMany(p => p.ItemOptions)
                .HasForeignKey(d => d.OptionId)
                .HasConstraintName("FK__ItemOptio__Optio__690797E6");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Messages__3214EC07D659B31E");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.MessageText).HasColumnType("text");

            entity.HasOne(d => d.Conversation).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ConversationId)
                .HasConstraintName("FK__Messages__Conver__7C4F7684");

            entity.HasOne(d => d.Sender).WithMany(p => p.Messages)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__Messages__Sender__7B5B524B");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC07DC8750B8");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionAr)
                .HasMaxLength(255)
                .HasColumnName("DescriptionAR");
            entity.Property(e => e.DescriptionEn)
                .HasMaxLength(255)
                .HasColumnName("DescriptionEN");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.NotificationType).HasMaxLength(255);
            entity.Property(e => e.TitleAr)
                .HasMaxLength(255)
                .HasColumnName("TitleAR");
            entity.Property(e => e.TitleEn)
                .HasMaxLength(255)
                .HasColumnName("TitleEN");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__UserI__0E391C95");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Offers__3214EC07D9C3EA9C");

            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionAr)
                .HasMaxLength(255)
                .HasColumnName("DescriptionAR");
            entity.Property(e => e.DescriptionEn)
                .HasMaxLength(255)
                .HasColumnName("DescriptionEN");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LimitAmount).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.OfferStatus).HasMaxLength(255);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TitleAr)
                .HasMaxLength(255)
                .HasColumnName("TitleAR");
            entity.Property(e => e.TitleEn)
                .HasMaxLength(255)
                .HasColumnName("TitleEN");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserPersons).HasDefaultValue(0);
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Options__3214EC07BCE5B2BE");

            entity.HasIndex(e => new { e.NameAr, e.NameEn, e.CategoryId }, "UQ__Options__1AE41C0288723465").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsRequired).HasDefaultValue(false);
            entity.Property(e => e.NameAr)
                .HasMaxLength(255)
                .HasColumnName("NameAR");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("NameEN");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Options)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Options__Categor__634EBE90");
        });

        modelBuilder.Entity<OptionCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OptionCa__3214EC078A16712A");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("ImageURL");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(255)
                .HasColumnName("NameAR");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("NameEN");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC0738BFBDC2");

            entity.Property(e => e.ClientRate).HasColumnType("decimal(2, 1)");
            entity.Property(e => e.ClientReview).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DriverRate).HasColumnType("decimal(2, 1)");
            entity.Property(e => e.DriverReview).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.OrderStatus).HasMaxLength(20);
            entity.Property(e => e.PaymentStatus).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__ClientId__14270015");

            entity.HasOne(d => d.DeliveryAddress).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DeliveryAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__Delivery__160F4887");

            entity.HasOne(d => d.Driver).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK__Orders__DriverId__151B244E");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK__Orders__PaymentM__1332DBDC");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC0737E9C077");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Review).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__OrderItem__ItemI__4A8310C6");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__4B7734FF");
        });

        modelBuilder.Entity<Otp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OTPs__3214EC076B68F46C");

            entity.ToTable("OTPs");

            entity.Property(e => e.Attempt).HasDefaultValue(0);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate)
                .HasDefaultValueSql("(dateadd(minute,(10),getdate()))")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsUsed).HasDefaultValue(false);
            entity.Property(e => e.Otpcode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OTPCode");

            entity.HasOne(d => d.User).WithMany(p => p.Otps)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__OTPs__UserId__078C1F06");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentM__3214EC07B3DF5BF4");

            entity.Property(e => e.CardHolderName).HasMaxLength(255);
            entity.Property(e => e.CardNumber).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Cvc)
                .HasMaxLength(255)
                .HasColumnName("CVC");
            entity.Property(e => e.ExpiryDate).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.PaymentMethods)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__PaymentMe__Clien__07C12930");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC07E7F86CA8");

            entity.HasIndex(e => e.NameEn, "UQ__Permissi__EE1C774FE4526220").IsUnique();

            entity.HasIndex(e => e.NameAr, "UQ__Permissi__EE1CD24C5E8C9133").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionAr)
                .HasMaxLength(255)
                .HasColumnName("DescriptionAR");
            entity.Property(e => e.DescriptionEn)
                .HasMaxLength(255)
                .HasColumnName("DescriptionEN");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .HasColumnName("NameAR");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("NameEN");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persons__3214EC079F114800");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Persons__85FB4E38562E525A").IsUnique();

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ProfileImageUrl).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.People)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Persons__UserId__45F365D3");
        });

        modelBuilder.Entity<ProblemTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProblemT__3214EC07F801BD4D");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ExpiredDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RefundAmount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TicketDescription).HasMaxLength(255);
            entity.Property(e => e.TicketStatus).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.ProblemTickets)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__ProblemTi__Clien__793DFFAF");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC078EBACC23");

            entity.HasIndex(e => e.RoleNameEn, "UQ__Roles__CB8E64908655FA0A").IsUnique();

            entity.HasIndex(e => e.RoleNameAr, "UQ__Roles__CB8F850998D373B2").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RoleNameAr)
                .HasMaxLength(50)
                .HasColumnName("RoleNameAR");
            entity.Property(e => e.RoleNameEn)
                .HasMaxLength(50)
                .HasColumnName("RoleNameEN");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolePerm__3214EC07C44E02B2");

            entity.HasIndex(e => new { e.RoleId, e.PermissionId }, "UQ__RolePerm__6400A1A9A24B83D1").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__RolePermi__Permi__656C112C");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RolePermi__RoleI__6477ECF3");
        });

        modelBuilder.Entity<SuggestionTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Suggesti__3214EC07405D50C3");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TicketDescription).HasMaxLength(255);
            entity.Property(e => e.TicketStatus).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.SuggestionTickets)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Suggestio__Clien__719CDDE7");
        });

        modelBuilder.Entity<SuperAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SuperAdm__3214EC076CF81275");

            entity.ToTable("SuperAdmin");

            entity.HasOne(d => d.User).WithMany(p => p.SuperAdmins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__SuperAdmi__UserI__48CFD27E");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tokens__3214EC071861C408");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsExpired).HasDefaultValue(false);
            entity.Property(e => e.Jwttoken)
                .HasMaxLength(255)
                .HasColumnName("JWTToken");

            entity.HasOne(d => d.User).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Tokens__UserId__7EF6D905");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC078B28F016");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105344CF0866A").IsUnique();

            entity.HasIndex(e => e.UserNameHash, "UQ__Users__E13D90791E01A047").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsLogging).HasDefaultValue(false);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(64);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserNameHash).HasMaxLength(64);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
