Title: Automatic Dropdown Lists for Razor Views.
Published: 1/2/2014 4:49:23 PM
Tags:
- re-blog
- Razor
---
Source: http://www.codeproject.com/Articles/703398/Automatic-Dropdown-Lists-for-Razor-Views
<h1 id="ctl00_ArticleTitle">Automatic Dropdown Lists for Razor Views.</h1>
<div id="contentdiv" class="text">
<h2>Introduction</h2>
<p>This article shows how we can apply a&nbsp;DropDownList&nbsp;metadata attribute to a View Model property, and have a DropdDownList&nbsp;rendered by the&nbsp;EditorFor&nbsp;HTML helper.</p>
<h2>Background</h2>
<p>I'm a big fan of runtime scaffolding in ASP.NET MVC. This is where you use e.g. the&nbsp;<a title="How to use the Html.EditorFor method" href="http://www.pearson-and-steel.co.uk/how-to-use-the-html-editorfor-method/">EditorFor</a>&nbsp;HTML Helper to decide how to render an HTML element for a property of your view model. For example, if a property is marked with theDataType&nbsp;attribute and that indicates the property's&nbsp;DataType&nbsp;is DateTime, then will automatically render a date picker. For integer properties,&nbsp;EditorFor&nbsp;renders an UpDown spinner control. If EditorFor works smoothly for all your properties, you can use a single&nbsp;EditorForModel&nbsp;element to render your whole view model into the view correctly.</p>
<h2>Using the code</h2>
<p>Using this system involves new code and changed code in several areas of your MVC application. It is not just a library or plugin, although I have plans for version 2 to use Unity at these points where I modify the code.</p>
<div id="premain0" class="pre-action-link"><img id="preimg0" src="http://www.codeproject.com/images/minus.gif" alt="" width="9" height="9" /><span id="precollapse0">&nbsp;Collapse</span>&nbsp;|&nbsp;<a href="http://www.codeproject.com/Articles/703398/Automatic-Dropdown-Lists-for-Razor-Views">Copy Code</a></div>
<pre id="pre0" lang="cs"><span class="code-keyword">public</span> <span class="code-keyword">class</span> DemoModel
{
    [DropDownList(<span class="code-string">"</span><span class="code-string">LanguageSelect"</span>)]
    <span class="code-keyword">public</span> <span class="code-keyword">int</span>? LanguageId { <span class="code-keyword">get</span>; <span class="code-keyword">set</span>; }
    <span class="code-keyword">public</span> SelectList LanguageSelect { <span class="code-keyword">get</span>; <span class="code-keyword">set</span>; } 
} 
</pre>
<p>Now when I use the Razor markup&nbsp;@EditorFor(m =&gt; m.LanguageId), I get a drop-down populated from theLanguageSelect&nbsp;list. I get this because the&nbsp;DropDownListAttrbute&nbsp;class attaches the select list name to theLanguageId&nbsp;model:</p>
<p>&nbsp;</p>
<div id="premain1" class="pre-action-link"><img id="preimg1" src="http://www.codeproject.com/images/minus.gif" alt="" width="9" height="9" /><span id="precollapse1">&nbsp;Collapse</span>&nbsp;|&nbsp;<a href="http://www.codeproject.com/Articles/703398/Automatic-Dropdown-Lists-for-Razor-Views">Copy Code</a></div>
<pre id="pre1" lang="cs"><span class="code-keyword">public</span> <span class="code-keyword">class</span> DropDownListAttribute : UIHintAttribute, IMetadataAware
{
    <span class="code-keyword">public</span> DropDownListAttribute(<span class="code-keyword">string</span> selectListName) : <span class="code-keyword">base</span>(KnownUiHints.DropDown, KnownPresentationLayers.Mvc, selectListName)
    {
        SelectListName = selectListName;
    }
    <span class="code-keyword">public</span> <span class="code-keyword">string</span> SelectListName { <span class="code-keyword">get</span>; <span class="code-keyword">set</span>; }
    <span class="code-keyword">public</span> <span class="code-keyword">void</span> OnMetadataCreated(ModelMetadata metadata)
    {
        <span class="code-keyword">var</span> listProp = metadata.ContainerType.GetProperty(SelectListName);
        metadata.AdditionalValues[KnowMetadataKeys.SelectListName] = SelectListName;
    }
} 
</pre>
<p>&nbsp;</p>
<p>&nbsp;All my view models derive from&nbsp;ViewModel, which offers a&nbsp;SelectListDictionary&nbsp;property:&nbsp;</p>
<p>&nbsp;</p>
<div id="premain2" class="pre-action-link"><img id="preimg2" src="http://www.codeproject.com/images/minus.gif" alt="" width="9" height="9" /><span id="precollapse2">&nbsp;Collapse</span>&nbsp;|&nbsp;<a href="http://www.codeproject.com/Articles/703398/Automatic-Dropdown-Lists-for-Razor-Views">Copy Code</a></div>
<pre id="pre2" lang="cs"><span class="code-keyword">private</span> IDictionary&lt;<span class="code-keyword">string</span>,&gt; _selectListdictionary;
<span class="code-keyword">public</span> <span class="code-keyword">virtual</span> IDictionary&lt;<span class="code-keyword">string</span>,&gt; SelectListDictionary
{
    <span class="code-keyword">get</span>
    {
        <span class="code-keyword">if</span> (_selectListdictionary == <span class="code-keyword">null</span>)
        {
            <span class="code-keyword">var</span> props = GetType().GetProperties().Where(p =&gt; p.PropertyType == <span class="code-keyword">typeof</span>(SelectList));
            _selectListdictionary = props.ToDictionary(prop =&gt; prop.Name, prop =&gt; (SelectList)prop.GetValue(<span class="code-keyword">this</span>, <span class="code-keyword">null</span>));
        }
        <span class="code-keyword">return</span> _selectListdictionary;
    }
}
<span class="code-keyword">&lt;/</span><span class="code-leadattribute">string,</span><span class="code-keyword">&gt;</span><span class="code-keyword">&lt;</span><span class="code-keyword">/</span><span class="code-leadattribute">string,</span><span class="code-keyword">&gt;</span></pre>
<p>&nbsp;</p>
<p>In my base controller, I override the&nbsp;View&nbsp;method to pull the entire select list dictionary from the view model, and insert it into the view's viewdata, making it available for the editor template:&nbsp;&nbsp;&nbsp;</p>
<p>&nbsp;</p>
<div id="premain3" class="pre-action-link"><img id="preimg3" src="http://www.codeproject.com/images/minus.gif" alt="" width="9" height="9" /><span id="precollapse3">&nbsp;Collapse</span>&nbsp;|&nbsp;<a href="http://www.codeproject.com/Articles/703398/Automatic-Dropdown-Lists-for-Razor-Views">Copy Code</a></div>
<pre id="pre3" lang="cs"><span class="code-keyword">protected</span> <span class="code-keyword">override</span> ViewResult View(<span class="code-keyword">string</span> viewName, <span class="code-keyword">string</span> masterName, <span class="code-keyword">object</span> model)
{
    <span class="code-keyword">var</span> result = <span class="code-keyword">base</span>.View(viewName, masterName, model);
    <span class="code-keyword">if</span> ((model <span class="code-keyword">is</span> ViewModel) &amp;&amp; (!ViewData.ContainsKey(KnowMetadataKeys.ViewDataSelectLists)))
    {
        <span class="code-keyword">var</span> vm = (ViewModel)model;
        result.ViewData.Add(KnowMetadataKeys.ViewDataSelectLists, vm.SelectListDictionary);
    }
    <span class="code-keyword">return</span> result;
}
</pre>
<p>&nbsp;</p>
<p>Said editor template:</p>
<div id="premain4" class="pre-action-link"><img id="preimg4" src="http://www.codeproject.com/images/minus.gif" alt="" width="9" height="9" /><span id="precollapse4">&nbsp;Collapse</span>&nbsp;|&nbsp;<a href="http://www.codeproject.com/Articles/703398/Automatic-Dropdown-Lists-for-Razor-Views">Copy Code</a></div>
<pre id="pre4" lang="cs">@using Erisia.Constants
@{
    <span class="code-keyword">var</span> list = (SelectList)ViewData.ModelMetadata.AdditionalValues[ViewData.ModelMetadata.AdditionalValues[KnowMetadataKeys.SelectListName].ToString()];
    <span class="code-keyword">var</span> listWithSelected = <span class="code-keyword">new</span> SelectList(list.Items, list.DataValueField, list.DataTextField, Model);
}
@Html.DropDownListFor(m =&gt; Model, listWithSelected, <span class="code-string">"</span><span class="code-string"> - select - "</span>)
</pre>
<p>&nbsp;</p>
<h2>Remarks&nbsp;&nbsp;</h2>
There are probably some better ways of doing this, and populating the select list inside the view model is probably not too kosher, but this little 'framework' has saved me so much time on so many projects, and I've just received a glowing compliment for it on&nbsp;<a title="Code Review from StackExchange" href="http://codereview.stackexchange.com/">Code Review beta</a>. It's been way too long since I wrote an article and I thought sharing this would make a good one.</div>
<h2>License</h2>
<div id="LicenseTerms">
<p>This article, along with any associated source code and files, is licensed under&nbsp;<a href="http://www.codeproject.com/info/cpol10.aspx" rel="license">The Code Project Open License (CPOL)</a></p>
</div>
