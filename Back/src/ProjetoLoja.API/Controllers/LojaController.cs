using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoLoja.API.Data;
using ProjetoLoja.API.Models;

namespace ProjetoLoja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LojaController : ControllerBase
    {
        
        private readonly DataContext _context;

        public LojaController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Loja> Get()
        {
            return _context.Lojas;
        }
        [HttpGet("{id}")]
        public Loja Get(int id)
        {
            return _context.Lojas.FirstOrDefault(loja => loja.LojaId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "exemplo de post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"exemplo de put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"exemplo de Delete com id = {id}";
        }

    }
}
