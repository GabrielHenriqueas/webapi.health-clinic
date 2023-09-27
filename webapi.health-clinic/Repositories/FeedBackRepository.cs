using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domain;
using webapi.health_clinic.Interfaces;
using webapi.health_clinic.Utils;

namespace webapi.health_clinic.Repositories
{
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly HealthClinicContext ctx;

        public FeedBackRepository()
        {
            ctx = new HealthClinicContext();
        }

        //==================================================================

        public void Cadastrar(FeedBack feedBack)
        {
            try
            {
                ctx.FeedBack.Add(feedBack);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //==================================================================

        public List<FeedBack> Listar()
        {
            List<FeedBack> feedBacks = ctx.FeedBack.ToList();

            return feedBacks;
        }
    }
}
