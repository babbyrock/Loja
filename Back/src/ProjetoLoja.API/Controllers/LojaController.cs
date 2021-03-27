using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoLoja.API.Models;

namespace ProjetoLoja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LojaController : ControllerBase
    {    
        public IEnumerable <Loja> _loja = new Loja[]{
            new Loja(){
            LojaId = 1,
            CNPJ = "12345",
            RazaoSocial = "Sapataria",
            NomeFantasia = "Nova",
            Telefone = "85989434173"
            },
            new Loja(){
            LojaId = 2,
            CNPJ = "5555",
            RazaoSocial = "Papelaria",
            NomeFantasia = "Faber Castel",
            Telefone = "85888888888"
            }
        };

        public LojaController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Loja> Get()
        {
            return _loja;
        }
        [HttpGet("{id}")]
        public IEnumerable<Loja> Get(int id)
        {
            return _loja.Where(loja => loja.LojaId == id);
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
