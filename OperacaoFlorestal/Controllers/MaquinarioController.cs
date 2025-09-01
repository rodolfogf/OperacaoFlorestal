using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OperacaoFlorestal.Data.DTOs.Maquinario;
using OperacaoFlorestal.Models;
using OperacaoFlorestal.Services.Interfaces;

namespace OperacaoFlorestal.Controllers
{
    public class MaquinarioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMaquinarioService _maquinarioService;

        public MaquinarioController(IMapper mapper, IMaquinarioService maquinarioService)
        {
            _mapper = mapper;
            _maquinarioService = maquinarioService;
        }

        public async Task<ActionResult<IEnumerable<ReadMaquinarioDTO>>> RetornarMaquinarios([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            try
            {
                var maquinarios = await _maquinarioService.GetAllMaquinarioAsync(skip, take);
                var maquinariosDTO = _mapper.Map<IEnumerable<ReadMaquinarioDTO>>(maquinarios);
                return Ok(maquinariosDTO);
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
                return StatusCode(500, $"Ocorreu um erro inesperado {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornarMaquinarioPorId(int id)
        {
            try
            {
                var maquinario = await _maquinarioService.GetMaquinarioById(id);
                var maquinarioDto = _mapper.Map<ReadMaquinarioDTO>(maquinario);
                return Ok(maquinarioDto);
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
                return StatusCode(500, $"Erro interno ao buscar maquinário: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarMaquinario([FromBody] CreateMaquinarioDTO maquinarioDto)
        {
            try
            {
                var maquinario = _mapper.Map<Maquinario>(maquinarioDto);
                var result = await _maquinarioService.AddMaquinarioAsync(maquinario);
                var readDto = _mapper.Map<ReadMaquinarioDTO>(result);

                return CreatedAtAction(
                    nameof(RetornarMaquinarioPorId),
                    new { id = result.Id },
                    readDto
                );
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao cadastrar maquinário: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaMaquinario(int id, [FromBody] UpdateMaquinarioDTO maquinarioDto)
        {
            try
            {
                var maquinarioAtualizar = _mapper.Map<Maquinario>(maquinarioDto);
                var result = await _maquinarioService.UpdateMaquinarioAsync(id, maquinarioAtualizar);
                var readDto = _mapper.Map<ReadMaquinarioDTO>(result);

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
                return StatusCode(500, $"Erro interno ao atualizar maquinário: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarMaquinario(int id)
        {
            try
            {
                await _maquinarioService.DeleteMaquinarioAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao excluir maquinário: {ex.Message}");
            }
        }
    }
}
