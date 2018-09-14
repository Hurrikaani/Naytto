using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Opinnaytetyo.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Linq;

namespace Opinnaytetyo.Utilities
{
    /// <summary>
    /// This class allows logging in using a hard-coded password. It implements
    /// OWIN compatible application with claims support, allowing direct operation
    /// through the ASP.NET MVC framework.
    /// </summary>
    public class SimpleDatabaseAuthentication
    {
        internal const string IdentityProviderClaimName = "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider";

        internal static SignInStatus Authenticate(string userName, string Salasana, ref string homeUrl)
        {
            // set the default home url for the user
            homeUrl = "~/";

            bool isValidUser = false;
            string username = userName.ToLower();
            string role = "";
            string companyName = "";
            string userId = "";
            string accountType = "";

            // check normal users first
            OpiskelijaTietokantaEntities1 entities = new OpiskelijaTietokantaEntities1();
            Kayttajatunnukset kayttaja = (from k in entities.Kayttajatunnukset
                                          where (k.Kayttajatunnus == username) &&
                                                (k.Salasana == Salasana)
                                          select k).FirstOrDefault();

            entities.Dispose();
            if (kayttaja != null)
            {
                if (kayttaja.KayttajatunnusID != null)
                {
                    role = "Customer User";
                }
                else if (kayttaja.KayttajatunnusID != null)
                {
                    role = "Personnel User";
                }

                    //else if (kayttaja.Student_id != null)
                    //    {
                    //        role = "Student User";
                    //    }
                    isValidUser = true;
                    userId = kayttaja.KayttajatunnusID.ToString();
                }

                // did we find a valid user?
                if (isValidUser)
                {
                    // retrieve the OWIN authentication context
                    IOwinContext owin = HttpContext.Current.GetOwinContext();

                    // create the claims
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, username));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                    claims.Add(new Claim(IdentityProviderClaimName, "CookieAuthentication"));
                    claims.Add(new Claim(ClaimTypes.Role, role));
                    claims.Add(new Claim(ClaimTypes.GroupSid, userId));
                    claims.Add(new Claim(ClaimTypes.Actor, companyName));
                    claims.Add(new Claim(ClaimTypes.GivenName, accountType));

                    // create the identity
                    ClaimsIdentity identity = new ClaimsIdentity(claims,
                        DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.Name, ClaimTypes.Role);

                    // create the properties object (non-persistent authentication cookie) and sign in
                    AuthenticationProperties nonPersistentProperties = new AuthenticationProperties() { IsPersistent = false };
                    owin.Authentication.SignIn(nonPersistentProperties, identity);

                    // indicate success to the caller
                    return SignInStatus.Success;
                }
                else
                {
                    return SignInStatus.Failure;
                }
            }

            internal static void SignOut()
            {
                // retrieve the OWIN authentication context
                IOwinContext owin = HttpContext.Current.GetOwinContext();

                if (owin != null)
                {
                    owin.Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                }
            }
        }
    }