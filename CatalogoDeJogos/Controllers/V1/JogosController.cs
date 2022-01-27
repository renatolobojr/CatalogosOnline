using CatalogoDeJogos.InputModel;
using CatalogoDeJogos.Services;
using CatalogoDeJogos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CatalogoDeJogos.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService JogoService;
        
        public JogosController(IJogoService jogoService)
        {
            JogoService = jogoService;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> ObterTodos([FromQuery,Range(1,int.MaxValue)] int pagina,
                                                                        [FromQuery,Range(5,50)] int quantidadePorPagina)
        {
            var jogos = await JogoService.ObterTodos(pagina, quantidadePorPagina);

            if (jogos.Count == 0) return NoContent();
            
            return Ok(jogos);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<JogoViewModel>> ObterPorId([FromRoute]Guid id )
        {
            var jogo = await JogoService.ObterPorId(id);

            if (jogo is null) return NoContent();

            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> Inserir([FromBody] JogoInputModel jogoNovo)
        {
            try
            {
                var jogo = await JogoService.Inserir(jogoNovo); 
                return Created("{id}", jogo);
            }
            catch (Exception)
            {
                return UnprocessableEntity("Ja existe um Jogo com esse Nome na Produtora");
            }
            
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Atualizar(  [FromRoute] Guid id, 
                                                    [FromBody] JogoInputModel jogoAtual)
        {
            try
            {
                await JogoService.Atualizar(id,jogoAtual);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound("Não existe esse Jogo");
            }
        }

        [HttpPatch("{id:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarPreco( [FromRoute] Guid id, 
                                                        [FromRoute] double preco)
        {
            try
            {
                await JogoService.AtualizarPreco(id, preco);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound("Não existe esse Jogo");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            try
            {
                await JogoService.Excluir(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound("Não existe esse Jogo");
            }
            
        }

        
    }
}
