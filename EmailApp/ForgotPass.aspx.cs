using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EmailApp
{
    public partial class ForgotPass : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                cmd.CommandText = "SELECT securityQuestion FROM users WHERE email='" + Request["email"] + "'";
                r = cmd.ExecuteReader();
                if (r.Read())
                {
                    lblSecurityQ.Text = r["securityQuestion"].ToString();
                }
            }
        }

        protected void btnCreatePass_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT securityAnswer FROM users WHERE email='" + Request["email"] + "'";
            r = cmd.ExecuteReader();
            if (r.Read())
            {
                if (txtAnswer.Text == r["securityAnswer"].ToString())
                {
                    if (txtNewPass.Text == txtConfirmNew.Text)
                    {
                        cmd.CommandText = "UPDATE users SET user_pass='" + txtConfirmNew.Text + "' WHERE email='" + Request["email"] + "'";
                        cmd.ExecuteNonQuery();
                        Response.Redirect("LoginPage.aspx");
                    }
                }
            }
        }
    }
}