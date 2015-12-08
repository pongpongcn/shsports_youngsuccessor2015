using ComputingServices.App.Models;
using ComputingServices.Core.Domain.Models.PersonalityTest;
using ComputingServices.Core.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity;
using ComputingServices.Core.Domain.Models.IQTest;

namespace ComputingServices.App
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ComputingService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ComputingService.svc 或 ComputingService.svc.cs，然后开始调试。
    public class ComputingService : IComputingService
    {

        public PersonalityTestElementStandardResult[] GetPersonalityTestElementStandardResults(PersonalityTestPaperResult[] paperResults)
        {
            var questionsSetCodes = paperResults.Select(item=>item.QuestionsSetCode).Distinct().ToList();
            var ages = paperResults.Select(item => item.Age).Distinct().ToList();

            List<PersonalityTestQuestionsSet> questionsSets;
            List<PersonalityTestElementStandardParametersSet> elementStandardParametersSets;
            using (var context = new ComputingServicesContext())
            {
                questionsSets = context.PersonalityTestQuestionsSets.Include(item => item.Questions.Select(question => question.ChoiceScores)).Where(item => questionsSetCodes.Contains(item.Code)).ToList();
                elementStandardParametersSets = context.PersonalityTestElementStandardParametersSets.Include(item => item.Parameters.Select(parameter => parameter.Segments)).Where(item => ages.Any(age => age >= item.AgeMin && age <= item.AgeMax)).ToList();
            }

            List<PersonalityTestElementStandardResult> elementStandardResultList = new List<PersonalityTestElementStandardResult>();

            foreach(PersonalityTestPaperResult paperResult in paperResults)
            {
                var questionsSet = questionsSets.Single(item=>item.Code == paperResult.QuestionsSetCode);

                Core.Domain.Models.Shared.Gender gender = ConvertToDomain(paperResult.Gender);

                var elementStandardParametersSet = elementStandardParametersSets.Single(item => item.Gender == gender && paperResult.Age >= item.AgeMin && paperResult.Age <= item.AgeMax);

                var elementStandardResult = GetPersonalityTestElementStandardResult(paperResult, questionsSet, elementStandardParametersSet);

                elementStandardResultList.Add(elementStandardResult);
            }

            return elementStandardResultList.ToArray();
        }

        private PersonalityTestElementStandardResult GetPersonalityTestElementStandardResult(PersonalityTestPaperResult paperResult, PersonalityTestQuestionsSet questionsSet, PersonalityTestElementStandardParametersSet elementStandardParametersSet)
        {
            var dicElementOriginalValue = new Dictionary<Core.Domain.Models.PersonalityTest.PersonalityElement, int>();
            foreach (var questionAnswer in paperResult.QuestionAnswers)
            {
                var question = questionsSet.Questions.SingleOrDefault(item => item.Code == questionAnswer.QuestionCode);
                if(question == null)
                {
                    continue;
                }

                Core.Domain.Models.PersonalityTest.PersonalityElement element;
                if (!Enum.TryParse<Core.Domain.Models.PersonalityTest.PersonalityElement>(question.Element.ToString(), out element))
                {
                    throw new ArgumentException("Wrong Personality Element");
                }
                if (!dicElementOriginalValue.ContainsKey(element))
                {
                    dicElementOriginalValue.Add(element, 0);
                }

                foreach(var choiceScore in question.ChoiceScores)
                {
                    if(choiceScore.Choice == questionAnswer.Answer)
                    {
                        dicElementOriginalValue[element] += choiceScore.Score;
                        break;
                    }
                }
            }

            var elementStandardScoreList = new List<PersonalityTestElementStandardScore>();

            foreach (Core.Domain.Models.PersonalityTest.PersonalityElement element in dicElementOriginalValue.Keys)
            {
                int originalValue = dicElementOriginalValue[element];

                PersonalityTestElementStandardParameter elementStandardParameter = elementStandardParametersSet.Parameters.Single(item => item.Element == element);

                int standardScoreValue = elementStandardParameter.Segments.Single(item => originalValue >= item.OriginalScoreMin && originalValue <= item.OriginalScoreMax).StandardScore;

                PersonalityTestElementStandardScore elementStandardScore = new PersonalityTestElementStandardScore();
                App.Models.PersonalityElement appElement;
                if (Enum.TryParse<App.Models.PersonalityElement>(element.ToString(), out appElement))
                {
                    elementStandardScore.Element = appElement;
                    elementStandardScore.Value = standardScoreValue;

                    elementStandardScoreList.Add(elementStandardScore);
                }
                else
                {
                    throw new ArgumentException("Wrong Personality Element");
                }
            }

            PersonalityTestElementStandardResult elementStandardResult = new PersonalityTestElementStandardResult();
            elementStandardResult.Age = paperResult.Age;
            elementStandardResult.Scores = elementStandardScoreList.ToArray();
            elementStandardResult.RefId = paperResult.RefId;

            return elementStandardResult;
        }

        private Core.Domain.Models.Shared.Gender ConvertToDomain(Gender appGender)
        {
            switch(appGender)
            {
                case Gender.MALE: return Core.Domain.Models.Shared.Gender.Male; 
                case Gender.FEMALE: return Core.Domain.Models.Shared.Gender.Female;
                default: throw new ArgumentException("Can not mapping to domain gender.");
            }
        }

        private Gender ConvertToApp(Core.Domain.Models.Shared.Gender domainGender)
        {
            switch (domainGender)
            {
                case Core.Domain.Models.Shared.Gender.Male: return Gender.MALE;
                case Core.Domain.Models.Shared.Gender.Female: return Gender.FEMALE;
                default: throw new ArgumentException("Can not mapping to app gender.");
            }
        }

        public PersonalityTestComplexResult[] GetPersonalityTestComplexResults(PersonalityTestElementStandardResult[] standardResults)
        {
            return standardResults.Select(item => GetPersonalityTestComplexResult(item)).ToArray();
        }

        private PersonalityTestComplexResult GetPersonalityTestComplexResult(PersonalityTestElementStandardResult standardResult)
        {
            List<PersonalityTestComplexScore> scores = new List<PersonalityTestComplexScore>();

            Dictionary<App.Models.PersonalityElement, int> dicElementValue = new Dictionary<Models.PersonalityElement, int>();
            foreach (var score in standardResult.Scores)
            {
                dicElementValue.Add(score.Element, score.Value);
            }

            #region A1
            {
                PersonalityTestComplexScore score = new PersonalityTestComplexScore();
                score.Category = PersonalityComplexCategory.A1;
                score.Value = ((38 + 2 * dicElementValue[Models.PersonalityElement.L] + 3 * dicElementValue[Models.PersonalityElement.O] + 4 * dicElementValue[Models.PersonalityElement.Q1]) - (2 * dicElementValue[Models.PersonalityElement.C] + 2 * dicElementValue[Models.PersonalityElement.H] + 2 * dicElementValue[Models.PersonalityElement.Q2])) / 10;

                scores.Add(score);
            }
            #endregion

            #region A2
            {
                PersonalityTestComplexScore score = new PersonalityTestComplexScore();
                score.Category = PersonalityComplexCategory.A2;
                score.Value = ((2*dicElementValue[Models.PersonalityElement.A]+3*dicElementValue[Models.PersonalityElement.E]+4*dicElementValue[Models.PersonalityElement.F]+5*dicElementValue[Models.PersonalityElement.H])-(2*dicElementValue[Models.PersonalityElement.Q2]+11))/10;

                scores.Add(score);
            }
            #endregion

            #region A3
            {
                PersonalityTestComplexScore score = new PersonalityTestComplexScore();
                score.Category = PersonalityComplexCategory.A3;
                score.Value = ((77 + 2 * dicElementValue[Models.PersonalityElement.C] + 2 * dicElementValue[Models.PersonalityElement.E] + 2 * dicElementValue[Models.PersonalityElement.F] + 2 * dicElementValue[Models.PersonalityElement.N]) - (4 * dicElementValue[Models.PersonalityElement.A] + 6 * dicElementValue[Models.PersonalityElement.I] + 2 * dicElementValue[Models.PersonalityElement.M])) / 10;

                scores.Add(score);
            }
            #endregion

            #region A3
            {
                PersonalityTestComplexScore score = new PersonalityTestComplexScore();
                score.Category = PersonalityComplexCategory.A3;
                score.Value = ((77 + 2 * dicElementValue[Models.PersonalityElement.C] + 2 * dicElementValue[Models.PersonalityElement.E] + 2 * dicElementValue[Models.PersonalityElement.F] + 2 * dicElementValue[Models.PersonalityElement.N]) - (4 * dicElementValue[Models.PersonalityElement.A] + 6 * dicElementValue[Models.PersonalityElement.I] + 2 * dicElementValue[Models.PersonalityElement.M])) / 10;

                scores.Add(score);
            }
            #endregion

            #region A4
            {
                PersonalityTestComplexScore score = new PersonalityTestComplexScore();
                score.Category = PersonalityComplexCategory.A4;
                score.Value = ((4*dicElementValue[Models.PersonalityElement.E]+3*dicElementValue[Models.PersonalityElement.M]+4*dicElementValue[Models.PersonalityElement.Q1]+4*dicElementValue[Models.PersonalityElement.Q2])-(3*dicElementValue[Models.PersonalityElement.A]+2*dicElementValue[Models.PersonalityElement.G]))/10;

                scores.Add(score);
            }
            #endregion

            if(standardResult.Age > 14)
            {
                #region B1
                {
                    PersonalityTestComplexScore score = new PersonalityTestComplexScore();
                    score.Category = PersonalityComplexCategory.B1;
                    score.Value = dicElementValue[Models.PersonalityElement.C] + dicElementValue[Models.PersonalityElement.F] + (11 - dicElementValue[Models.PersonalityElement.O]) + (11 - dicElementValue[Models.PersonalityElement.Q4]);

                    scores.Add(score);
                }
                #endregion

                #region B2
                {
                    PersonalityTestComplexScore score = new PersonalityTestComplexScore();
                    score.Category = PersonalityComplexCategory.B2;
                    score.Value = dicElementValue[Models.PersonalityElement.Q3]*2+dicElementValue[Models.PersonalityElement.G]*2+dicElementValue[Models.PersonalityElement.C]*2+dicElementValue[Models.PersonalityElement.E]+dicElementValue[Models.PersonalityElement.N]+dicElementValue[Models.PersonalityElement.Q2]+dicElementValue[Models.PersonalityElement.Q1];

                    scores.Add(score);
                }
                #endregion

                #region B3
                {
                    PersonalityTestComplexScore score = new PersonalityTestComplexScore();
                    score.Category = PersonalityComplexCategory.B3;
                    score.Value = (11-dicElementValue[Models.PersonalityElement.A])*2+dicElementValue[Models.PersonalityElement.B]*2+dicElementValue[Models.PersonalityElement.E]+(11-dicElementValue[Models.PersonalityElement.F])*2+dicElementValue[Models.PersonalityElement.H]+dicElementValue[Models.PersonalityElement.I]*2+dicElementValue[Models.PersonalityElement.M]+(11-dicElementValue[Models.PersonalityElement.N])+dicElementValue[Models.PersonalityElement.Q1]+dicElementValue[Models.PersonalityElement.Q3]*2;

                    scores.Add(score);
                }
                #endregion

                #region B4
                {
                    PersonalityTestComplexScore score = new PersonalityTestComplexScore();
                    score.Category = PersonalityComplexCategory.B4;
                    score.Value = dicElementValue[Models.PersonalityElement.B]+dicElementValue[Models.PersonalityElement.G]+dicElementValue[Models.PersonalityElement.Q1]+(11-dicElementValue[Models.PersonalityElement.F]);

                    scores.Add(score);
                }
                #endregion
            }

            PersonalityTestComplexResult complexResult = new PersonalityTestComplexResult();
            complexResult.Scores = scores.ToArray();
            complexResult.RefId = standardResult.RefId;

            return complexResult;
        }

        public IQTestStandardResult[] GetIQTestStandardResults(IQTestPaperResult[] paperResults)
        {
            foreach(IQTestPaperResult paperResult in paperResults)
            {
                if (string.IsNullOrEmpty(paperResult.QuestionsSetCode))
                {
                    paperResult.QuestionsSetCode = "Default";
                }
            }

            var questionsSetCodes = paperResults.Select(item => item.QuestionsSetCode).Distinct().ToList();
            var ages = paperResults.Select(item => item.Age).Distinct().ToList();

            List<IQTestQuestionsSet> questionsSets;
            List<IQTestStandardParametersSet> standardParametersSets;
            using (var context = new ComputingServicesContext())
            {
                questionsSets = context.IQTestQuestionsSets.Include(item => item.Questions).Where(item => questionsSetCodes.Contains(item.Code)).ToList();
                standardParametersSets = context.IQTestStandardParametersSets.Include(item => item.Parameters).Where(item => ages.Any(age => age >= item.AgeMin && age <= item.AgeMax)).ToList();
            }

            List<IQTestStandardResult> standardResultList = new List<IQTestStandardResult>();

            foreach (IQTestPaperResult paperResult in paperResults)
            {
                var questionsSet = questionsSets.Single(item => item.Code == paperResult.QuestionsSetCode);

                var standardParametersSet = standardParametersSets.Single(item => paperResult.Age >= item.AgeMin && paperResult.Age <= item.AgeMax);

                var standardResult = GetIQTestStandardResult(paperResult, questionsSet, standardParametersSet);

                standardResultList.Add(standardResult);
            }

            return standardResultList.ToArray();
        }

        private IQTestStandardResult GetIQTestStandardResult(IQTestPaperResult paperResult, IQTestQuestionsSet questionsSet, IQTestStandardParametersSet standardParametersSet)
        {
            int originalValue = 0;
            foreach (var questionAnswer in paperResult.QuestionAnswers)
            {
                var question = questionsSet.Questions.Single(item => item.Group == questionAnswer.QuestionGroup && item.Code == questionAnswer.QuestionCode);

                if (question.CorrectChoice == questionAnswer.Answer)
                {
                    originalValue += 1;
                }
            }

            IQTestStandardParameter standardParameter = standardParametersSet.Parameters.Where(item => originalValue >= item.OriginalScore).OrderByDescending(item => item.IQ).FirstOrDefault();
            if (standardParameter == null)
            {
                standardParameter = standardParametersSet.Parameters.OrderBy(item => item.IQ).First();
            }

            int IQ = standardParameter.IQ;

            IQLevel Level;
            if(IQ >= 130)
            {
                Level = IQLevel.EXCELLENT;
            }
            else if(IQ >= 120)
            {
                Level = IQLevel.GREAT;
            }
            else if(IQ>=110)
            {
                Level = IQLevel.MEDIUM1;
            }
            else if(IQ>=90)
            {
                Level = IQLevel.MEDIUM2;
            }
            else if(IQ>=80)
            {
                Level = IQLevel.MEDIUM3;
            }
            else if(IQ>=70)
            {
                Level = IQLevel.EDGE;
            }
            else if(IQ>=55)
            {
                Level = IQLevel.BAD1;
            }
            else if(IQ>=40)
            {
                Level = IQLevel.BAD2;
            }
            else if(IQ>=25)
            {
                Level = IQLevel.BAD3;
            }
            else
            {
                Level = IQLevel.BAD4;
            }

            IQTestStandardResult standardResult = new IQTestStandardResult();
            standardResult.Value = IQ;
            standardResult.Level = Level;
            standardResult.RefId = paperResult.RefId;

            return standardResult;
        }
    }
}
