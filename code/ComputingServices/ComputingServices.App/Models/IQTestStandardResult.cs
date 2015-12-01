using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ComputingServices.App.Models
{
    /// <summary>
    /// 认知测试中计算出的IQ值与类别结果
    /// </summary>
    [DataContract]
    public class IQTestStandardResult
    {
        /// <summary>
        /// IQ值
        /// </summary>
        [DataMember]
        public int Value { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        [DataMember]
        public IQLevel Level { get; set; }
        /// <summary>
        /// 关联标识 可为空，便于对接口返回结果的检索（批量调用）。
        /// </summary>
        [DataMember]
        public string RefId { get; set; }
    }
}