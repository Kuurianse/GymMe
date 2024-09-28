<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="TransactionsReport.aspx.cs" Inherits="ProjectPSD.Views.TransactionsReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    </div>

</asp:Content>
