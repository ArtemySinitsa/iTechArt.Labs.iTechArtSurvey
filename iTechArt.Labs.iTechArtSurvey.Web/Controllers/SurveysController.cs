using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using iTechArt.Labs.iTechArtSurvey.BusinessLayer.SurveyManagement;
using iTechArt.Labs.iTechArtSurvey.Web.Library;
using iTechArt.Labs.iTechArtSurvey.Web.Library.DTO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace iTechArt.Labs.iTechArtSurvey.Web.Controllers
{

    [RoutePrefix("surveys")]
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class SurveysController : ApiController
    {
        private SurveyManager _manager;

        public SurveyManager Manager
        {
            get
            {
                return _manager ?? Request.GetOwinContext().Get<SurveyManager>();
            }
        }

        // GET: api/surveys
        [HttpGet]
        public Task<ServerResponse> GetSurveyDescriptions()
        {
            return Manager.GetSurveyDescriptionsAsync();
        }

        //POST apt/surveys/
        [HttpPost]
        public Task<ServerResponse> SaveSurvey([FromBody]SurveyDTO survey)
        {
            var userId = User.Identity.GetUserId();
            return Manager.Save(userId, survey);
        }

        // GET: api/surveys/5
        public Task<ServerResponse> Get(Guid id)
        {
            return Manager.GetAsync(id);
        }



        // DELETE: api/Surveys/5
        public void Delete(int id)
        {
        }
    }
}
