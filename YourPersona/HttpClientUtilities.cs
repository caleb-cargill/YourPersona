using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public static class HttpClientUtilities
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<string> GetAsync(string requestUrl, string apiKey)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        var response = await client.GetAsync(requestUrl);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public static async Task<string> PostAsync(string requestUrl, string apiKey, Dictionary<string, string> headers, string? body = "{}")
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        foreach (var header in headers)
            client.DefaultRequestHeaders.Add(header.Key, header.Value);
        if (string.IsNullOrEmpty(body)) body = "{}";
        var content = new StringContent(body, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(requestUrl, content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}