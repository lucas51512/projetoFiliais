using projetofiliais.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace projetofiliais.Models
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

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Compra")]
        public float compra { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Venda")]
        public float venda { get; set; }

        public ICollection<Filial> filiais { get; set; }
    }
}