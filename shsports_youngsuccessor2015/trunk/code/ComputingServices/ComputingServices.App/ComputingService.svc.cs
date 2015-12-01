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
                elementStandardParametersSets = context.PersonalityTestElementStandardParametersSets.Include(item => item.Parameters).Where(item => ages.Any(age => age >= item.AgeMin && age <= item.AgeMax)).ToList();
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
                var question = questionsSet.Questions.Single(item => item.Code == questionAnswer.QuestionCode);

                Core.Domain.Models.PersonalityTest.PersonalityElement element;
                if (!Enum.TryParse<Core.Domain.Models.PersonalityTest.PersonalityElement>(question.Element.ToString(), out element))
                {
                    break;
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

                int standardScoreValue = decimal.ToInt32((Convert.ToDecimal(originalValue) - elementStandardParameter.ParameterX) / elementStandardParameter.ParameterS);

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
            throw new NotImplementedException();
        }

        public IQTestStandardResult[] GetIQTestStandardResults(IQTestPaperResult[] paperResults)
        {
            throw new NotImplementedException();
        }
    }
}
