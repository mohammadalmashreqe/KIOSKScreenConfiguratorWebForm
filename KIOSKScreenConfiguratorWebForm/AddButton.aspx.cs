using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BusinessLayer;
using System.Web.Hosting;

namespace KIOSKScreenConfiguratorWebForm
{
    public partial class AddButton : System.Web.UI.Page
    {
        static BusinessLayer.Button button;
        static List<Confirmation_activity> mylis1 = new List<Confirmation_activity>();
        static List<Print_ticket_type> mylis2 = new List<Print_ticket_type>();
        static List<Request_identification> mylis3 = new List<Request_identification>();
        static bool isprint = false; 
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {if (!IsPostBack)
                {
                    GridView1.DataSource = BusinessLayer.Button.getButtons();
                    GridView1.DataBind();
                    button = new BusinessLayer.Button();
                    Panel1.Visible = true;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    Button1.Enabled = false;
                    Button1.Text = "Add Activity" + button.getList().Count + "/5";
                    Button_save.Enabled = false;
                    isprint = false;

                }
               
            }
            catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }

        }

        protected void Button_add_Click(object sender, EventArgs e)
        {


            try
            {

                string name;
                string text;
                int order;

                name = TextBox_name.Text;
                text = TextBox_text.Text;

                order = int.Parse(TextBox_order.Text);

                

                button.Text = text;
                button.Order = order;
                button.ButtonName = name;

                Button1.Enabled = true; 
                //button.AddButton();
                //GridView1.DataSource = BusinessLayer.Button.getButtons();
                //GridView1.DataBind();
            }
            catch(Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
           


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
          
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
              
            
        

        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList1.Text == "Print ticket type")
                {
                    Panel1.Visible = true;
                    panel2.Visible = false;
                    panel3.Visible = false;

                }
                else
                      if (DropDownList1.Text == "Request identification")
                {
                    Panel1.Visible = false;
                    panel2.Visible = true;
                    panel3.Visible = false;

                }
                else
                      if (DropDownList1.Text == "Confirmation activity")
                {
                    Panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = true;
                }
            }
            catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {try
            {
                if (!isprint)
                {

                    if (DropDownList1.SelectedIndex == 0)
                    {
                        string m = TextBox_Info_message.Text;
                        string n = TextBox1.Text;

                        Print_ticket_type a = new Print_ticket_type(m, int.Parse(n));

                        if (button.addActivity(a))
                        {
                            mylis2.Add(a);
                            Button1.Text = "Add Activity" + button.getList().Count + "/5";
                            ListBox1.Items.Add(m);
                            ListBox1.DataBind();
                            Button_save.Enabled = true;
                            isprint = true;
                        }
                        else
                            Label1.Text = "cannot added this activity ";


                    }
                    else
                        if (DropDownList1.SelectedIndex == 1)
                    {
                        Identification_type r;
                        string m = TextBox_Info_message.Text;
                        if (DropDownList2.SelectedIndex == 0)
                            r = Identification_type.card;
                        else
                            r = Identification_type.mobile;


                        Request_identification a = new Request_identification(m, r, CheckBox1.Checked);
                        if (button.addActivity(a))
                        {
                            mylis3.Add(a);
                            Button1.Text = "Add Activity" + button.getList().Count + "/5";
                            ListBox1.Items.Add(m);
                            ListBox1.DataBind();
                            Button_save.Enabled = true;
                        }
                        else
                            Label1.Text = "cannot added this activity ";


                    }
                    else
                    {
                        Confirmation_activity a = new Confirmation_activity(TextBox_Info_message.Text, int.Parse(TextBox_TimeOut.Text));
                        if (button.addActivity(a))
                        {
                            mylis1.Add(a);
                            Button1.Text = "Add Activity" + button.getList().Count + "/5";
                            ListBox1.Items.Add(a.Information_message);
                            ListBox1.DataBind();
                            Button_save.Enabled = true;
                        }
                        else
                        {
                            Label1.Text = "cannot added this activity ";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                else
                {
                    Label1.Text = "cannot added  activity after print ticket ";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
                
            }
            catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void ListBox1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //if(ListBox1.SelectedIndex==0||ListBox1.SelectedIndex==1||ListBox1.SelectedIndex==2)
            //{///function to delete activity 

            ////    Button2.Visible = true; 


            ////}
            ////else
            ////{
            ////    Button2.Visible = false; 


            //}

        }

        protected void Button_save_Click(object sender, EventArgs e)
        {

            try { 
            button.AddButton();
            int i = button.GetId();

            foreach (Confirmation_activity item in mylis1)
                item.AddconActivity(i);

            foreach (Request_identification item in mylis3)
                item.AddRequestActivity(i);

            foreach (Print_ticket_type item in mylis2)
                item.AddPrintActivity(i);

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" +"Button with activity  saved');", true);

                GridView1.DataSource = BusinessLayer.Button.getButtons();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                
                    String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                    ErrorLogger.ErrorLog(file, ex.Message);
                
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}