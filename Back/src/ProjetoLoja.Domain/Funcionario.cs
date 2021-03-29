using System.Collections.Generic;

namespace ProjetoLoja.Domain
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public int LojaId { get; set; }
        public  Loja Loja { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }
    }
}