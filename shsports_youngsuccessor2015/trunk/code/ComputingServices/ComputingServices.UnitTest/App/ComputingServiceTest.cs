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
            paperResult.Age = 13;
            paperResult.Gender = Gender.MALE;
            paperResult.QuestionsSetCode = "CPQ";
            paperResult.RefId = "";
            paperResult.QuestionAnswers = new PersonalityTestPaperQuestionAnswer[]{
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 1, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 2, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 3, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 4, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 5, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 6, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 7, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 8, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 9, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 10, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 11, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 12, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 13, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 14, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 15, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 16, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 17, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 18, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 19, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 20, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 21, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 22, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 23, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 24, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 25, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 26, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 27, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 28, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 29, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 30, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 31, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 32, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 33, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 34, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 35, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 36, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 37, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 38, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 39, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 40, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 41, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 42, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 43, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 44, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 45, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 46, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 47, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 48, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 49, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 50, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 51, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 52, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 53, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 54, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 55, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 56, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 57, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 58, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 59, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 60, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 61, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 62, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 63, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 64, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 65, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 66, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 67, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 68, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 69, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 70, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 71, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 72, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 73, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 74, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 75, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 76, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 77, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 78, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 79, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 80, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 81, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 82, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 83, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 84, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 85, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 86, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 87, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 88, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 89, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 90, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 91, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 92, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 93, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 94, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 95, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 96, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 97, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 98, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 99, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 100, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 101, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 102, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 103, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 104, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 105, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 106, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 107, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 108, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 109, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 110, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 111, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 112, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 113, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 114, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 115, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 116, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 117, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 118, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 119, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 120, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 121, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 122, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 123, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 124, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 125, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 126, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 127, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 128, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 129, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 130, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 131, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 132, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 133, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 134, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 135, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 136, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 137, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 138, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 139, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 140, Answer = "B" }
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
