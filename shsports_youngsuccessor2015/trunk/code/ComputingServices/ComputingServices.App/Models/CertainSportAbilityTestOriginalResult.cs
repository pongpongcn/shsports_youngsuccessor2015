using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ComputingServices.App.Models
{
    /// <summary>
    /// 专项测试原始成绩
    /// </summary>
    [DataContract]
    public class CertainSportAbilityTestOriginalResult
    {
        /// <summary>
        /// 测试对象出生日期
        /// </summary>
        [DataMember]
        public DateTime Birthdate { get; set; }
        /// <summary>
        /// 进行测试的日期（用于计算年龄）
        /// </summary>
        [DataMember]
        public DateTime TestDate { get; set; }
        /// <summary>
        /// 大项标识（根据字典）
        /// </summary>
        [DataMember]
        public string SportType { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public Gender Gender { get; set; }
        /// <summary>
        /// 子项测试成绩
        /// </summary>
        [DataMember]
        public CertainSportAbilityTestOriginalSubScore[] SubScores { get; set; }
        /// <summary>
        /// 关联标识 可为空，便于对接口返回结果的检索（批量调用）。
        /// </summary>
        [DataMember]
        public string RefId { get; set; }
    }

    [DataContract]
    public class CertainSportAbilityTestOriginalSubScore
    {
        /// <summary>
        /// 子项标识
        /// </summary>
        [DataMember]
        public string SubType { get; set; }
        /// <summary>
        /// 子项原始测试成绩
        /// </summary>
        [DataMember]
        public string Value { get; set; }
    }
}