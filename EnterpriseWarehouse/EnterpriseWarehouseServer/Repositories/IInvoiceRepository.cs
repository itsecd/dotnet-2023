using Enterprise.Data;

namespace EnterpriseWarehouseServer.Repositories;
public interface IInvoiceRepository
{
    List<Invoice> Invoices { get; }
}