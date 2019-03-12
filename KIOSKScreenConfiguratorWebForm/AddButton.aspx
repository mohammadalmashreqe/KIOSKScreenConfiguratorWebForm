<%@ Page Title="Add Button" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddButton.aspx.cs" Inherits="KIOSKScreenConfiguratorWebForm.AddButton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <br />
    <br />
  

  
    <div class="row ">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div class="col-md-6 ">
            <h1>Add button</h1>
            <div class="form-group">
                <label >name : 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_name" ErrorMessage="Required " ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                </label>
               
                <asp:TextBox ID="TextBox_name" CssClass="form-control" runat="server"></asp:TextBox>
                
            </div>
            <div class="form-group">
                <label>Text : 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_text" ErrorMessage="Required" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="TextBox_text" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
            <div class="form-group ">
               
                <label >Order :<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_order" ErrorMessage="Required" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                </label>&nbsp;<asp:TextBox ID="TextBox_order" CssClass="form-control" runat="server"></asp:TextBox>

            </div>

          



            <asp:Button ID="Button_add" runat="server" Text="Add button"  CssClass="btn btn-primary" OnClick="Button_add_Click" ValidationGroup="a"/>
           
            <asp:Button ID="Button_save" CssClass="btn btn-success" runat="server" Text="Save" OnClick="Button_save_Click" />
        </div>
</ContentTemplate>
</asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
              <ContentTemplate>
            <div class="col-md-5">
                <h1>Add activity</h1>

                 <asp:Panel ID="contentArea" runat="server">

                   
                         <div class="form-group">
                              <label>Activity Type :</label>
                          <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" AutoPostBack="true">
                                   <asp:ListItem>Print ticket type</asp:ListItem>
                              <asp:ListItem>Request identification</asp:ListItem>
                              <asp:ListItem>Confirmation activity</asp:ListItem>

                          </asp:DropDownList>
                             </div>
                    
                     <div class="form-group ">

                         <label>Information message :<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox_Info_message" ErrorMessage="Required" ForeColor="Red" ValidationGroup="b"></asp:RequiredFieldValidator>
                         </label>
                         &nbsp;<asp:TextBox ID="TextBox_Info_message" CssClass="form-control" runat="server" ValidationGroup="b"></asp:TextBox>

                     </div>
                      <%--print tic activit --%>
                     <asp:Panel ID="Panel1" runat="server">
                         <div class="form-group ">

                             <label>Number of printed tickets :<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="enter value between 1 and 5 " ForeColor="Red" MaximumValue="5" MinimumValue="1" ValidationGroup="b" Display="Dynamic"></asp:RangeValidator>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1" ErrorMessage="Required" ForeColor="Red" ValidationGroup="b"></asp:RequiredFieldValidator>
                             </label>
                             &nbsp;<asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" ValidationGroup="b"></asp:TextBox>

                         </div>
                     </asp:Panel>

                     <asp:Panel ID="panel2" runat="server">

                         <div class="form-group">
                             <label>Identification type  : </label>
                             <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server">
                                 <asp:ListItem>Card</asp:ListItem>
                                 <asp:ListItem>Mobile</asp:ListItem>
                             </asp:DropDownList>

                         </div>

                           <div class="form-group">
                         <asp:CheckBox ID="CheckBox1" runat="server" Text="ِ  Is mandatory"/>
                                 </div>

                     </asp:Panel>

                     <asp:Panel ID="panel3" runat="server">
                           <div class="form-group">
                         <label>Time out in seconds :<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox_TimeOut" ErrorMessage="Required" ForeColor="Red" ValidationGroup="b"></asp:RequiredFieldValidator>
                               </label>
                         &nbsp;<asp:TextBox ID="TextBox_TimeOut" CssClass="form-control" runat="server" ValidationGroup="b"></asp:TextBox>
                               </div>

                     </asp:Panel>







                      <asp:Button ID="Button1" runat="server" Text=""  CssClass="btn btn-primary" ValidationGroup="b" OnClick="Button1_Click"/>

                         <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>

                </asp:Panel>

            </div>

              </ContentTemplate>
</asp:UpdatePanel>


    </div>
        <div class ="row">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                  <ContentTemplate>
        <div class="col-md-6" >
            <h1>Button List</h1>
             <asp:GridView CssClass="table table-striped table-hover table-bordered" ID="GridView1" runat="server" Width="60%"></asp:GridView>
        </div>
            <div class="col-md-6">
                <h1>Activity added</h1>
              <p>  <asp:ListBox ID="ListBox1" runat="server" Width="50%" CssClass="list-group" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged1"></asp:ListBox>
                </p>
            </div>
</ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>
