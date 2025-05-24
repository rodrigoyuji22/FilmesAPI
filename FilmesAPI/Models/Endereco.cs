using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Logradouro { get; set; }
    [Required]
    public int Numero { get; set; }
    public string? Complemento { get; set; }
    [Required]
    public int Cep { get; set; }
    public virtual Cinema? Cinema { get; set; }
}
