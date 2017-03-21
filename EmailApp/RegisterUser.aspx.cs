using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EmailApp
{
    public partial class RegisterUser : System.Web.UI.Page
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
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT * FROM users WHERE email='" + txtEmail.Text + "'";
            r = cmd.ExecuteReader();
            if (!r.Read())
            {
                r.Close();
                if (txtPassOne.Text == txtPassTwo.Text)
                {
                    cmd.CommandText = "INSERT INTO users VALUES('" + txtEmail.Text + "', '" + txtName.Text + "','" + txtAddress.Text + "','" + txtSQ.Text + "','" + txtSA.Text + "','" + txtPassOne.Text + "')";
                    cmd.ExecuteNonQuery();
                }
            }else
            {
                r.Close();
            }
        }
    }
}