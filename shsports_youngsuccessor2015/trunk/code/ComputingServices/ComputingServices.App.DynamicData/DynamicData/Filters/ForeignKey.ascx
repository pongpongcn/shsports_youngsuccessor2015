﻿<%@ Control Language="C#" CodeBehind="ForeignKey.ascx.cs" Inherits="ComputingServices.App.DynamicData.ForeignKeyFilter" %>

<asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="True" CssClass="DDFilter"
    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    <asp:ListItem Text="全部" Value="" />
</asp:DropDownList>

