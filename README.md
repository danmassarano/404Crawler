### 404Crawler

A basic web crawler written in C# that will find all links in a website and check their validity. It is designed to be internally facing, so will find all pages linked to in a website, but will only check externally facing links to make sure that they are valid, not crawl those pages as well.

The intended use of this app would be a basic maintenance check to see that your site isn't linking to dead pages and that none of your pages are broken.

This crawler works by parsing the HTML content of a page, so will not be able to handle sites that load linked content via javascript.

### Setup
Either build a release version in the usual way, or run a debug version from the directory where the .csproj file is located. The app will need the URL of the site to point to, this can be input as an argument or the app can just be run and it will prompt for a link in the terminal.

``` powershell
dotnet run 404Crawler.csproj
```
or
``` powershell
dotnet run 404Crawler.csproj <site>
``` 
### Testing

Basic unit tests are in place, but the WebHandler class requires a test MVC app to be running (I haven't figured out how to mock some of the web requests yet). Either download and run the TestMVC app, or build a stock one from the command line:

``` powershell
dotnet new mvc
dotnet run
```

There can be issues with it running if there's something running on port 5001 - either kill that process or change the default port it runs on to a free port - that option will also require changing where the tests point to. 

To kill what's running on port 5001:

``` powershell
lsof -i :5001
kill -9 <ID of process>
lsof -i :5000
kill -9 <ID of process>
```

### Extensions
This is a work in progress and has a lot to go, including improving the crawler process, optimisation, making sure it's compliant with robots protocol and more. This will be update in the future.