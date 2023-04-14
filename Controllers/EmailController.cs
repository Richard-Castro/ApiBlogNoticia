using EnviaEmail;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Email model)
    {
        try
        {
            SendEmail.Send(model.EmailDestino);
            return Ok("E-mail enviado com sucesso !!!");
        }
        catch
        {
            return BadRequest("Falha ao inserir o Leitor informado");
        }
    }
}