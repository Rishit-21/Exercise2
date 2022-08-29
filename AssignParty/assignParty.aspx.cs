using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Exercise2.Assign_Party
{
    public partial class assignParty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            FillAssignData();
            }
        }
        protected void FillAssignData()
        {
           
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
                    SqlDataAdapter sde = new SqlDataAdapter("select assignId, partyName,productName from assignProduct ap, party pa, product pr where pa.id = ap.partyId and pr.id = ap.productid; ", con);
                    DataSet ds = new DataSet();
                    sde.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    con.Open();
                }
                catch (Exception em)
                {
                AssignPartyMsg.Text = em.Message;
                }
                finally
                {
                    con.Close();
                }
           
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow grv = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
            int id = Convert.ToInt32(grv.Cells[0].Text);
            string partyName = grv.Cells[1].Text;
            string productName = grv.Cells[2].Text;
            if (e.CommandName == "Edi")
            {
                Response.Write("done");
            Response.Redirect("~/AssignParty/AddAssign.aspx?id=" + id + "&paName=" + partyName + "&prName=" + productName);
            }
            else if (e.CommandName == "Del")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
                    SqlCommand scm = new SqlCommand("delete from assignProduct where assignId=" + id, con);
                    con.Open();
                    scm.ExecuteNonQuery();
                    FillAssignData();

                }
                catch(Exception em)
                {
                    Response.Write(em.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

      
    }
}