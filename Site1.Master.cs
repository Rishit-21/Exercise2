using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercise2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String activepage = Request.RawUrl; 
            if (activepage.StartsWith("/Party"))
            {
                partyTb.ForeColor = System.Drawing.Color.White;
            }
            else if (activepage.StartsWith("/ProductRateListFldr"))
            {
                prouctTb.ForeColor = System.Drawing.Color.White;
            }
            else if (activepage.StartsWith("/Product"))
            {
                productsTb.ForeColor = System.Drawing.Color.White;
            }
            else if (activepage.StartsWith("/AssignParty"))
            {
                assignPartyTb.ForeColor = System.Drawing.Color.White;

            }
            else if (activepage.StartsWith("/Invoice"))
            {
                invoiceTb.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}