using System.ComponentModel.DataAnnotations;

namespace iTechArt.Labs.iTechArtSurvey.Web.ViewModels.UserProfile
{
    public class UserProfileViewModel
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
    }
}