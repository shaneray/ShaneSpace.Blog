using System;
using IdentityUser = RavenDB.AspNet.Identity.IdentityUser;

namespace ShanesSpot.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            // No user picture
            ProfilePictureUrl = "/content/images/no_photo.jpg";
        }

        // Profile
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTimeOffset? Birthdate { get; set; }

        public ManageProfileViewModel ToManageProfileViewModel()
        {
            ManageProfileViewModel output = new ManageProfileViewModel
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                ProfilePictureUrl = this.ProfilePictureUrl,
                Birthdate = this.Birthdate
            };
            return output;
        }

    }

}