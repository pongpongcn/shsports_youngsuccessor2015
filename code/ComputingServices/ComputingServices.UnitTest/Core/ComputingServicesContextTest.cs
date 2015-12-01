using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputingServices.Core.Infrastructure.Persistence;
using ComputingServices.Core.Domain.Models.PersonalityTest;

namespace ComputingServices.UnitTest.Core
{
    [TestClass]
    public class ComputingServicesContextTest
    {
        [TestMethod]
        public void TestQueryPersonalityTestQuestionsSet()
        {
            string questionsSetCode = "T1";
            PersonalityTestQuestionsSet newQuestionsSet = new PersonalityTestQuestionsSet(questionsSetCode);

            #region Question3
            {
                PersonalityTestQuestion question = new PersonalityTestQuestion(3, PersonalityElement.B);

                PersonalityTestQuestionChoiceScore choiceScore1 = new PersonalityTestQuestionChoiceScore("B", 1);
                question.ChoiceScores.Add(choiceScore1);

                PersonalityTestQuestionChoiceScore choiceScore2 = new PersonalityTestQuestionChoiceScore("C", 2);
                question.ChoiceScores.Add(choiceScore2);

                newQuestionsSet.Questions.Add(question);
            }
            #endregion

            #region Question5
            {
                PersonalityTestQuestion question = new PersonalityTestQuestion(5, PersonalityElement.G);

                PersonalityTestQuestionChoiceScore choiceScore1 = new PersonalityTestQuestionChoiceScore("A", 2);
                question.ChoiceScores.Add(choiceScore1);

                PersonalityTestQuestionChoiceScore choiceScore2 = new PersonalityTestQuestionChoiceScore("C", 1);
                question.ChoiceScores.Add(choiceScore2);

                newQuestionsSet.Questions.Add(question);
            }
            #endregion

            using (var context = new ComputingServicesContext())
            {
                context.PersonalityTestQuestionsSets.Add(newQuestionsSet);
                context.SaveChanges();
            }
        }
    }
}
