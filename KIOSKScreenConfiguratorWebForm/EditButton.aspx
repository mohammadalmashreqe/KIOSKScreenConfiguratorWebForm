<%@ Page Title="Edit buttons" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditButton.aspx.cs" Inherits="KIOSKScreenConfiguratorWebForm.EditButton" %>



 






<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <link href="Content/Site.css" rel="stylesheet" />







    <div class="row ">
        <div class="col-md-8">
            <h1>Select button  </h1>
            <h4>
                <asp:GridView CssClass="table table-hover table-striped " ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCreated="GridView1_RowCreated" BorderStyle="Outset" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" EmptyDataText="No button stored in database ">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                        <asp:BoundField DataField="order" HeaderText="Order" SortExpression="order" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KIOSK screen configurator object orientedConnectionString2 %>" SelectCommand="getButtons" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
           </h4>
            <div>
            </div>

        </div>





    </div>
















</asp:Content>
