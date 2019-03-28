using System;
using System.Linq;
using System.Web.Hosting;
using System.Web.UI;
using BusinessLayer;

namespace KIOSKScreenConfiguratorWebForm
{
    public partial class Temppage : Page
    {
        private static  bool _isprint; 

       static  Button _b = new Button(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            try 
            {
                if (!IsPostBack)
                {
                    Panel1.Visible = true;
                    panel2.Visible = false;
                    panel3.Visible = false;
                
                    _b = new Button();
                    _isprint = false;
                }

            }
            catch (Exception ex)
            {
                string file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>next_step1()</script>",
                    false);
                _b.Name = TextBox_name.Text;
                _b.Order = int.Parse(TextBox_Order.Text);
            }
            catch (Exception ex)
            {
                string file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList_ActivityType.Text == "Print ticket type")
                {
                    Panel1.Visible = true;
                    panel2.Visible = false;
                    panel3.Visible = false;

                }
                else if (DropDownList_ActivityType.Text == "Request identification")
                {
                    Panel1.Visible = false;
                    panel2.Visible = true;
                    panel3.Visible = false;

                }
                else if (DropDownList_ActivityType.Text == "Confirmation activity")
                {
                    Panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = true;
                }
            }
            catch (Exception ex)
            {
                string file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void Button_nex_Click(object sender, EventArgs e)
        {
            try
            {


                if (_b.Activities.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm",
                        "<script> next_step2()</script>",
                        false);
                    string info = "Name : " + _b.Name + "<br>" +
                                  "Order : " + _b.Order + "<br>" +
                                  "# of activities : " + _b.Activities.Count + "<br>";


                    Label_result.Text = info;

                    var lis = from x in _b.Activities
                        select new {Information  = x.InformationMessage, x.Type};
                    GridView1.DataSource = lis;

                    GridView1.DataBind();


                }
                else
                {
                   
                    ScriptManager.RegisterStartupScript(Page, GetType(), "d", "<script>myFunction(\"please add one activity at least \")</script>",
                        false);


                }
            }
            catch (Exception ex)
            {
                string file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void Button_prev_Click(object sender, EventArgs e)
        {

            try
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "d", "<script>prev_step1()</script>",
                    false);
            }
            catch (Exception ex)
            {
                string file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }

        }

        protected void TextBox_name_TextChanged(object sender, EventArgs e)
        {
  
        }

        protected void TextBox_Order_TextChanged(object sender, EventArgs e)
        {
      
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>prev_step2()</script>",
                    false);
            }
            catch (Exception ex)
            {
                string file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                _b.AddButton();

                int id = _b.GetId();
                foreach (Activity t in _b.Activities)
                {
                    if (t.Type == ActivityTypeConst.PrintTicketType)
                    {
                        PrintTicketType temp = (PrintTicketType) t;
                        temp.AddPrintActivity(id);
                    }
                    else if (t.Type == ActivityTypeConst.ConfirmationActivity)
                    {
                        ConfirmationActivity temp = (ConfirmationActivity) t;
                        temp.AddConfirmationActivity(id);
                    }
                    else
                    {

                        RequestIdentification temp = (RequestIdentification) t;
                        temp.AddRequestActivity(id);
                    }
                }

                ScriptManager.RegisterStartupScript(Page, GetType(), "d", "<script>myFunction(\" Done ...\")</script>",
                    false);


                Response.Redirect("temppage.aspx");

            }
            catch (Exception ex)
            {
                string file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {

                if (_b.Activities.Count <= 5)
                {
                    if (!_isprint)
                    {



                        if (DropDownList_ActivityType.SelectedIndex == 0)
                        {
                            PrintTicketType printActivit = new PrintTicketType(TextBox_informationMessage.Text,
                                int.Parse(TextBox_numOftick.Text)) {Type = ActivityTypeConst.PrintTicketType};
                            _b.Activities.Add(printActivit);
                            _isprint = true;
                        }
                        else if (DropDownList_ActivityType.SelectedIndex == 1)
                        {
                            RequestIdentification requestActivity = new RequestIdentification(
                                TextBox_informationMessage.Text,
                                DropDownList_idenType.SelectedIndex == 0
                                    ? IdentificationType.Card
                                    : IdentificationType.Mobile,
                                CheckBox1.Checked) {Type = ActivityTypeConst.RequestIdentification};
                            _b.Activities.Add(requestActivity);
                        }
                        else
                        {
                            ConfirmationActivity confirmActivity = new ConfirmationActivity(
                                TextBox_informationMessage.Text,
                                int.Parse(TextBox_TimeOut.Text)) {Type = ActivityTypeConst.ConfirmationActivity};
                            _b.Activities.Add(confirmActivity);
                        }

                        DropDownList_ActivityType.SelectedIndex = 0;
                        TextBox_informationMessage.Text = "";
                        TextBox_numOftick.Text = "1";
                        TextBox_TimeOut.Text = "";
                        CheckBox1.Checked = false;
                        DropDownList_idenType.SelectedIndex = 0;
                        panel2.Visible = false;
                        Panel1.Visible = true;
                        panel3.Visible = false;



                       
                        ScriptManager.RegisterStartupScript(Page, GetType(), "d", "<script>myFunction(\" Activity Added...\")</script>",
                            false);

                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "d", "<script>myFunction(\" You cannot add activity after print tickets\")</script>",
                            false);
                   

                    }

                }
                else
                {
            
                    ScriptManager.RegisterStartupScript(Page, GetType(), "d", "<script>myFunction(\" You cannot add more than 5 Activities\")</script>",
                        false);



                }

            }
            catch (Exception ex)
            {
                string file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

    }
}