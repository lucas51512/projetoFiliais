using criptowebbcc.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace criptowebbcc.Models
{
    [Table("Transacoes")]
    public class Transacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo Tipo Produto é obrigatório")]
        [Display(Name = "Tipo Produto")]
        public String tipoProduto { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Required(ErrorMessage = "Campo quantidade é obrigatório")]
        [Display(Name = "Quantidade")]
        public int quantidade { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Campo data é obrigatório")]
        [Display(Name = "Data")]
        public DateTime data { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "Campo valor é obrigatório")]
        [Display(Name = "Valor")]
        public float valor { get; set; }

        [Display(Name = "Produto: ")]
        [ForeignKey("Produtos")]
        public int produtoId { get; set; }
        public virtual Produto Produto { get; set; }

        [Display(Name = "Cliente: ")]
        [ForeignKey("Clientes")]
        public int clienteId { get; set; }
        public virtual Cliente cliente { get; set; }

        [Display(Name = "Total: ")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public virtual float total {
            get { return quantidade * valor; }
        }
    }
}