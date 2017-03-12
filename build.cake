#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#addin "Cake.Powershell"
#addin "Cake.Git"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./src/Example/bin") + Directory(configuration);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

#tool nuget:?package=Wyam
#addin nuget:?package=Cake.Wyam

Task("Build")
    .Does(() =>
    {
        Wyam();
    });

Task("Deploy")
    .Does(() =>
    {
        // runs wyam
        Wyam(new WyamSettings
        {
            OutputPath = "..\\output"
        });

        // Reset any changes to switch to gh-page branch
        StartPowershellScript("git reset --hard");
        StartPowershellScript("git checkout gh-pages"); // added try/catch because git will throw an exception if it was in a detached head state.

        // remove existing files and copy output folder
        StartPowershellScript("git rm -rf .");
        StartPowershellScript("xcopy ..\\output . /E");

        // rename Index.html to index.html
        MoveFile("Index.html", "Index.rename.html");
        MoveFile("Index.rename.html", "index.html");

        //Push changes to git
        StartPowershellScript("git remote set-url origin https://github.com/shaneray/ShaneSpace.Blog.git");
        StartPowershellScript("git add -A");
        StartPowershellScript("git commit -a -m \"Commit from Cake\"");
        StartPowershellScript("git push");
    });

Task("Preview")
    .Does(() =>
    {
        StartPowershellScript("Start-Process", args =>
        {
            args.AppendQuoted("http://localhost:5080");
        });
        Wyam(new WyamSettings
        {
            Preview = true,
            Watch = true
        });
    });

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);