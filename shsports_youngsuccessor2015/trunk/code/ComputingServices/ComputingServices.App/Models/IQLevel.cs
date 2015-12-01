using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ComputingServices.App.Models
{
    /// <summary>
    /// IQ智力分类
    /// </summary>
    [DataContract]
    public enum IQLevel
    {
        /// <summary>
        /// 极优
        /// </summary>
        [EnumMember]
        EXCELLENT,
        /// <summary>
        /// 优秀
        /// </summary>
        [EnumMember]
        GREAT,
        /// <summary>
        /// 中上（聪明）
        /// </summary>
        [EnumMember]
        MEDIUM1,
        /// <summary>
        /// 中等（一般）
        /// </summary>
        [EnumMember]
        MEDIUM2,
        /// <summary>
        /// 中下（迟钝）
        /// </summary>
        [EnumMember]
        MEDIUM3,
        /// <summary>
        /// 边缘
        /// </summary>
        [EnumMember]
        EDGE,
        /// <summary>
        /// 弱智.轻度
        /// </summary>
        [EnumMember]
        BAD1,
        /// <summary>
        /// 弱智.中度
        /// </summary>
        [EnumMember]
        BAD2,
        /// <summary>
        /// 弱智.重度
        /// </summary>
        [EnumMember]
        BAD3,
        /// <summary>
        /// 弱智.极重
        /// </summary>
        [EnumMember]
        BAD4
    }
}