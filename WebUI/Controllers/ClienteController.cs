using Microsoft.AspNetCore.Mvc;
using eAuditoria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using eAuditoria.Application.Common.Interfaces;
using eAuditoria.WebUI.Extensions;
using eAuditoria.Application.ViewModels;

namespace eAuditoria.WebUI.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService) 
            => _clienteService = clienteService;

        //Simple registering card method
        [HttpGet]
        [Route("v1/clientes")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var clientes = await _clienteService.GetAllAsync();
                return Ok(new ResultViewModel<List<Cliente>>(clientes));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Cliente>>("A1X1E1 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/clientes/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
          [FromRoute] int id )
        {
            try
            {
                var cliente = await _clienteService.GetByIdAsync( id );

                if (cliente == null)
                    return NotFound(new ResultViewModel<Cliente>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Cliente>(cliente));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Cliente>("A1X2E1 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/clientes/cadastro")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorClienteViewModel model)
        {
            if( !ModelState.IsValid )
                return BadRequest(new ResultViewModel<EditorClienteViewModel>(ModelState.GetErrors()));

            try
            {
                await _clienteService.AddAsync(model);
                return Created("v1/clientes", new ResultViewModel<EditorClienteViewModel>(model));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Cliente>("A1X3E1 - Não foi possível incluir o cliente."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Cliente>("A1X3E2 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/clientes/alterar/{id:int}")]
        public async Task<IActionResult> PutAsync(
           [FromRoute] int id,
           [FromBody] EditorClienteViewModel model )
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Cliente>(ModelState.GetErrors()));

            try
            {
                var cliente = await _clienteService.GetByIdAsync(id);

                if (cliente == null)
                    return NotFound(new ResultViewModel<Cliente>("Conteúdo não encontrado"));

                await _clienteService.ChangeAsync(cliente, model);
                return Ok(new ResultViewModel<Cliente>(cliente));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Cliente>("A1X4E1 - Não foi possível alterar o cliente."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Cliente>("A1X4E2 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/clientes/delete/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
          [FromRoute] int id )
        {
            try
            {
                var cliente = await _clienteService.GetByIdAsync(id);

                if (cliente == null)
                    return NotFound(new ResultViewModel<Cliente>("Conteúdo não encontrado"));
                
                await _clienteService.DeleteAsync(cliente);

                return Ok(new ResultViewModel<Cliente>(cliente));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Cliente>("A1X5E1 - Não foi possível excluir o cliente."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Cliente>("A1X5E2 - Falha interna no servidor"));
            }
        }
    }
}