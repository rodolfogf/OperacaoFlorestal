using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OperacaoFlorestal.Data.DTOs.Coleta;
using OperacaoFlorestal.Services.Interfaces;

namespace OperacaoFlorestal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColetaDadosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IColetaDadosService _coletaDadosService;

        public ColetaDadosController(IMapper mapper, IColetaDadosService coletaDadosService)
        {
            _mapper = mapper;
            _coletaDadosService = coletaDadosService;
        }

        [HttpPost("{idMaquinario}")]
        public async Task<IActionResult> Coletar(int idMaquinario)
        {
            try
            {
                var result = await _coletaDadosService.ColetarDadosAsync(idMaquinario);
                var dto = _mapper.Map<ReadColetaDadosDTO>(result);

                return Ok(dto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno na coleta de dados: {ex.Message}");
            }
        }
    }
}
