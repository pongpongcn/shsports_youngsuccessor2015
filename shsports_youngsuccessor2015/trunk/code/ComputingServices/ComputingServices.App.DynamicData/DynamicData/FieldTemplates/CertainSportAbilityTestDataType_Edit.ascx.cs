using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputingServices.App.DynamicData.DynamicData.FieldTemplates
{
    public partial class CertainSportAbilityTestDataType_Edit : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            var genderNames = typeof(Core.CertainSportAbilityTestDataType).GetEnumNames();

            var items =
       typeof(Core.CertainSportAbilityTestDataType).GetEnumNames()
        .Select(x => new ListItem(((DescriptionAttribute)typeof(Core.CertainSportAbilityTestDataType).GetMember(x)[0].GetCustomAttributes(
           typeof(DescriptionAttribute), false)[0]).Description, x));

            //Add items to ddl

            ddlDataType.Items.Add(new ListItem("", ""));
            foreach (var item in items)
                ddlDataType.Items.Add(item);

            object val = FieldValue;
            if (val != null)
                ddlDataType.SelectedValue = (string)val;
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = ddlDataType.SelectedValue;
        }

        public override Control DataControl
        {
            get
            {
                return ddlDataType;
            }
        }
    }
}