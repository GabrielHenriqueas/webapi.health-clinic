using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.Domain
{
    [Table(nameof(Paciente))]
    [Index(nameof(Telefone), IsUnique = true)]
    [Index(nameof(RG), IsUnique = true)]
    [Index(nameof(CPF), IsUnique = true)]
    [Index(nameof(Endereco), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "A idade do paciente é obrigatório!")]
        [Column(TypeName = "INT")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O Telefone do paciente é obrigatório!")]
        [Column(TypeName = "VARCHAR(30)")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O RG do paciente é obrigatório!")]
        [Column(TypeName = "VARCHAR(30)")]
        public string? RG { get; set; }

        [Required(ErrorMessage = "O CPF do paciente é obrigatório!")]
        [Column(TypeName = "VARCHAR(30)")]
        public string? CPF { get; set; }

        [Required(ErrorMessage = "O CEP do paciente é obrigatório!")]
        [Column(TypeName = "VARCHAR(30)")]
        public string? CEP { get; set; }

        [Required(ErrorMessage = "O Endereço do paciente é obrigatório!")]
        [Column(TypeName = "VARCHAR(30)")]
        public string? Endereco { get; set; }

        //=======================================================================

        //Referência da Tabela IdUsuario = FK;
        [Required(ErrorMessage = "O Tipo de Usuário é obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
