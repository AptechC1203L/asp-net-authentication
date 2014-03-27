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
            if (DropDownList1.SelectedIndex == 0)
            {
                Authentication.SetAuthenticationMode(Authentication.AuthenticationMode.Membership);
            }
            else
            {
                Authentication.SetAuthenticationMode(Authentication.AuthenticationMode.Ldap);
                Authentication.SetLdapServer("LDAP://localhost:10389");
                Authentication.SetBaseAddress("dc=example,dc=com");
            }

            var authenticator = Authentication.GetAuthenticator();
            bool isAuthen = authenticator.Authenticate(txtUsername.Text, txtPassword.Text);

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