using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDialUp.Data
{
    public class Version
    {
        public string SoftwareName { get; set; }
        public double VersionNumber { get; set; }
        public string ProjectPageUrl { get; set; }
        public string OpenSourceUrl { get; set; }

        public Version()
        {
            SoftwareName = "易拨 - 自动拨号上网";
            VersionNumber = 1.3;
            ProjectPageUrl = @"https://xn--e-5g8az75bbi3a.com/%E9%A1%B9%E7%9B%AE%E5%8F%91%E5%B8%83/10.html";
            OpenSourceUrl = @"https://github.com/EJianZQ/AutoDialUp";
        }
    }
}
