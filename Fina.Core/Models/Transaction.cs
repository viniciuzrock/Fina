using Fina.Core.Enums;

namespace Fina.Core.Models;

public record Transaction 
{
    public Guid Id  { get; init; }
    public string Title  { get; set; } = string.Empty;
    public DateTime CreatedAt  { get; init; } = DateTime.UtcNow;
    public DateTime? PaidOrReceivedAt  { get; set; }
    public ETransactionType Type  { get; set; } =  ETransactionType.Withdraw;
    public decimal Amount { get; set; }
    public Guid CategoryId   { get; set; }
    public Category Category { get; init; } = null!;
    public string UserId  { get; init; } = string.Empty;
}
