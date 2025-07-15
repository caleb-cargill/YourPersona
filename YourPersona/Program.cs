
using System.ComponentModel;
using Newtonsoft.Json;

var ntnApiKey = Environment.GetEnvironmentVariable("NOTION_API_KEY");

if (string.IsNullOrEmpty(ntnApiKey))
    throw new Exception("Notion API Key could not be found");

var client = new NotionClient(ntnApiKey);

var databaseId = "2315dff5d22c804e9a5ceb2149ddb424";
var pageId = "2315dff5d22c80bb9693c37eaa6f88e2";

var response =
    await HttpClientUtilities.PostAsync<Response>(
        client,
        $"https://api.notion.com/v1/databases/{databaseId}/query");
Console.WriteLine(response);

var pageResponse = 
    await HttpClientUtilities.GetAsync<Response>(
        client,
        $"https://api.notion.com/v1/pages/{pageId}"
    );
Console.WriteLine(pageResponse);

var props =
    JsonConvert.SerializeObject(pageResponse.properties);
Console.WriteLine(props);

var patchResponse =
    await HttpClientUtilities.PatchAsync<Response>(
        client,
        $"https://api.notion.com/v1/pages/{pageId}",
        props
    );

Console.WriteLine(patchResponse);
