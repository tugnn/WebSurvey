using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSurvey
{
    public partial class Home : System.Web.UI.MasterPage
    {
        DataClasses1DataContext dt = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}