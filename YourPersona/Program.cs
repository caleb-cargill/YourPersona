
var ntnApiKey = Environment.GetEnvironmentVariable("NOTION_API_KEY");

if (string.IsNullOrEmpty(ntnApiKey))
    throw new Exception("Notion API Key could not be found");

var databaseId = "2315dff5d22c804e9a5ceb2149ddb424";

var response =
    await HttpClientUtilities.PostAsync(
        $"https://api.notion.com/v1/databases/{databaseId}/query", 
        ntnApiKey,
        new() { { "Notion-Version", "2022-06-28" } });

Console.WriteLine(response);
