using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ComputingServices.App.Models
{
    /// <summary>
    /// 城镇儿童、农村儿童
    /// </summary>
    [DataContract]
    public enum ChildArea
    {
        /// <summary>
        /// 城镇（儿童）
        /// </summary>
        [EnumMember]
        CITY,
        /// <summary>
        /// 农村（儿童）
        /// </summary>
        [EnumMember]
        COUNTRY
    }
}