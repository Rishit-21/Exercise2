using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Exercise2.Invoice
{
    public partial class addInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            SqlConnection con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
            //////--------- for party drop down------------
            try
            {
                string com = "select distinct id,partyName from assignProduct ,party where partyId=id";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                con.Open();
                AssignPartyDrp.DataSource = dt;
                //AssignPartyDrp.DataBind();
                AssignPartyDrp.DataTextField = "partyName";
                AssignPartyDrp.DataValueField = "id";
                AssignPartyDrp.DataBind();
                AssignPartyDrp.Items.Insert(0, new ListItem("Select Party", "0"));
            }
                catch (Exception em)
                {
                    Label2.Text = em.Message;
                }
                finally
                {
                    con.Close();
                }
                /////////----- for product drop down--------
             
                   
               


            }
        }

        protected void AssignPartyDrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
            try
            {
                string com = "Select productName,pr.productId as proId from assignProduct ,product pro,productRate pr where pro.id=assignProduct.productId and partyId=" + AssignPartyDrp.SelectedItem.Value + " and pr.productId=pro.id";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                con.Open();
                AssignProductDrp.DataSource = dt;
                //AssignPartyDrp.DataBind();
                AssignProductDrp.DataTextField = "productName";
                AssignProductDrp.DataValueField = "proId";
                AssignProductDrp.DataBind();
                AssignProductDrp.Items.Insert(0, new ListItem("Select Product", "0"));
            }
            catch (Exception em)
            {
                Label2.Text = em.Message;
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                con.Close();
            }
        }

        protected void AssignProductDrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
            try
            {
                string com = "select rate from productRate where productId = "+AssignProductDrp.SelectedItem.Value+" ";
                SqlCommand scm = new SqlCommand(com, con);
                con.Open();
                SqlDataReader sdr = scm.ExecuteReader();
                sdr.Read();
                CurrentRateID.Text = sdr["rate"].ToString();

        
            }
            catch (Exception em)
            {
                Label2.Text = em.Message;
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                con.Close();
            }
        }

        protected void AddToInvoiceBtnId_Click(object sender, EventArgs e)
        {
           
            SqlConnection  con = new SqlConnection("data source =.\\SQLEXPRESS; database = partyProduct; integrated security = SSPI");
            AssignPartyDrp.Enabled = false;
            AssignPartyDrp.ForeColor = System.Drawing.Color.DarkGray;

            try
            {
                SqlCommand scm = new SqlCommand("insert into invoice(partyId,productId,rateOfProduct,quantity,total) values(" + AssignPartyDrp.SelectedItem.Value + "," + AssignProductDrp.SelectedItem.Value + "," + decimal.Parse(CurrentRateID.Text) + "," + Convert.ToInt32(quantityTxtid.Text) + "," + decimal.Parse(CurrentRateID.Text) * Convert.ToInt32(quantityTxtid.Text) + ")", con);
                con.Open();
                scm.ExecuteNonQuery();
                Label2.Text = "ADDED Successfully";
                Label2.ForeColor = System.Drawing.Color.Green;

            }
            catch(Exception em)
            {
                Label2.Text = em.Message;
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                con.Close();
            }
            
            try
            {
                con = new SqlConnection("data source =.\\SQLEXPRESS; database = partyProduct; integrated security = SSPI");
                SqlDataAdapter sde = new SqlDataAdapter("Select invoiceId,partyName,productName,rateOfProduct,quantity,total from invoice,party,product where partyId=party.id and productId=product.id and partyId="+AssignPartyDrp.SelectedItem.Value+"", con);
                con.Open();

                DataSet ds = new DataSet();
                sde.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
               
            }
            catch (Exception em)
            {
                Label2.Text = em.Message;
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                con.Close();
            }
            try
            {
                SqlCommand scm = new SqlCommand("select sum(total) as total from invoice where partyId=" + AssignPartyDrp.SelectedItem.Value + "", con);
                con.Open();
                SqlDataReader sdr = scm.ExecuteReader();
                sdr.Read();
                GarndTotalValueId.Text = sdr["total"].ToString();
            }
            catch (Exception em)
            {
                Label2.Text = em.Message;
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                con.Close();
            }
            AssignProductDrp.SelectedIndex = 0;
            CurrentRateID.Text = "";
            quantityTxtid.Text = "";


        }

        protected void ClosetoInvoiceBtnId_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Invoice/addInvoice.aspx");
        }
    }
}