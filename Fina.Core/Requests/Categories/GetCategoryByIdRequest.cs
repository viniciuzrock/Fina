using System.ComponentModel.DataAnnotations;

namespace Fina.Core.Requests.Categories;

public class GetCategoryByIdRequest :  Request
{
    [Required(ErrorMessage = "O id deve ser informado")]
    public Guid Id { get; set; }
}