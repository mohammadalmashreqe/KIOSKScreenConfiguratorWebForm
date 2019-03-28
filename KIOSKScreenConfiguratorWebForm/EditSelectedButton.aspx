<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSelectedButton.aspx.cs" Inherits="KIOSKScreenConfiguratorWebForm.EditSelectedButton" %>
<asp:Content  ID="Head" ContentPlaceHolderID="Head" runat="server">
    
    

    <link href="popupstyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
  

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button_Edit" />

            </Triggers>
            <ContentTemplate>
        <div class="col-md-6 ">
            <h1>Edit button</h1>
            <div class="form-group">
                <label>name : 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_name" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </label>

                <asp:TextBox ID="TextBox_name" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
      
            <div class="form-group ">

                <label>Order :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_order" ErrorMessage="Required" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;<asp:TextBox ID="TextBox_order" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
            <asp:Button ID="Button_Edit" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="Button_Edit_Click" OnClientClick="Inform()" />
            <asp:Button ID="Button_delete" runat="server" Text="Delete button" CssClass="btn btn-primary" OnClick="Button_delete_Click" OnClientClick = "Confirm()" />

            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
            please waite .....
                </ProgressTemplate>
            </asp:UpdateProgress>

        </div>  


        </ContentTemplate>
       </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
          <ContentTemplate>
            <h1>Activity </h1>

                 <div class="form-group">
                   <br />
                  
                     </div>
        <div class="col-md-4">
        </div>
              <div class="col-md-6">
                  <asp:GridView  CssClass="table table-hover" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCreated="GridView1_RowCreated" BorderStyle="Outset" EmptyDataText="No activities found">
                      <EmptyDataRowStyle ForeColor="Red" />
                  </asp:GridView>

                
             
                      <asp:Button ID="Button5" runat="server" CssClass="open-button btn btn-primary" Text="Edit" OnClick="Button5_Click" />
               
                  </div>
              </div>
         
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate> 
    <div class="form-popup" id="myForm">
        <div  class="form-container">
            <h1>Edit Activity</h1>
            <label for="em"><b>Type :</b></label>
            <input runat="server" ID="TextBox_type" type="text" readonly="readonly"  name="em" />
            <label for="email"><b>Information Message :</b></label>
            <input runat="server" ID="TextBox_infoMsg" type="text"  name="email" />
           
            <asp:Panel runat="server" ID="panel_print">
            <label for="psw"><b>Number of printed tickets: </b></label>
                <input type="text" runat="server" ID="TextBox_numoftick" name="psw" />
            </asp:Panel>
            
            <asp:Panel runat="server" ID="panel_confirm">
                
                <label for="to"><b>Time Out : </b></label>
                <input type="text" runat="server" ID="TextBox_Timeout" name="to" />
            </asp:Panel>

           
            <asp:Panel runat="server" ID="panel_request">
               
                <label><b>Identification type :</b></label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Card</asp:ListItem>
                    <asp:ListItem>Mobile</asp:ListItem>
                </asp:DropDownList>
                <label><b>	Is mandatory  :</b></label>
                <asp:CheckBox ID="CheckBox1" runat="server" />
            </asp:Panel>
            <asp:Button ID="Button1" CssClass="btn" runat="server" Text="Update" OnClick="Button1_Click1" />
            <asp:Button ID="Button3_deleteAct" CssClass="btn btn-danger cancel" runat="server" Text="Delete" OnClick="Button3_deleteAct_Click"  />
            <asp:Button ID="Button2" runat="server" CssClass="btn-primary" OnClientClick="closeForm()" Width="300px"  Text="Close" />
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
          </ContentTemplate>
       </asp:UpdatePanel>
        
           


         </div>  



    <script type = "text/javascript">
        function Confirm() {
            var confirmValue = document.createElement("INPUT");
            confirmValue.type = "hidden";
            confirmValue.name = "confirm_value";
            if (confirm("Are you sure want to delete button ?")) {
                confirmValue.value = "Yes";
            } else {
                confirmValue.value = "No";
            }
            document.forms[0].appendChild(confirmValue);
        }

            function openForm() {
                document.getElementById("myForm").style.display = "block";
            }

        function closeForm() {
            document.getElementById("myForm").style.display = "none";
        }
 
    
    </script>


    
</asp:Content>
