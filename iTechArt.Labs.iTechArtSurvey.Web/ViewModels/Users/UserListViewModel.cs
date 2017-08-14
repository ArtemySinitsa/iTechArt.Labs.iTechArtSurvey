using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace iTechArt.Labs.iTechArtSurvey.Web.ViewModels.Users
{
    public class UserListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [DisplayName("Role")]
        public string Roles { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Register date")]
        public DateTime? Registered { get; set; }
        [DisplayName("Survey count")]
        public int SurveyCount { get; set; }
    }
}