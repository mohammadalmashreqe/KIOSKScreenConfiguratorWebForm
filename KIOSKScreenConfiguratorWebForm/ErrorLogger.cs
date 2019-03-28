using System;
using System.IO;

namespace KIOSKScreenConfiguratorWebForm
{
    /// <summary>
    /// class to write runTime errors to the file 
    /// </summary>
    public class ErrorLogger
    {
        private static string _sLogFormat;
        // ReSharper disable once NotAccessedField.Local
        private static string _sErrorTime;

        public static  void ErrorLog(string sPathName, string sErrMsg)
        { //sLogFormat used to create log files format :
            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            _sLogFormat = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " ==> ";

            //this variable used to create log filename format "
            //for example filename : ErrorLogYYYYMMDD
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            _sErrorTime = sYear + sMonth + sDay;
            StreamWriter sw = new StreamWriter(sPathName , true);
            sw.WriteLine(_sLogFormat + sErrMsg);
    
            sw.Flush();
            sw.Close();
        }
    }
}