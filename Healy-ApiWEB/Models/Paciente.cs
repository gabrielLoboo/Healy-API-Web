using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Healy_ApiWEB.Models
{
    [Table("T_PACIENTE")]
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O cpf é obrigatório")]
        [MaxLength(11, ErrorMessage = "O CPF deve conter no máximo 11 caracteres.")]
        public string Cpf { get; set; }

        [Column("Email", TypeName = "varchar(255)")]
        [EmailAddress(ErrorMessage = "O email esta invalido")]
        public string Email { get; set; }
    }
}
