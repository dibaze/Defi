using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CalculatriceDEF;

namespace CalculatriceGraphique
{
    public partial class PagePrincipale : System.Web.UI.Page
    {
        ServiceCalculatrice sc;
        protected void Page_Load(object sender, EventArgs e)
        {
            sc = new ServiceCalculatrice();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox3.Text = sc.Calculer(TextBox2.Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
    }
}