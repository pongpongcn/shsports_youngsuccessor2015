using ComputingServices.Core.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using ComputingServices.Core.Domain.Models.PersonalityTest;

namespace ComputingServices.App
{
    public partial class Tools : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImportQuestionsSet_Click(object sender, EventArgs e)
        {
            List<PersonalityTestQuestionsSet> questionsSetList = new List<PersonalityTestQuestionsSet>();

            string dataDirectoryPath = MapPath("~/App_Data/PersonalityTest");
            string[] dataFilePaths = Directory.GetFiles(dataDirectoryPath, "QuestionsSet*.xml");
            foreach (string dataFilePath in dataFilePaths)
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(dataFilePath);

                XmlElement xeQuestionsSet = (XmlElement)xd.SelectSingleNode("QuestionsSet");
                string questionsSetCode = xeQuestionsSet.GetAttribute("Code");

                PersonalityTestQuestionsSet questionsSet = new PersonalityTestQuestionsSet(questionsSetCode);

                foreach(XmlNode xnQuestion in xeQuestionsSet.SelectNodes("Question"))
                {
                    XmlElement xeQuestion = (XmlElement)xnQuestion;

                    int questionCode = int.Parse(xeQuestion.GetAttribute("Code"));
                    string questionElement = xeQuestion.GetAttribute("Element");
                    PersonalityElement element = (PersonalityElement)Enum.Parse(typeof(PersonalityElement), questionElement);

                    PersonalityTestQuestion question = new PersonalityTestQuestion(questionCode, element);

                    foreach(XmlNode xnChoiceScore in xeQuestion.SelectNodes("ChoiceScore"))
                    {
                        XmlElement xeChoiceScore = (XmlElement)xnChoiceScore;

                        string choice = xeChoiceScore.GetAttribute("Choice");
                        int score = int.Parse(xeChoiceScore.GetAttribute("Score"));

                        PersonalityTestQuestionChoiceScore choiceScore = new PersonalityTestQuestionChoiceScore(choice, score);
                        question.ChoiceScores.Add(choiceScore);
                    }

                    questionsSet.Questions.Add(question);
                }

                questionsSetList.Add(questionsSet);
            }

            if (questionsSetList.Count > 0)
            {
                using (var context = new ComputingServicesContext())
                {
                    foreach (PersonalityTestQuestionsSet questionsSet in questionsSetList)
                    {
                        if (context.PersonalityTestQuestionsSets.Any(item => item.Code == questionsSet.Code))
                        {
                            PersonalityTestQuestionsSet oldQuestionsSet = context.PersonalityTestQuestionsSets.Single(item => item.Code == questionsSet.Code);
                            context.PersonalityTestQuestionsSets.Remove(oldQuestionsSet);
                        }
                        context.PersonalityTestQuestionsSets.Add(questionsSet);
                    }
                    context.SaveChanges();
                }

                ltlLog.Text = "成功完成。";
            }
            else
            {
                ltlLog.Text = "没有数据。";
            }
        }
    }
}