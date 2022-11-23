using System.ComponentModel.DataAnnotations.Schema;

namespace criptowebbcc.Models.Consulta
{
    public class TransacaoQry
    {
        public int id { get; set; }
        public int produto { get; set; }
        public String tipoProduto { get; set; }
        public int quantidade { get; set; }
        public DateTime data { get; set; }
        public float valor { get; set; }
        public int cliente { get; set; }
        public string clienteNome { get; set; }
        public float total { get; set; }

    }
}
