using System;
using System.Collections.Generic;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.Web.Library.DTO;
using Newtonsoft.Json;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.Utils
{
    internal static class QuestionDTOConverter
    {
        internal static QuestionDTO ConvertToDTO(this SurveyQuestion surveyQuestion)
        {
            var questionDTO = new QuestionDTO()
            {
                Id = surveyQuestion.Question.Id,
                Order = surveyQuestion.Order,
                Title = surveyQuestion.Question.Title,
                Type = surveyQuestion.Question.Type.ToString(),
                Options = JsonConvert.DeserializeObject<List<string>>(surveyQuestion.Question.JsonMetaInformation)
            };

            return questionDTO;
        }

        internal static SurveyQuestion ConvertFromDTO(this QuestionDTO questionDTO, Guid surveyId)
        {
            var surveyQuestion = new SurveyQuestion()
            {
                Order = questionDTO.Order,
                SurveyId = surveyId,
                Question = new Question()
                {
                    Title = questionDTO.Title,
                    Required = true,
                    Type = (QuestionType)Enum.Parse(typeof(QuestionType), questionDTO.Type),
                    JsonMetaInformation = JsonConvert.SerializeObject(questionDTO.Options),
                }
            };

            return surveyQuestion;
        }
    }
}
