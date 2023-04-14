using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class LeitorController : ControllerBase
{
    private readonly DataContext context;

    public LeitorController(DataContext Context)
    {
        context = Context;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Leitor model)
    {
        try
        {
            context.Leitor.Add(model);
            await context.SaveChangesAsync();
            return Ok("Leitor salvo com sucesso");
        }
        catch
        {
            return BadRequest("Falha ao inserir o Leitor informado");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Leitor>>> Get()
    {
        try
        {
            return Ok(await context.Leitor.ToListAsync());
        }
        catch
        {
            return BadRequest("Erro ao obter os Leitores");
        }
    }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<TipoCurso>> Get([FromRoute] int id)
    // {
    //     try
    //     {
    //         if (await context.TipoCursos.AnyAsync(p => p.Id == id))
    //             return Ok(await context.TipoCursos.FindAsync(id));
    //         else
    //             return NotFound();
    //     }
    //     catch
    //     {
    //         return BadRequest();
    //     }
    // }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Leitor model)
    {
        if (id != model.Id)
            return BadRequest();

        try
        {
            if (await context.Leitor.AnyAsync(p => p.Id == id) == false)
                return NotFound();

            context.Leitor.Update(model);
            await context.SaveChangesAsync();
            return Ok("Leitor Atualizado com sucesso");
        }
        catch
        {
            return BadRequest();
        }
    }

    // [HttpDelete("{id}")]
    // public async Task<ActionResult> Delete([FromRoute] int id)
    // {
    //     try
    //     {
    //         TipoCurso model = await context.TipoCursos.FindAsync(id);

    //         if (model == null)
    //             return NotFound();

    //         context.TipoCursos.Remove(model);
    //         await context.SaveChangesAsync();
    //         return Ok("Tipo de curso removido com sucesso");
    //     }
    //     catch
    //     {
    //         return BadRequest("Falha ao remover o tipo de curso");
    //     }
    // }
}