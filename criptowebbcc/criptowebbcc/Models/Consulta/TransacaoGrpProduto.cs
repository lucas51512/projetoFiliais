namespace criptowebbcc.Models.Consulta
{
    public class TransacaoGrpProduto
    {
        public int id { get; set; }
        public int produto { get; set; }
        public DateTime data { get; set; }
        public string clienteNome { get; set; }
        public float valor { get; set; }
    }
}
