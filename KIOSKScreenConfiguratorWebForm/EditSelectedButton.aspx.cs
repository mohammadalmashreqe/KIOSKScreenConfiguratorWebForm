using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace KIOSKScreenConfiguratorWebForm
{
    public partial class EditSelectedButton : Page
    {
        readonly List<Activity> _mylist = new List<Activity>();
         private static  PrintTicketType _curPr;
         private static  ConfirmationActivity _curCon;
        private  static RequestIdentification _curIde;
        /// <summary>
        /// // display the info of selected button to update it 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Request.Cookies.AllKeys.Contains("ButtonInfo"))
                {
                    Response.Redirect("EditButton.aspx");
                }
                else
                {
                    if (!IsPostBack)
                    {

                        TextBox_name.Text = Request.Cookies["ButtonInfo"]["Name"];
                        TextBox_order.Text = Request.Cookies["ButtonInfo"]["Order"];

                   

                    }
                    Button5.Visible = false;

                    int id = int.Parse(Request.Cookies["ButtonInfo"]["id"]);
                    DataTable dt = RequestIdentification.GetRequestActivity(id);
                    foreach (DataRow t in dt.Rows)
                    {


                        RequestIdentification r = new RequestIdentification(t["info_msg"].ToString(),
                            t["Identification_type"].ToString() == "card"
                                ? IdentificationType.Card
                                : IdentificationType.Mobile, bool.Parse(t["Is_mandatory"].ToString()))
                        {
                            Type = "Request Identification", Id = int.Parse(t["ID"].ToString())
                        };

                        _mylist.Add(r);


                    }

                    dt = PrintTicketType.GetPrintActivity(id);

                    foreach (DataRow t in dt.Rows)
                    {
                        PrintTicketType r = new PrintTicketType(t["info_msg"].ToString(),
                            int.Parse(t["num_of_tick"].ToString()))
                        {
                            Type = ActivityTypeConst.PrintTicketType, Id = int.Parse(t["ID"].ToString())
                        };
                        _mylist.Add(r);


                    }

                    dt = ConfirmationActivity.GetConfirmationActivity(id);


                    foreach (DataRow t in dt.Rows)
                    {
                        ConfirmationActivity r = new ConfirmationActivity(t["info_msg"].ToString(),
                            int.Parse(t["timeOutInSec"].ToString()))
                        {
                            Type = ActivityTypeConst.ConfirmationActivity, Id = int.Parse(t["ID"].ToString())
                        };
                        _mylist.Add(r);


                    }

                    var res = from temp in _mylist
                              select new { Information = temp.InformationMessage, temp.Type };

                    GridView1.DataSource = null;
                    GridView1.DataSource = res;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowIndex == GridView1.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;



                        Button5.Visible = true;



                        if (GridView1.SelectedRow.Cells[1].Text == ActivityTypeConst.ConfirmationActivity)
                        {
                            foreach (Activity t in _mylist)
                            {
                                if (t.InformationMessage == GridView1.SelectedRow.Cells[0].Text)
                                {
                                    _curCon = (ConfirmationActivity) t;
                                    break; 
                                }

                            }
                        }
                        else
                        if (GridView1.SelectedRow.Cells[1].Text == ActivityTypeConst.PrintTicketType)
                        {
                            foreach (Activity t in _mylist)
                            {
                                if (t.InformationMessage == GridView1.SelectedRow.Cells[0].Text)
                                {
                                    _curPr = (PrintTicketType)t;
                                    break;
                                }

                            }
                        }
                        else
                        if (GridView1.SelectedRow.Cells[1].Text == ActivityTypeConst.RequestIdentification)
                        {
                            foreach (Activity t in _mylist)
                            {
                                if (t.InformationMessage == GridView1.SelectedRow.Cells[0].Text)
                                {
                                    _curIde = (RequestIdentification)t;
                                    break;
                                }

                            }
                        }




                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = "Click to select this row.";
                    }



                }
            }
            catch (Exception ex)
            {
                string file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                    e.Row.CssClass = "table-primary";

                //Add CSS class on normal row.
                if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                    e.Row.CssClass = "table-hover";

                //Add CSS class on alternate row.
                if (e.Row.RowType == DataControlRowType.DataRow &&
                          e.Row.RowState == DataControlRowState.Alternate)
                    e.Row.CssClass = "table-hover";
            }
            catch (Exception ex)
            {
               string file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }
        /// <summary>
        /// make  grid view selectable 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                    e.Row.ToolTip = "Click to select this row.";


                }
            }
            catch (Exception ex)
            {
                string file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        /// <summary>
        /// delete button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.Button b = new BusinessLayer.Button
                {
                    Id = int.Parse(Request.Cookies["ButtonInfo"]["id"])
                };


                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    if (b.DeleteButton())
                    {
                        Request.Cookies.Remove("ButtonInfo");

                        Request.Cookies.Clear();
                        Session.Abandon();

                        Response.Cookies.Clear();
                        Response.Redirect("EditButton.aspx");
                    }
                }




            }
            catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void Button_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.Cookies["ButtonInfo"]["id"]);


                string name = TextBox_name.Text;
                string order = TextBox_order.Text;


                BusinessLayer.Button b = new BusinessLayer.Button
                {
                    Name = name,
                    Order = int.Parse(order),
                    Id = id
                };


                if (b.UpdateButton())
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "d", "<script>myFunction(\" Button Updated ...\")</script>",
                        false);
                    TextBox_name.Text = name;
                    TextBox_order.Text = order;

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                string file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {

                GridViewRow row = GridView1.SelectedRow;
                string infoMsg = row.Cells[0].Text;
                string type = row.Cells[1].Text;

                TextBox_infoMsg.Value = infoMsg;
                if (type == ActivityTypeConst.PrintTicketType)
                {
                    panel_print.Visible = true;
                    panel_confirm.Visible = false;
                    panel_request.Visible = false;

                    TextBox_type.Value = ActivityTypeConst.PrintTicketType;
                    foreach (Activity t in _mylist)
                    {
                        if (t.InformationMessage == infoMsg)
                        {
                            PrintTicketType tempObj = (PrintTicketType) t;
                            TextBox_numoftick.Value = tempObj.NumOfPrintedTickets.ToString();
                            _curPr = tempObj;
                            break;

                        }
                    }


                }
                else if (type == ActivityTypeConst.ConfirmationActivity)
                {
                    panel_print.Visible = false;
                    panel_confirm.Visible = true;
                    panel_request.Visible = false;
                    TextBox_type.Value = ActivityTypeConst.ConfirmationActivity;

                    foreach (Activity t in _mylist)
                    {
                        if (t.InformationMessage == infoMsg)
                        {
                            ConfirmationActivity tempObj = (ConfirmationActivity) t;
                            TextBox_Timeout.Value = tempObj.Timeout.ToString();
                            _curCon = tempObj;
                            break;


                        }
                    }


                }
                else
                {
                    panel_print.Visible = false;
                    panel_confirm.Visible = false;
                    panel_request.Visible = true;
                    TextBox_type.Value = ActivityTypeConst.RequestIdentification;
                    foreach (Activity t in _mylist)
                    {
                        if (t.InformationMessage == infoMsg)
                        {
                            RequestIdentification tempObj = (RequestIdentification) t;
                            _curIde = tempObj;
                            DropDownList1.SelectedIndex = tempObj.IdType == IdentificationType.Card ? 0 : 1;

                            CheckBox1.Checked = tempObj.IsMandatory;
                            break;


                        }
                    }

                }

                ScriptManager.RegisterStartupScript(Page, GetType(), "d", "<script> openForm() </script>",
                    false);
            }
            catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                string info = TextBox_infoMsg.Value;

            if (TextBox_type.Value == ActivityTypeConst.PrintTicketType)
            {
                string numofprinttick = TextBox_numoftick.Value;
                _curPr.InformationMessage = info;
                _curPr.NumOfPrintedTickets = int.Parse(numofprinttick);
                _curPr.UpdateActivity();
            }
            else if (TextBox_type.Value == ActivityTypeConst.ConfirmationActivity)
            {
                string timo = TextBox_Timeout.Value;

                _curCon.Timeout = int.Parse(timo);
                _curCon.InformationMessage = info;
                _curCon.UpdateActivity();
               

            }
            else
            {

                bool ismand = CheckBox1.Checked;
                IdentificationType idt = DropDownList1.SelectedIndex == 0 ? IdentificationType.Card : IdentificationType.Mobile;

                _curIde.InformationMessage = info;
                _curIde.IsMandatory = ismand;
                _curIde.IdType = idt; 


            }


          
                _mylist.Clear();
                if (!Request.Cookies.AllKeys.Contains("ButtonInfo"))
                {
                    Response.Redirect("EditButton.aspx");
                }
                else
                {
                    if (!IsPostBack)
                    {

                        TextBox_name.Text = Request.Cookies["ButtonInfo"]["Name"];
                        TextBox_order.Text = Request.Cookies["ButtonInfo"]["Order"];



                    }
                  
                    Button5.Visible = false;

                    int id = int.Parse(Request.Cookies["ButtonInfo"]["id"]);
                    DataTable dt = RequestIdentification.GetRequestActivity(id);
                    foreach (DataRow t in dt.Rows)
                    {


                        RequestIdentification r = new RequestIdentification(t["info_msg"].ToString(),
                            t["Identification_type"].ToString() == "card"
                                ? IdentificationType.Card
                                : IdentificationType.Mobile, bool.Parse(t["Is_mandatory"].ToString()))
                        {
                            Type = "Request Identification", Id = int.Parse(t["ID"].ToString())
                        };

                        _mylist.Add(r);


                    }

                    dt = PrintTicketType.GetPrintActivity(id);

                    foreach (DataRow t in dt.Rows)
                    {
                        PrintTicketType r = new PrintTicketType(t["info_msg"].ToString(),
                            int.Parse(t["num_of_tick"].ToString()))
                        {
                            Type = ActivityTypeConst.PrintTicketType, Id = int.Parse(t["ID"].ToString())
                        };
                        _mylist.Add(r);


                    }

                    dt = ConfirmationActivity.GetConfirmationActivity(id);


                    foreach (DataRow t in dt.Rows)
                    {
                        ConfirmationActivity r = new ConfirmationActivity(t["info_msg"].ToString(),
                            int.Parse(t["timeOutInSec"].ToString()))
                        {
                            Type = ActivityTypeConst.ConfirmationActivity, Id = int.Parse(t["ID"].ToString())
                        };
                        _mylist.Add(r);


                    }

                    var res = from temp in _mylist
                              select new { Information = temp.InformationMessage, temp.Type };

                    GridView1.DataSource = null;
                    GridView1.DataSource = res;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

        protected void Button3_deleteAct_Click(object sender, EventArgs e)
        {
            try
            {
                
                int id = int.Parse(Request.Cookies["ButtonInfo"]["id"]);
           

                    if (TextBox_type.Value == ActivityTypeConst.PrintTicketType)
                        PrintTicketType.DeleteActivity(_curPr.Id + "");
                    else if (TextBox_type.Value == ActivityTypeConst.ConfirmationActivity)
                    {
                        ConfirmationActivity.DeleteActivity(_curCon.Id + "");


                    }
                    else
                    {
                        RequestIdentification.DeleteActivity(_curIde.Id + "");
                    }





                _mylist.Clear();
                if (!Request.Cookies.AllKeys.Contains("ButtonInfo"))
                {
                    Response.Redirect("EditButton.aspx");
                }
                else
                {
                    if (!IsPostBack)
                    {

                        TextBox_name.Text = Request.Cookies["ButtonInfo"]["Name"];
                        TextBox_order.Text = Request.Cookies["ButtonInfo"]["Order"];



                    }
           
                    Button5.Visible = false;

                  
                    DataTable dt = RequestIdentification.GetRequestActivity(id);
                    foreach (DataRow t in dt.Rows)
                    {


                        RequestIdentification r = new RequestIdentification(t["info_msg"].ToString(),
                            t["Identification_type"].ToString() == "card"
                                ? IdentificationType.Card
                                : IdentificationType.Mobile, bool.Parse(t["Is_mandatory"].ToString()))
                        {
                            Type = "Request Identification", Id = int.Parse(t["ID"].ToString())
                        };

                        _mylist.Add(r);


                    }

                    dt = PrintTicketType.GetPrintActivity(id);

                    foreach (DataRow t in dt.Rows)
                    {
                        PrintTicketType r = new PrintTicketType(t["info_msg"].ToString(),
                            int.Parse(t["num_of_tick"].ToString()))
                        {
                            Type = ActivityTypeConst.PrintTicketType, Id = int.Parse(t["ID"].ToString())
                        };
                        _mylist.Add(r);


                    }

                    dt = ConfirmationActivity.GetConfirmationActivity(id);


                    foreach (DataRow t in dt.Rows)
                    {
                        ConfirmationActivity r = new ConfirmationActivity(t["info_msg"].ToString(),
                            int.Parse(t["timeOutInSec"].ToString()))
                        {
                            Type = ActivityTypeConst.ConfirmationActivity, Id = int.Parse(t["ID"].ToString())
                        };
                        _mylist.Add(r);


                    }

                    var res = from temp in _mylist
                              select new { Information = temp.InformationMessage, temp.Type };

                    GridView1.DataSource = null;
                    GridView1.DataSource = res;
                    GridView1.DataBind();
                }




            }
            catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }

        }
    }
}