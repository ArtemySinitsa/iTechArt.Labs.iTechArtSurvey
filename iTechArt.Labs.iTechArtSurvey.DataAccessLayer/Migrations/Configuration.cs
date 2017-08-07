namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Migrations
{
    using DomainModel;
    using EF;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SurveyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SurveyContext context)
        {

            //Roles
            context.Roles.Add(new Role { Name = "Admin" });
            context.Roles.Add(new Role { Name = "User" });

            //Users
            context.Users.Add(new User
            {
                Name = "Alexandr",
                Email = "alex@gmail.com",
                Password = "alex1991",
                Role = context.Roles.FirstOrDefault(r => r.Name == "Admin"),
                RegisterDate = DateTime.Now
            });

            context.Users.Add(new User
            {
                Name = "Maxim",
                Email = "max@gmail.com",
                Password = "max9090",
                Role = context.Roles.FirstOrDefault(r => r.Name == "User"),
                RegisterDate = DateTime.Now
            });
            var john = new User
            {
                Name = "John",
                Email = "john.john@gmail.com",
                Password = "jjohn100",
                Role = context.Roles.FirstOrDefault(r => r.Name == "User"),
                RegisterDate = DateTime.Now
            };
            context.Users.Add(john);


            var greatSurveyPages = new List<SurveyPage> {
                new SurveyPage {
                Number = 0,
                Title = "Great first page",
                QuestionOrders = new List<QuestionOrder>()
                            {
                                new QuestionOrder()
                                {
                                    Order = 0,
                                    Question = new Question()
                                    {
                                        Title = "What is it?",
                                        JsonMetaInformation = "{}",
                                        Required = true,
                                        Type = QuestionTypes.Textarea
                                    }
                                },
                                new QuestionOrder()
                                {
                                    Order = 1,
                                    Question = new Question()
                                    {
                                        Title = "Choose your way?",
                                        JsonMetaInformation = "{options:['1','2','3']}",
                                        Required = true,
                                        Type = QuestionTypes.Radio
                                    }
                                }
                            }
                },
                new SurveyPage {
                Number = 1,
                Title = "Great second page",
                QuestionOrders = new List<QuestionOrder>()
                            {
                                new QuestionOrder()
                                {
                                    Order = 1,
                                    Question = new Question()
                                    {
                                        Title = "What is that?",
                                        JsonMetaInformation = "{}",
                                        Required = true,
                                        Type = QuestionTypes.File
                                    }
                                }
                            }
                },
            };

            var survey = new Survey()
            {
                Author = john,
                Title = "My great survey",
                Lookup = new SurveyLookup()
                {
                    Id = 0,
                    SurveyPages = greatSurveyPages
                },
                LastModified = DateTime.Now
            };
            context.Surveys.Add(survey);
        }
    }
}
