Title: Migrating my blog to Wyam
Published: 2/26/2017
Updated: 2/27/2017
Tags:
- Wyam
- Static Site Generator
---

This post covers how I migrated my existing MVC blog to a statically generated site using [Wyam](https://wyam.io/).

Steps Taken
-----
- Went to [Wyam.io](https://wyam.io/) and followed instructions.
- Downloaded latest Wyam.zip
- wyam.exe new --recipe Blog
- wyam.exe --recipe Blog --theme CleanBlog (just to see)
- tried opening index.html file in chrome - stylesheets broken
- ran with -p for preview and opened http://localhost:5080/
- edited configuration file to automatically use the CleanBlog theme
- noticed you cannot override the theme set in the config via command line (going to create GitHub issue)
- ran `dotnet new solution`
- opened solution in Visual Studio and added "existing website" using the input folder as the source
- added "solution items" solution folder for configuration files
  - config.wyam
  - .gitattributes
  - .gitignore
  - .editorconfig
  - build.cake
- used configuration from https://wyam.io/docs/deployment/cake
  - added powershell plugin and the following code before calling the Wyam function
  ```
  StartPowershellScript("Start-Process", args =>
  {
      args.AppendQuoted("http://localhost:5080");
  });
  ```
- configured "input" start options to run cake build target "Preview" (pictured below).  This allows me to open Visual Studio and simply press F5 to start the preview server with watching enabled and launch the browser to the specified url.

<img src="/images/inputPropertyPages.png">

- edited CSS to my liking
- set the following setting in config.wyam
  - Title
  - Image
  - Description
  - Intro
- added override files
  - css\override.css
  - _IndexHeader.cshtml
  - Index.chtml
- built simple console application to pull existing blog entries from RavenHQ and write them to `.md' files and place them in the posts folder.
  - I ended up having a few blog entries that contained `:`, this broke the yaml parser and blew things up.  I chose to just replace `:` with `string.Empty` and move on. (going to create github issue)
- modified tags on imported blog entries