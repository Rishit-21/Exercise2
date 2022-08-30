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
    public partial class Products : System.Web.UI.Page
    {
        public string CS = ConfigurationManager.ConnectionStrings["partyProduct"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            FillProducts();
            }
        }
    
        protected void FillProducts()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(CS);
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

        protected void editBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[0].Text);
            string pName = GridView1.Rows[rowIndex].Cells[1].Text;
            Response.Redirect("~/Product/AddProducts.aspx?id=" + id + "&name=" + pName);
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
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
                SqlCommand scm = new SqlCommand("delete from product where id =" + id + "", con);
                con.Open();
                scm.ExecuteNonQuery();
                FillProducts();

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