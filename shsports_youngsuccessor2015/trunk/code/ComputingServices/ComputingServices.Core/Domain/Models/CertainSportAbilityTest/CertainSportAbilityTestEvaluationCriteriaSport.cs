using ComputingServices.Core.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingServices.Core.Domain.Models.CertainSportAbilityTest
{
    /// <summary>
    /// 专项能力测试大项
    /// </summary>
    public class CertainSportAbilityTestEvaluationCriteriaSport
    {
        public CertainSportAbilityTestEvaluationCriteriaSport(string code, string name)
        {
            this.Code = code;
            this.Name = name;
            this.Parameters = new HashSet<CertainSportAbilityTestEvaluationCriteriaSportParameter>();
        }

        private CertainSportAbilityTestEvaluationCriteriaSport() { }

        public void UpdateBasicInfo(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        public int Id { get; private set; }
        /// <summary>
        /// 大项代号
        /// </summary>
        public string Code { get; private set; }
        /// <summary>
        /// 大项名称
        /// </summary>
        public string Name { get; private set; }
        public virtual ICollection<CertainSportAbilityTestEvaluationCriteriaSportParameter> Parameters { get; private set; }
    }

    /// <summary>
    /// 大项等级划分
    /// </summary>
    public class CertainSportAbilityTestEvaluationCriteriaSportParameter
    {
        public CertainSportAbilityTestEvaluationCriteriaSportParameter(string level, int score, int? ageMin, int? ageMax, Gender? gender)
        {
            this.Level = level;
            this.Score = score;
            this.AgeMin = ageMin;
            this.AgeMax = ageMax;
            this.Gender = gender;
        }

        private CertainSportAbilityTestEvaluationCriteriaSportParameter() { }

        public int Id { get; private set; }
        /// <summary>
        /// 等级
        /// </summary>
        public string Level { get; private set; }
        /// <summary>
        /// 分值（最低总分要求）
        /// </summary>
        public int Score { get; private set; }
        /// <summary>
        /// 年龄下限
        /// </summary>
        public int? AgeMin { get; private set; }
        /// <summary>
        /// 年龄上限
        /// </summary>
        public int? AgeMax { get; private set; }
        public string GenderString { get; private set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Gender? Gender
        {
            get
            {
                if(GenderString == null)
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
    } 
}
