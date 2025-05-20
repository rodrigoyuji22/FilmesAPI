using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class CreateFilmeDto
{
    [Required]
    [StringLength(100, ErrorMessage = "Titulo inválido.")]
    public string Titulo { get; set; }
    [Required]
    [Range(1900, 2025, ErrorMessage = "Ano inválido.")]
    public int Ano { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "Genêro inválido.")]
    public string Genero { get; set; }
    [Required]
    [Range(70, 600, ErrorMessage = "A duração do filme deve ser entre 70 e 600 minutos.")]
    public int Duracao { get; set; }
}
