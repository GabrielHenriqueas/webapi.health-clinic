using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.Domain
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Nome Fantasia é obrigatório!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "CNPJ é obrigatório!")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Razão Social é obrigatório!")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Hora de Abertura é obrigatório!")]
        public TimeSpan? HoraAbertura { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Hora de Fechamento é obrigatório!")]
        public TimeSpan? HoraFechamento { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Endereço é obrigatório!")]
        public string? Endereco { get; set; }

    }
}
