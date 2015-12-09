using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ComputingServices.App.Models
{
    /// <summary>
    /// 专项测试标准分
    /// </summary>
    [DataContract]
    public class CertainSportAbilityTestStandardResult
    {
        /// <summary>
        /// 所有分数总和（所有子项加权综合）通常情况下为整数 皮划艇、赛艇此值为数组形式，因为存在两个分项。
        /// </summary>
        [DataMember]
        public string OverallScore { get; set; }
        /// <summary>
        /// 等级、分类（优秀、及格、合格、通过等）通常情况下为单个每种大项标准不一皮划艇、赛艇此值为数组形式，因为存在两个分项。
        /// </summary>
        [DataMember]
        public string Level { get; set; }
        /// <summary>
        /// 子项测试成绩
        /// </summary>
        [DataMember]
        public CertainSportAbilityTestStandardSubScore[] SubScores { get; set; }
        /// <summary>
        /// 关联标识 可为空，便于对接口返回结果的检索（批量调用）。
        /// </summary>
        [DataMember]
        public string RefId { get; set; }
    }

    /// <summary>
    /// 专项测试子项标准分
    /// </summary>
    [DataContract]
    public class CertainSportAbilityTestStandardSubScore
    {
        /// <summary>
        /// 子项标识
        /// </summary>
        [DataMember]
        public string SubType { get; set; }
        /// <summary>
        /// 子项测试成绩标准分
        /// </summary>
        [DataMember]
        public int Value { get; set; }
        /// <summary>
        /// 等级、分类（优秀、及格、合格、通过等）
        /// </summary>
        [DataMember]
        public string Level { get; set; }
    }
}