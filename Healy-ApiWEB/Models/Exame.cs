using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Healy_ApiWEB.Models
{
    [Table("T_EXAME")]
    public class Exame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string NomeExame { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de realização é obrigatória.")]
        public DateTime DataRealizacao { get; set; }

        [Required(ErrorMessage = "O custo é obrigatório.")]
        public double Custo { get; set; }

    }
}
