using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KIOSKScreenConfiguratorWebForm
{
    public partial class EditButton : System.Web.UI.Page
    {
        /// <summary>
        /// load data and bind it in grid view 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = BusinessLayer.Button.getButtons();
          
            GridView1.DataBind();
            
          
        }
        /// <summary>
        /// event to add event listner to each row in grid view to be selectable 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";

               
            }
        }
        /// <summary>
        /// add event to grid view to redirct to anthor form to edit selected button  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                        Response.Cookies["ButtonInfo"]["Text"] = row.Cells[2].Text;
                        Response.Cookies["ButtonInfo"]["Name"] = row.Cells[1].Text;
                        Response.Cookies["ButtonInfo"]["Order"] = row.Cells[3].Text;
                        Response.Cookies["ButtonInfo"]["id"] = row.Cells[0].Text;


                        Response.Redirect("EditSelectedButton.aspx");





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
                if (e.Row.RowType == DataControlRowType.Header )
                    e.Row.CssClass = "table-primary";

                //Add CSS class on normal row.
                if (e.Row.RowType == DataControlRowType.DataRow &&
                          e.Row.RowState == DataControlRowState.Normal)
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
    }
}