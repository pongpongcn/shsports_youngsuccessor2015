using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputingServices.App;
using ComputingServices.App.Models;

namespace ComputingServices.UnitTest.App
{
    [TestClass]
    public class ComputingServiceTest
    {
        [TestMethod]
        public void TestGetPersonalityTestElementStandardResults()
        {
            IComputingService target = new ComputingService();

            PersonalityTestPaperResult paperResult = new PersonalityTestPaperResult();
            paperResult.Age = 12;
            paperResult.Gender = Gender.FEMALE;
            paperResult.QuestionsSetCode = "Set1";
            paperResult.QuestionAnswers = new PersonalityTestPaperQuestionAnswer[]{
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 3, Answer = "A" }, 
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 76, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 151, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 53, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 54, Answer = "A" }
            };

            target.GetPersonalityTestElementStandardResults(new PersonalityTestPaperResult[] { paperResult });
        }
    }
}
