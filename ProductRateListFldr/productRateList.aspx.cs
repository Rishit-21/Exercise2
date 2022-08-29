using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Exercise2.ProductRateListFldr
{
    public partial class productRateList : System.Web.UI.Page
    {
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
                con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
            int id = Convert.ToInt32(gvr.Cells[0].Text);
            string proName = gvr.Cells[1].Text;

            if (e.CommandName == "Edi")
            {
                Response.Redirect("~/ProductRateListFldr/addProductRate.aspx?id=" + id + "&proName=" + proName);
            }
            else if (e.CommandName == "Del")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
                    SqlCommand scm = new SqlCommand("delete from productRate where productRateId=" + id + "",con);
                    con.Open();
                    scm.ExecuteNonQuery();
                    FillProdRate();
                }
                catch(Exception em)
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