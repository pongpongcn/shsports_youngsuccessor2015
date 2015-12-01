﻿using ComputingServices.Core.Infrastructure.Persistence;
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

        protected void btnImportPersonalityTestQuestionsSet_Click(object sender, EventArgs e)
        {
            var questionsSetList = new List<PersonalityTestQuestionsSet>();

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
                    foreach (var questionsSet in questionsSetList)
                    {
                        PersonalityTestQuestionsSet oldQuestionsSet = context.PersonalityTestQuestionsSets.SingleOrDefault(item => item.Code == questionsSet.Code);
                        if (oldQuestionsSet != null)
                        {
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

        protected void btnImportPersonalityTestElementStandardParametersSet_Click(object sender, EventArgs e)
        {
            List<PersonalityTestElementStandardParametersSet> parametersSetList = new List<PersonalityTestElementStandardParametersSet>();

            string dataDirectoryPath = MapPath("~/App_Data/PersonalityTest");
            string[] dataFilePaths = Directory.GetFiles(dataDirectoryPath, "ElementStandardParametersSet*.xml");

            foreach (string dataFilePath in dataFilePaths)
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(dataFilePath);

                XmlElement xeElementStandardParametersSet = (XmlElement)xd.SelectSingleNode("ElementStandardParametersSet");
                string name = xeElementStandardParametersSet.GetAttribute("Name");
                int ageMin = int.Parse(xeElementStandardParametersSet.GetAttribute("AgeMin"));
                int ageMax = int.Parse(xeElementStandardParametersSet.GetAttribute("AgeMax"));
                Core.Domain.Models.Shared.Gender gender = (Core.Domain.Models.Shared.Gender)Enum.Parse(typeof(Core.Domain.Models.Shared.Gender), xeElementStandardParametersSet.GetAttribute("Gender"));

                PersonalityTestElementStandardParametersSet parametersSet = new PersonalityTestElementStandardParametersSet(name, ageMin, ageMax, gender);

                foreach (XmlNode xnParameter in xeElementStandardParametersSet.SelectNodes("Parameter"))
                {
                    XmlElement xeParameter = (XmlElement)xnParameter;

                    string parameterElement = xeParameter.GetAttribute("Element");
                    PersonalityElement element = (PersonalityElement)Enum.Parse(typeof(PersonalityElement), parameterElement);
                    decimal parameterX = decimal.Parse(xeParameter.GetAttribute("X"));
                    decimal parameterS = decimal.Parse(xeParameter.GetAttribute("S"));

                    PersonalityTestElementStandardParameter elementStandardParameter = new PersonalityTestElementStandardParameter(element, parameterX, parameterS);
                    parametersSet.Parameters.Add(elementStandardParameter);
                }

                parametersSetList.Add(parametersSet);
            }

            if (parametersSetList.Count > 0)
            {
                using (var context = new ComputingServicesContext())
                {
                    foreach (var parametersSet in parametersSetList)
                    {
                        var oldPersonalityTestElementStandardParametersSet = context.PersonalityTestElementStandardParametersSets.Where(item => item.AgeMin == parametersSet.AgeMin && item.AgeMax == parametersSet.AgeMax).ToList().SingleOrDefault(item => item.Gender == parametersSet.Gender);
                        if (oldPersonalityTestElementStandardParametersSet != null)
                        {
                            context.PersonalityTestElementStandardParametersSets.Remove(oldPersonalityTestElementStandardParametersSet);
                        }
                        context.PersonalityTestElementStandardParametersSets.Add(parametersSet);
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