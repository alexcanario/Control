namespace Dima.Core.Requests.Categories;

public class UpdateCategoryRequest : Request
{
	public long Id { get; set; }

	[Required(ErrorMessage = "Título inválido!")]
	[MaxLength(80, ErrorMessage = "Título deve ter no máximo {1} caracteres!")]
	public string Title { get; set; } = string.Empty;

	[Required(ErrorMessage = "Descrição inválida!")]
	public string Description { get; set; } = string.Empty;

}