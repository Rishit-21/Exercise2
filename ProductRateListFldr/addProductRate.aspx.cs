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
    public partial class addProductRate : System.Web.UI.Page
    {

        public string CS = ConfigurationManager.ConnectionStrings["partyProduct"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection(CS);
                    string com1 = "select id,productName from product where id not in(select productId from productRate) ";
                    SqlDataAdapter adpt1 = new SqlDataAdapter(com1, con);
                    DataTable dt1 = new DataTable();
                    con.Open();
                    adpt1.Fill(dt1);
                    AssignProductDrp.DataSource = dt1;
                    //AssignProductDrp.DataBind();
                    AssignProductDrp.DataTextField = "productName";
                    AssignProductDrp.DataValueField = "id";
                    AssignProductDrp.DataBind();
                    AssignProductDrp.Items.Insert(0, new ListItem("Select Product", "0"));
                }
                catch(Exception em)
                {
                    Label1.Text = em.Message;
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
                finally
                {
                con.Close();
                }
                try
                {
                    SqlCommand cmd = new SqlCommand("Select  format(getdate(),'yyyy-MM-dd') as getDate", con);
                    con.Open();
                    SqlDataReader sdr1 = cmd.ExecuteReader();
                    sdr1.Read();
                    addRateDateID.Text = sdr1["getDate"].ToString();
                }
                catch (Exception em)
                {
                    Label1.Text = em.Message;
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
                finally
                {
                    con.Close();
                }
                if (Request.QueryString["id"] != null)
                {

                    try              
                    {
                        ProductRate.Text = "Update Product Rate";
                        string com2 = "select productId,rate from productRate where productRateId="+Request.QueryString["id"]+"";
                        SqlCommand scm = new SqlCommand(com2, con);
                        con.Open();
                        SqlDataReader sdr = scm.ExecuteReader();
                        sdr.Read();
                        AssignProductDrp.SelectedItem.Value = sdr["productId"].ToString();
                        AssignProductDrp.SelectedItem.Text = Request.QueryString["proName"];
                        addProductRateTxtId.Text = sdr["rate"].ToString();

                        saveBtnId.Visible = false;
                        UpdateBtnId.Visible = true;
                    }
                    catch(Exception em)
                    {
                        Label1.Text = em.Message;
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                    finally {
                        con.Close();
                    }
                }
            
            }
        }

        protected void saveBtnId_Click(object sender, EventArgs e)
        {
            int proId = Convert.ToInt32(AssignProductDrp.SelectedValue);
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(CS);
                SqlCommand cm = new SqlCommand("insert into productRate(productId,rate,dateOFRate) values("+proId+","+ decimal.Parse(addProductRateTxtId.Text) + ",'" + addRateDateID.Text + "')", con);
                con.Open();
                cm.ExecuteNonQuery();
                Label1.Text = "Added succesfully";
                Label1.ForeColor = System.Drawing.Color.Green;
               
            }
            catch (Exception em)
            {
                Label1.Text = em.Message;
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                con.Close();
                Response.Redirect("~/ProductRateListFldr/productRateList.aspx");
            }

        }

        protected void UpdateBtnId_Click(object sender, EventArgs e)
        {
            int proId = Convert.ToInt32(AssignProductDrp.SelectedValue);
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(CS);
                SqlCommand cm = new SqlCommand("update productRate set productId=" + proId + ",rate=" + decimal.Parse(addProductRateTxtId.Text) + ",dateOfRate='" + addRateDateID.Text + "'where productRateId="+Request.QueryString["id"]+"",con);
                con.Open();
                cm.ExecuteNonQuery();
                Label1.Text = "update succesfully";
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception em)
            {
                Label1.Text = em.ToString();
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                con.Close();
                Response.Redirect("~/ProductRateListFldr/productRateList.aspx");
            }
        }

        protected void cancelBtnId_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProductRateListFldr/productRateList.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            addRateDateID.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            Calendar1.Visible = false;
        }
    }
}