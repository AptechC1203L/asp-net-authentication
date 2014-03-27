using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DemoLoginMembership
{
    public class Authen
    {
        public static bool membershipAuthen(String usrName, String password)
        {
            return Membership.ValidateUser(usrName, password);
        }

        public static bool apacheserverAuthen(String usrName, String password)
        {
            String _path = String.Format("cn={0},dc=example,dc=com", usrName);
            var entry = new DirectoryEntry("LDAP://localhost:10389", _path, password);

            entry.AuthenticationType = AuthenticationTypes.None;
            try
            {
                object obj = entry.NativeObject;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool authen(String usrName, String password, int mode)
        {
            bool isValidated = false;

            if (mode == 0)
            {
                isValidated = membershipAuthen(usrName, password);
            }
            else if (mode == 1)
            {
                isValidated = apacheserverAuthen(usrName, password);
            }

            return isValidated;            
        }
    }
}