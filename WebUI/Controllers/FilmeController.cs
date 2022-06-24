using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eAuditoria.Domain.Models;
using eAuditoria.Application.Common.Interfaces;
using eAuditoria.Application.ViewModels;
using eAuditoria.WebUI.Extensions;

namespace eAuditoria.WebUI.Controllers
{
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
            => _filmeService = filmeService;

        //Simple registering card method
        [HttpGet]
        [Route("v1/filmes")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var filme = await _filmeService.GetAllAsync();
                return Ok(new ResultViewModel<List<Filme>>(filme));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Filme>>("A2X1E1 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/filmes/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
          [FromRoute] int id)
        {
            try
            {
                var filme = await _filmeService.GetByIdAsync(id);

                if (filme == null)
                    return NotFound(new ResultViewModel<Filme>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Filme>(filme));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Filme>("A2X2E1 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/filmes/cadastro")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorFilmeViewModel model )
        {
            if( !ModelState.IsValid )
                return BadRequest(new ResultViewModel<EditorFilmeViewModel>(ModelState.GetErrors()));

            try
            {
                await _filmeService.AddAsync(model);                
                return Created("v1/filmes", new ResultViewModel<EditorFilmeViewModel>(model));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<EditorFilmeViewModel>("A2X3E1 - Não foi possível incluir o filme."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<EditorFilmeViewModel>("A2X3E2 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/filmes/alterar/{id:int}")]
        public async Task<IActionResult> PutAsync(
           [FromRoute] int id,
           [FromBody] EditorFilmeViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Filme>(ModelState.GetErrors()));

            try
            {
                var filme = await _filmeService.GetByIdAsync(id);

                if (filme == null)
                    return NotFound(new ResultViewModel<Filme>("Conteúdo não encontrado"));

                await _filmeService.UpdateAsync( filme, model );

                return Ok(new ResultViewModel<Filme>(filme));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Filme>("A2X4E1 - Não foi possível alterar o filme."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Filme>("A2X4E2 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/filmes/delete/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
          [FromRoute] int id )
        {
            try
            {
                var filme = await _filmeService.GetByIdAsync(id);

                if (filme == null)
                    return NotFound(new ResultViewModel<Filme>("Conteúdo não encontrado"));

                await _filmeService.DeleteAsync(filme);

                return Ok(new ResultViewModel<Filme>(filme));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Filme>("A2X5E1 - Não foi possível excluir o filme."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Filme>("A2X5E2 - Falha interna no servidor"));
            }
        }
    }
}