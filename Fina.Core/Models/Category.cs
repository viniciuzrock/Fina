namespace Fina.Core.Models;

public record Category
{
    public Guid Id  { get; init; }
    public string Title  { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string UserId  { get; init; } = string.Empty;
}