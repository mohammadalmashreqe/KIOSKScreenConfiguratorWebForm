using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies == null)
                    Response.Write("please select Button");
                else
                {
                    TextBox_text.Text = Request.Cookies["ButtonInfo"]["Text"].ToString();
                    TextBox_name.Text = Request.Cookies["ButtonInfo"]["Name"].ToString();
                    TextBox_order.Text = Request.Cookies["ButtonInfo"]["Order"].ToString();
                    if (!IsPostBack)
                        Button4.Visible = false;

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
                        Response.Redirect("EditButton.aspx");
                }




            }
            catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }
        }

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
    }
}