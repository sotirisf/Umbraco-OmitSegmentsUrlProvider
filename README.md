# Umbraco-OmitSegmentsUrlProvider
Makes Umbraco omit URL segments from a node's URL, based on rules specified in web.config. The URLs generated are native Umbraco URLs, i.e. no rewriting, urlAlias or redirects.

Works with document types, e.g. omits the URL segment for doctype A if found in the path which has doctype B as parent.

Simply put, sometimes you want to omit parts of URLs created by Umbraco (which are based on a node's path). 

For example, you'd like the URL:

/company/pageelements/portfolio/portfolioitems/anawesomeproject 

to become:

/company/portolio/anawesomeproject

## Usage
You can make Umbraco omit URL parts from the default url it constructs from a page by excluding it from the path. All you have to do is add entries (as many as you like) in the appSettings section of your web.config file like this:
```xml
<add key="omiturlsegments:DocTypeToLookFor" value ="DocTypeToOmitFromUrl,AnotherDocTypeToOmitFromUrl"/>
```
Where:

DocTypeToLookFor is the document type alias that will trigger the plugin to alter the node's URL and 

DocTypeToOmitFromUrl (as well as any additional doctypes, comma-separated) is(are) the doctype(s) that will be omitted from the URL path.

## Example
Let's suppose that you have a document of type "CarPage" which is used to display car data. You add a child of type "Parts" which is used to group various car parts detailed descriptions, and under it you add multiple documents of type "PartPage".

So, for example, you may have a structure like Peugeot 208/Parts/Engine, where "Peugeot 208" is the CarPage doctype, "Parts" is the Parts doctype and "Engine" belongs to the "PartPage" doctype. 

But you don't want the url to say "Parts" or whatever the name of this interim node is. It's just a grouping node and you need this URL segment to go away, so that your Url can be something like:

"/Peugeot-208/Engine" 

instead of:

"/Peugeot-208/Parts/Engine".

In order to achieve that, you will simply have to create an entry in the appSettings section of your web.config, like the following:

```xml
<add key="omiturlsegments:CarPage" value ="Parts"/>
```
which will tell the plugin to produce Urls for CarPage doctypes that will IGNORE any segment that comes from "Parts" doctypes under it.

## Beware!
Make sure that the URLs generated after applying your rules are still unique! Use this plugin only to omit "grouping" nodes or nodes that will not alter the uniqueness of the URL. 
