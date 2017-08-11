using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace iTechArt.Labs.iTechArtSurvey.Web.Models
{
    public class UserEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}