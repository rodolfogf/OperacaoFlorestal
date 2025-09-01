using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OperacaoFlorestal.Data.DTOs.VooVant;
using OperacaoFlorestal.Models;
using OperacaoFlorestal.Services.Interfaces;

namespace OperacaoFlorestal.Controllers
{
    public class VooVantController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVooVantService _vooVantService;

        public VooVantController(IMapper mapper, IVooVantService vooVantService)
        {
            _mapper = mapper;
            _vooVantService = vooVantService;
        }

        public async Task<ActionResult<IEnumerable<ReadVooVantDTO>>> RetornarVoosVant([FromQuery] int skip=0, [FromQuery] int take=10)
        {
            try
            {
                var vooVants = await _vooVantService.GetAllVooVantAsync(skip, take);
                var vooVantsDTO = _mapper.Map<IEnumerable<ReadVooVantDTO>>(vooVants);
                return Ok(vooVantsDTO);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado {ex.Message }");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornarVooVantPorId(int id)
        {
            try
            {
                var vooVant = await _vooVantService.GetVooVantById(id);
                var vooVantDto = _mapper.Map<ReadVooVantDTO>(vooVant);
                return Ok(vooVantDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao buscar vooVant: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarVooVant([FromBody] CreateVooVantDTO vooVantDto)
        {
            try
            {
                var vooVant = _mapper.Map<VooVant>(vooVantDto);
                var result = await _vooVantService.AddVooVantAsync(vooVant);
                var readDto = _mapper.Map<ReadVooVantDTO>(result);

                return CreatedAtAction(
                    nameof(RetornarVooVantPorId),
                    new { id = result.Id },
                    readDto
                );
            }
            catch (HttpRequestException ex) // erro ao salvar no banco
            {
                return StatusCode(500, ex.Message);
            }
            catch (InvalidOperationException ex) // maquinario não é VANT
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex) // maquinario não encontrado
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao cadastrar voo de Vant: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaVoovant(int id, [FromBody] UpdateVooVantDTO vooVantDto)
        {
            try
            {
                var vooVantAtualizar = _mapper.Map<VooVant>(vooVantDto);
                var result = await _vooVantService.UpdateVooVantAsync(id, vooVantAtualizar);
                var readDto = _mapper.Map<ReadVooVantDTO>(result);

                return Ok(readDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao atualizar voo vant: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarVooVant(int id)
        {
            try
            {
                await _vooVantService.DeleteVooVantAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex) // id inválido
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex) // vooVant não encontrado
            {
                return NotFound(ex.Message);
            }
            catch (HttpRequestException ex) // erro ao excluir do banco
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao excluir voo vant: {ex.Message}");
            }
        }
    }
}
