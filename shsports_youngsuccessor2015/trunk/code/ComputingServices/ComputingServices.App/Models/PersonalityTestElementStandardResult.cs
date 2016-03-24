using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ComputingServices.App.Models
{
    /// <summary>
    /// 个性测试中因素标准分（基于单张问卷）
    /// </summary>
    [DataContract]
    public class PersonalityTestElementStandardResult
    {
        /// <summary>
        /// 所有因素的标准分
        /// </summary>
        [DataMember]
        public PersonalityTestElementStandardScore[] Scores { get; set; }
        /// <summary>
        /// 进行本问卷测试时，答卷者当时的年龄
        /// </summary>
        [DataMember]
        public int Age { get; set; }
        /// <summary>
        /// 关联标识 可为空，便于对接口返回结果的检索（批量调用）。
        /// </summary>
        [DataMember]
        public string RefId { get; set; }
    }

    /// <summary>
    /// 个性测试中某个因素的标准分
    /// </summary>
    [DataContract]
    public class PersonalityTestElementStandardScore
    {
        /// <summary>
        /// 因素种类
        /// </summary>
        [DataMember]
        public PersonalityElement Element { get; set; }
        /// <summary>
        /// 本因素标准分
        /// </summary>
        [DataMember]
        public int Value { get; set; }
        /// <summary>
        /// 本因素原始分
        /// </summary>
        [DataMember]
        public int OriginalValue { get; set; }
    }
}