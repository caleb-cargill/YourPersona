using System.Net.Http.Headers;

public class NotionClient : HttpClient
{

    public NotionClient(string apiKey)
    {
        Authorize(apiKey);
        AddHeaders(new() { { "Notion-Version", "2022-06-28" } });
    }

    private void Authorize(string apiKey)
        => DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiKey);

    private void AddHeaders(Dictionary<string, string> headers)
    {
        foreach (var header in headers)
            DefaultRequestHeaders.Add(header.Key, header.Value);
    }

}