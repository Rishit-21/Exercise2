using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Exercise2
{
    public partial class Party : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            FillData();
            }
           
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
            int id = Convert.ToInt32(gvr.Cells[0].Text);
            string name = gvr.Cells[1].Text;


            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/Party/AddParty.aspx?id="+id+"&name="+name);
                
            }
            else if (e.CommandName == "Del")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
                    string query = "delete from party where id="+id+"";
                    SqlCommand scm = new SqlCommand(query, con);
                    con.Open();
                    scm.ExecuteNonQuery();
                    //GridView1.DataBind();
                    FillData();
                }
                catch(Exception em)
                {
                    PartyMsgLbl.Text = em.Message;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    
        protected void FillData()
    {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
                SqlDataAdapter sde = new SqlDataAdapter("Select*from party", con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                con.Open();
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