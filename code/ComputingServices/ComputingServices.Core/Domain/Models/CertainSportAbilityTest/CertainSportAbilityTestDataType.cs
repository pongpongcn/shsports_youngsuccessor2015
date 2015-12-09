using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingServices.Core.Domain.Models.CertainSportAbilityTest
{
    /// <summary>
    /// 数据类型
    /// </summary>
    public enum CertainSportAbilityTestDataType
    {
        /// <summary>
        /// 文本
        /// </summary>
        Characters,
        /// <summary>
        /// 数值（小数，这里保留2位小数）
        /// </summary>
        Numeric,
        /// <summary>
        /// 整数
        /// </summary>
        Integer,
        /// <summary>
        /// 时间跨度
        /// </summary>
        TimeSpan
    }
}
