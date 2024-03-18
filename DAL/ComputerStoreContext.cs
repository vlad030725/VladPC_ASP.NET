using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DomainModel;

namespace DAL;

public partial class ComputerStoreContext : DbContext
{
    public ComputerStoreContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public ComputerStoreContext(DbContextOptions<ComputerStoreContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public virtual DbSet<Company> Company { get; set; }

    public virtual DbSet<Custom> Custom { get; set; }

    public virtual DbSet<CustomRow> CustomRow { get; set; }

    public virtual DbSet<FormFactor> FormFactor { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }

    public virtual DbSet<Procurement> Procurement { get; set; }

    public virtual DbSet<ProcurementRow> ProcurementRow { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<PromoCode> PromoCode { get; set; }

    public virtual DbSet<Socket> Socket { get; set; }

    public virtual DbSet<Status> Status { get; set; }

    public virtual DbSet<TypeMemory> TypeMemory { get; set; }

    public virtual DbSet<TypeProduct> TypeProduct { get; set; }

    public virtual DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ComputerStore;Username=postgres;Password=fgvcdrt");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Companies");

            entity.ToTable("Companies", "dbo");
        });

        modelBuilder.Entity<Custom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Customs");

            entity.ToTable("Customs", "dbo");

            entity.HasIndex(e => e.IdPromoCode, "Customs_IX_IdPromoCode");

            entity.HasIndex(e => e.IdStatus, "Customs_IX_IdStatus");

            entity.HasIndex(e => e.IdUser, "Customs_IX_IdUser");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.IdPromoCodeNavigation).WithMany(p => p.Customs)
                .HasForeignKey(d => d.IdPromoCode)
                .HasConstraintName("FK_dbo.Customs_dbo.PromoCodes_IdPromoCode");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Customs)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK_dbo.Customs_dbo.Status_IdStatus");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Customs)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_dbo.Customs_dbo.Users_IdUser");
        });

        modelBuilder.Entity<CustomRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.CustomRows");

            entity.ToTable("CustomRows", "dbo");

            entity.HasIndex(e => e.IdCustom, "CustomRows_IX_IdCustom");

            entity.HasIndex(e => e.IdProduct, "CustomRows_IX_IdProduct");

            entity.HasOne(d => d.IdCustomNavigation).WithMany(p => p.CustomRows)
                .HasForeignKey(d => d.IdCustom)
                .HasConstraintName("FK_dbo.CustomRows_dbo.Customs_IdCustom");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.CustomRows)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_dbo.CustomRows_dbo.Products_IdProduct");
        });

        modelBuilder.Entity<FormFactor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.FormFactors");

            entity.ToTable("FormFactors", "dbo");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory", "dbo");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Procurement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Procurements");

            entity.ToTable("Procurements", "dbo");

            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<ProcurementRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.ProcurementRows");

            entity.ToTable("ProcurementRows", "dbo");

            entity.HasIndex(e => e.IdProcurement, "ProcurementRows_IX_IdProcurement");

            entity.HasIndex(e => e.IdProduct, "ProcurementRows_IX_IdProduct");

            entity.HasOne(d => d.IdProcurementNavigation).WithMany(p => p.ProcurementRows)
                .HasForeignKey(d => d.IdProcurement)
                .HasConstraintName("FK_dbo.ProcurementRows_dbo.Procurements_IdProcurement");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProcurementRows)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_dbo.ProcurementRows_dbo.Products_IdProduct");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Products");

            entity.ToTable("Products", "dbo");

            entity.HasIndex(e => e.IdCompany, "Products_IX_IdCompany");

            entity.HasIndex(e => e.IdFormFactor, "Products_IX_IdFormFactor");

            entity.HasIndex(e => e.IdSocket, "Products_IX_IdSocket");

            entity.HasIndex(e => e.IdTypeMemory, "Products_IX_IdTypeMemory");

            entity.HasIndex(e => e.IdTypeProduct, "Products_IX_IdTypeProduct");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK_dbo.Products_dbo.Companies_IdCompany");

            entity.HasOne(d => d.IdFormFactorNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdFormFactor)
                .HasConstraintName("FK_dbo.Products_dbo.FormFactors_IdFormFactor");

            entity.HasOne(d => d.IdSocketNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdSocket)
                .HasConstraintName("FK_dbo.Products_dbo.Sockets_IdSocket");

            entity.HasOne(d => d.IdTypeMemoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdTypeMemory)
                .HasConstraintName("FK_dbo.Products_dbo.TypeMemories_IdTypeMemory");

            entity.HasOne(d => d.IdTypeProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdTypeProduct)
                .HasConstraintName("FK_dbo.Products_dbo.TypeProducts_IdTypeProduct");
        });

        modelBuilder.Entity<PromoCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.PromoCodes");

            entity.ToTable("PromoCodes", "dbo");
        });

        modelBuilder.Entity<Socket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Sockets");

            entity.ToTable("Sockets", "dbo");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Status");

            entity.ToTable("Status", "dbo");
        });

        modelBuilder.Entity<TypeMemory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.TypeMemories");

            entity.ToTable("TypeMemories", "dbo");
        });

        modelBuilder.Entity<TypeProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.TypeProducts");

            entity.ToTable("TypeProducts", "dbo");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Users");

            entity.ToTable("Users", "dbo");
        });

        // Инициализация БД

        IEnumerable<Company> CompanyData = new List<Company>
        {
            new Company() { Id = 1, Name = "Intel" },
            new Company() { Id = 2, Name = "AMD" },
            new Company() { Id = 3, Name = "NVidia" }
        };

        modelBuilder.Entity<Company>().HasData(CompanyData);

        IList<User> UserData = new List<User>
        {
            new User() { Id = 1, Name = "admin", Login = "admin", Password = "password" },
            new User() { Id = 2, Name = "Юдин Владислав Сергеевич", Login = "vlad030725", Password = "1234" },
            new User() { Id = 3, Name = "Дядя Фридрих", Login = "Fridrih", Password = "1234" }
        };

        modelBuilder.Entity<User>().HasData(UserData);

        IList<TypeProduct> TypeProductData = new List<TypeProduct>
        {
            new TypeProduct() { Id = 1, Name = "Процессор" },
            new TypeProduct() { Id = 2, Name = "Видеокарта" }
        };

        modelBuilder.Entity<TypeProduct>().HasData(TypeProductData);

        IList<Socket> SocketData = new List<Socket>
        {
            new Socket() { Id = 1, Name = "LGA1700" },
            new Socket() { Id = 2, Name = "LGA1200" },
            new Socket() { Id = 3, Name = "AM5" },
            new Socket() { Id = 4, Name = "AM3+" },
            new Socket() { Id = 5, Name = "LGA 1151-v2" },
            new Socket() { Id = 6, Name = "LGA 1151" },
            new Socket() { Id = 7, Name = "LGA 2066" },
            new Socket() { Id = 8, Name = "sWRX8" },
            new Socket() { Id = 9, Name = "AM4" },
        };

        modelBuilder.Entity<Socket>().HasData(SocketData);

        IList<Status> StatusData = new List<Status>
        {
            new Status() { Id = 1, Name = "В корзине" },
            new Status() { Id = 2, Name = "В пути" },
            new Status() { Id = 3, Name = "Готов к выдачи" },
            new Status() { Id = 4, Name = "Получен" }
        };

        modelBuilder.Entity<Status>().HasData(StatusData);

        IList<TypeMemory> TypeMemoryData = new List<TypeMemory>()
        {
            new TypeMemory() { Id = 1, Name = "GDDR5" },
            new TypeMemory() { Id = 2, Name = "GDDR6" },
            new TypeMemory() { Id = 3, Name = "GDDR6X" },
            new TypeMemory() { Id = 4, Name = "DDR5" },
            new TypeMemory() { Id = 5, Name = "DDR4" },
            new TypeMemory() { Id = 6, Name = "DDR3" },
        };

        modelBuilder.Entity<TypeMemory>().HasData(TypeMemoryData);

        IList<FormFactor> FormFactorData = new List<FormFactor>()
        {
            new FormFactor() { Id = 1, Name = "Standart-ATX" },
            new FormFactor() { Id = 2, Name = "mini-ATX" },
            new FormFactor() { Id = 3, Name = "micro-ATX" },
        };

        modelBuilder.Entity<FormFactor>().HasData(FormFactorData);

        IList<PromoCode> PromoCodeData = new List<PromoCode>()
        {
            new PromoCode() { Id = 1, Code = "POLTOS", Discount = 0.05 }
        };

        modelBuilder.Entity<PromoCode>().HasData(PromoCodeData);

        IList<Product> ProductData = new List<Product>
        {
            new Product() { Id = 1, Name = "i7-11700F", Price = 30899, Count = 3, IdCompany = 1, IdTypeProduct = 1, CountCores = 8, CountStreams = 16, Frequency = 2500, IdSocket = 2, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
            new Product() { Id = 2, Name = "i3-13100F", Price = 12399, Count = 3, IdCompany = 1, IdTypeProduct = 1, CountCores = 4, CountStreams = 8, Frequency = 3400, IdSocket = 1, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
            new Product() { Id = 3, Name = "Ryzen 7 5800X3D", Price = 36799, Count = 2, IdCompany = 2, IdTypeProduct = 1, CountCores = 8, CountStreams = 16, Frequency = 3400, IdSocket = 3, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
            new Product() { Id = 4, Name = "Ryzen 3 3200G", Price = 9099, Count = 2, IdCompany = 2, IdTypeProduct = 1, CountCores = 4, CountStreams = 4, Frequency = 3600, IdSocket = 3, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
            new Product() { Id = 5, Name = "Ryzen Threadripper PRO 5995WX", Price = 714999, Count = 1, IdCompany = 2, IdTypeProduct = 1, CountCores = 64, CountStreams = 64, Frequency = 2700, IdSocket = 8, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
            new Product() { Id = 6, Name = "GeForce RTX 4060 Ti", Price = 43499, Count = 4, IdCompany = 3, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2310, IdSocket = null, CountMemory = 8, IdTypeMemory = 2, IdFormFactor = null },
            new Product() { Id = 7, Name = "GeForce RTX 4090", Price = 199999, Count = 2, IdCompany = 3, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2230, IdSocket = null, CountMemory = 24, IdTypeMemory = 3, IdFormFactor = null },
            new Product() { Id = 8, Name = "Arc A770", Price = 30999, Count = 4, IdCompany = 1, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2100, IdSocket = null, CountMemory = 8, IdTypeMemory = 2, IdFormFactor = null },
            new Product() { Id = 9, Name = "Radeon RX 7800 XT", Price = 65999, Count = 1, IdCompany = 2, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2430, IdSocket = null, CountMemory = 16, IdTypeMemory = 2, IdFormFactor = null },
        };

        modelBuilder.Entity<Product>().HasData(ProductData);

        IList<Custom> CustomData = new List<Custom>()
        {
            new Custom() { Id = 1, IdUser = 3, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-3), Sum = 0 },
            new Custom() { Id = 2, IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-5), Sum = 0 },
            new Custom() { Id = 3, IdUser = 3, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-6), Sum = 0 },
            new Custom() { Id = 4, IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-7), Sum = 0 },
            new Custom() { Id = 5, IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-9), Sum = 0 }
        };

        

        IList<CustomRow> CustomRowData = new List<CustomRow>()
        {
            new CustomRow() { Id = 1, IdCustom = 1, IdProduct = 1, Price = 32899, Count = 1 },
            new CustomRow() { Id = 2, IdCustom = 1, IdProduct = 6, Price = 43499, Count = 1 },
            new CustomRow() { Id = 3, IdCustom = 2, IdProduct = 5, Price = 714999, Count = 1 },
            new CustomRow() { Id = 4, IdCustom = 3, IdProduct = 2, Price = 12399, Count = 10 },
            new CustomRow() { Id = 5, IdCustom = 4, IdProduct = 2, Price = 12399, Count = 1 },
            new CustomRow() { Id = 6, IdCustom = 4, IdProduct = 2, Price = 12399, Count = 1 },
            new CustomRow() { Id = 7, IdCustom = 4, IdProduct = 4, Price = 10099, Count = 1 },
            new CustomRow() { Id = 8, IdCustom = 4, IdProduct = 8, Price = 29999, Count = 1 },
            new CustomRow() { Id = 9, IdCustom = 4, IdProduct = 6, Price = 43499, Count = 2 },
            new CustomRow() { Id = 10, IdCustom = 5, IdProduct = 7, Price = 210999, Count = 1 }
        };

        

        for (int i = 0; i < CustomData.Count; i++)
        {
            for (int j = 0; j < CustomRowData.Count; j++)
            {
                if (CustomRowData[j].IdCustom == i + 1)
                {
                    CustomData[i].Sum += CustomRowData[j].Count * CustomRowData[j].Price;
                }
            }
        }

        modelBuilder.Entity<Custom>().HasData(CustomData);
        modelBuilder.Entity<CustomRow>().HasData(CustomRowData);

        IList<Procurement> ProcurementData = new List<Procurement>()
        {
            new Procurement() { Id = 1, CreatedDate = DateTime.Now.AddDays(-4), Sum = 0 },
            new Procurement() { Id = 2, CreatedDate = DateTime.Now.AddDays(-6), Sum = 0 },
            new Procurement() { Id = 3, CreatedDate = DateTime.Now.AddDays(-7), Sum = 0 },
            new Procurement() { Id = 4, CreatedDate = DateTime.Now.AddDays(-8), Sum = 0 },
            new Procurement() { Id = 5, CreatedDate = DateTime.Now.AddDays(-9), Sum = 0 },
        };


        IList<ProcurementRow> ProcurementRowData = new List<ProcurementRow>()
        {
            new ProcurementRow() { Id = 1, IdProcurement = 1, IdProduct = 1, Price = 30899, Count = 1 },
            new ProcurementRow() { Id = 2, IdProcurement = 1, IdProduct = 6, Price = 40499, Count = 1 },
            new ProcurementRow() { Id = 3, IdProcurement = 2, IdProduct = 5, Price = 690999, Count = 1 },
            new ProcurementRow() { Id = 4, IdProcurement = 3, IdProduct = 2, Price = 9399, Count = 10 },
            new ProcurementRow() { Id = 5, IdProcurement = 3, IdProduct = 2, Price = 9499, Count = 1 },
            new ProcurementRow() { Id = 6, IdProcurement = 3, IdProduct = 2, Price = 11399, Count = 1 },
            new ProcurementRow() { Id = 7, IdProcurement = 4, IdProduct = 4, Price = 8099, Count = 1 },
            new ProcurementRow() { Id = 8, IdProcurement = 5, IdProduct = 8, Price = 32999, Count = 1 },
            new ProcurementRow() { Id = 9, IdProcurement = 5, IdProduct = 6, Price = 41499, Count = 2 },
            new ProcurementRow() { Id = 10, IdProcurement = 5, IdProduct = 7, Price = 200999, Count = 1 }
        };

        for (int i = 0; i < ProcurementData.Count; i++)
        {
            for (int j = 0; j < ProcurementRowData.Count; j++)
            {
                if (ProcurementRowData[j].IdProcurement == i + 1)
                {
                    ProcurementData[i].Sum += ProcurementRowData[j].Count * ProcurementRowData[j].Price;
                }
            }
        }

        modelBuilder.Entity<Procurement>().HasData(ProcurementData);
        modelBuilder.Entity<ProcurementRow>().HasData(ProcurementRowData);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
