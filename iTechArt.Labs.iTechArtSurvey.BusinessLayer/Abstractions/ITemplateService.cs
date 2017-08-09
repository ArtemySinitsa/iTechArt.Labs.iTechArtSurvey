using System.Threading.Tasks;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.Abstractions
{
    public interface ITemplateService
    {
        Task CreateAsync(Template template);
        Task EditAsync(Template template);
        Task<Template> GetAsync(int id);
    }
}
