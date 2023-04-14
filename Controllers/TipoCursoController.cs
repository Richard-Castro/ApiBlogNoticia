using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TipoCursoController : ControllerBase
{
    private readonly DataContext context;

    public TipoCursoController(DataContext Context)
    {
        context = Context;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] TipoCurso model)
    {
        try
        {
            context.TipoCursos.Add(model);
            await context.SaveChangesAsync();
            return Ok("Tipo de curso salvo com sucesso");
        }
        catch
        {
            return BadRequest("Falha ao inserir o tipo de curso informado");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoCurso>>> Get()
    {
        try
        {
            return Ok(await context.TipoCursos.ToListAsync());
        }
        catch
        {
            return BadRequest("Erro ao obter os tipos de curso");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TipoCurso>> Get([FromRoute] int id)
    {
        try
        {
            if (await context.TipoCursos.AnyAsync(p => p.Id == id))
                return Ok(await context.TipoCursos.FindAsync(id));
            else
                return NotFound();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] TipoCurso model)
    {
        if (id != model.Id)
            return BadRequest();

        try
        {
            if (await context.TipoCursos.AnyAsync(p => p.Id == id) == false)
                return NotFound();

            context.TipoCursos.Update(model);
            await context.SaveChangesAsync();
            return Ok("Tipo de curso salvo com sucesso");
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        try
        {
            TipoCurso model = await context.TipoCursos.FindAsync(id);

            if (model == null)
                return NotFound();

            context.TipoCursos.Remove(model);
            await context.SaveChangesAsync();
            return Ok("Tipo de curso removido com sucesso");
        }
        catch
        {
            return BadRequest("Falha ao remover o tipo de curso");
        }
    }
}