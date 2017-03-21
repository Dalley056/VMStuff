using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EmailApp
{
    public partial class ComposeEmail : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader r;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='c:\\users\\administrator\\documents\\visual studio 2015\\Projects\\EmailApp\\EmailApp\\App_Data\\Emails.mdf';Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            if(Session["ReplyTo"] != null)
            {
                txtCTo.Text = Session["ReplyTo"].ToString();
                txtCSubject.Text = Session["ReplySubject"].ToString();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "INSERT INTO user_emails Values('" + Session["email"] + "','" + txtCTo.Text + "', '" + txtCSubject.Text + "','" + txtComposeBody.Text + "', getDate(), 'y');SELECT SCOPE_IDENTITY();";
            int tempID = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = "INSERT INTO cc_table values(" + tempID + ",'" + txtCC.Text + "')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO user_emails Values('" + Session["email"] + "','" + txtCC.Text + "', 'CC: " + txtCSubject.Text + "','" + txtComposeBody.Text + "', getDate(), 'y');SELECT SCOPE_IDENTITY();";
            cmd.ExecuteNonQuery();
            Session["ReplyTo"] = null;
            Session["ReplySubject"] = null;
            Response.Redirect("ViewEmails.aspx");
        }
    }
}