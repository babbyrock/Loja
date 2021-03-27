namespace ProjetoLoja.API.Models
{
    public class Loja
    {
        public int LojaId { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
    }
}