using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingServices.Core.Domain.Models.CertainSportAbilityTest
{
    /// <summary>
    /// 专项能力测试小项
    /// </summary>
    public class CertainSportAbilityTestEvaluationCriteriaSubSport
    {
        public CertainSportAbilityTestEvaluationCriteriaSubSport(string code, string name, string unitOfMeasure, CertainSportAbilityTestDataType dataType, CertainSportAbilityTestComparePattern comparePattern, CertainSportAbilityTestEvaluationCriteriaSport sport)
        {
            this.Code = code;
            this.Name = name;
            this.UnitOfMeasure = unitOfMeasure;
            this.DataType = dataType;
            this.ComparePattern = comparePattern;
            this.Sport = sport;
        }

        private CertainSportAbilityTestEvaluationCriteriaSubSport() { }

        public int Id { get; private set; }
        /// <summary>
        /// 小项标识
        /// </summary>
        public string Code { get; private set; }
        /// <summary>
        /// 小项名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 度量单位（厘米、名次、秒、个、次），可以为空，仅用于显示。
        /// </summary>
        public string UnitOfMeasure { get; private set; }
        public string DataTypeString { get; private set; }
        /// <summary>
        /// 数据类型（分值对照表中的原始成绩）
        /// </summary>
        public CertainSportAbilityTestDataType DataType
        {
            get
            {
                CertainSportAbilityTestDataType dataType;
                if (Enum.TryParse<CertainSportAbilityTestDataType>(this.DataTypeString, out dataType))
                {
                    return dataType;
                }
                else
                {
                    throw new ArgumentException("Invalid CertainSportAbilityTestDataType");
                }
            }
            set
            {
                this.DataTypeString = value.ToString();
            }
        }
        public string ComparePatternString { get; private set; }
        /// <summary>
        /// 算分比对模式
        /// </summary>
        public CertainSportAbilityTestComparePattern ComparePattern
        {
            get
            {
                CertainSportAbilityTestComparePattern comparePattern;
                if (Enum.TryParse<CertainSportAbilityTestComparePattern>(this.ComparePatternString, out comparePattern))
                {
                    return comparePattern;
                }
                else
                {
                    throw new ArgumentException("Invalid CertainSportAbilityTestComparePattern");
                }
            }
            set
            {
                this.ComparePatternString = value.ToString();
            }
        }
        /// <summary>
        /// 所属项目
        /// </summary>
        public virtual CertainSportAbilityTestEvaluationCriteriaSport Sport { get; private set; }
    }
}
