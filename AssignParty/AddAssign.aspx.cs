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
    public partial class AddAssign : System.Web.UI.Page
    {
      public  string CS = ConfigurationManager.ConnectionStrings["partyProduct"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SqlConnection con = new SqlConnection(CS);
                try
                {
                    string com = "select id,partyName from party";
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


                    //SqlConnection con1 = new SqlConnection("data source=.\\SQLEXPRESS;database=partyProduct; integrated security=SSPI");
                    string com1 = "select id,productName from product";
                    SqlDataAdapter adpt1 = new SqlDataAdapter(com1, con);
                    DataTable dt1 = new DataTable();
                    adpt1.Fill(dt1);
                    AssignProductDrp.DataSource = dt1;
                    //AssignProductDrp.DataBind();
                    AssignProductDrp.DataTextField = "productName";
                    AssignProductDrp.DataValueField = "id";
                    AssignProductDrp.DataBind();
                    AssignProductDrp.Items.Insert(0, new ListItem("Select Party", "0"));

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

                if (Request.QueryString["id"] != null)
                {

                    try
                    {
                        PartyAssign.Text = "Update Assign";
                        string com2 = "select productId from assignProduct where assignId=" + Request.QueryString["id"] + "";
                        SqlCommand scm = new SqlCommand(com2, con);
                        con.Open();
                        SqlDataReader sdr = scm.ExecuteReader();
                        sdr.Read();
                        AssignProductDrp.SelectedItem.Value = sdr["productId"].ToString();
                        AssignProductDrp.SelectedItem.Text = Request.QueryString["prName"];
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
                    string com3 = "select partyId from assignProduct where assignId=" + Request.QueryString["id"] + "";
                    SqlCommand scm1 = new SqlCommand(com3, con);
                    con.Open();
                    SqlDataReader sdr1 = scm1.ExecuteReader();
                    sdr1.Read();
                    AssignPartyDrp.SelectedItem.Value = sdr1["partyId"].ToString();
                    AssignPartyDrp.SelectedItem.Text = Request.QueryString["paName"];
                    }
                    catch(Exception em)
                    {
                       Label2.Text= em.Message;
                        Label2.ForeColor = System.Drawing.Color.Red;
                    }
                    finally
                    {
                    con.Close();
                    }
                    saveBtnId.Visible = false;
                    UpdateBtnId.Visible = true;
                }
            }
        }

        protected void UpdateBtnId_Click(object sender, EventArgs e)
        {
            int paId = Convert.ToInt32(AssignPartyDrp.SelectedValue);
            int prId = Convert.ToInt32(AssignProductDrp.SelectedValue);
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(CS);
                SqlCommand scm = new SqlCommand("update assignProduct set partyId=" + paId + ", productId=" + prId + "where assignId=" + Request.QueryString["id"], con);
                con.Open();
                scm.ExecuteNonQuery();
                Label2.Text = "Update Succesfully";
                Label2.ForeColor = System.Drawing.Color.Green;
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

        protected void saveBtnId_Click(object sender, EventArgs e)
        {
            int paId = Convert.ToInt32(AssignPartyDrp.SelectedValue);
            int prId = Convert.ToInt32(AssignProductDrp.SelectedValue);
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(CS);
                SqlCommand scm = new SqlCommand("insert into assignProduct(partyId,productId) values(" + paId + "," + prId + ")", con);
                con.Open();
                scm.ExecuteNonQuery();
                Label2.Text = "Added Succesfully";
                Label2.ForeColor = System.Drawing.Color.Green;
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

        protected void cancelBtnId_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AssignParty/assignParty.aspx");
        }
    }
}