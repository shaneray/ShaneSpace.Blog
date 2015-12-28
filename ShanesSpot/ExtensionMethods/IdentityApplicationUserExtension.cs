using Microsoft.AspNet.Identity;
using Raven.Client;
using RavenDB.AspNet.Identity;
using ShanesSpot.Models;
using System.Security.Principal;
using System.Web.Mvc;

namespace ShanesSpot.ExtensionMethods
{
    public class UserHelper
    {
        public UserHelper(IDocumentSession ravenSession)
        {
            RavenSession = ravenSession;
        }

        public ApplicationUser GetApplicationUser(IIdentity identity)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(() => RavenSession));
            return manager.FindById<ApplicationUser>(identity.GetUserId());
        }

        public static IDocumentSession RavenSession { get; set; }

        public MvcHtmlString GetUserImageAndNameById(string userId)
        {
            string profilePictureUrl = "/content/images/no_photo.jpg";
            string username = "No User Name";

            if (!string.IsNullOrWhiteSpace(userId))
            {
                ApplicationUser user = RavenSession.Load<ApplicationUser>(userId);

                // Format Name
                username = user.UserName;
                if (!string.IsNullOrWhiteSpace(user.FirstName))
                {
                    username = user.FirstName;
                    if (!string.IsNullOrWhiteSpace(user.LastName))
                    {
                        username += string.Format(" {0}", user.LastName);
                    }
                }

                // Profile Picture
                if (!string.IsNullOrWhiteSpace(user.ProfilePictureUrl))
                {
                    profilePictureUrl = user.ProfilePictureUrl;
                }
            }

            // Return HTML
            return new MvcHtmlString(string.Format(@"<img src=""{1}"" style=""max-height: 50px;"" class=""img-circle"" /><br style=""clear: both"">{0}", username, profilePictureUrl));
        }
    }
}
