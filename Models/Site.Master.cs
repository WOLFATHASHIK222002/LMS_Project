using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_project.Models
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string SetActiveClass(string pageName)
        {

            string activeClass = string.Empty;
            // Check if the current page matches the pageName, and if so, set the "active" class
            if (Request.Url.AbsolutePath.Contains(pageName))
            {
                activeClass = "active";
            }
            return activeClass;
        }



    }
}