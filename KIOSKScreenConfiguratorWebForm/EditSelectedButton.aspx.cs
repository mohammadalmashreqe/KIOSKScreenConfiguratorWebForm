﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace KIOSKScreenConfiguratorWebForm
{
    public partial class EditSelectedButton : System.Web.UI.Page
    {
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
                {  if (!IsPostBack)
                    {
                        TextBox_text.Text = Request.Cookies["ButtonInfo"]["Text"].ToString();
                        TextBox_name.Text = Request.Cookies["ButtonInfo"]["Name"].ToString();
                        TextBox_order.Text = Request.Cookies["ButtonInfo"]["Order"].ToString();

                        Button4.Visible = false;
                    }

                }
            }
            catch(Exception ex)
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


                        Button4.Visible = true;







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
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
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
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
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
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }
        /// <summary>
        /// load activity 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.Cookies["ButtonInfo"]["id"].ToString());
                GridView1.DataSource = Print_ticket_type.getPrintActivity(id);
                GridView1.DataBind();

            }
           catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }
        /// <summary>
        /// load activity 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.Cookies["ButtonInfo"]["id"].ToString());
                GridView1.DataSource = Request_identification.getRequestActivity(id);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }

        }
        /// <summary>
        /// load activity 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.Cookies["ButtonInfo"]["id"].ToString());
                GridView1.DataSource = Confirmation_activity.getConActivity(id);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
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
                BusinessLayer.Button b = new BusinessLayer.Button();
                b.ID1 = int.Parse(Request.Cookies["ButtonInfo"]["id"].ToString());


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
        /// <summary>
        /// delete activity 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.Cookies["ButtonInfo"]["id"].ToString());

                string r = GridView1.SelectedRow.Cells[0].Text;
                Confirmation_activity.deleteActivity(GridView1.SelectedRow.Cells[0].Text);
               
                GridView1.DataSource = Confirmation_activity.getConActivity(id);
                GridView1.DataBind();
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
                int id = int.Parse(Request.Cookies["ButtonInfo"]["id"].ToString());


                string name = TextBox_name.Text;
                string order = TextBox_order.Text;
                string text = TextBox_text.Text;

                BusinessLayer.Button b = new BusinessLayer.Button();
                b.ButtonName = name;
                b.Order = int.Parse(order);
                b.Text = text;

                b.ID1 = id;

                if(b.updatButton())
                {
                    Response.Write("<script> alert ('button updated'); </script>");
                    TextBox_name.Text = name;
                    TextBox_order.Text = order;
                    TextBox_text.Text = text;
                }
                else
                {

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