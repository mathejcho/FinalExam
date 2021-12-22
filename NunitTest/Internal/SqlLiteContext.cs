using Bank.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SurveyUsers.Services.Test.Internal
{
    public abstract class SqlLiteContext : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;
        protected readonly BankDbContext DbContext;
        protected DbContextOptions<BankDbContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<BankDbContext>()
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseSqlite(_connection)
                .Options;
        }
        protected SqlLiteContext(bool withData = false)
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            DbContext = new SurveyDbContext(CreateOptions());
            _connection.Open();
            DbContext.Database.EnsureCreated();
            if (withData)
                SeedData(DbContext);
        }
        private void SeedData(SurveyDbContext context)
        {
            var users = new List<SurveyUser>
                {
                    new SurveyUser
                    {
                        Id = 1,
                        FirstName = "Kiril",
                        LastName = "Kocovski",
                        DoB = DateTime.Today.AddYears(-23),
                        Gender = SurveyUsers.Data.Enums.Gender.Male,
                        Country = "Macedonia",
                    },
                    new SurveyUser
                    {
                        Id = 2,
                        FirstName = "Jenna",
                        LastName = "Jonson",
                        DoB = DateTime.Today.AddYears(-28),
                        Gender = SurveyUsers.Data.Enums.Gender.Female,
                        Country = "USA",
                    },
                    new SurveyUser
                    {
                        Id = 3,
                        FirstName = "John",
                        LastName = "White",
                        DoB = DateTime.Today.AddYears(-22),
                        Gender = SurveyUsers.Data.Enums.Gender.Male,
                        Country = "USA",
                    }
                };
            var questions = new List<Question>
                {
                    new Question
                    {
                        Id = 1,
                        Text = "Question 1",
                        Description = "Description 1"
                    },
                    new Question
                    {
                        Id = 2,
                        Text = "Question 2",
                        Description = "Description 2"
                    },
                    new Question
                    {
                        Id = 3,
                        Text = "Question 3",
                        Description = "Description 3"
                    },
                    new Question
                    {
                        Id = 4,
                        Text = "Question 4",
                        Description = "Description 4"
                    },
                };
            var options = new List<Option>
                {
                    new Option
                    {
                        Id = 1,
                        Text = "Option 1",
                        Order = 1,
                        QuestionId = 2
                    },
                    new Option
                    {
                        Id = 2,
                        Text = "Option 2",
                        Order = 1,
                        QuestionId = 2
                    },
                   new Option
                    {
                        Id = 3,
                        Text = "Option 3",
                        Order = 2,
                        QuestionId = 2
                    },
                    new Option
                    {
                        Id = 4,
                        Text = "Option 4",
                        Order = 2,
                        QuestionId = 2
                    },
                    new Option
                    {
                        Id = 5,
                        Text = "Option 1",
                        Order = 1,
                        QuestionId = 1
                    },
                    new Option
                    {
                        Id = 6,
                        Text = "Option 2",
                        Order = 1,
                        QuestionId = 1
                    },
                    new Option
                    {
                        Id = 7,
                        Text = "Option 3",
                        Order = 1,
                        QuestionId = 1
                    },
                    new Option
                    {
                        Id = 8,
                        Text = "Option 4",
                        Order = 1,
                        QuestionId = 1
                    },
                    new Option
                    {
                        Id = 9,
                        Text = "Option 1",
                        Order = 1,
                        QuestionId = 3
                    },
                    new Option
                    {
                        Id = 10,
                        Text = "Option 2",
                        Order = 1,
                        QuestionId = 3
                    },
                    new Option
                    {
                        Id = 11,
                        Text = "Option 3",
                        Order = 1,
                        QuestionId = 3
                    },
                    new Option
                    {
                        Id = 12,
                        Text = "Option 4",
                        Order = 1,
                        QuestionId = 3
                    },
                };
            var answers = new List<Answer>
            {
                new Answer
                {
                    Id = 1,
                    UserId = 1,
                    OptionId = 1
                },
                new Answer
                {
                    Id = 2,
                    UserId = 1,
                    OptionId = 2
                },
                new Answer
                {
                    Id = 3,
                    UserId = 1,
                    OptionId = 5
                },
                new Answer
                {
                    Id = 4,
                    UserId = 2,
                    OptionId = 6
                },
                new Answer
                {
                    Id = 5,
                    UserId = 3,
                    OptionId = 5
                },
                new Answer
                {
                    Id = 6,
                    UserId = 2,
                    OptionId = 4,
                },
                new Answer
                {
                    Id = 7,
                    UserId = 2,
                    OptionId = 8,
                },
                new Answer
                {
                    Id = 8,
                    UserId = 2,
                    OptionId = 9,
                },
            };
            context.AddRange(users);
            context.AddRange(options);
            context.AddRange(questions);
            context.AddRange(answers);
            context.SaveChanges();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
