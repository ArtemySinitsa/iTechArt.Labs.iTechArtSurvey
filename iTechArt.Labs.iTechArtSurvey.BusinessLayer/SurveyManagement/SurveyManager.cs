using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using iTechArt.Labs.iTechArtSurvey.BusinessLayer.UserManagement;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Repository;
using iTechArt.Labs.iTechArtSurvey.Web.Library;
using iTechArt.Labs.iTechArtSurvey.Web.Library.DTO;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.SurveyManagement
{
    public class SurveyManager : IDisposable
    {
        private readonly IRepository<Survey> _repository;
        private SurveyUserManager _userManager;

        public SurveyManager(IRepository<Survey> repository, SurveyUserManager userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<ServerResponse> GetSurveyDescriptionsAsync()
        {
            var storedSurveys = await _repository.GetAllAsync();
            var latestSurveys = GetLatestVersionsOfSurveys(storedSurveys);
            var surveysDTO = latestSurveys
                .Select(s =>
                    new SurveyDescriptionDTO()
                    {
                        Id = s.Id,
                        Title = s.Title,
                        QuestionsCount = s.Lookups.FirstOrDefault().SurveyPage.SurveyPageQuestions.Count,
                        Author = "asd",
                        Description = "default description"
                    });

            return new ServerResponse()
            {
                isError = false,
                Message = "latest surveys",
                Data = JsonConvert.SerializeObject(surveysDTO, new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            };
        }

        private IEnumerable<Survey> GetLatestVersionsOfSurveys(IEnumerable<Survey> surveys)
        {
            return surveys
                .GroupBy(s => s.Id)
                .Select(g => g.Select(s => s).OrderByDescending(s => s.Version).FirstOrDefault());
        }

        public async Task<ServerResponse> GetAsync(Guid id)
        {
            var surveys = (await _repository.FindAsync(s => s.Id == id));
            var latestSurvey = surveys
                .OrderByDescending(s => s.Version)
                .FirstOrDefault();
            var latestSurveyDTO = new SurveyDTO()
            {
                Id = latestSurvey.Id,
                Title = latestSurvey.Title,
                Author = "Ari",
                Questions = latestSurvey
                .Lookups
                .FirstOrDefault()
                .SurveyPage
                .SurveyPageQuestions
                .Select(
                    sp => new QuestionDTO()
                    {
                        Id = sp.QuestionId,
                        Title = sp.Question.Title,
                        Type = sp.Question.Type.ToString(),
                        Options = JsonConvert.DeserializeObject<List<string>>(sp.Question.JsonMetaInformation)
                    })
            };
            return new ServerResponse()
            {
                isError = false,
                Message = "OK",
                Data = JsonConvert.SerializeObject(latestSurveyDTO, new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            };
        }

        public async Task<ServerResponse> Save(string userId, SurveyDTO survey)
        {
            ServerResponse response = null;
            try
            {
                var alreadyInDatabaseSurvey = (await _repository
                    .FindAsync(s => s.Id == survey.Id))
                    .OrderByDescending(s => s.Version)
                    .FirstOrDefault();

                if (alreadyInDatabaseSurvey != null)
                {
                    var modifiedSurvey = ModifySurvey(userId, survey, alreadyInDatabaseSurvey);
                    await _repository.CreateAsync(modifiedSurvey);
                    response = new ServerResponse()
                    {
                        isError = false,
                        Message = "Survey was successfully saved."
                    };
                }
                else
                {
                    var newSurvey = CreateNewSurvey(userId, survey);
                    await _repository.CreateAsync(newSurvey);
                    response = new ServerResponse()
                    {
                        isError = false,
                        Message = "Survey was successfully saved."
                    };
                }

            }
            catch (ArgumentException e)
            {
                response = new ServerResponse()
                {
                    isError = true,
                    Message = "Error occured while saving survey, unknown type of question."
                };
            }
            catch (DbEntityValidationException e)
            {
                response = new ServerResponse()
                {
                    isError = true,
                    Message = "Error occured while saving survey: " + GetErrorsMessages(e.EntityValidationErrors)
                };
            }

            return response;
        }

        private string GetErrorsMessages(IEnumerable<DbEntityValidationResult> results)
        {
            string message = "\n";

            foreach (var result in results)
            {

                foreach (var error in result.ValidationErrors)
                {
                    message += error.ErrorMessage + "\n";
                }
            }

            return message;
        }

        private Survey ModifySurvey(string userId, SurveyDTO survey, Survey storedSurvey)
        {
            var lookup = new SurveyLookup()
            {
                SurveyPage = CreateSurveyPage(survey.Questions, Guid.Empty)
            };

            var newSurvey = new Survey()
            {
                Id = storedSurvey.Id,
                Version = storedSurvey.Version + 1,
                Title = survey.Title,
                Author = storedSurvey.Author,
                Created = storedSurvey.Created,
                Edited = DateTime.Now,
                Lookups = new List<SurveyLookup>() { lookup }
            };

            return newSurvey;
        }

        private Survey CreateNewSurvey(string userId, SurveyDTO survey)
        {
            var lookup = new SurveyLookup()
            {
                SurveyPage = CreateSurveyPage(survey.Questions, Guid.Empty)
            };

            var newSurvey = new Survey()
            {
                Id = Guid.NewGuid(),
                Version = 0,
                Title = survey.Title,
                Author = _userManager.Users.FirstOrDefault(),
                Created = DateTime.Now,
                Lookups = new List<SurveyLookup>() { lookup }
            };

            return newSurvey;
        }

        private SurveyPage CreateSurveyPage(IEnumerable<QuestionDTO> questions, Guid surveyId)
        {
            var surveyPageQuestions = questions.Select(CreateQuestion);

            var page = new SurveyPage()
            {
                Number = 1,
                Title = "default page title",
                SurveyPageQuestions = surveyPageQuestions.ToList()
            };

            return page;
        }

        private SurveyPageQuestion CreateQuestion(QuestionDTO question, int index)
        {

            var newQuestion = new Question()
            {
                Required = true,
                Title = question.Title,
                Type = (QuestionType)Enum.Parse(typeof(QuestionType), question.Type),
                JsonMetaInformation = JsonConvert.SerializeObject(question.Options)
            };

            return new SurveyPageQuestion()
            {

                Order = index,
                Question = newQuestion
            };

        }

        public static SurveyManager Create(
          IdentityFactoryOptions<SurveyManager> identityFactoryOptions,
          IOwinContext context)
        {
            return new SurveyManager(
                new GenericRepository<Survey>(context.Get<SurveyContext>()),
                context.Get<SurveyUserManager>());
        }

        public void Dispose()
        {

        }
    }
}
