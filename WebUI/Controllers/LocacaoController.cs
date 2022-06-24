using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eAuditoria.Domain.Models;
using eAuditoria.Application.Common.Interfaces;
using eAuditoria.Application.ViewModels;
using eAuditoria.WebUI.Extensions;

namespace eAuditoria.WebUI.Controllers
{
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoService _locacaoService;
        private readonly IClienteService _clienteService;
        private readonly IFilmeService _filmeService;
        public LocacaoController(ILocacaoService locacaoService, IClienteService clienteService, IFilmeService filmeService )
        {
            _locacaoService = locacaoService;
            _clienteService = clienteService;
            _filmeService = filmeService;
        }

        //Simple registering card method
        [HttpGet]
        [Route("v1/locacoes")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var locacao = await _locacaoService.GetAllAsync();
                return Ok(new ResultViewModel<List<Locacao>>(locacao));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Locacao>>("A3X1E1 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/locacoes/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
          [FromRoute] int id )
        {
            try
            {
                var locacao = await _locacaoService.GetByIdAsync(id);

                if (locacao == null)
                    return NotFound(new ResultViewModel<Locacao>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Locacao>(locacao));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Locacao>("A3X2E1 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/locacoes/cadastro")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CreateLocacaoViewModel model )
        {
            if( !ModelState.IsValid )
                return BadRequest(new ResultViewModel<CreateLocacaoViewModel>(ModelState.GetErrors()));

            try
            {
                var cliente = await _clienteService.GetByIdAsync(model.Id_Cliente);
                var filme = await _filmeService.GetByIdAsync(model.Id_Filme);
             
                if(cliente == null )
                    return NotFound(new ResultViewModel<CreateLocacaoViewModel>($"Cliente com Id {model.Id_Cliente} não encontrado"));
                if( filme == null )
                    return NotFound(new ResultViewModel<CreateLocacaoViewModel>($"Filme com Id {model.Id_Filme} não encontrado"));

                await _locacaoService.AddAsync(model, filme);

                return Created("v1/locacoes", new ResultViewModel<CreateLocacaoViewModel>(model));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<CreateLocacaoViewModel>("A3X3E1 - Não foi possível incluir a locação."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<CreateLocacaoViewModel>("A3X3E2 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/locacoes/alterar/{id:int}")]
        public async Task<IActionResult> PutAsync(
           [FromRoute] int id,
           [FromBody] UpdateLocacaoViewModel model )
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Locacao>(ModelState.GetErrors()));

            try
            {
                var locacao = await _locacaoService.GetByIdAsync(id);

                if (locacao == null)
                    return NotFound(new ResultViewModel<Locacao>("Conteúdo não encontrado"));

                await _locacaoService.UpdateAsync(locacao, model);

                return Ok(new ResultViewModel<Locacao>(locacao));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Locacao>("A3X4E1 - Não foi possível alterar a locação."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Locacao>("A3X4E2 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/locacoes/delete/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
          [FromRoute] int id )
        {
            try
            {
                var locacao = await _locacaoService.GetByIdAsync(id);

                if (locacao == null)
                    return NotFound(new ResultViewModel<Locacao>("Conteúdo não encontrado"));

                await _locacaoService.DeleteAsync(locacao);

                return Ok(new ResultViewModel<Locacao>(locacao));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Locacao>("A3X5E1 - Não foi possível excluir a locação."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Locacao>("A3X5E2 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/locacoes/clientes-locacoes-atrasadas")]
        public async Task<IActionResult> GetClientesLocacaoesAtrasadas()
        {
            try
            {
                var clientes = await _locacaoService.GetClientesLocacaoAtrasada();
                return Ok(new ResultViewModel<List<Cliente>>(clientes));
            }            
            catch
            {
                return StatusCode(500, new ResultViewModel<Cliente>("A3X6E1 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/locacoes/sem-locacao")]
        public async Task<IActionResult> GetFilmesSemLocacaoAsync()
        {
            try
            {
                var filmes = await _locacaoService.GetFilmesSemLocacao();
                return Ok(new ResultViewModel<List<Filme>>(filmes));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Filme>>("A3X7E1 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/locacoes/top5-filmes-ano")]
        public async Task<IActionResult> GetTop5FilmesAnoAsync()
        {
            try
            {
                var filmes = await _locacaoService.GetTop5FilmesAno();
                return Ok(new ResultViewModel<List<Filme>>(filmes));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Filme>>("A3X8E1 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/locacoes/bottom3-filmes-semana")]
        public async Task<IActionResult> GetBottom3FilmesSemanaAsync()
        {
            try
            {
                var filmes = await _locacaoService.GetBttom3FilmesSemana();
                return Ok(new ResultViewModel<List<Filme>>(filmes));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Filme>>("A3X9E1 - Falha interna no servidor"));
            }
        }


        [HttpGet("v1/locacoes/segundo-melhor-cliente")]
        public async Task<IActionResult> GetSegundoMelhorCliente()
        {
            try
            {
                var cliente = await _locacaoService.GetSegundoMelhorCliente();
                return Ok(new ResultViewModel<Cliente>(cliente));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Cliente>("A3X9E1 - Falha interna no servidor"));
            }
        }
    }
}