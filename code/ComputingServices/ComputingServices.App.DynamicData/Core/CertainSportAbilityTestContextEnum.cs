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
}