using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.Domain
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "O CRM do Médico é obrigatório!")]
        public string? CRM { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "O Estado do Médico é obrigatório!")]
        public bool Estado { get; set; }

        //=======================================================================

        //Referência da Tabela IdUsuario = FK;        
        [Required(ErrorMessage = "O Tipo de Usuário é obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //Referência da Tabela Especialidae = FK;
        [Required(ErrorMessage = "A Especialidade é obrigatório!")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        //Referência da Tabela Clinica = FK;
        [Required(ErrorMessage = "A Clínica é obrigatório!")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }

        
    }
}
