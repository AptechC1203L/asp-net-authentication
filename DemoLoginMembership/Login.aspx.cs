using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoLoginMembership
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Membership.CreateUser("minh", "Minh@1234");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            //Response.Write(Request.Cookies[FormsAuthentication.FormsCookieName].Values[0]);
            bool isAuthen = Authen.authen(txtUsername.Text,txtPassword.Text,DropDownList1.SelectedIndex);
            if (isAuthen)
            {
                FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, cbRememberme.Checked);
            }
            else
            {
                Response.Write("Wrong user name or password.");
            }
        }

        
    }
}