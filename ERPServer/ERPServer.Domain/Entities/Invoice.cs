using ERPServer.Domain.Abstractions;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Enums;

public sealed class Invoice:Entity
{
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public InvoiceTypeEnum Type { get; set; } = InvoiceTypeEnum.Purchase;
    public List<InvoiceDetail>? Details { get; set; }
    
}
