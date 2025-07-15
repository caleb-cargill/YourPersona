using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public static class HttpClientUtilities
{
    public static async Task<T> GetAsync<T>(this HttpClient client, string requestUrl)
    {
        var response = await client.GetAsync(requestUrl);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent);
    }

    public static async Task<T> PostAsync<T>(this HttpClient client, string requestUrl, string? body = "{}")
    {
        var content = GetRequestContent(body);
        var response = await client.PostAsync(requestUrl, content);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent);
    }

    public static async Task<T> PatchAsync<T>(this HttpClient client, string requestUrl, string? body = "{}")
    {
        var content = GetRequestContent(body);
        var response = await client.PatchAsync(requestUrl, content);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent);
    }

    private static StringContent GetRequestContent(string? body = "{}")
    {
        if (string.IsNullOrEmpty(body)) body = "{}";
        return new StringContent(body, Encoding.UTF8, "application/json");
    }
    
}