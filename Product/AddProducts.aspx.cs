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
    public partial class AddProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ProductAdd.Text = "Edit Product";
                    var name = Request.QueryString["name"];
                    addProductTxt.Text = name;
                    saveBtnId.Visible = false;
                    UpdateBtnId.Visible = true;          
                }
            }
        }

        protected void saveBtnId_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
                SqlCommand scm = new SqlCommand("Select productName from product where productName='" + addProductTxt.Text + "'", con);
                con.Open();
                SqlDataReader sdr = scm.ExecuteReader();
                sdr.Read();

                if (sdr["productName"].ToString() != null)
                {
                    ProductAddMsg.Text = "Product Name is repeated";
                    ProductAddMsg.ForeColor = System.Drawing.Color.Red;
                }




                
            }
            catch 
            {
                try
                {
                    con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
                    SqlCommand scm = new SqlCommand("insert into product(productName) values('" + addProductTxt.Text + "')", con);
                    con.Open();
                    scm.ExecuteNonQuery();
                    ProductAddMsg.Text = "Added Succesfully";
                    ProductAddMsg.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception em)
                {
                ProductAddMsg.Text = em.Message;
                ProductAddMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            finally
            {
                con.Close();
            }
        }

        protected void UpdateBtnId_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
                SqlCommand scm = new SqlCommand("Select productName from product where partyName='" + addProductTxt.Text + "'", con);
                con.Open();
                SqlDataReader sdr = scm.ExecuteReader();
                sdr.Read();

                if (sdr["productName"].ToString() != null)
                {
                    ProductAddMsg.Text = "Product Name is repeated";
                    ProductAddMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch 
            {
                try
                {
                    SqlCommand scm = new SqlCommand("update product set productName='" + addProductTxt.Text + "'where id = " + Request.QueryString["id"] + "", con);
                    con.Open();
                    scm.ExecuteNonQuery();
                    ProductAddMsg.Text = "Updated Succesfully";
                    ProductAddMsg.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception em)
                {
                ProductAddMsg.Text = em.Message;
                ProductAddMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            finally
            {
                con.Close();
            }
        }


        protected void cancelBtnId_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Product/Products.aspx");
        }

        
    }
}