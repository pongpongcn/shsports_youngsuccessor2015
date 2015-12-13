using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputingServices.App.DynamicData.Core
{
    [MetadataType(typeof(CertainSportAbilityTestEvaluationCriteriaSportsMetadata))]
    public partial class CertainSportAbilityTestEvaluationCriteriaSports
    {
        [DisplayName("运动项目")]
        internal class CertainSportAbilityTestEvaluationCriteriaSportsMetadata
        {
            [DisplayName("编号")]
            public string Code { get; set; }
            [DisplayName("名称")]
            public string Name { get; set; }

            [DisplayName("总分等级规则")]
            public virtual ICollection<CertainSportAbilityTestEvaluationCriteriaSportParameters> CertainSportAbilityTestEvaluationCriteriaSportParameters { get; set; }
            [DisplayName("子项目")]
            public virtual ICollection<CertainSportAbilityTestEvaluationCriteriaSubSports> CertainSportAbilityTestEvaluationCriteriaSubSports { get; set; }
        }
    }

    [MetadataType(typeof(CertainSportAbilityTestEvaluationCriteriaSportParametersMetadata))]
    public partial class CertainSportAbilityTestEvaluationCriteriaSportParameters
    {
        [DisplayName("运动项目总分等级规则")]
        internal class CertainSportAbilityTestEvaluationCriteriaSportParametersMetadata
        {
            [DisplayName("等级")]
            public string Level { get; set; }
            [DisplayName("分值")]
            public int Score { get; set; }
            [DisplayName("年龄下限")]
            public Nullable<int> AgeMin { get; set; }
            [DisplayName("年龄上限")]
            public Nullable<int> AgeMax { get; set; }
            [UIHint("Gender")]
            [DisplayName("性别")]
            public string Gender { get; set; }
        }
    }

    [MetadataType(typeof(CertainSportAbilityTestEvaluationCriteriaSubSportsMetadata))]
    public partial class CertainSportAbilityTestEvaluationCriteriaSubSports
    {
        [DisplayName("子项目")]
        internal class CertainSportAbilityTestEvaluationCriteriaSubSportsMetadata
        {
            [DisplayName("编号")]
            public string Code { get; set; }
            [DisplayName("名称")]
            public string Name { get; set; }
            [DisplayName("计量单位")]
            public string UnitOfMeasure { get; set; }
            [DisplayName("数据类型")]
            public string DataType { get; set; }
            [DisplayName("数据比较模式")]
            public string ComparePattern { get; set; }

            [DisplayName("子项目规则组")]
            public virtual ICollection<CertainSportAbilityTestEvaluationCriteriaSubSportParametersSets> CertainSportAbilityTestEvaluationCriteriaSubSportParametersSets { get; set; }
        }
    }

    [MetadataType(typeof(CertainSportAbilityTestEvaluationCriteriaSubSportParametersSetsMetadata))]
    public partial class CertainSportAbilityTestEvaluationCriteriaSubSportParametersSets
    {
        [DisplayName("子项目规则组")]
        internal class CertainSportAbilityTestEvaluationCriteriaSubSportParametersSetsMetadata
        {
            [DisplayName("年龄下限")]
            public int AgeMin { get; set; }
            [DisplayName("年龄上限")]
            public int AgeMax { get; set; }
            [DisplayName("性别")]
            public string Gender { get; set; }

            [DisplayName("子项目规则")]
            public virtual ICollection<CertainSportAbilityTestEvaluationCriteriaSubSportParameters> CertainSportAbilityTestEvaluationCriteriaSubSportParameters { get; set; }
        }
    }

    [MetadataType(typeof(CertainSportAbilityTestEvaluationCriteriaSubSportParametersMetadata))]
    public partial class CertainSportAbilityTestEvaluationCriteriaSubSportParameters
    {
        [DisplayName("子项目规则")]
        internal class CertainSportAbilityTestEvaluationCriteriaSubSportParametersMetadata
        {
            [DisplayName("原始值")]
            public string OriginalValue { get; set; }
            [DisplayName("分值")]
            public int ScoreValue { get; set; }
            [DisplayName("等级")]
            public string ScoreLevel { get; set; }
        }
    }
}