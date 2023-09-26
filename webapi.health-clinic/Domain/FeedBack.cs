using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.Domain
{
    [Table(nameof(FeedBack))]
    public class FeedBack
    {
        [Key]
        public Guid IdFeedBack { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Comentário é obrigatório!")]
        public string? Comentario { get; set; }

        //=======================================================================

        //Referência da Tabela Consulta = FK;
        [Required(ErrorMessage = "A consulta é obrigatório!")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
