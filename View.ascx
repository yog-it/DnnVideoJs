<%@ Control Language="c#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="YogIt.Modules.VideoJs.View" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<dnn:DnnJsInclude ID="jsVideoJS" runat="server" FilePath="//vjs.zencdn.net/7.17.0/video.min.js" />
<dnn:DnnCssInclude id="cssVideoJS" runat="server" filepath="//vjs.zencdn.net/7.17.0/video-js.min.css" />
<asp:Panel ID="pnlVideo" runat="server" CssClass="video-container">
    <video id="vPlayer" runat="server" class="video-js vjs-big-play-centered video-player" data-setup='{"controls": true, "autoplay": false, "preload": "none", "fluid": true}'>
        <source id="vSource" runat="server" type="audio/mp4" />
        <track kind="captions" id="vTrack" runat="server" srclang="en" label="English" default>
        <p class="vjs-no-js"><asp:Literal ID="plNoJS" runat="server"></asp:Literal></p>
    </video>
</asp:Panel>
<asp:Panel ID="pnlBackground" runat="server" Visible="false" CssClass="video-bg-container">
    <video autoplay muted loop id="bgVideo">
      <source id="bgSource" runat="server" type="video/mp4">
    </video>
</asp:Panel>
