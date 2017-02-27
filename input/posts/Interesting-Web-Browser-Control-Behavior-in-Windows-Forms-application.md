Title: Interesting Web Browser Control Behavior in Windows Forms application
Published: 1/7/2014 2:10:32 PM
Tags:
- WinForms
---
<p>
I tend to use the web browser control in window forms for GUI. &nbsp;This may not be the best choice, but I am also a web developer and find this suits me well. &nbsp;It does sometimes introuduce challenges along the way...

<img class="descImage" src="http://vb.net-informations.com/communications/img/web-browser.JPG" alt="" /></p>
<p>&nbsp;</p>
<p><strong>The Problem</strong></p>
<p>&nbsp; I had a large list (1000+) of text and images that I dropped into DIV containers. &nbsp;I then used the following code to place that list into my Web Browser control.</p>
<p><code> webBrowser1.Document.GetElementById("content").InnerHtml = largeList;</code></p>
<p>This got the job done, but was painfully slow. I attempted to split the list up and load chunks, it still caused the GUI to lock up.</p>
<p>&nbsp;</p>
<p><strong>The Solution</strong></p>
<p>The solution turned out to be pretty simple. Write that large list to a html file, and navigate the webbrowser to the new file. This allows the WebBrowser control to load the document enough to get into an "Interactive State". This allows the GUI to opperate normally while the WebBrowser control handles the loading of the long list.</p>
