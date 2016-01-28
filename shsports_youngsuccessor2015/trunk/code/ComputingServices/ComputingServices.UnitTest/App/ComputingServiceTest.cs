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
            paperResult.Age = 15;
            paperResult.Gender = Gender.MALE;
            paperResult.QuestionsSetCode = "16PF";
            paperResult.RefId = "";
            paperResult.QuestionAnswers = new PersonalityTestPaperQuestionAnswer[]{
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 1, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 2, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 3, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 4, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 5, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 6, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 7, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 8, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 9, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 10, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 11, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 12, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 13, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 14, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 15, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 16, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 17, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 18, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 19, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 20, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 21, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 22, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 23, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 24, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 25, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 26, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 27, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 28, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 29, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 30, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 31, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 32, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 33, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 34, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 35, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 36, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 37, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 38, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 39, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 40, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 41, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 42, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 43, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 44, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 45, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 46, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 47, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 48, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 49, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 50, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 51, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 52, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 53, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 54, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 55, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 56, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 57, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 58, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 59, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 60, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 61, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 62, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 63, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 64, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 65, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 66, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 67, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 68, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 69, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 70, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 71, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 72, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 73, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 74, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 75, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 76, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 77, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 78, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 79, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 80, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 81, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 82, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 83, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 84, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 85, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 86, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 87, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 88, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 89, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 90, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 91, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 92, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 93, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 94, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 95, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 96, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 97, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 98, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 99, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 100, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 101, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 102, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 103, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 104, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 105, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 106, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 107, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 108, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 109, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 110, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 111, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 112, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 113, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 114, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 115, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 116, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 117, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 118, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 119, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 120, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 121, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 122, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 123, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 124, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 125, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 126, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 127, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 128, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 129, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 130, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 131, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 132, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 133, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 134, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 135, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 136, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 137, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 138, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 139, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 140, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 141, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 142, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 143, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 144, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 145, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 146, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 147, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 148, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 149, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 150, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 151, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 152, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 153, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 154, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 155, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 156, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 157, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 158, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 159, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 160, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 161, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 162, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 163, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 164, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 165, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 166, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 167, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 168, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 169, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 170, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 171, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 172, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 173, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 174, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 175, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 176, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 177, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 178, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 179, Answer = "C" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 180, Answer = "B" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 181, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 182, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 183, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 184, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 185, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 186, Answer = "A" },
                new PersonalityTestPaperQuestionAnswer { QuestionCode = 187, Answer = "A" },
            };

            var actual = target.GetPersonalityTestElementStandardResults(new PersonalityTestPaperResult[] { paperResult });
        }

        [TestMethod]
        public void TestGetPersonalityTestComplexResults_CPQ()
        {
            IComputingService target = new ComputingService();

            PersonalityTestElementStandardResult standardResult = new PersonalityTestElementStandardResult();
            standardResult.Age = 10;
            standardResult.RefId = "";
            standardResult.Scores = new PersonalityTestElementStandardScore[]{
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)0, Value = -2 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)1, Value = -2 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)3, Value = 2 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)2, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)5, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)4, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)6, Value = -1 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)7, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)8, Value = -1 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)9, Value = 1 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)12, Value = 1 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)13, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)16, Value = -2 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)17, Value = 1 }
            };


            var actual = target.GetPersonalityTestComplexResults(new PersonalityTestElementStandardResult[] { standardResult });
        }

        [TestMethod]
        public void TestGetPersonalityTestComplexResults_16PF()
        {
            IComputingService target = new ComputingService();

            PersonalityTestElementStandardResult standardResult = new PersonalityTestElementStandardResult();
            standardResult.Age = 18;
            standardResult.RefId = "";
            standardResult.Scores = new PersonalityTestElementStandardScore[]{
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)0, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)2, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)4, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)5, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)6, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)7, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)8, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)10, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)11, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)12, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)13, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)14, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)15, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)16, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)17, Value = 0 },
                new PersonalityTestElementStandardScore { Element = (PersonalityElement)1, Value = 0 }
            };


            var actual = target.GetPersonalityTestComplexResults(new PersonalityTestElementStandardResult[] { standardResult });
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

        [TestMethod]
        public void TestGetCertainSportAbilityTestStandardResults()
        {
            IComputingService target = new ComputingService();

            CertainSportAbilityTestOriginalResult originalResult = new CertainSportAbilityTestOriginalResult
            {
                SportType = "sport_for_test",
                Birthdate = new DateTime(2000, 3, 5),
                TestDate = new DateTime(2010, 6, 7),
                Gender = Gender.FEMALE,
                RefId = "",
                SubScores = new CertainSportAbilityTestOriginalSubScore[] { 
                    new CertainSportAbilityTestOriginalSubScore{SubType="800m",Value="4:05"},
                    new CertainSportAbilityTestOriginalSubScore{SubType="NeckLength",Value="14"},
                    new CertainSportAbilityTestOriginalSubScore{SubType="Expressiveness",Value="具有较强的感染力"},
                }
            };


            var actual = target.GetCertainSportAbilityTestStandardResults(new CertainSportAbilityTestOriginalResult[] { originalResult });
        }
    }
}
