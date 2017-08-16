using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace iTechArt.Labs.iTechArtSurvey.Web.ViewModels.Users
{
    public class UserEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Name { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}