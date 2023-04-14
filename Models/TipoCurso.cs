using System.ComponentModel.DataAnnotations;

public class TipoCurso
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    [MinLength(3)]
    [MaxLength(10, ErrorMessage = "O nome pode conter, no máximo, 10 caracteres")]
    public string Nome { get; set; }
    
    [Required]
    public string Descricao { get; set; }
}