using System.ComponentModel.DataAnnotations;
using Fina.Core.Enums;

namespace Fina.Core.Requests.Transactions;

public class UpdateTransactionsRequest :  Request
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Título inválido")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Tipo inválido")]
    public ETransactionType Type { get; set; } =  ETransactionType.Withdraw;
    
    [Required(ErrorMessage = "Valor inválido")]
    public decimal Amount { get; set; }
    
    [Required(ErrorMessage = "Categoria inválida")]
    public Guid CategoryId { get; set; }
    
    public DateTime? PaidOrReceivedAt { get; set; }
    
}