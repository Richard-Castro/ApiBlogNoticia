using System.ComponentModel.DataAnnotations;

public class Email
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Email é obrigatório")]
    public string EmailDestino { get; set; }

}