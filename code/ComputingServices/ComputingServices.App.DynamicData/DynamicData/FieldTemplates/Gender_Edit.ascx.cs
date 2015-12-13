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
    public partial class Gender_Edit : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            var genderNames = typeof(Core.Gender).GetEnumNames();

            var items =
       typeof(Core.Gender).GetEnumNames()
        .Select(x => new ListItem(((DescriptionAttribute)typeof(Core.Gender).GetMember(x)[0].GetCustomAttributes(
           typeof(DescriptionAttribute), false)[0]).Description, x));

//Add items to ddl

            ddlGender.Items.Add(new ListItem("",""));
            foreach (var item in items)
                ddlGender.Items.Add(item);

            object val = FieldValue;
            if (val != null)
                ddlGender.SelectedValue = (string)val;
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = ddlGender.SelectedValue;
        }

        public override Control DataControl
        {
            get
            {
                return ddlGender;
            }
        }
    }
}