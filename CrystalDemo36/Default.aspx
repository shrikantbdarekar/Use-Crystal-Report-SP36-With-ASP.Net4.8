<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CrystalDemo36._Default" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Crystal Report Demo (SP36)</h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
            <br />

        </section>

        <div class="row p-3">
         <asp:Button ID="ButtonView" 
            runat="server" 
            Text="View Student Report"
            CssClass="btn btn-primary"
            OnClick="ButtonView_Click"
            OnClientClick="
                var w = 1000, h = 800;
                var left = (screen.width / 2) - (w / 2);
                var top = (screen.height / 2) - (h / 2);
                // open popup without address bar, toolbars, or URL
                window.open('', 'ReportPopup',
                    'width=' + w + 
                    ',height=' + h + 
                    ',top=' + top + 
                    ',left=' + left + 
                    ',resizable=yes,scrollbars=yes,menubar=no,toolbar=no,location=no,status=no');
                this.form.target = 'ReportPopup';
            " />


        </div>
        <div class="row p-3">
            <asp:Button ID="ButtonDownload" runat="server" Text="Download Report" OnClick="ButtonDownload_Click" />
        </div>
    </main>

</asp:Content>
