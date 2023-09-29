using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.Domain
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Situação da Consulta é obrigatório!")]
        public bool Situacao { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição da Consulta é obrigatório!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data da Consulta é obrigatório!")]
        public DateTime DataConsulta { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horário da Consulta é obrigatório!")]
        public TimeSpan HoraConsulta { get; set; }

        //=======================================================================

        //Referência da Tabela Paciente = FK;
        [Required(ErrorMessage = "O Paciente é obrigatório!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        //Referência da Tabela Medico = FK;
        [Required(ErrorMessage = "O Médico é obrigatório!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }
    }
}
