using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailApp
{
    public partial class HomePaul : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["Color"].Value != null)
            {
                changeColor();
            }else
            {
                HttpCookie mc = new HttpCookie("Color", "White");
                Response.Cookies.Add(mc);
            }
        }

        protected void BtnLogIn_Click(object sender, EventArgs e)
        {
            HttpCookie mc = new HttpCookie("Color", RadioButtonList1.SelectedValue);
            Response.Cookies.Add(mc);
            Response.Redirect("LoginPage.aspx");
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {            
            Response.Redirect("RegisterUser.aspx");
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //This doesn't appear to execute. If the radiobuttonlist is set to postback on selected changed
            //Then this code seems to execute after the page has loaded, making it useless for this purpose

            HttpCookie mc = new HttpCookie("Color", RadioButtonList1.SelectedValue);
            Response.Cookies.Add(mc);
            //Response.Redirect("HomePaul.aspx");
        }

        private void changeColor()
        {
            bHome.Attributes.Add("bgColor", Request.Cookies["Color"].Value);
        }
    }
}