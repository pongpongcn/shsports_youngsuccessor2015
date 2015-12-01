using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingServices.Core.Domain.Models.PersonalityTest
{
    public class PersonalityTestQuestionsSet
    {
        public PersonalityTestQuestionsSet(string code)
        {
            this.Code = code;
            this.Questions = new HashSet<PersonalityTestQuestion>();
        }
        private PersonalityTestQuestionsSet() { }

        public int Id { get; private set; }
        public string Code { get; private set; }
        public virtual ICollection<PersonalityTestQuestion> Questions { get; private set; }
    }

    public class PersonalityTestQuestion
    {
        public PersonalityTestQuestion(int code, PersonalityElement element)
        {
            this.Code = code;
            this.ElementString = element.ToString();
            this.ChoiceScores = new HashSet<PersonalityTestQuestionChoiceScore>();
        }
        public int Id { get; private set; }
        /// <summary>
        /// 题目编号
        /// 1、2、3、4...
        /// </summary>
        public int Code { get; private set; }
        /// <summary>
        /// Use Element Instead
        /// </summary>
        public string ElementString { get; private set; }
        public PersonalityElement Element
        {
            get
            {
                PersonalityElement element;
                if (Enum.TryParse<PersonalityElement>(this.ElementString, out element))
                {
                    return element;
                }
                else
                {
                    throw new ArgumentException("Invalid Element");
                }
            }
        }

        public virtual ICollection<PersonalityTestQuestionChoiceScore> ChoiceScores { get; private set; }
    }

    public class PersonalityTestQuestionChoiceScore
    {
        public PersonalityTestQuestionChoiceScore(string choice, int score)
        {
            this.Choice = choice;
            this.Score = score;
        }
        public int Id { get; private set; }
        public string Choice { get; private set; }
        public int Score { get; private set; }
    }

    /// <summary>
    /// 个性测试因素种类
    /// </summary>
    public enum PersonalityElement
    {
        A=101,
        B=102,
        C=103,
        /// <summary>
        /// CPQ特有
        /// </summary>
        D=104,
        E=105,
        F=106,
        G=107,
        H=108,
        I=109,
        L=112,
        M=113,
        N=114,
        O=115,
        Q1=201,
        Q2=202,
        Q3=203,
        Q4=204
    }
}
