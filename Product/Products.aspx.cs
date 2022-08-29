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
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            FillProducts();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
            int id = Convert.ToInt32( gvr.Cells[0].Text);
            string pName = gvr.Cells[1].Text;
            if (e.CommandName== "Edit")
            {
                Response.Redirect("~/Product/AddProducts.aspx?id=" + id + "&name=" + pName);
            }
            else if (e.CommandName == "Del")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
                    SqlCommand scm = new SqlCommand("delete from product where id =" + id + "",con);
                    con.Open();
                    scm.ExecuteNonQuery();
                    FillProducts();

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
        protected void FillProducts()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
                SqlDataAdapter sde = new SqlDataAdapter("Select*from product", con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                con.Open();
            }
            catch (Exception em)
            {
                ProductlistMsgLbl.Text = em.Message;
            }
            finally
            {
                con.Close();
            }
        }

        
    }
}