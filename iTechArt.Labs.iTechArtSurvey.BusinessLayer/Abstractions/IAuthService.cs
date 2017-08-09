using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.Abstractions
{
    public interface IAuthService
    {
        void LogIn(User user);
        void LogOut();
        void Register(User user);
    }
}
