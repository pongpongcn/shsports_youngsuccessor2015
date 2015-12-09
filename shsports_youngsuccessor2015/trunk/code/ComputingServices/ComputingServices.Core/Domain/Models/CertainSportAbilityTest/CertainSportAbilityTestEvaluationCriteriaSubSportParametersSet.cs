using ComputingServices.Core.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingServices.Core.Domain.Models.CertainSportAbilityTest
{
    public class CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet
    {
        public CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet(int ageMin, int ageMax, Gender? gender, CertainSportAbilityTestEvaluationCriteriaSubSport subSport)
        {
            this.AgeMin = ageMin;
            this.AgeMax = ageMax;
            this.Gender = gender;
            this.SubSport = subSport;
            this.Parameters = new HashSet<CertainSportAbilityTestEvaluationCriteriaSubSportParameter>();
        }
        private CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet() { }

        public int Id { get; private set; }
        /// <summary>
        /// 年龄下限
        /// </summary>
        public int AgeMin { get; private set; }
        /// <summary>
        /// 年龄上限
        /// </summary>
        public int AgeMax { get; private set; }
        public string GenderString { get; private set; }
        /// <summary>
        /// 性别，若为空则表示同时适用于男、女。
        /// </summary>
        public Gender? Gender
        {
            get
            {
                if (GenderString == null)
                {
                    return null;
                }

                Gender gender;
                if (Enum.TryParse<Gender>(this.GenderString, out gender))
                {
                    return gender;
                }
                else
                {
                    throw new ArgumentException("Invalid Gender");
                }
            }
            set
            {
                if (value == null)
                {
                    this.GenderString = null;
                }
                else
                {
                    this.GenderString = value.ToString();
                }
            }
        }

        public virtual CertainSportAbilityTestEvaluationCriteriaSubSport SubSport { get; private set; }
        public virtual ICollection<CertainSportAbilityTestEvaluationCriteriaSubSportParameter> Parameters { get; private set; }
    }

    public class CertainSportAbilityTestEvaluationCriteriaSubSportParameter
    {
        public CertainSportAbilityTestEvaluationCriteriaSubSportParameter(string originalValue, int scoreValue, string scoreLevel)
        {
            this.OriginalValue = originalValue;
            this.ScoreValue = scoreValue;
            this.ScoreLevel = scoreLevel;
        }
        private CertainSportAbilityTestEvaluationCriteriaSubSportParameter() { }

        public int Id { get; private set; }
        /// <summary>
        /// 原始成绩（下限），注意这里的下限与算分比对模式有关，并非为范围边界值中较小的，而是最坏成绩。
        /// </summary>
        public string OriginalValue { get; private set; }
        /// <summary>
        /// 小项测试得分分值
        /// </summary>
        public int ScoreValue { get; private set; }
        /// <summary>
        /// 小项测试得分等级（可能为空）
        /// </summary>
        public string ScoreLevel { get; private set; }
    }
}
