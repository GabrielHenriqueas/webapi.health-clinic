using webapi.health_clinic.Domain;

namespace webapi.health_clinic.Interfaces
{
    public interface IFeedBackRepository
    {
        void Cadastrar(FeedBack feedBack);

        List<FeedBack> Listar();
    }
}
