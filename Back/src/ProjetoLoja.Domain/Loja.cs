using System.Collections.Generic;

namespace ProjetoLoja.Domain
{
    public class Loja
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
    }
}