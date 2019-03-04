<%@ Page Title="Edit buttons" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditButton.aspx.cs" Inherits="KIOSKScreenConfiguratorWebForm.EditButton" %>



 






<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


        <link href="Content/Site.css" rel="stylesheet" />







    <div class="row ">
        <div class="col-md-4">
            <h1>Select button </h1>
            <div class="table-responsive-md">
                <asp:GridView CssClass="table table-hover" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCreated="GridView1_RowCreated" BorderStyle="Outset"></asp:GridView>
            </div>

        </div>





    </div>

















</asp:Content>
