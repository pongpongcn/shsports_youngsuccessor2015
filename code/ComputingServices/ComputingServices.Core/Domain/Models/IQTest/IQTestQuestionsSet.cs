using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingServices.Core.Domain.Models.IQTest
{
    public class IQTestQuestionsSet
    {
        public IQTestQuestionsSet(string code)
        {
            this.Code = code;
            this.Questions = new HashSet<IQTestQuestion>();
        }
        private IQTestQuestionsSet() { }
        public int Id { get; private set; }
        public string Code { get; private set; }
        public virtual ICollection<IQTestQuestion> Questions { get; private set; }
    }

    public class IQTestQuestion
    {
        public IQTestQuestion(string correctChoice)
        {
            this.CorrectChoice = correctChoice;
        }

        private IQTestQuestion() { }

        public int Id { get; private set; }
        public string CorrectChoice { get; private set; }
    }
}
