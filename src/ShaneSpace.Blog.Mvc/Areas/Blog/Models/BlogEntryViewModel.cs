using Raven.Client;
using ShanesSpot.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShanesSpot.Areas.Blog.Models
{
    public class BlogEntryViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public MvcHtmlString User { get; set; }
        public string Link { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

    }
    public static class BlogEntryViewModelHelper
    {
        public static BlogEntryViewModel ToBlogEntryViewModel(this BlogEntry blogEntry, IDocumentSession ravenSession)
        {
            // get user info
            ApplicationUser user = ravenSession.Load<ApplicationUser>(blogEntry.UserId);

            // Format Name
            string profilePictureUrl = "/content/images/no_photo.jpg";
            string username = "No User Name";

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

            BlogEntryViewModel output = new BlogEntryViewModel
            {
                Id = blogEntry.Id,
                Body = blogEntry.Body,
                DateTime = blogEntry.DateTime,
                Description = blogEntry.Description,
                Link = blogEntry.Link,
                Title = blogEntry.Title,
                User = new MvcHtmlString(string.Format(@"<img src=""{1}"" style=""max-height: 50px;"" class=""img-circle"" /><br style=""clear: both"">{0}", username, profilePictureUrl)),
                UserId = blogEntry.UserId
            };
            return output;
        }
    }
}