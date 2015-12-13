using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ComputingServices.App.DynamicData.Core
{
    public enum Gender
    {
        [Description("男")]
        Male,
        [Description("女")]
        Female
    }

    /// <summary>
    /// 数据类型
    /// </summary>
    public enum CertainSportAbilityTestDataType
    {
        [Description("文本")]
        Characters,
        [Description("数值")]
        Numeric,
        [Description("整数")]
        Integer,
        [Description("时间跨度")]
        TimeSpan
    }

    public enum CertainSportAbilityTestComparePattern
    {
        [Description("小于等于")]
        LessThanOrEqual,
        [Description("大于等于")]
        GreaterThanOrEqual,
        [Description("等于")]
        Equal
    }
}