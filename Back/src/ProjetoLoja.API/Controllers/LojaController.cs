using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoLoja.Persistence;
using ProjetoLoja.Domain;
using ProjetoLoja.Persistence.Context;
using ProjetoLoja.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace ProjetoLoja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LojaController : ControllerBase
    {


        private readonly ILojaService _lojaService;

        public LojaController(ILojaService lojaService)
        {
            _lojaService = lojaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lojas = await _lojaService.GetAllLojaAsync();
                if (lojas == null) return NotFound("Nenhum evento encontrado.");

                return Ok(lojas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar lojas. Error: {ex.Message}");

            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var loja = await _lojaService.GetLojaByIdAsync(id);
                if (loja == null) return NotFound("Loja por Id não encontrado.");

                return Ok(loja);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar lojas. Error: {ex.Message}");

            }
        }

        [HttpGet("{nomefantasia}/nomefantasia")]
        public async Task<IActionResult> GetByNomeFantasia(string nome)
        {
            try
            {
                var loja = await _lojaService.GetAllLojaByNomeFantasiaAsync(nome);
                if (loja == null) return NotFound("Loja por Nome não encontrado.");

                return Ok(loja);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar lojas. Error: {ex.Message}");

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Loja model)
        {
            try
            {
                var loja = await _lojaService.AddLoja(model);
                if (loja == null) return BadRequest("Erro ao tentar adicionar uma loja.");

                return Ok(loja);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar lojas. Error: {ex.Message}");

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Loja model)
        {
            try
            {
                var loja = await _lojaService.UpdateLoja(id, model);
                if (loja == null) return BadRequest("Erro ao tentar adicionar uma loja.");

                return Ok(loja);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar lojas. Error: {ex.Message}");

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _lojaService.DeleteLoja(id) ?
                     Ok("Deletado") :
                    BadRequest("Evento não deletado");
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar lojas. Error: {ex.Message}");

            }
        }

    }
}
