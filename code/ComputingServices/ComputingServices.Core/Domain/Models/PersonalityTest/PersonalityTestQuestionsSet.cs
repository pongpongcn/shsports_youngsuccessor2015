using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingServices.Core.Domain.Models.PersonalityTest
{
    /// <summary>
    /// 个性测试题目及答案
    /// </summary>
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
            this.Element = element;
            this.ChoiceScores = new HashSet<PersonalityTestQuestionChoiceScore>();
        }
        private PersonalityTestQuestion() { }
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
            set
            {
                this.ElementString = value.ToString();
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
        private PersonalityTestQuestionChoiceScore() { }
        public int Id { get; private set; }
        public string Choice { get; private set; }
        public int Score { get; private set; }
    }

    /// <summary>
    /// 个性测试因素种类
    /// </summary>
    public enum PersonalityElement
    {
        A,
        B,
        C,
        /// <summary>
        /// CPQ特有
        /// </summary>
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        L,
        M,
        N,
        O,
        Q1,
        Q2,
        Q3,
        Q4
    }
}
