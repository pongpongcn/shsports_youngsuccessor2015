using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputingServices.App.DynamicData.DynamicData.FieldTemplates
{
    public partial class Gender : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected override void OnDataBinding(EventArgs e)
        {
            ltlGender.Text = ProcessGender(FieldValueString);
        }

        private string ProcessGender(string value)
        {
            Core.Gender gender;
            if(Enum.TryParse(value, out gender))
            {
                var attr = (DescriptionAttribute)typeof(Core.Gender).GetMember(value)[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0];
                return attr.Description;
            }
            else
            {
                return null;
            }
        }

        public override Control DataControl
        {
            get
            {
                return ltlGender;
            }
        }
    }
}