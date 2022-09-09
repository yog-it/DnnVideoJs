<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="YogIt.Modules.VideoJs.Edit" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnn" TagName="FilePickerUploader" Src="~/controls/filepickeruploader.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>

<div class="dnnForm">
     <div class="dnnFormItem">
        <dnn:Label id="plTitle" runat="server" ResourceKey="plTitle" ControlName="txtTitle" CssClass="dnnFormRequired" />
        <asp:Textbox ID="txtTitle" runat="server" />
    </div>
    <asp:Panel ID="pnlPosterImage" runat="server" class="dnnFormItem">
        <dnn:Label id="plPosterImage" runat="server" ResourceKey="plPosterImage" ControlName="ctlImage" />
        <dnn:FilePickerUploader ID="ctlImage" FolderPath="Videos" runat="server" Required="True" FileFilter="jpg,gif,png" />
    </asp:Panel>        
    <div class="dnnFormItem">
        <dnn:Label id="plVideo" runat="server" ResourceKey="plVideo" ControlName="ctlVideo" />
        <dnn:FilePickerUploader ID="ctlVideo" FolderPath="Videos" runat="server" Required="True" FileFilter="mp4,avi,wmv,mov" />
    </div>      
    <div class="dnnFormItem">
        <dnn:Label id="plCaption" runat="server" ResourceKey="plCaption" ControlName="ctlCaption" />
        <dnn:FilePickerUploader ID="ctlCaption" FolderPath="Videos" runat="server" Required="True" FileFilter="vtt" />
    </div>
</div>

<ul class="dnnActions">
    <li>
        <asp:LinkButton ID="cmdUpdate" runat="server" CssClass="dnnPrimaryAction" OnClick="cmdUpdate_Click" ResourceKey="cmdUpdate" /></li>
    <li>
        <asp:LinkButton ID="cmdDelete" runat="server" CssClass="dnnSecondaryAction" CausesValidation="false" ResourceKey="cmdDelete" OnClick="cmdDelete_Click" /></li>
    <li>
        <asp:HyperLink ID="cmdCancel" runat="server" CssClass="dnnSecondaryAction" CausesValidation="false" resourcekey="cmdCancel" /></li>
</ul>