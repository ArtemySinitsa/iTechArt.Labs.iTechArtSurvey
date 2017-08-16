using System.ComponentModel.DataAnnotations;

namespace iTechArt.Labs.iTechArtSurvey.Web.ViewModels.Users
{
    public class InvitedUserRegisterViewModel
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        [Editable(false)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        [Display(Name = "Name")]
        [Editable(false)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}