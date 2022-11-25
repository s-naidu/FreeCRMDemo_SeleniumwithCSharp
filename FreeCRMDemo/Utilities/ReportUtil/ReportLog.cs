using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCRMDemo.Utilities.ReportUtil
{
    public class ReportLog
    {
        public static void Pass(string message)
        {
            ExtentTestManager.GetTest().Pass(message);
        }

        public static void Fail(string message,MediaEntityModelProvider media=null)
        {
            ExtentTestManager.GetTest().Fail(message,media);
        }

        public static void Skip(string message)
        {
            ExtentTestManager.GetTest().Skip(message);
        }
    }
}
