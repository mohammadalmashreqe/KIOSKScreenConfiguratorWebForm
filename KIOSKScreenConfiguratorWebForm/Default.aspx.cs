using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using Button = System.Web.UI.WebControls.Button;

namespace KIOSKScreenConfiguratorWebForm
{
    public partial class _Default : Page
    {

        /// <summary>
        /// load all buttons from database and display its at the screen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = BusinessLayer.Button.getButtons();
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {





                    string id = row["id"].ToString();



                    var h1 = new HtmlGenericControl("div");
                    h1.Attributes["class"]= "col-sm-5";
                    DataTable da = Print_ticket_type.getPrintActivity(int.Parse(row["id"].ToString()));

                    string printAct = "<ul>";
                    foreach (DataRow Act in da.Rows)
                    {
                        printAct += "<br><li> message : " + Act["info_msg"] + "</li><li> number of tickits : " + Act["num_of_tick"] + "</li>";
                    }
                    printAct += "</ul>";

                    string confAct = "<ul>";

                    DataTable da2 = Confirmation_activity.getConActivity(int.Parse(row["id"].ToString()));

                    foreach (DataRow Act in da2.Rows)
                    {
                        confAct += "<br><li> message :" + Act["info_msg"] + "</li><li> Time out in second :" + Act["timeOutInSec"] + "<hr></li>";
                    }

                    confAct += "</ul>";


                    DataTable da3 = Request_identification.getRequestActivity(int.Parse(row["id"].ToString()));

                    string IdentAct = "<ul>";

                    foreach (DataRow Act in da3.Rows)
                    {
                        IdentAct += "<br><li> message :" + Act["info_msg"] + "</li><li> Identificationtype :" + Act["Identification_type"] + "</li>" + "<li> Is_mandatory " + Act["Is_mandatory"] + "<hr> </li>";
                    }
                    IdentAct += "</ul>";
                
                    string col = "<button type = \"button\" class=\"btn btn-info\" data-toggle=\"collapse\" data-target=\"#demo" + i + "\">Print ticket type</button>  <div id = \"demo" + i + "\" class=\"collapse \">" + printAct + " </div>";

                    string col2 = "<button type = \"button\" class=\"btn btn-info\" data-toggle=\"collapse\" data-target=\"#demo" + (i + 1) + "\">Confirmation Activity</button>  <div id = \"demo" + (i + 1) + "\" class=\"collapse \">" + confAct + " </div>";

                    string col3 = "<button type = \"button\" class=\"btn btn-info\" data-toggle=\"collapse\" data-target=\"#demo" + (i + 2) + "\">Request identification</button>  <div id = \"demo" + (i + 2) + "\" class=\"collapse \">" + IdentAct + " </div>";

                    string html = " <div class=\"\"> <div class=\"card-body\"> <h4 class=\"card-text\"><b >name : " + row["name"].ToString() + " </b></h4>  <p>Order : " + row["order"] + "</p> " + col + "" + "" + col2 + "" + " " + col3 + "  <br> </div> <br> </div> <hr>";
                    h1.InnerHtml = html;
                    contentArea.Controls.Add(h1);


                    i += 3;
                }
            }
            catch (Exception ex)
            {
                String file = HostingEnvironment.MapPath(@"/App_Data/LogFile.txt");
                ErrorLogger.ErrorLog(file, ex.Message);
            }


        }

        protected void GridView_buttonList_RowCreated(object sender, GridViewRowEventArgs e)
        {
      

        }

        protected void GridView_buttonList_RowCommand(object sender, GridViewCommandEventArgs e)
        { 

        }

        protected void GridView_buttonList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}