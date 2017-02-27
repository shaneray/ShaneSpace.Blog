Title: Helpful hint
Published: 12/31/2013 7:21:25 PM
Tags:
- re-blog
- Razor
---
<p>You can write an extension method as follows:</p>
<pre>public static class IdentityApplicationUserExtension {<br />&nbsp; &nbsp;public static ApplicationUser GetApplicationUser(this IIdentity identity) {<br />       var manager = new UserManager(new UserStore(new ApplicationDbContext()));<br />       return manager.FindById(identity.GetUserId());<br />   }<br />}</pre>
<p>&nbsp;</p>
<p>This way, it becomes possible to access the ApplicationUser fields directly from razor</p>
