using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace iTechArt.Labs.iTechArtSurvey.Web.Models
{
    public class UserListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Register date")]
        public DateTime Registered { get; set; }
        [DisplayName("Survey count")]
        public int SurveyCount { get; set; }
    }
}