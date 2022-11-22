using criptowebbcc.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace criptowebbcc.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int id { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [Display(Name = "Nome")]
        public string nomeProduto { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo descrição é obrigatório")]
        [Display(Name = "Descrição")]
        public string descricaoProduto { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Required(ErrorMessage = "Campo quantidade é obrigatório")]
        [Display(Name = "Quantidade")]
        public int quantidade { get; set; }

        public ICollection<Filial> filiais { get; set; }
    }
}