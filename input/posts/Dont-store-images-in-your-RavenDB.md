Title: Dont store images in your RavenDB
Published: 12/30/2013 5:57:21 PM
Tags:
- re-blog
- RavenDB
---
Source: http://ayende.com/blog/4743/the-design-of-ravendbs-attachments
<p>I ws pondering if I could store some images in the RavenDB for simplicity of keeping them with the "Blog" documents, for a movie server I am working on. &nbsp;I stumbled across this article while doing my research...</p>
<p>&nbsp;</p>
<blockquote>Originally posted at 1/6/2011</blockquote>
<p><a href="http://ayende.com/Blog/images/ayende_com/Blog/Windows-Live-Writer/The-design-of-RavenDBs-attachments_D981/image_2.png"><img title="image" src="http://ayende.com/Blog/images/ayende_com/Blog/Windows-Live-Writer/The-design-of-RavenDBs-attachments_D981/image_thumb.png" alt="image" align="right" border="0" /></a>I got a question on attachments in&nbsp;<a href="http://ravendb.net/">RavenDB</a>&nbsp;recently:</p>
<blockquote>
<p>I know that RavenDb allows for attachments. Thinking in terms of facebook photo albums - would raven attachments be suitable?</p>
</blockquote>
<p>And one of the answers from the community was:</p>
<blockquote>
<p>We use attachments and it works ok. We are using an older version of&nbsp; RavenDB (Build 176 unstable), and the thing I wish would happen is that attachments were treated like regular documents in the DB. That way you could query them just like other documents. I am not sure if this was changed in newer releases, but there was talk about it being changed.</p>
<p>If I had to redesign again, I would keep attachments out of the DB cause they are resources you could easily off load to a CDN or cloud service like Amazon or Azure. If the files are in your DB, that makes it more work to optimize later.</p>
<p>In summary: You could put them in the DB, but you could also put ketchup on your ice cream. :)</p>
</blockquote>
<p>I thought that this is a good point to stop and explain a bit about the attachment support in RavenDB. Let us start from the very beginning.</p>
<p>The only reason RavenDB has attachments support is that we wanted to support the notion of Raven Apps (see&nbsp;<a href="http://couchapp.org/page/index">Couch Apps</a>) which are completely hosted in RavenDB. That was the original impetus. Since then, they evolved quite nicely. Attachments in RavenDB can have metadata, are replicated between nodes, can be cascade deleted on document deletions and are HTTP cacheable.</p>
<p>One of the features that was requested several times was automatically turning a binary property to an attachment on the client API. I vetoed that feature for several reasons:</p>
<ul>
<li>It makes things more complicated.</li>
<li>It doesn&rsquo;t actually gives you much.</li>
<li>I couldn&rsquo;t think of a good way to explain the rules governing this without it being too complex.</li>
<li>It encourage storing large binaries in the same place as the actual document.</li>
</ul>
<p>Let us talk in concrete terms here, shall we? Here is my model class:</p>
<blockquote>
<pre class="csharpcode"><span class="kwrd">public</span> <span class="kwrd">class</span> User
{
  <span class="kwrd">public</span> <span class="kwrd">string</span> Id {get;set;}
  <span class="kwrd">public</span> <span class="kwrd">string</span> Name {get;set;}
  <span class="kwrd">public</span> <span class="kwrd">byte</span>[] HashedPassword {get;set;}
  <span class="kwrd">public</span> Bitmap ProfileImage {get;set;}
}</pre>
</blockquote>
<p>From the point of view of the system, how is it supposed to make a distinction between HashedPassword (16 &ndash; 32 bytes, should be stored inside the User document) and ProfileImage (1Kb &ndash; 2 MB, should be stored as a separate attachment).</p>
<p>What is worst, and the main reason why attachments are clearly separated from documents, is that there are some things that we&nbsp;<em>don&rsquo;t</em>&nbsp;want to store inside our document, because that means that:</p>
<ul>
<li>Whenever we pull the document out, we have to pull the image as well.</li>
<li>Whenever we index the document, we need to load the image as well.</li>
<li>Whenever we update the document we need to send the image as well.</li>
</ul>
<p>Do you sense a theme here?</p>
<p>There is another issue, whenever we update the user, we invalidate&nbsp;<em>all&nbsp;</em>the user data. But when we are talking about large files, changing the password doesn&rsquo;t means that you need to invalidate the cached image. For that matter, I really want to be able to load all the images separately and concurrently. If they are stored in the document itself (or even if they are stored as an external attachment with client magic to make it appears that they are in the document) you can&rsquo;t do that.</p>
<p>You might be familiar with this screen:</p>
<p><img src="http://ayende.com/Blog/images/ayende_com/Blog/WindowsLiveWriter/LightSwitchonthewire_8EF2/image_thumb%5B1%5D_f8593434-3dd0-471a-99bf-9fb9149ff5d8.png" alt="image_thumb[1]" /></p>
<p>If we store the image in the Animal document, we run into all of the problems outlined above.</p>
<p>But if we store it as a Url reference to the information, we can then:</p>
<ul>
<li>Load all the images on the form concurrently.</li>
<li>Take advantage of HTTP caching.</li>
<li>Only update the images when they are actually changed.</li>
</ul>
<p>Overall, that is a much nicer system all around.</p>
