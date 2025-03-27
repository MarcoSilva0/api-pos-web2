using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TipoCursoController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Olá mundo";
    }

    [HttpPost]
    public ActionResult Post(TipoCurso item)
    {
        return Ok("Apenas validando os dados");
    }

}