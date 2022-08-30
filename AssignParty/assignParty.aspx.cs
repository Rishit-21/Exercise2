using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Exercise2.Assign_Party
{
    public partial class assignParty : System.Web.UI.Page
    {
        public string CS = ConfigurationManager.ConnectionStrings["partyProduct"].ConnectionString;
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
                    con = new SqlConnection(CS);
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
              
            }
            else if (e.CommandName == "Del")
            {
            }
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[0].Text);
            string partyName = GridView1.Rows[rowIndex].Cells[1].Text;
            string productName = GridView1.Rows[rowIndex].Cells[2].Text;
            Response.Write("done");
            Response.Redirect("~/AssignParty/AddAssign.aspx?id=" + id + "&paName=" + partyName + "&prName=" + productName);
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[0].Text);
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(CS);
                SqlCommand scm = new SqlCommand("delete from assignProduct where assignId=" + id, con);
                con.Open();
                scm.ExecuteNonQuery();
                FillAssignData();

            }
            catch (Exception em)
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