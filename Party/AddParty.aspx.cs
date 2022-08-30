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
    public partial class AddParty : System.Web.UI.Page
    {
        public  string CS = ConfigurationManager.ConnectionStrings["partyProduct"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            if (Request.QueryString["id"] != null)
            {
                PartyAdd.Text = "Upadate Party";
                var name = Request.QueryString["name"];
                addPartyTxt.Text = name;
                saveBtnId.Visible = false;
                UpdateBtnId.Visible = true;
            }
            }
        }

        protected void UpdateBtnId_Click(object sender, EventArgs e)
        {
            
            //int currId = Convert.ToInt32(Request.QueryString["id"]);
            string NewName = addPartyTxt.Text;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(CS);
                SqlCommand scm = new SqlCommand("Select partyName from party where partyName='"+addPartyTxt.Text+"'",con);
                con.Open();
                SqlDataReader sdr  = scm.ExecuteReader();
                sdr.Read();

                if (sdr["partyName"].ToString() != null)
                {
                    PartyAddMsg.Text = "Party Name is repeated";
                    PartyAddMsg.ForeColor = System.Drawing.Color.Red;

                }
            }
            catch 
            {
                con.Close();
                try
                {
                    SqlCommand sde = new SqlCommand("update party set partyName='" + addPartyTxt.Text + "'where id =" + Request.QueryString["id"], con);
                    con.Open();
                    sde.ExecuteNonQuery();

                    PartyAddMsg.Text = "Update succesfully";
                    PartyAddMsg.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception em1)
                {
                PartyAddMsg.Text = em1.Message;
                PartyAddMsg.ForeColor = System.Drawing.Color.Red;

                }
            }
            finally
            {
                con.Close();
            }
        }

        protected void saveBtnId_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;

            try
            {
                con = new SqlConnection(CS);
                SqlCommand scm = new SqlCommand("Select partyName from party where partyName='" + addPartyTxt.Text + "'", con);
                con.Open();
                SqlDataReader sdr = scm.ExecuteReader();
                sdr.Read();

                if (sdr["partyName"].ToString() != null)
                {
                    PartyAddMsg.Text = "Party Name is repeated";
                    PartyAddMsg.ForeColor = System.Drawing.Color.Red;
                }
                con.Close();  
            }
            catch
            {
                try
                {
                    con = new SqlConnection(CS);
                    SqlCommand scm1 = new SqlCommand("spParty", con);
                    scm1.CommandType = System.Data.CommandType.StoredProcedure;
                    scm1.Parameters.AddWithValue("@partyName", addPartyTxt.Text);
                    con.Open();
                    scm1.ExecuteNonQuery();
                    PartyAddMsg.Text = "Added Succesfully";
                    PartyAddMsg.ForeColor = System.Drawing.Color.Green;
                }
                catch(Exception em1)
                {
                PartyAddMsg.Text = em1.Message;
                PartyAddMsg.ForeColor = System.Drawing.Color.Red;

                }
            }
            finally 
            { 
                con.Close();
            }
        }

        protected void cancelBtnId_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Party/party.aspx");
        }
    }
}