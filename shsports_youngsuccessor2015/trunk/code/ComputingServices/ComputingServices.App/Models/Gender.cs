using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ComputingServices.App.Models
{
    /// <summary>
    /// 性别
    /// </summary>
    [DataContract]
    public enum Gender
    {
        /// <summary>
        /// 男
        /// </summary>
        [EnumMember]
        MALE,
        /// <summary>
        /// 女
        /// </summary>
        [EnumMember]
        FEMALE,
        /// <summary>
        /// 未指定
        /// </summary>
        [EnumMember]
        UNKNOWN
    }
}