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
            paperResult.Age = 10;
            paperResult.Gender = Gender.MALE;
            paperResult.QuestionsSetCode = "Set1";
            paperResult.QuestionAnswers = new PersonalityTestPaperQuestionAnswer[]{
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 3, Answer = "A" }, 
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 76, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 151, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 53, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 54, Answer = "A" }
            };

            var actual = target.GetPersonalityTestElementStandardResults(new PersonalityTestPaperResult[] { paperResult });
        }

        [TestMethod]
        public void TestGetIQTestStandardResults()
        {
            IComputingService target = new ComputingService();

            IQTestPaperResult paperResult = new IQTestPaperResult();
            paperResult.Age = 8;
            paperResult.QuestionAnswers = new IQTestPaperQuestionAnswer[]{
                new IQTestPaperQuestionAnswer{ QuestionGroup="A",QuestionCode=2, Answer="E"},
                new IQTestPaperQuestionAnswer{ QuestionGroup="AB",QuestionCode=4, Answer="F"}
            };

            var actual = target.GetIQTestStandardResults(new IQTestPaperResult[] { paperResult });
        }
    }
}
