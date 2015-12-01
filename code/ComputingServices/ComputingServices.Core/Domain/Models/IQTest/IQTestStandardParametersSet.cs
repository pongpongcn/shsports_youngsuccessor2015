using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingServices.Core.Domain.Models.IQTest
{
    public class IQTestStandardParametersSet
    {
        public IQTestStandardParametersSet(int ageMin, int ageMax)
        {
            this.AgeMin = ageMin;
            this.AgeMax = ageMax;
            this.Parameters = new HashSet<IQTestStandardParameter>();
        }
        private IQTestStandardParametersSet() { }
        public int Id { get; private set; }
        public int AgeMin { get; private set; }
        public int AgeMax { get; private set; }

        public virtual ICollection<IQTestStandardParameter> Parameters { get; private set; }
    }

    public class IQTestStandardParameter
    {
        public IQTestStandardParameter(int originalScore, int iQ)
        {
            this.OriginalScore = originalScore;
            this.IQ = iQ;
        }
        private IQTestStandardParameter() { }
        public int Id { get; private set; }
        public int OriginalScore { get; private set; }
        public int IQ { get; private set; }
    }
}
