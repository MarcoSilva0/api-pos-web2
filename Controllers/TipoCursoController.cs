using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TipoCursoController : ControllerBase
{
    private readonly DataContext context;

    public TipoCursoController(DataContext _context)
    {
        context = _context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TipoCurso>> Get([FromRoute] int id)
    {
        try
        {
            if (await context.TipoCursos.AnyAsync(p => p.Id == id))
            {
                return Ok(await context.TipoCursos.FindAsync(id));
            }
            else
            {
                return NotFound("O tipo de curso informado não foi encontrado!");
            }
        }
        catch
        {
            return BadRequest("Erro ao efetuar a busca de tipo de curso");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] TipoCurso model) {
        if (id != model.Id) {
            return BadRequest("Tipó de curso inválido");
        }

        try
        {
            if(!await context.TipoCursos.AnyAsync(p => p.Id != id)){
                return NotFound("Tipo de curso inválido");
            }

            context.TipoCursos.Update(model);
            await context.SaveChangesAsync();
            return Ok("Tipo de curso salvo com sucesso");
        }
        catch
        {
            return BadRequest("Erro ao salvar o tipo de curso informado");
        }
    }	

    [HttpDelete("{id}")]
    public async Task<ActionResult>Delete([FromRoute] int id) {
        try
        {
            TipoCurso model = await context.TipoCursos.FindAsync(id);

            if (model == null) {
                return NotFound("Tipo de curso inválido");
            }

            context.TipoCursos.Remove(model);
            await context.SaveChangesAsync();
            return Ok("Tipo de curso removido com sucesso");
        }
        catch
        {
            return BadRequest("Falha ao remover o tipo de curso");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] TipoCurso item)
    {
        try
        {
            await context.TipoCursos.AddAsync(item);
            await context.SaveChangesAsync();
            return Ok("Tipo de curso salvo com sucesso");
        }
        catch
        {
            return BadRequest("Erro ao salvar o tipo de curso informado");

        }
    }

    [HttpGet("pesquisaNome/{nome}")]
    public async Task<ActionResult<IEnumerable<TipoCurso>>> Get([FromRoute] string nome) {
        try
        {
            List<TipoCurso> resultado = await context.TipoCursos.Where(p => p.Nome == nome).ToListAsync();
            return Ok(resultado);
        }
        catch
        {
            return BadRequest("Falha ao buscar um tipo de curso");
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
            return BadRequest("Erro ao listar os tipos de curso");
        }
    }

}