<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="temppage.aspx.cs" Inherits="KIOSKScreenConfiguratorWebForm.Temppage" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content runat="server" ContentPlaceHolderID="Head">
    
    

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
    
    


  <div class="container">


        <div class="content">
            <!-- Multistep Form -->
            <div id="snackbar"></div>
               
            <div class="regform">
                <!-- Progressbar -->
                <ul id="progressbar">
                    <li id="active1">Add Button</li>
                    <li id="active2">Add Activity</li>
                    <li id="active3">review and finish</li>
                </ul>
                <!-- Fieldsets -->
                <fieldset id="first">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <h2 class="title">Add Button</h2>
                            <p class="subtitle">Step 1/3</p>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Name :</label><br/>
                                    <asp:TextBox ID="TextBox_name" placeholder="Enter Button name" CssClass="text_field" runat="server" OnTextChanged="TextBox_name_TextChanged" ValidationGroup="a"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="TextBox_name" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                </div>


                            </div>
                           

                            <div class="row" >
                          
                                <div class="col-md-6">
                                    <label>Order : </label><br/>
                                    <asp:TextBox ID="TextBox_Order" placeholder="Enter Button order" CssClass="text_field" runat="server" OnTextChanged="TextBox_Order_TextChanged" ValidationGroup="a"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox_Order" ErrorMessage="Required" ForeColor="Red" ValidationGroup="a" Display="Dynamic"></asp:RequiredFieldValidator>

                                    </div>
                               


                            </div>

                            <asp:Button ID="Button1" runat="server" Text="Next" OnClick="Button1_Click" ValidationGroup="a" />

                        </ContentTemplate>
                    </asp:UpdatePanel>


                </fieldset>

                <fieldset id="second" style="display: none">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <h2 class="title">Add Activity</h2>
                            <p class="subtitle">Step 2/3</p>

                            <div class="row">
                                <div class="col-md-4">
                                    <label>Activity Type :</label>
                                    <asp:DropDownList CssClass="options" ID="DropDownList_ActivityType" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem>Print ticket type</asp:ListItem>
                                        <asp:ListItem>Request identification</asp:ListItem>
                                        <asp:ListItem Value="Confirmation activity">Confirmation activity</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <label>Information message</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox_informationMessage" runat="server" ErrorMessage="Required" ForeColor="Red" ValidationGroup="b"></asp:RequiredFieldValidator>
                                   
                                        <asp:TextBox CssClass="text_field" ID="TextBox_informationMessage" placeholder="Enter Information message" runat="server"></asp:TextBox>
                                   
                                </div>
                            </div>

                            <asp:Panel ID="Panel1" runat="server">
                                <div class="row">
                                    <div class="col-md-4">

                                        <label>Number of printed tickets:  </label>

                                    </div>
                                    
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:TextBox CssClass="text_field" Enabled="False" ID="TextBox_numOftick" runat="server" Font-Size="Medium" Height="35"></asp:TextBox>
                                        <asp:NumericUpDownExtender ID="TextBox2_NumericUpDownExtender" runat="server"
                                            Enabled="True" Maximum="5"
                                            Minimum="1" RefValues="" ServiceDownMethod=""
                                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" Width="310"
                                            TargetButtonUpID="" TargetControlID="TextBox_numOftick"></asp:NumericUpDownExtender>


                                    </div>

                                </div>


                            </asp:Panel>
                            <br />


                            <asp:Panel ID="panel2" runat="server">
                                <div class="row">
                                    <div class="form-group col-md-4">
                                        <label>Identification type  : </label>
                                        <asp:DropDownList ID="DropDownList_idenType" CssClass="form-control" runat="server">
                                            <asp:ListItem>Card</asp:ListItem>
                                            <asp:ListItem>Mobile</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                
                              
                                        <asp:CheckBox CssClass="form-check" ID="CheckBox1" runat="server" Text=".  is mandotry " />

                                    
                              
                            </asp:Panel>

                            <asp:Panel ID="panel3" runat="server">
                                <div class="form-group">
                                    <label>
                                        Time out in seconds :
                                    </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox_TimeOut" ErrorMessage="Required" ForeColor="Red" ValidationGroup="b" Display="Dynamic"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:TextBox ID="TextBox_TimeOut" CssClass="form-control" runat="server" ValidationGroup="b"></asp:TextBox>
                                </div>

                            </asp:Panel>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <div class="row" style="padding-left: 0">
                                        <div class="col-md-3">
                                            <asp:Button ID="Button_prev" runat="server" Text="Previous" OnClick="Button_prev_Click" />
                                        </div>

                                 
                                  
                                        <div class="col-md-3">
                                            <asp:Button ID="Button4" runat="server" Text="Add more activity" ValidationGroup="b" OnClick="Button4_Click" />
                                           
                                        </div>
                                   
                                  
                                        <div class="col-md-3">
                                            <asp:Button ID="Button_nex" runat="server" Text="Next" OnClick="Button_nex_Click" ValidateRequestMode="Disabled" />
                                   </div>

                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
                <fieldset id="third" style="display: none">
                    <h2 class="title">Details and Save</h2>
                    <p class="subtitle">Step 3/3</p>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>

                            <asp:Label ID="Label_result" runat="server" Text="Label"></asp:Label>
                            <br />
                            <p class="subtitle">Activities</p>

                            <asp:GridView CssClass="table-hover table" ID="GridView1" runat="server"></asp:GridView>
                            <asp:Button ID="Button2" runat="server" Text="Save" OnClick="Button2_Click" />
                            <asp:Button ID="Button3" runat="server" Text="Previous" OnClick="Button3_Click" />

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
            </div>
        </div>




    </div>
    
    
  













  
    
    
    
    
    
    

</asp:Content>
