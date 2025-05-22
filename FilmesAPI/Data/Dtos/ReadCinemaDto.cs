using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class ReadCinemaDto
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Nome { get; set; }
}
