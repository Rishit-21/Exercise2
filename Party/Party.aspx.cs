using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;


namespace Exercise2
{
    public partial class Party : System.Web.UI.Page
    {
        public string CS = ConfigurationManager.ConnectionStrings["partyProduct"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillData();
            }

        }



        protected void FillData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(CS);
                //SqlDataAdapter sde = new SqlDataAdapter("Select*from party", con);
                //DataSet ds = new DataSet();
                //sde.Fill(ds);
                //GridView1.DataSource = ds;
                //GridView1.DataBind();
                //con.Open();
                SqlCommand scm = new SqlCommand("Select * from party", con);
                con.Open();
                SqlDataReader sdr = scm.ExecuteReader();
                GridView1.DataSource = sdr;
                GridView1.DataBind();
            }
            catch (Exception em)
            {
                PartyMsgLbl.Text = em.Message;
            }
            finally
            {
                con.Close();
            }
        }



        protected void edit_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[0].Text);
            string name = GridView1.Rows[rowIndex].Cells[1].Text;
            Response.Redirect("~/Party/AddParty.aspx?id=" + id + "&name=" + name);
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[0].Text);
            SqlConnection con = null;
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                try
                {
                    con = new SqlConnection(CS);
                    string query = "delete from party where id=" + id + "";
                    SqlCommand scm = new SqlCommand(query, con);
                    con.Open();
                    scm.ExecuteNonQuery();
                    //GridView1.DataBind();
                    FillData();
                }
                catch (Exception em)
                {
                    PartyMsgLbl.Text = em.Message;
                }
                finally
                {
                    con.Close();
                }
            }

        }
    }
}