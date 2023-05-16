using Enterprise.Data;

namespace EnterpriseWarehouseServer.Repositories;

/// <summary>
///     InvoceRepository - create list of element of the Invoce
/// </summary>
public class InvoiceRepository : IInvoiceRepository
{
    private readonly List<Invoice> _invoices;

    public InvoiceRepository()
    {
        _invoices = new List<Invoice>{
            new Invoice (1, "СамараПласт", "г. Самара, ул. Луцкая, 16.", new DateTime(2023, 2, 10), new Dictionary<uint, uint>{ { 102302, 10} } ),
            new Invoice (2, "Посуда Центр", "г. Самара, ул. Партизанская, 17.", new DateTime(2023, 2, 11), new Dictionary<uint, uint>{{ 101700, 5}, { 320510, 10 } }),
            new Invoice (4, "Посуда Центр", "г. самара, ул. Партизанская, 17.", new DateTime(2023, 2, 15), new Dictionary<uint, uint>{{103700, 10}})
        };
    }

    public List<Invoice> Invoices => _invoices;
}