using criptowebbcc.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace criptowebbcc.Models
{

    [Table("Filiais")]
    public class Filial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int id { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [Display(Name = "Nome")]
        public string nomeFilial { get; set; }

        [ForeignKey("Clientes")]
        public int clienteId { get; set; }  
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("Produtos")]
        public int produtoId { get; set; }
        public virtual Produto Produto { get; set; }

        [ForeignKey("Transacoes")]
        public int transacaoId { get; set; }
        public virtual Transacao Transacao { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo cidade é obrigatório")]
        [Display(Name = "Cidade")]
        public string cidadeFilial { get; set; }

        [Required(ErrorMessage = "Campo estado é obrigatório")]
        [Display(Name = "Estado")]
        public Estado estadoFilial { get; set; }
    }
}