using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Exercise2.ProductRateListFldr
{
    public partial class productRateList : System.Web.UI.Page
    {
        public string CS = ConfigurationManager.ConnectionStrings["partyProduct"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillProdRate();
            }
        }
        protected void FillProdRate()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(CS);
                SqlDataAdapter sde = new SqlDataAdapter("select productRateId, productName,rate,Format(dateOfRate,'dd-MM-yyyy') as dateOfRate from product pr,productRate ra where pr.id=ra.productId; ", con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                con.Open();
            }
            catch (Exception em)
            {
                Label1.Text = em.Message;
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
            string proName = GridView1.Rows[rowIndex].Cells[1].Text;
            Response.Redirect("~/ProductRateListFldr/addProductRate.aspx?id=" + id + "&proName=" + proName);
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
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
                    SqlCommand scm = new SqlCommand("delete from productRate where productRateId=" + id + "", con);
                    con.Open();
                    scm.ExecuteNonQuery();
                    FillProdRate();
                }
                catch (Exception em)
                {
                    Label1.Text = em.Message;
                }
                finally
                {
                    con.Close();
                }

            }
        }
    }
}