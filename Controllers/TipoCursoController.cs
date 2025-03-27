using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TipoCursoController : ControllerBase
{
    private readonly DataContext context;

    public TipoCursoController(DataContext _context)
    {
        context = _context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TipoCurso>> Get()
    {
        try
        {
            return Ok(context.TipoCursos.ToList());
        }
        catch
        {
            return BadRequest("Erro ao listar os tipos de curso");
        }
    }

    [HttpPost]
    public ActionResult Post(TipoCurso item)
    {
        try
        {
            context.TipoCursos.Add(item);
            context.SaveChanges();
            return Ok("Tipo de curso salvo com sucesso");
        }
        catch
        {
            return BadRequest("Erro ao salvar o tipo de curso informado");

        }
    }

}