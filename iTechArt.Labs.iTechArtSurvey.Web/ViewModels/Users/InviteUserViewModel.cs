using System.ComponentModel.DataAnnotations;

namespace iTechArt.Labs.iTechArtSurvey.Web.ViewModels.Users
{
    public class InviteUserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Name { get; set; }
    }
}