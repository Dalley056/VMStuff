using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace EmailApp
{
    public partial class ViewEmails : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader r;
        ArrayList checkedBoxes = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            //This is no longer needed(?) as we exectue all our commands for this page through the SqlDataSource
            //Need to remove and test to be certain
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='c:\\users\\administrator\\documents\\visual studio 2015\\Projects\\EmailApp\\EmailApp\\App_Data\\Emails.mdf';Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            //populateTable();
            if (!IsPostBack)
            {
                //When a user clicks the inbox, deleted, or sent hyperlinks the page will be reloaded but with
                //?Version=1 (for example) added to the url. This value could also be 2 or 3, with each
                //representing a different set of emails to display. If the value is null then no set of 
                //emails has been selected so the inbox is displayed
                if(Request["Version"] != null)
                {
                    //If the value is not null then we check what the value is and display the relevant set of
                    //data in the grid view.
                    //A better way would be to use a listview so we can apply a custom layout to each row
                    //and make the entire row interactive rather than using individual hyperlinks
                    string v = Request["Version"];
                    if (v == "1")
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM user_emails WHERE email_to='" + Session["email"] + "'";
                        GridView1.Columns[0].Visible = true;
                    }
                    else if(v == "2")
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM user_emails WHERE active='n' AND email_to='" + Session["email"] + "'";
                        GridView1.Columns[0].Visible = false;
                    }
                    else if(v == "3"){
                        SqlDataSource1.SelectCommand = "SELECT * FROM user_emails WHERE email_from='" + Session["email"] + "'";
                    }
                }
            }
        }

        private void populateTable()
        {
            //Old code for creating and populating a html table
            //********************************************************
            //containTable.InnerHtml += "<table id='tbl1' border='1' runat='server'><tr><th>Select</th><th>From</th><th>Subject</th><th>Date</th></tr>";
            //cmd.CommandText = "SELECT * FROM user_emails WHERE email_to='" + Session["email"] + "'";
            //r = cmd.ExecuteReader();
            //while (r.Read())
            //{
            //    containTable.InnerHtml += "<tr><td><input type='Checkbox' id='" + r["eID"] + "'</td><td><A HREF='DisplayEmail.aspx?eID=" + r["eID"] + "'>" + r["email_from"] + "</a></td><td><A HREF='DisplayEmail.aspx?eID=" + r["eID"] + "'>" + r["email_subject"] + "</a></td><td><A HREF='DisplayEmail.aspx?eID=" + r["eID"] + "'>" + r["email_date"] + "</a></td></tr>";
            //    boxes.Add(r["eID"]);
            //}
            //containTable.InnerHtml += "</table>";
            //********************************************************
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //For each row in our grid view (We don't know the number of rows since it depends on
            //how many emails the user has recieved)
            foreach(GridViewRow gvr in GridView1.Rows)
            {
                //Creates a checkbox reference variable and points it at the checkbox in the currentrow
                //Then checks if the checkbox is checked
                CheckBox cBox = (CheckBox)gvr.FindControl("chkDelete");
                if (cBox.Checked == true)
                {
                    //DataRowView rowView = (DataRowView)gvr.DataItem; ----- Old Code
                    //gets the value of the eID column from the current row. Has to be done this
                    //way since the field is hidden so it's .text value is empty
                    checkedBoxes.Add(GridView1.DataKeys[gvr.RowIndex].Values["eID"].ToString());
                    //lblTest.Text = GridView1.DataKeys[gvr.RowIndex].Values["eID"].ToString(); ----- Test Code
                }
            }
            foreach(string s in checkedBoxes)
            {
                //This is like assigning the command text to a command object and then executing the command
                //the SQLDataSource object is already created to populate the gridview so it makes sense to make
                //use of it.
                SqlDataSource1.UpdateCommand = "UPDATE user_emails SET active='n' WHERE eID=" + s;
                SqlDataSource1.Update();
                //SqlDataSource1.DeleteCommand = "DELETE FROM user_emails WHERE eID=" + s; ----- Old Code
                //SqlDataSource1.Delete(); ----- Old Code
            }
        }
    }
}