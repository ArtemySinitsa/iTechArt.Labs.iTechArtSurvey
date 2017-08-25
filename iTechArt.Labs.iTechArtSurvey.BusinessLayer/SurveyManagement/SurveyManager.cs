using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using iTechArt.Labs.iTechArtSurvey.BusinessLayer.UserManagement;
using iTechArt.Labs.iTechArtSurvey.BusinessLayer.Utils;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Repository;
using iTechArt.Labs.iTechArtSurvey.Web.Library;
using iTechArt.Labs.iTechArtSurvey.Web.Library.DTO;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.SurveyManagement
{
    public class SurveyManager : IDisposable
    {
        private bool disposed = false;
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
                .Select(s => s.ConvertToDescriptionDTO()).ToList();

            return new ServerResponse()
            {
                IsError = false,
                Message = "latest surveys",
                Data = surveysDTO
            };
        }

        public async Task<ServerResponse> Delete(Guid id)
        {
            bool isError = false;
            try
            {
                var storedSurveys = await _repository.FindAsync(s => s.Id == id);

                for (int i = 0; i < storedSurveys.Count(); i++)
                {
                    await _repository.DeleteAsync(storedSurveys.ElementAt(i));
                }
            }
            catch (Exception)
            {
                isError = true;
                throw;
            }

            return new ServerResponse()
            {
                IsError = isError
            };

        }

        private IEnumerable<Survey> GetLatestVersionsOfSurveys(IEnumerable<Survey> surveys)
        {
            return surveys
                .GroupBy(s => s.Id)
                .Select(g => g.Select(s => s).GetByMax(s => s.Version));
        }

        public async Task<ServerResponse> GetAsync(Guid id)
        {
            var surveys = (await _repository.FindAsync(s => s.Id == id));
            var latestSurvey = surveys.GetByMax(s => s.Version);
            var latestSurveyDTO = latestSurvey.ConvertToDTO();

            return new ServerResponse()
            {
                IsError = false,
                Message = "OK",
                Data = latestSurveyDTO
            };
        }

        public async Task<ServerResponse> Save(string userId, SurveyDTO survey)
        {
            var user = await _userManager.FindByIdAsync(userId);
            ServerResponse response = null;
            string message = string.Empty;
            bool isError = false;
            try
            {
                var alreadyInDatabaseSurvey = (await _repository
                    .FindAsync(s => s.Id == survey.Id)).GetByMax(s => s.Version);

                if (alreadyInDatabaseSurvey != null)
                {
                    var modifiedSurvey = survey.ConvertFromDTO(user, alreadyInDatabaseSurvey);
                    await _repository.CreateAsync(modifiedSurvey);
                }
                else
                {
                    var newSurvey = survey.ConvertFromDTO(user);
                    await _repository.CreateAsync(newSurvey);
                }
                message = "Survey was successfully saved";

            }
            catch (ArgumentException)
            {
                isError = true;
                message = "Error occured while saving survey, unknown type of question.";
            }
            catch (DbEntityValidationException e)
            {
                isError = true;
                message = "Error occured while saving survey: " + GetErrorsMessages(e.EntityValidationErrors);
            }
            finally
            {
                response = new ServerResponse()
                {
                    IsError = isError,
                    Message = message
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _repository.Dispose();
                _userManager.Dispose();
            }

            disposed = true;
        }
    }
}
