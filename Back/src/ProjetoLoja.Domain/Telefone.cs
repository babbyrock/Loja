namespace ProjetoLoja.Domain
{
    public class Telefone
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Phone { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}