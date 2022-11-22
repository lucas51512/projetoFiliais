using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste.Models
{
    public enum Estado
    {
        RS, SC, PR, SP, RJ, ES, MG, MS, MT,
        TO, GO, DF, RO, BA, AC, AM, PA, PE, PB, CE, RN
    }
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int id { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Campo nome é obrigatorio")]
        [Display(Name = "Nome:")]
        public string nome { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo cidade é obrigatorio")]
        [Display(Name = "Cidade:")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "Campo estado é obrigatorio")]
        [Display(Name = "Estado:")]
        public Estado estado { get; set; }

        [Range(18, 70, ErrorMessage = "Idade entre 18 e 70 anos")]
        [Display(Name = "Idade:")]
        public int idade { get; set; }

        public ICollection<Filial> filiais { get; set; }
    }
}
