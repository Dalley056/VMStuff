using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EmailApp
{
    public partial class LoginPage : System.Web.UI.Page
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
            if (Request.Cookies["Color"].Value != null)
            {
                lMaster.Attributes.Add("bgColor", Request.Cookies["Color"].Value);
            }
            try
            {
                if (Request.Cookies["email"].Value != null)
                {
                    if (!IsPostBack)
                    {
                        txtEmail.Text = Request.Cookies["email"].Value;
                        txtPassword.Attributes["value"] = Request.Cookies["pass"].Value;
                        chkRememberPass.Checked = true;
                    }
                }
            }catch (Exception ex)
            {
                HttpCookie ec = new HttpCookie("email", null);
                HttpCookie pc = new HttpCookie("pass", null);
                Response.Cookies.Add(ec);
                Response.Cookies.Add(pc);
            }
            if (txtEmail.Text == "")
            {
                chkRememberPass.Checked = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT * FROM users WHERE email='" + txtEmail.Text + "' AND user_pass='" + txtPassword.Text + "'";
            r = cmd.ExecuteReader();
            if (r.Read())
            {
                if (chkRememberPass.Checked)
                {
                    HttpCookie ec = new HttpCookie("email", r["email"].ToString());
                    HttpCookie pc = new HttpCookie("pass", r["user_pass"].ToString());
                    Response.Cookies.Add(ec);
                    Response.Cookies.Add(pc);
                }else
                {
                    Response.Cookies["email"].Value = null;
                    Response.Cookies["pass"].Value = null;
                }
                Session["email"] = r["email"];
                Response.Redirect("ViewEmails.aspx");
            }
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterUser.aspx");
        }

        protected void btnForgot_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT * FROM users WHERE email='" + txtEmail.Text + "'";
            r = cmd.ExecuteReader();
            if (r.Read())
            {
                Response.Redirect("ForgotPass.aspx/?E=" + txtEmail.Text);
            }
        }
    }
}