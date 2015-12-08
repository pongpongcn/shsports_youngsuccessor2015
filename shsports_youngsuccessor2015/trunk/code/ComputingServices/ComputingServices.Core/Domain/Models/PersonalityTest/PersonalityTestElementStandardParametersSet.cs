using ComputingServices.Core.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingServices.Core.Domain.Models.PersonalityTest
{
    /// <summary>
    /// 个性测试16种人格因素常模
    /// </summary>
    public class PersonalityTestElementStandardParametersSet
    {
        public PersonalityTestElementStandardParametersSet(string name, int ageMin, int ageMax, Gender gender)
        {
            this.Name = name;
            this.AgeMin = ageMin;
            this.AgeMax = ageMax;
            this.Gender = gender;
            this.Parameters = new HashSet<PersonalityTestElementStandardParameter>();
        }

        private PersonalityTestElementStandardParametersSet() { }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int AgeMin { get; private set; }
        public int AgeMax { get; private set; }
        public string GenderString { get; private set; }
        public Gender Gender
        {
            get
            {
                Gender gender;
                if (Enum.TryParse<Gender>(this.GenderString, out gender))
                {
                    return gender;
                }
                else
                {
                    throw new ArgumentException("Invalid Element");
                }
            }
            set
            {
                this.GenderString = value.ToString();
            }
        }

        public virtual ICollection<PersonalityTestElementStandardParameter> Parameters { get; private set; }
    }

    public class PersonalityTestElementStandardParameter
    {
        public PersonalityTestElementStandardParameter(PersonalityElement element, decimal parameterX, decimal parameterS)
        {
            this.Element = element;
            this.ParameterX = parameterX;
            this.ParameterS = parameterS;
            this.Segments = new HashSet<PersonalityTestElementStandardParameterSegment>();
        }

        private PersonalityTestElementStandardParameter() { }

        public int Id { get; private set; }
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
        public decimal ParameterX { get; private set; }
        public decimal ParameterS { get; private set; }
        public virtual ICollection<PersonalityTestElementStandardParameterSegment> Segments { get; private set; }
    }

    public class PersonalityTestElementStandardParameterSegment
    {
        public PersonalityTestElementStandardParameterSegment(int originalScoreMin, int originalScoreMax, int standardScore)
        {
            this.OriginalScoreMin = originalScoreMin;
            this.OriginalScoreMax = originalScoreMax;
            this.StandardScore = standardScore;
        }

        private PersonalityTestElementStandardParameterSegment() { }

        public int Id { get; private set; }
        public int OriginalScoreMin { get; private set; }
        public int OriginalScoreMax { get; private set; }
        public int StandardScore { get; private set; }
    }
}
