using System.Threading.Tasks;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.Abstractions
{
    public interface ISurveyService
    {
        Task CreateAsync(Survey survey);
        Task EditAsync(Survey survey);
        Task<Survey> GetAsync(int id);
    }
}
