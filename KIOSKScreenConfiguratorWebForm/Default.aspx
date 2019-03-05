<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KIOSKScreenConfiguratorWebForm._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- <div class="jumbotron">
       
    </div>--%>


  <style> 
      .card {
  /* Add shadows to create the "card" effect */
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  transition: 0.3s;
}

/* On mouse-over, add a deeper shadow */
.card:hover {
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
}

/* Add some padding inside the card container */
.container {
  padding: 2px 16px;
}
</style>

    <div class="container">
    <div class="row">
<h2>Option</h2>
        <div class="col-md-6">
            
            <p>
            </p>
            <p>
                     <a class="btn btn-default" href="AddButton.aspx">Add Button &raquo;</a>
                <a class="btn btn-default" href="EditButton.aspx">Edit Button &raquo;</a>
            </p>
        </div>
</div>
        <div class="row">
            <h2>Button List</h2>

            <asp:Panel ID="contentArea" runat="server">
            </asp:Panel>




        </div>
       
   </div>
 
</asp:Content>
