using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCRMDemo.Utilities
{
    public class Utility
    {
        public static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split("bin")[0];
        }
    }
}
