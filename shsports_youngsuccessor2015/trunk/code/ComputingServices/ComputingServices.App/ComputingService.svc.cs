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

            var dicQuestionsSet = new Dictionary<string, PersonalityTestQuestionsSet>();

            using (var context = new ComputingServicesContext())
            {
                var questionsSets = context.PersonalityTestQuestionsSets.Include(item => item.Questions.Select(question => question.ChoiceScores)).Where(item => questionsSetCodes.Contains(item.Code));
                foreach(var questionsSet in questionsSets)
                {
                    dicQuestionsSet.Add(questionsSet.Code, questionsSet);
                }
            }

            List<PersonalityTestElementStandardResult> elementStandardResultList = new List<PersonalityTestElementStandardResult>();

            foreach(PersonalityTestPaperResult paperResult in paperResults)
            {
                var questionsSet = dicQuestionsSet[paperResult.QuestionsSetCode];

                var elementStandardResult = GetPersonalityTestElementStandardResult(paperResult, questionsSet);

                elementStandardResultList.Add(elementStandardResult);
            }

            return elementStandardResultList.ToArray();
        }

        private PersonalityTestElementStandardResult GetPersonalityTestElementStandardResult(PersonalityTestPaperResult paperResult, PersonalityTestQuestionsSet questionsSet)
        {
            var dicElementOriginalValue = new Dictionary<App.Models.PersonalityElement, int>();
            foreach (var questionAnswer in paperResult.QuestionAnswers)
            {
                var question = questionsSet.Questions.Single(item => item.Code == questionAnswer.QuestionCode);

                App.Models.PersonalityElement element;
                if (!Enum.TryParse<App.Models.PersonalityElement>(question.Element.ToString(), out element))
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
            return null;
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
