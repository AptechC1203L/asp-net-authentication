using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.DirectoryServices;

namespace DemoLoginMembership
{
    public interface IAuthenticator
    {
        public bool Authenticate(String username, String password);
    }

    private class MembershipAuthenticator : IAuthenticator
    {
        public bool Authenticate(String username, String password)
        {
            return Membership.ValidateUser(username, password);
        }
    }

    private class LdapAuthenticator : IAuthenticator
    {
        // Public because the class is private to this file,
        // no need to hide stuffs from ourselves.
        public String serverAddress;
        public String baseAddress;

        public LdapAuthenticator()
        {
        }

        public LdapAuthenticator(String serverAddress, String baseAddress)
        {
            this.serverAddress = serverAddress;
            this.baseAddress = baseAddress;
        }

        public bool Authenticate(String username, String password)
        {
            String dn = String.Format("cn={0},{1}", username, this.baseAddress);
            var entry = new DirectoryEntry(this.serverAddress, dn, password);

            entry.AuthenticationType = AuthenticationTypes.None;
            try
            {
                object obj = entry.NativeObject;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class Authentication
    {
        public enum AuthenticationMode
	    {
	         LdapAuthentication,
             MembershipAuthentication
	    }

        private static MembershipAuthenticator membershipAuthenticator = null;
        private static LdapAuthenticator ldapAuthenticator = null;
        private static AuthenticationMode mode = AuthenticationMode.MembershipAuthentication;

        private Authentication()
        {
        }

        public void SetAuthenticatorMode(AuthenticationMode mode)
        {
            Authentication.mode = mode;
        }

        public static IAuthenticator GetAuthenticator()
        {
            if (mode == AuthenticationMode.MembershipAuthentication)
            {
                return membershipAuthenticator;
            }
            else
            {
                return ldapAuthenticator;
            }
        }

        public static void SetLdapBaseAddress(String baseAddress)
        {
            ldapAuthenticator.baseAddress = baseAddress;
        }

        public static void SetLdapServerAddress(String serverAddress)
        {
            ldapAuthenticator.serverAddress = serverAddress;
        }
    }
}
