using System.ComponentModel.DataAnnotations;

namespace iTechArt.Labs.iTechArtSurvey.Web.ViewModels.UserProfile
{
    public class UserProfileChangeNameViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}