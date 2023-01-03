using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] Filme filme)
    {
        //adciona um filme com um id
        filme.Id = id++;
        filmes.Add(filme);
        //cria o filme e redireciona para o caminho com o id que foi criado
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    [HttpGet]
    //busca todos os filmes, com skip(pula) como padrão 0, e take(pega) como padrão 10
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    //recupera um filme por id que é passado como parametro
    public IActionResult RecuperaFilmePorId(int id)
    {
        //pega o primeiro filme da lista com o id solicitado
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        //caso o retorno for um id que não há na base, retorna falso e devolve uma ação 404 (not found)
        if (filme == null) return NotFound();
        //caso contrario retorna os dados do filme com o status 200(ok)
        return Ok(filme);
    }
}
