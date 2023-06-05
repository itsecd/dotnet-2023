using Microsoft.EntityFrameworkCore;

namespace EnterpriseWarehouse.Model;

public class EnterpriseWarehouseDbContext : DbContext
{
    public DbSet<Product>? Products { get; set; }

    public DbSet<StorageCell>? StorageCells { get; set; }

    public DbSet<Invoice>? Invoices { get; set; }

    public DbSet<InvoiceContent>? InvoicesContent { get; set; }

    public EnterpriseWarehouseDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var product_1 = new Product { Id = 1, ItemNumber = 102302, Title = "Картонная коробка 40*30*30", Quantity = 100 };
        var product_2 = new Product { Id = 2, ItemNumber = 104302, Title = "Картонная коробка 60*40*50", Quantity = 50 };
        var product_3 = new Product { Id = 3, ItemNumber = 106302, Title = "Чайник из нерж. стали 3л", Quantity = 5 };
        var product_4 = new Product { Id = 4, ItemNumber = 108302, Title = "Кастрюля алюм. с крышкой 5л", Quantity = 10 };
        var product_5 = new Product { Id = 5, ItemNumber = 310510, Title = "Столовая ложка из нерж. стали", Quantity = 35 };
        var product_6 = new Product { Id = 6, ItemNumber = 312510, Title = "Чайная ложка из нерж. стали", Quantity = 50 };
        var product_7 = new Product { Id = 7, ItemNumber = 320510, Title = "Вилка из нерж. стали", Quantity = 25 };
        var product_8 = new Product { Id = 8, ItemNumber = 101700, Title = "Кувшин для воды из стекла 4л", Quantity = 10 };
        var product_9 = new Product { Id = 9, ItemNumber = 103700, Title = "Кувшин для воды из стекла 3л", Quantity = 15 };

        var storageCell_1 = new StorageCell { Id = 1, Number = 1, ProductID = 1 };
        var storageCell_2 = new StorageCell { Id = 2, Number = 2, ProductID = 2 };
        var storageCell_3 = new StorageCell { Id = 3, Number = 3, ProductID = 3 };
        var storageCell_4 = new StorageCell { Id = 4, Number = 4, ProductID = 4 };
        var storageCell_5 = new StorageCell { Id = 5, Number = 5, ProductID = 5 };
        var storageCell_6 = new StorageCell { Id = 6, Number = 6, ProductID = 5 };
        var storageCell_7 = new StorageCell { Id = 7, Number = 7, ProductID = 5 };
        var storageCell_8 = new StorageCell { Id = 8, Number = 8, ProductID = 6 };
        var storageCell_9 = new StorageCell { Id = 9, Number = 9, ProductID = 6 };
        var storageCell_10 = new StorageCell { Id = 10, Number = 10, ProductID = 7 };
        var storageCell_11 = new StorageCell { Id = 11, Number = 11, ProductID = 8 };
        var storageCell_12 = new StorageCell { Id = 12, Number = 12, ProductID = 8 };
        var storageCell_13 = new StorageCell { Id = 13, Number = 13, ProductID = 8 };
        var storageCell_14 = new StorageCell { Id = 14, Number = 14, ProductID = 8 };
        var storageCell_15 = new StorageCell { Id = 15, Number = 15, ProductID = 9 };
        var storageCell_16 = new StorageCell { Id = 16, Number = 16, ProductID = 9 };

        var invoice_1 = new Invoice { Id = 1, NameOrganization = "СамараПласт", AddressOrganization = "г. Самара, ул. Луцкая, 16.", ShipmentDate = new DateTime(2023, 2, 10) };
        var invoice_2 = new Invoice { Id = 2, NameOrganization = "Посуда Центр", AddressOrganization = "г. Самара, ул. Партизанская, 17.", ShipmentDate = new DateTime(2023, 2, 11) };
        var invoice_3 = new Invoice { Id = 3, NameOrganization = "Посуда Центр", AddressOrganization = "г. самара, ул. Партизанская, 17.", ShipmentDate = new DateTime(2023, 2, 15) };

        var invoiceContent_1 = new InvoiceContent { Id = 1, InvoiceId = 1, ProductID = 1, Quantity = 10 };
        var invoiceContent_2 = new InvoiceContent { Id = 2, InvoiceId = 2, ProductID = 8, Quantity = 5 };
        var invoiceContent_3 = new InvoiceContent { Id = 3, InvoiceId = 2, ProductID = 7, Quantity = 10 };
        var invoiceContent_4 = new InvoiceContent { Id = 4, InvoiceId = 3, ProductID = 9, Quantity = 10 };

        modelBuilder.Entity<Product>().HasKey(x => x.Id);
        modelBuilder.Entity<Invoice>().HasKey(x => x.Id);

        modelBuilder.Entity<Product>().HasData(new List<Product>
        {
            product_1,
            product_2,
            product_3,
            product_4,
            product_5,
            product_6,
            product_7,
            product_8,
            product_9
        });

        modelBuilder.Entity<StorageCell>().HasData(new List<StorageCell>
         {
             storageCell_1,
             storageCell_2,
             storageCell_3,
             storageCell_4,
             storageCell_5,
             storageCell_6,
             storageCell_7,
             storageCell_8,
             storageCell_9,
             storageCell_10,
             storageCell_11,
             storageCell_12,
             storageCell_13,
             storageCell_14,
             storageCell_15,
             storageCell_16
         });

        modelBuilder.Entity<Invoice>().HasData(new List<Invoice>
          {
              invoice_1,
              invoice_2,
              invoice_3
          });

        modelBuilder.Entity<InvoiceContent>().HasData(new List<InvoiceContent>{
              invoiceContent_1,
              invoiceContent_2,
              invoiceContent_3,
              invoiceContent_4
          });
    }
}
