using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ComputingServices.App.Models
{
    /// <summary>
    /// 个性测试中基于多因素标准分得出的综合评价
    /// </summary>
    [DataContract]
    public class PersonalityTestComplexResult
    {
        /// <summary>
        /// 所有综合评价
        /// </summary>
        [DataMember]
        public PersonalityTestComplexScore[] Scores { get; set; }
        /// <summary>
        /// 关联标识 可为空，便于对接口返回结果的检索（批量调用）。
        /// </summary>
        [DataMember]
        public string RefId { get; set; }
    }

    /// <summary>
    /// 个性测试中基于多因素标准分得出的单项综合评价
    /// </summary>
    [DataContract]
    public class PersonalityTestComplexScore
    {
        /// <summary>
        /// 评价类别
        /// </summary>
        [DataMember]
        public PersonalityComplexCategory Category { get; set; }
        /// <summary>
        /// 本类别得分
        /// </summary>
        [DataMember]
        public int Value { get; set; }
        /// <summary>
        /// 根据分数得出对应的性格类型或者对应的评价
        /// 预留，但暂时先不添加
        /// </summary>
        public string Level { get; set; }
    }
}