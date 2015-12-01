using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ComputingServices.App.Models
{
    /// <summary>
    /// 个性测试因素种类
    /// </summary>
    [DataContract]
    public enum PersonalityElement
    {
        [EnumMember]
        A,
        [EnumMember]
        B,
        [EnumMember]
        C,
        /// <summary>
        /// CPQ特有
        /// </summary>
        [EnumMember]
        D,
        [EnumMember]
        E,
        [EnumMember]
        F,
        [EnumMember]
        G,
        [EnumMember]
        H,
        [EnumMember]
        I,
        [EnumMember]
        L,
        [EnumMember]
        M,
        [EnumMember]
        N,
        [EnumMember]
        O,
        [EnumMember]
        Q1,
        [EnumMember]
        Q2,
        [EnumMember]
        Q3,
        [EnumMember]
        Q4
    }
}