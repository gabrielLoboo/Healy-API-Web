using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.ML.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healy_ApiWEB.Models
{
    [Table("T_PROFISSIONAL")]
    public class Profissional
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O cpf é obrigatório")]
        [MaxLength(11, ErrorMessage = "O CPF deve conter no máximo 11 caracteres.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "A Área de atuação é obrigatória")]
        public string AreaAtuacao { get; set; }
    }

    public class ProfissionalRecomendacao
    {
        [LoadColumn(0)]
        public int PacienteId { get; set; }

        [LoadColumn(1)]
        public int ProfissionalId { get; set; } 

        [LoadColumn(2)]
        public float Label { get; set; }
    }

    public class ProfissionalPrediction
    {
        public float Score { get; set; } 
    }
}
