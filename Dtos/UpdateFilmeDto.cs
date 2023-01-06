using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos;

public class UpdateFilmeDto
{
    
    [Required(ErrorMessage = "O titulo do filme é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O genero do filme é obrigatório")]
    [StringLength(50, ErrorMessage = "o tamanho maximo do gênero é 50 caracteres")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "A duração do filme é obrigatório")]
    [Range(70, 600, ErrorMessage = "a druação deve estar entre 70 e 600 minutos")]
    public int Duracao { get; set; }
}
