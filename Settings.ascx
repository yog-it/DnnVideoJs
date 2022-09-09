<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="YogIt.Modules.VideoJs.Settings" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls"%>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>

<div class="dnnForm">
    <div class="dnnFormItem">
        <dnn:Label ID="plPlayFrom" runat="server" Text="Play from folder" resourcekey="plPlayFrom" />
        <asp:CheckBox ID="chkPlayFrom" runat="server" AutoPostBack="true" OnCheckedChanged="chkPlayFrom_CheckedChanged" />
    </div>
    <asp:Panel ID="pnlPlayFrom" runat="server" Visible="false" CssClass="dnnFormItem">
        <dnn:Label ID="plFolder" runat="server" Text="Folder" resourcekey="plFolder" />
        <dnn:DnnFolderDropDownList ID="ddlFolders" runat="server" DataTextField="FolderName" DataValueField="FolderId"></dnn:DnnFolderDropDownList>
    </asp:Panel>
    <div class="dnnFormItem">
        <dnn:Label ID="plFullScreen" runat="server" Text="Play in full screen mode automatically" resourcekey="plFullScreen" />
        <asp:CheckBox ID="chkFullScreen" runat="server" />
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="plBackground" runat="server" Text="Display as page background" resourcekey="plBackground" />
        <asp:CheckBox ID="chkBackground" runat="server" />
    </div>
</div>