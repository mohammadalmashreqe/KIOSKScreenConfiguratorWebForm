using System;
using System.Data;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BusinessLayer;

namespace KIOSKScreenConfiguratorWebForm
{
    public partial class Default : Page
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
                DataTable dt = Button.GetButtons();
                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        var h1 = new HtmlGenericControl("div");
                        h1.Attributes["class"] = "col-md-4";
                        DataTable da = PrintTicketType.GetPrintActivity(int.Parse(row["id"].ToString()));

                        string printAct = "<ul>";
                        foreach (DataRow act in da.Rows)
                        {
                            printAct += "<br><li> message : " + act["info_msg"] + "</li><li> Type : " +
                                        "Print Ticket Type" + "<br></li>";

                        }


                        DataTable da2 = ConfirmationActivity.GetConfirmationActivity(int.Parse(row["id"].ToString()));

                        foreach (DataRow act in da2.Rows)
                        {
                            printAct += "<hr><br><li> Message :" + act["info_msg"] + "</li><li> Type :" +
                                        "ConfirmationActivity" + "<br></li>";
                        }



                        DataTable da3 = RequestIdentification.GetRequestActivity(int.Parse(row["id"].ToString()));

                        foreach (DataRow act in da3.Rows)
                        {
                            printAct += "<hr><li> Message :" + act["info_msg"] + "</li><li>  Type :" +
                                        "Request Identification" + "<br></li>";
                        }

                        printAct += "</ul>";

                        string col =
                            "<button type = \"button\" class=\"btn btn-info\" style=\"background-color:#222\"  data-toggle=\"collapse\" data-target=\"#demo" +
                            i + "\">Activities</button>  <div id = \"demo" + i + "\" class=\"collapse \">" + printAct +
                            " </div>";



                        string html =
                            " <div style=\"border-style: solid; padding-left: 20px; \"> <div class=\"card-body\"> <h4 class=\"card-text\"><b >Name : " +
                            row["name"] + " </b></h4>  <h4>Order : " + row["order"] + "</h4> " + col +
                            "  <br> </div> <br> </div> <hr>";
                        h1.InnerHtml = html;
                        contentArea.Controls.Add(h1);


                        i += 1;
                    }
                }
                else
                {
                    var h1 = new HtmlGenericControl("div");
                    h1.Attributes["class"] = "col-md-8";
                    h1.InnerHtml = "<h4>dont have buttons in database yet add buttons from <a href=\"temppage.aspx\">here</a></h4>";
                    contentArea.Controls.Add(h1);

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