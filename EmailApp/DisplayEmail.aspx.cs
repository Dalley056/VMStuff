using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EmailApp
{
    public partial class DisplayEmail : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader r;
        string emailID;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='c:\\users\\administrator\\documents\\visual studio 2015\\Projects\\EmailApp\\EmailApp\\App_Data\\Emails.mdf';Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            displayEmail();
        }

        private void displayEmail()
        {
            cmd.CommandText = "SELECT * FROM user_emails WHERE eID='" + Request["eID"] + "'";
            r = cmd.ExecuteReader();
            if (r.Read())
            {
                txtFrom.Text = r["email_from"].ToString();
                txtSubject.Text = r["email_subject"].ToString();
                txtEmailBody.Text = r["email_text"].ToString();
                emailID = r["eID"].ToString();
            }
            r.Close();
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            Session["ReplyTo"] = txtFrom.Text;
            Session["ReplySubject"] = "RE: " + txtSubject.Text;
            Response.Redirect("ComposeEmail.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "DELETE FROM user_emails WHERE eID='" + emailID + "'";
            cmd.ExecuteNonQuery();
            Response.Redirect("ViewEmails.aspx");
        }
    }
}