<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSelectedButton.aspx.cs" Inherits="KIOSKScreenConfiguratorWebForm.EditSelectedButton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
     
        <div class="col-md-4 ">
            <h1>Edit button</h1>
            <div class="form-group">
                <label>name : 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_name" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </label>

                <asp:TextBox ID="TextBox_name" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
            <div class="form-group">
                <label>Text : 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_text" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="TextBox_text" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
            <div class="form-group ">

                <label>Order :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_order" ErrorMessage="Required" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;<asp:TextBox ID="TextBox_order" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
            <asp:Button ID="Button_Edit" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="Button_Edit_Click" OnClientClick="Inform()" />
            <asp:Button ID="Button_delete" runat="server" Text="Delete button" CssClass="btn btn-primary" OnClick="Button_delete_Click" OnClientClick = "Confirm()" />

        </div>  


         
       

          
            <h1>Activity </h1>

                 <div class="form-group">
                   <br />
                       <asp:Button ID="Button2" runat="server" Text="Print ticket type Activities"  CssClass="btn btn-info" OnClick="Button2_Click"/>
                       <asp:Button ID="Button1" runat="server" Text="Request identification activities" CssClass="btn btn-info" OnClick="Button1_Click"  />
                       <asp:Button ID="Button3" runat="server" Text="Confirmation activities" CssClass="btn btn-info" OnClick="Button3_Click" />
                  
                     </div>
                <div class="col-md-4">
                </div>
             <div class="col-md-6">
                    <asp:GridView CssClass="table table-hover" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCreated="GridView1_RowCreated" BorderStyle="Outset" EmptyDataText="No activities found">
                        <EmptyDataRowStyle ForeColor="Red" />
                    </asp:GridView>
                 <asp:Button ID="Button4" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="Button4_Click" />
                </div>
               </div>
       
        
           


           




    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

      
    
    </script>


</asp:Content>
