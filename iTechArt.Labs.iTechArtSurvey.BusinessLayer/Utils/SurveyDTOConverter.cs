using System;
using System.Linq;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.Web.Library.DTO;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.Utils
{
    internal static class SurveyDTOConverter
    {
        internal static SurveyDTO ConvertToDTO(this Survey survey)
        {
            var questions = survey.SurveyQuestions.Select(q => q.ConvertToDTO());
            var surveyDTO = new SurveyDTO()
            {
                Id = survey.Id,
                Title = survey.Title,
                Author = survey.Author == null ? "none" : survey.Author.Name,
                Questions = questions
            };

            return surveyDTO;
        }

        internal static Survey ConvertFromDTO(this SurveyDTO surveyDTO, User author)
        {
            var id = Guid.NewGuid();
            var survey = new Survey()
            {
                Id = id,
                Version = 0,
                Title = surveyDTO.Title,
                Author = author,
                Created = DateTime.Now,
                SurveyQuestions = surveyDTO
                .Questions
                .Select(q => q.ConvertFromDTO(id)).ToList()
            };

            return survey;
        }

        internal static Survey ConvertFromDTO(this SurveyDTO surveyDTO, User editor, Survey storedSurvey)
        {
            var survey = new Survey()
            {
                Id = storedSurvey.Id,
                Version = storedSurvey.Version + 1,
                Title = surveyDTO.Title,
                Author = storedSurvey.Author,
                Created = storedSurvey.Created,
                Edited = DateTime.Now,
                Editor = editor,
                SurveyQuestions = surveyDTO.Questions.Select(q => q.ConvertFromDTO(storedSurvey.Id)).ToList()
            };

            return survey;
        }

        internal static SurveyDescriptionDTO ConvertToDescriptionDTO(this Survey survey)
        {

            var surveyDescriptionDTO = new SurveyDescriptionDTO()
            {
                Id = survey.Id,
                Title = survey.Title,
                Author = survey.Author == null ? "none" : survey.Author.Name,
                QuestionsCount = survey.SurveyQuestions.Count,
                Description = $"Created at: {survey.Created.ToShortDateString()}"
            };

            return surveyDescriptionDTO;
        }
    }
}
