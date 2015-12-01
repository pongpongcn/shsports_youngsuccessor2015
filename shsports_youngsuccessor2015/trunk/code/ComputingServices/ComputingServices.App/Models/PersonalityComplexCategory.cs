using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ComputingServices.App.Models
{
    /// <summary>
    /// 综合评价类别（4种次级人格因素和4种特殊因素）
    /// </summary>
    [DataContract]
    public enum PersonalityComplexCategory
    {
        /// <summary>
        /// 适应与焦虑型
        /// </summary>
        [EnumMember]
        A1,
        /// <summary>
        /// 内向与外向型
        /// </summary>
        [EnumMember]
        A2,
        /// <summary>
        /// 情感用事与安详机警型
        /// </summary>
        [EnumMember]
        A3,
        /// <summary>
        /// 怯懦与果断型
        /// </summary>
        [EnumMember]
        A4,
        /// <summary>
        /// 心理健康因素
        /// </summary>
        [EnumMember]
        B1,
        /// <summary>
        /// 专业而有成就者的人格因素
        /// </summary>
        [EnumMember]
        B2,
        /// <summary>
        /// 创造能力人格因素
        /// </summary>
        [EnumMember]
        B3,
        /// <summary>
        /// 在新环境中有成长能力的人格因素
        /// </summary>
        [EnumMember]
        B4
    }
}