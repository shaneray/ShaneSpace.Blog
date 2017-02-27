Title: Raven Query Statistics returning null?
Published: 12/31/2013 12:06:53 PM
Tags:
- re-blog
- MVC
- RavenDB
---
Source: http://stackoverflow.com/questions/7093346/best-way-to-get-count-for-paging-in-ravendb
<p>While trying to implement paging in this blog, I ran into an issue where the following code would result in my stats object having no info.</p>
<pre>RavenQueryStatistics stats;<br />var list = RavenSession.Query&lt;BlogEntry&gt;().Statistics(out stats).OrderByDescending(x =&gt; x.DateTime).Skip(skip).Take(take);<br />var totalResults = stats.TotalResults;</pre>
<p>&nbsp;</p>
<p><strong>It turns out that the fix was simple, but kind of cryptic.</strong></p>
<p>&nbsp;</p>
<p><code>stats.TotalResults</code>&nbsp;is 0 because the query was never executed. Try this instead:</p>
<p class="lang-cs prettyprint prettyprinted"><code><span class="kwd">var</span><span class="pln"> results </span><span class="pun">=</span><span class="pln"> _session</span><span class="pun">.</span><span class="typ">Query</span><span class="pun">&lt;</span><span class="pln">T</span><span class="pun">&gt;()</span><span class="pun">.</span><span class="typ">Statistics</span><span class="pun">(</span><span class="kwd">out</span><span class="pln"> stats</span><span class="pun">).</span><span class="typ">Take</span><span class="pun">(</span><span class="lit">0</span><span class="pun">).</span><span class="typ">ToArray</span><span class="pun">();<br /></span></code></p>
<p>&nbsp;</p>
<p>TLDR; Basically, I just needed to force to array or list. Apparently this is because of deferred execution in LINQ.</p>
