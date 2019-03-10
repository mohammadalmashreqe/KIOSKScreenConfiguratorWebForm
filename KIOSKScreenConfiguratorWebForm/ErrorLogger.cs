﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace KIOSKScreenConfiguratorWebForm
{
    /// <summary>
    /// class to write runTime errors to the file 
    /// </summary>
    public class ErrorLogger
    {
        private static string sLogFormat;
        private static string sErrorTime;

        public  ErrorLogger()
        {
           
        }
        public static  void ErrorLog(string sPathName, string sErrMsg)
        { //sLogFormat used to create log files format :
            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

            //this variable used to create log filename format "
            //for example filename : ErrorLogYYYYMMDD
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sErrorTime = sYear + sMonth + sDay;
            StreamWriter sw = new StreamWriter(sPathName , true);
            sw.WriteLine(sLogFormat + sErrMsg);
    
            sw.Flush();
            sw.Close();
        }
    }
}